// For more information see https://aka.ms/fsharp-console-apps
open System.IO

let fullPath =
    Path.Combine(__SOURCE_DIRECTORY__, "input.txt")




let data = File.ReadAllText(fullPath).Split("\n\n")
            |> List.ofArray
            |> List.map (fun s -> s.Split "\n" |> List.ofArray)
            |> List.map (fun sl -> sl  |> List.map int |> List.sum)
            |> List.sortDescending
            |> List.head



printf "%d" data
