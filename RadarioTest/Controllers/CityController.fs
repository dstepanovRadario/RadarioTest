namespace  RadarioTest.Controllers

open Microsoft.AspNetCore.Mvc
open System.Web.Http

[<Route("api/[controller]")>]
[<ApiController>]
type CityController () =
    inherit ControllerBase()
    
//    [<HttpGet>]
//    member this.Get() =
//        let values = DownloadCity.citiesDict
//        ActionResult<(Map<string, string seq>)>(values)
//        
    [<HttpGet>]
     member this.GetFilter(symbols:string, numbersOfItems:int, page:int) =
         let values = DownloadCity.filterCity symbols numbersOfItems page
         ActionResult<(string seq)>(values)