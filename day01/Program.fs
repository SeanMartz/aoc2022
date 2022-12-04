// For more information see https://aka.ms/fsharp-console-apps
open System.IO

let fullPath =
    Path.Combine(__SOURCE_DIRECTORY__, "input.txt")

let caloriesOrdered =
    File.ReadAllText(fullPath).Split("\n\n")
    |> Array.map (fun s -> s.Split "\n")
    |> Array.map (fun sl -> sl |> Array.map int |> Array.sum)
    |> Array.sortDescending


let topElf = caloriesOrdered |> Array.head
printfn "Top elf calories %d" topElf

let topThreeElves =
    caloriesOrdered |> Array.take 3 |> Array.sum

printfn "Top 3 elves calories %d" topThreeElves
