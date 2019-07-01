module Flap

open Fable.Core
open Browser.Types
open Browser

module Images =
    let bird = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACQAAAAaCAMAAADorg53AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMC1jMDYxIDY0LjE0MDk0OSwgMjAxMC8xMi8wNy0xMDo1NzowMSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNS4xIFdpbmRvd3MiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6MzhFOTYxRUI0NUYzMTFFNEI0ODFGRDcyNDE1REYzRUMiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6MzhFOTYxRUM0NUYzMTFFNEI0ODFGRDcyNDE1REYzRUMiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDozOEU5NjFFOTQ1RjMxMUU0QjQ4MUZENzI0MTVERjNFQyIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDozOEU5NjFFQTQ1RjMxMUU0QjQ4MUZENzI0MTVERjNFQyIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PtkYwlQAAAAYUExURdfmzPrXjPw4AOCALPi3M/r6+lM4Rv///7EeEpAAAAAIdFJOU/////////8A3oO9WQAAAHZJREFUeNqs0+EOgCAIBGBM0/d/41BGO1q1o3X/1G/iUGUQkTDqkO9oLpSV3ncNsBQy0DRGAqORH7U1QyJGTkYi3P4vdGV5VIpNzTb64cP1kMgbiWSDKKORt7OuTHJTjkYVguWyyAoiC484heI3ePlSFHrMIcAAAkwT8QMy308AAAAASUVORK5CYII="
    let background = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAASAAAAGACAMAAAA6QU9cAAAAA3NCSVQICAjb4U/gAAABgFBMVEXn+tfn+dfj+tfi+Njf99jb99fX9dfg8dLg787R89fc787c7svX8MbY7c7a7cnX7MrT78PR78bb687O78LP7crW7MfQ69DO7cbT68nO7b/T7MTT7MXL7MvL7MbN7MnN7MbL7LvJ7L7O6sHK7MLH68LG677G67rD67rD67a/67S/6rq+6ce+58K658e658K25sS65sC15cKy5MW05by05b6x5MGv5Mex5L6v5MGv5Lut476q47qm47Sm47am3dih3NSh29ee29Oe29ea29ea286a2tOa2deX2Nea2dCZ2dGV2cyV2NOT2M2V2M2O2MeN18qK18qK18dp4Hll33ll33Vh33Jh3nhh33Ve33Rd33Jd3210zM1Z3m1Z3G1wy81ty81pys1wzoFkyMxtzIFszX9ex8xhx8xpzIFkzH1ny31mzIFZxsxjzHphyn9gyoFey3xeyYFgynhey3pazHNVxMxaynZbynZVy3FYynhWynlUym9RwstUynVSym1TyG9OwMqp/iN2AAAACXBIWXMAAArrAAAK6wGCiw1aAAAAFHRFWHRDcmVhdGlvbiBUaW1lADIvOS8xNPjouooAAAAcdEVYdFNvZnR3YXJlAEFkb2JlIEZpcmV3b3JrcyBDUzbovLKMAAAKiElEQVR4nO2YDVcaVxeFbQRrjTYStZSmkaKCqW1iYqrG2ihiQW2MpPgdbUKMKCDUQtF89/3r7xxvxhlgcE+UZMha+1krUbkzZ/Y8nHvvQNP/yJk0OR2g0aEgAAUBKAhAQQAKAlAQgIIAFASgIAAFASgIQEEACgJQEICCABQEoCAABQEoCEBBAAoCUBCAggAUBKAgAAUBKAhAQQAKAlAQgIIAFASgIAAFASgIQEEACgJQEICCABQEoCAABQEoCEBBAAoCUBCAggAUBKAgAAUBKAhAQQAKAlAQgIIAFASgIAAFASgIQEEACgJQEICCABQEoCAABQEoCEBBAAoCUBCAggAUBKAgAAUBKAhAQQAKAlAQgIIAFASgIAAFASgIQEEACgJQEICCABQEoCAABQEoCEBBAAoCUBCAggAUBKAgAAUBKAhAQQAKAlAQgIIAFASgIAAFASgIQEEACgJQEICCABQEoCAABQEo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"
    let tube1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADQAAAFACAMAAADEYq+6AAAAA3NCSVQICAjb4U/gAAAAh1BMVEX////k/Yvf+Yfb9YXZ84PS7X7R7X7R7XzJ5XfJ5njJ5XjE4XPD4XTA3nDA3XC31Wq102iszGKlxVyhw1qXulKVt1CNsUuFqkSFqUSDqESCp0N5nz11nTp2nTp2nDlwlzZwlzVvlzZokTBnkDBnkS9giSpdhyhehyhahSZahSVVgCJWgCJUOEcmarqzAAAALXRSTlMA///////////////////////////////////////////////////////////weBRqAAAACXBIWXMAAAsSAAALEgHS3X78AAAAHHRFWHRTb2Z0d2FyZQBBZG9iZSBGaXJld29ya3MgQ1M26LyyjAAAABR0RVh0Q3JlYXRpb24gVGltZQAyLzkvMTT46LqKAAACWUlEQVR4nO2Z6ZKCMBCEOQRRERFFPFfFW3n/59uy1AJBkswQousO/7+qzmTSmTSapiXJeByGQeD7nY5tm6aum2az6bq+HwRhGEXzeRzv9+f7lyTa9UNCUfSAms0H1OncoPF4sYjjw0Eu5LoPebb9DDHkgaBXhUihn586oaw84X0SgFiFiCJE9UohljxA71WGStqoEpQWIt3cmzzZULk8VCGETi7gPCEhnrzLpU6opOTSoNQsub4HgN7RESxjuVzqhVDykGtSB3GvT2kXAKIjkCcXsSaul7suwFgqQa8OYd1Q/gKQBanrvSKEkocqRF4e0CxRkNyJRZ0bfcatQR6Bgaj3qPfedT9RSkApAaUElBJQSgCSRykBpQQSIEoJaAqjlIBSAnqpkUeQR5BHkEeoW9PziF0fRBkLZSyUsVDGQhkLUB5lLJSxSIAoY6H3E72f6P30v95PciF10/I7HLZoYYBHV0VI4LgDIHXVU+cR6m5C9uai2ujDT66qiUUgjwBAfHmyoM+YluvviHSgApxcAAQwy4pQ3XkEa6ACWJgApD6hei+kzve+EVI5l//tNaEiVVR4+03JB/sQloTsKKh4AWSfrNw2AkCfMVkC/tVUHnNQP0NQmyuzemfAh4cSxIeFIOLuApGQZTUahqHrhtFoWJbjeF6v1+8PBsPhaDSdzmbrdRzvdqdTdci2s1C7nYUmk9lsubxCx2N1iCdPHvQsr9XKy1utNhs5UFaebTtOt5uHOPskDGXlvYJum8tYExoqFmK75coTglibi2qjUsjzHOcZZMN4SJEb/QLFWJFg34TiJAAAAABJRU5ErkJggg=="
    let tube2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADQAAAFACAMAAADEYq+6AAAAA3NCSVQICAjb4U/gAAAAh1BMVEX////k/Yvf+Yfb9YXZ84PS7X7R7X7R7XzJ5XfJ5njJ5XjE4XPD4XTA3nDA3XC31Wq102iszGKlxVyhw1qXulKVt1CNsUuFqUSFqkSEqUSCp0N5nz11nTp2nTp2nDlwlzZwlzVvlzZokTBnkDBnkS9giSpdhyhehyhahSZahSVVgCJWgCJUOEcNncuWAAAALXRSTlMA///////////////////////////////////////////////////////////weBRqAAAACXBIWXMAAAsSAAALEgHS3X78AAAAHHRFWHRTb2Z0d2FyZQBBZG9iZSBGaXJld29ya3MgQ1M26LyyjAAAABR0RVh0Q3JlYXRpb24gVGltZQAyLzkvMTT46LqKAAACh0lEQVR4nO2Z15KCQBBFTSAq5oBjRMyy//99W+yuNYJMapuRcpsnHzxVTee+VL4ATwUI9Xqe5ziNRq1WrdZqjUby23E8r9fr94fD8Xgymc0YWy632yg6Hi8XOJQGxH++/T1wyHU55LppaLFYLsPwcDger1d8qNtNm7fbaZinBT06Ig8KwwTKmAeCHs1znFbr2RH7vfSdtCFZcBPIOCOEUNq8drs4SGXeb3AlcdKGboYPHLLVjSqGBv4gYGg+n05Ho8Gg03Hder1ardddt9MZDEaj6XQ+X62i6HTCgYJADAXBZoMHcfOazSzE2HodReczNlS09xjLmtdscigxDwuSm6d0ORLEGMB7ICgIAI4QQneX+36eIzAheWkkjshJWBDE0wjwTkaQvXeSQSDzSgDJi9AWhFu56uBiQc/m8WYpTCMQpA4uFvQ8AECjxgji5vn+Y3A1G4sSKkeW40LyhAVkhBCSFyEmpDYP5IiSBDevNIqB3rmXC4sQBMlWAuVCBcyIvGVe6T0kSCNOL3bYdBFiQe+cue/osPa2sGJuDeAhiQSBzgbQQmXQ90CQvR1WwzwQJF+oDNJIG/J9kVyCBb1DYym6w36i8lGOFZuPmjh+HbKnfOSZdy9C4XmHBqVLww706Ig4xoJAjcUAsi8BcVEwOwAkezkIKl6PkEOAzVI5AIwkVRAkHwCgUaMN8eAyJhDZQZDMEcp6AkF5nygMvtVoQHmO4M3SwOUAKNuWsSC1MIMF0f1UFET3E91Pn3E/UY+gHkE9gnoEaSyksZDGQhoLaSykseBApLFgQP9FY6EtjC4125ca5R7lHqkEpBJQj8CASCUoCiKVgFQCUglIJSCVABcilaBkKsE3yVaUPKIeitMAAAAASUVORK5CYII="

module Random = 
    let private rng = System.Random()
    let next max = rng.Next max
    let nextFloat max = rng.NextDouble() * max

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
    let movement () =
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

    let drawInfo (i:int) fittest =
        let ctx = context
        ctx.font <- "20px Arial";
        ctx.fillText(i.ToString(), 10., 30.);
        ctx.fillText(fittest, 10., 50.);

    ///Fill the canvas with an image
    let drawSprite x y (src:string) =
        src
        |> createImage
        |> drawImage' x y

    ///Draw all the tubes for the level
    let drawTubes scroll (level: (float * float) list) =
        let drawTube (x,y) =
            Images.tube1
            |> createImage
            |> drawImage' (x-scroll) (-320.+y)

            Images.tube2
            |> createImage
            |> drawImage' (x-scroll) (y+100.)

        for (x,y) in level do drawTube (x,y)

    let clear() =
        let ctx = context
        ctx.clearRect(0.,0.,w,h)

module Level =
    /// Generates the level's tube positions
    let generate n =
       let xGap = 200
       let xOffset = Canvas.w * (3./4.) - float xGap
       let yMin, yMax = 32, 160
       [for i in 1..n -> xOffset+ float (i*xGap), float (yMin+Random.next(yMax))]

type Surroundings =
    { xDistanceToNextTube: float; yDistanceToMiddleOfNextTube: float }

type Action = Flap | NoFlap
type Rule = Surroundings -> Action
type Individual = Rule list

module AI =
    let rule _ : Rule =
        let prop sur =
            match Random.next 2 with
            | 0 -> sur.xDistanceToNextTube 
            | 1 -> sur.yDistanceToMiddleOfNextTube

        let comparer =
            match Random.next 2 with
            | 0 -> (<)
            | 1 -> (>)

        let action =
            match Random.next 2 with
            | 0 -> (Flap, NoFlap)
            | 1 -> (NoFlap, Flap)

        let distance = Random.nextFloat Canvas.h

        fun sur -> if comparer (prop sur) distance then fst action else snd action

    let individual size = List.init size rule
    //let population popSize ruleCount = List.init popSize (individual ruleCount)

    let breedCrossover (mum:Individual) (dad:Individual) : Individual =
        let crossoverPoint = Random.next mum.Length
        let traits =
            [
                mum |> List.take crossoverPoint
                dad |> List.skip crossoverPoint
            ] |> List.concat
        traits

    let mutateRandomRule (rules:Individual) =
        let t = rules |> Array.ofList
        t.[Random.next t.Length] <- rule ()
        t |> List.ofArray

type SpriteModel =
    { x:float; y:float;
      vx:float; vy:float;
      progress: float; crashed: bool;
      surroundings: Surroundings;
      traits: Individual }

module Surroundings =
    let calculate level sprite =
        let distanceToTube (x,y) sprite =
            let tubeX = x - (sprite.progress + 32.)

            let dX = tubeX - sprite.x
            let dY = (sprite.y + 16.) - (y + 50.)
            { xDistanceToNextTube = dX; yDistanceToMiddleOfNextTube = dY}

        let closestSurroundings =
            level
            |> List.map (fun (x,y) -> distanceToTube (x,y) sprite)
            |> List.filter (fun x -> x.xDistanceToNextTube > 0.)
            |> List.minBy (fun x -> x.xDistanceToNextTube)//Closest tube which is ahead of us

        { sprite with surroundings = closestSurroundings }

module SpriteModel =
    let height() = (Random.nextFloat Canvas.h/2.) + Canvas.h/4.
    let defaultSurroundings = { xDistanceToNextTube= Canvas.w; yDistanceToMiddleOfNextTube = Canvas.h}
    let start() =
        { x=Canvas.w/2.-32.; y=height(); vx=0.; vy=0.; progress=0.;
        crashed = false; surroundings = defaultSurroundings;
        traits = AI.individual 25}
    let next traits =
        { x=Canvas.w/2.-32.; y=height(); vx=0.; vy=0.; progress=0.;
        crashed = false; surroundings = defaultSurroundings;
        traits = traits }

module Physics =
    /// If the Y direction is up (y > 0),
    /// then create sprite with a y velocity 'vy'
    //let jump (_,y) m =
    //    if y > 0 then { m with vy = -5. } else m

    let jump s =
        let majorityAction, _ =
            s.traits
            |> List.countBy (fun t -> t(s.surroundings))
            |> List.maxBy (fun (_, count) -> count)

        match majorityAction with
        | Flap -> { s with vy = -5. }
        | NoFlap -> s
        
    let bounded n =
        min (Canvas.h-32.) (max 0. n)

    /// If sprite is in the air, then its "up" velocity is decreasing
    let gravity m =
        if bounded m.y = m.y then { m with vy = m.vy + 0.2 } else m

    /// Apply physics - move sprite according to the current velocities
    let physics m =
        { m with x = m.x + m.vx; y = bounded (m.y + m.vy) }

    /// Move sprite along in the world
    let progress s =
        { s with progress = s.progress + 3. }

    let moveSprite dir sprite =
        if sprite.crashed then
            sprite
        else 
            sprite
            |> progress
            |> jump
            |> gravity 
            |> physics

module Collision =
    //TODO: probably easier using surroundings data
    let check level sprite =
        let hitsAnyTube (x,y) game =
            let tubeX = x - game.progress

            let collidesX = game.x + 32. > tubeX && game.x < tubeX + 32.
            let collidesTopY = game.y < y
            let collidesBottomY = game.y > y+100.-32.

            collidesX && (collidesTopY || collidesBottomY)

        let crashed =
            level
            |> List.map (fun (x,y) -> hitsAnyTube (x,y) sprite)
            |> List.exists id

        { sprite with crashed = crashed }

module Population =
    let breedFittest fittest (currentGeneration: SpriteModel list) =
        let currentGeneration =
            currentGeneration
            |> List.sortByDescending fittest
            |> List.map (fun x -> x.traits)
    
        currentGeneration
        |> function // take the first two and breed with the rest.
        | first::second::rest ->
            [
                rest |> List.map (fun prevGen -> (AI.breedCrossover first  prevGen) |> AI.mutateRandomRule)
                rest |> List.map (fun prevGen -> (AI.breedCrossover second prevGen) |> AI.mutateRandomRule)
            ] |> List.concat
        | _ -> failwithf "Population is too small (%i) for another generation." currentGeneration.Length
        |> List.take currentGeneration.Length
        |> List.map (fun traits -> SpriteModel.next traits)

let origin =
    // Sample is running in an iframe, so get the location of parent
    let topLocation = window.top.location
    topLocation.origin + topLocation.pathname

let fitness = (fun x -> x.progress, abs (x.surroundings.yDistanceToMiddleOfNextTube))

let render level sprites i =
    Images.background
    |> Canvas.drawBackground

    let fittest =
        sprites
        |> List.sortByDescending fitness
        |> List.map (fun x -> (x.progress, x.surroundings.yDistanceToMiddleOfNextTube))
        |> List.head
        |> sprintf "%A"

    Canvas.drawInfo i fittest

    let maxP = sprites |> List.maxBy (fun s -> s.progress)
    Canvas.drawTubes maxP.progress level

    let drawSprite sprite =
        if not sprite.crashed then
            Images.bird
            |> Canvas.drawSprite sprite.x sprite.y

    sprites
    |> List.map drawSprite
    |> ignore

Keyboard.initKeyboard()
let level = Level.generate 100

let rec update sprites iteration () =
    let dir = Keyboard.movement()

    let move s =
        s
        |> Collision.check level
        |> Physics.moveSprite dir
        |> Surroundings.calculate level

    let sprites =
        sprites
        |> List.map move

    let sprites, iteration =
        if sprites |> List.forall (fun s -> s.crashed) then
            (sprites |> Population.breedFittest fitness, iteration+1)
        else
            (sprites, iteration)

    render level sprites iteration
    window.setTimeout((update sprites iteration), 1000 / 60) |> ignore

let population = List.init 100 (fun _ -> SpriteModel.start())
update population 0 ()