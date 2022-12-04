open System.IO

let fullPath =
    Path.Combine(__SOURCE_DIRECTORY__, "input.txt")

let input = File.ReadAllLines(fullPath)

let q =
    input
    |> List.ofArray // "2-4,6-8"
    |> List.map (fun line -> ((line.Split ",")[0], (line.Split ",")[1])) // ("2-4","6-8")
    |> List.map (fun (fst, snd) -> ((fst.Split("-")[0], fst.Split("-")[1]), (snd.Split("-")[0], snd.Split("-")[1]))) // (("2","4"),("6","8"))
    |> List.map (fun ((a, b), (c, d)) -> ((int a, int b), (int c, int d))) // ((2,4),(6,8))
    |> List.map (fun ((b1, e1), (b2, e2)) -> (seq { b1..e1 }, seq { b2..e2 })) // ([2,3,4],[6,7,8])
    |> List.map (fun (s1, s2) -> (s1 |> Set.ofSeq, s2 |> Set.ofSeq)) // ({2,3,4},{6,7,8})

let answer1 =
    q
    |> List.map (fun (a, b) ->
        if (a.Count < b.Count) then
            (b, a)
        else
            (a, b))
    |> List.map (fun (s1, s2) -> Set.isSubset s2 s1)
    |> List.filter (fun r -> r)

printfn $"Answer {answer1.Length}"

let answer2 =
    q
    |> List.map (fun (fst, snd) -> Set.intersect fst snd)
    |> List.filter (fun set -> not set.IsEmpty)

printfn $"Answer2 {answer2.Length}"
