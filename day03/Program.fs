open System
open System.IO

let fullPath =
    Path.Combine(__SOURCE_DIRECTORY__, "day03.txt")

let input = File.ReadAllLines(fullPath)

let q =
    input
    |> List.ofArray
    |> List.map (fun line -> (line.Substring(0, line.Length / 2), line.Substring(line.Length / 2, line.Length / 2)))
    |> List.map (fun (comp1, comp2) -> ((comp1 |> Set.ofSeq), (comp2 |> Set.ofSeq)))
    |> List.map (fun (set1, set2) -> (set1, set2) ||> Set.intersect)
    |> List.map (fun set -> set.MinimumElement)
    |> List.map (fun ch ->
        match Char.IsUpper ch with
        | true -> (int ch) - 64 + 26
        | false -> (int ch) - 96)
    |> List.sum

printfn $"Answer {q}"

let badgePriority =
    input
    |> List.ofArray
    |> List.chunkBySize 3
    |> List.map (fun groupStringList -> groupStringList |> List.map Set.ofSeq)
    |> List.map (fun groupSetList -> groupSetList |> Set.intersectMany)
    |> List.map (fun a -> a.MinimumElement)
     |> List.map (fun ch ->
        match Char.IsUpper ch with
        | true -> (int ch) - 64 + 26
        | false -> (int ch) - 96)
    |> List.sum
    
printfn $"Answer2 {badgePriority}"