open System.IO

let fullPath =
    Path.Combine(__SOURCE_DIRECTORY__, "day02.txt")

let input = File.ReadAllLines(fullPath)


let ChoiceScoreMap =
    Map [ ('A', 1)
          ('X', 1)
          ('B', 2)
          ('Y', 2)
          ('C', 3)
          ('Z', 3) ]

// Rock -> A/X
// Paper -> B/Y
// Scissors -> C/Z
    // win 6
    // tie 3
    // loss 0
let determineScore (play: string) : int =
    let myPlay = play[2]
    let theirPlay = play[0]
    let choiceScore = ChoiceScoreMap[myPlay]
    let handScore =
        match myPlay, theirPlay with
        | 'X', 'C' -> 6 // rock beats scissors
        | 'Y', 'A' -> 6 // paper beats rock
        | 'Z', 'B' -> 6 // scissors beats paper
        | 'X', 'A' -> 3 // rock draws rock
        | 'Y', 'B' -> 3 // paper draws paper
        | 'Z', 'C' -> 3 // scissors draws scissors
        | 'X', 'B' -> 0 // rock loses paper
        | 'Y', 'C' -> 0 // paper loses scissor
        | 'Z', 'A' -> 0 // scissors loses rock
        | _ -> failwith "Wtf?"

    choiceScore + handScore



let answer =  input |> Array.map determineScore



printfn "%d" (answer |> Array.sum)
