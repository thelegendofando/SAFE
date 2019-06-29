module Flap

open Fable.Core
open Browser.Types
open Browser

module Keyboard =

    let mutable keysPressed = Set.empty

    /// Returns 1 if key with given code is pressed
    let code x =
        if keysPressed.Contains(x) then 1 else 0

    /// Update the state of the set for given key event
    let update (e : KeyboardEvent, pressed) =
        let keyCode = int e.keyCode
        let op =  if pressed then Set.add else Set.remove
        keysPressed <- op keyCode keysPressed

    /// (move horizontal, move vertical)
    /// 1 = move, 0 = don't move
    let arrows () =
        (0, code 32)

    let initKeyboard () =
        document.addEventListener("keydown", fun e -> update(e :?> _, true))
        document.addEventListener("keyup", fun e -> update(e :?> _, false))

module Canvas =
    // Get the canvas context for drawing
    let private canvas = document.getElementsByTagName("canvas").[0] :?> HTMLCanvasElement
    let private context = canvas.getContext_2d()

    ///Width, Height of Canvas
    let w, h = canvas.width, canvas.height
    
    /// Create image using the specified data
    let private createImage data =
      let img = document.createElement("img") :?> HTMLImageElement
      img.src <- data
      img

    let private drawImage x y width height img =
        let ctx = context
        ctx.drawImage ((U3.Case1 img), x, y, width, height)

    let private drawImage' x y img =
        let ctx = context
        ctx.drawImage ((U3.Case1 img), x, y)

    ///Fill the canvas with an image
    let drawBackground (src:string) =
        src
        |> createImage
        |> drawImage 0. 0. canvas.width canvas.height

    ///Fill the canvas with an image
    let drawSprite x y (src:string) =
        src
        |> createImage
        |> drawImage' x y

    let drawTubes scroll level =
        printf "%f" scroll
        let drawTube (x,y) =
            "http://flappycreator.com/default/tube1.png"
            |> createImage
            |> drawImage' (x-scroll) (-320.+y)

            "http://flappycreator.com/default/tube2.png"
            |> createImage
            |> drawImage' (x-scroll) (y+100.)

        for (x,y) in level do drawTube (x,y)

module Level =
    /// Generates the level's tube positions
    let generate n =
       let rand = System.Random()
       let xOffset = Canvas.w / 2.
       let xGap = 150
       let yMin, yMax = 32, 160
       [for i in 1..n -> xOffset+ float (i*xGap), float (yMin+rand.Next(yMax))]

module Physics =

    type SpriteModel =
        { x:float; y:float;
          vx:float; vy:float;
          progress: float }

    /// If the Y direction is up (y > 0),
    /// then create sprite with a y velocity 'vy'
    let jump (_,y) m =
        if y > 0 then { m with vy = -5. } else m

    let bounded n =
        min (Canvas.h-32.) (max 0. n)

    /// If sprite is in the air, then its "up" velocity is decreasing
    let gravity m =
        if bounded m.y = m.y then { m with vy = m.vy + 0.2 } else m

    /// Apply physics - move sprite according to the current velocities
    let physics m =
        printfn "%A" m
        { m with x = m.x + m.vx; y = bounded (m.y + m.vy) }

    /// Move sprite along in the world
    let progress m =
        { m with progress = m.progress + 1. }

    let moveSprite dir sprite =
        if sprite.progress > 0. || dir > (0,0) then
            sprite
            |> progress
            |> jump dir
            |> gravity 
            |> physics
        else
            sprite
     
open Canvas
open Physics

let origin =
    // Sample is running in an iframe, so get the location of parent
    let topLocation = window.top.location
    topLocation.origin + topLocation.pathname

let render level (sprite: SpriteModel) =
    "http://flappycreator.com/default/bg.png"
    |> drawBackground

    drawTubes sprite.progress level

    "http://flappycreator.com/default/bird_sing.png"
    |> drawSprite sprite.x sprite.y

Keyboard.initKeyboard()
let level = Level.generate 100

let rec update game () =
    let sprite = game |> Physics.moveSprite (Keyboard.arrows())
    render level sprite
    window.setTimeout(update sprite, 1000 / 60) |> ignore

let game = { x=Canvas.w/2.-32.; y=Canvas.h/2.; vx=0.; vy=0.; progress=0.}
update game ()