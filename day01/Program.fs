// For more information see https://aka.ms/fsharp-console-apps
open System.IO

let fullPath =
    Path.Combine(__SOURCE_DIRECTORY__, "input.txt")




let caloriesOrdered =
    File.ReadAllText(fullPath).Split("\n\n")
    |> List.ofArray
    |> List.map (fun s -> s.Split "\n" |> List.ofArray)
    |> List.map (fun sl -> sl |> List.map int |> List.sum)
    |> List.sortDescending


let topElf = caloriesOrdered |> List.head
printfn "Top elf calories %d" topElf

let topThreeElves =
    caloriesOrdered |> List.take 3 |> List.sum

printfn "Top 3 elves calories %d" topThreeElves
