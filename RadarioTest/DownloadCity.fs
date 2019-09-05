
module  DownloadCity 
open FSharp.Data

type Cities = HtmlProvider<"https://ru.wikipedia.org/wiki/%D0%A1%D0%BF%D0%B8%D1%81%D0%BE%D0%BA_%D0%B3%D0%BE%D1%80%D0%BE%D0%B4%D0%BE%D0%B2_%D0%A0%D0%BE%D1%81%D1%81%D0%B8%D0%B8">
              
let cities = Cities.GetSample()

let citiesDict =
    cities.Tables.Table1.Rows
    |> Seq.map (fun x -> x.``Города Российской Федерации - Город``)
    |> Seq.groupBy (fun x -> x.Substring(0,2))
    |> Map.ofSeq

let sliceList (stringList:seq<string>) (symbols:string) (numbersOfItems:int) (page:int) =
    stringList |> Seq.filter (fun x -> x.StartsWith(symbols)) |> Seq.skip (numbersOfItems * page) |> Seq.take numbersOfItems
    
let filterCity (symbols:string) (numbersOfItems:int) (page:int) =
    match symbols with
    | null -> Seq.empty
    | _ -> match citiesDict.ContainsKey(symbols.Substring(0,2)) with
            | true -> sliceList citiesDict.[symbols.Substring(0,2)] symbols numbersOfItems page
            | false -> Seq.empty
 
    
