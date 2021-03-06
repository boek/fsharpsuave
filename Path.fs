module SuaveMusicStore.Path

type IntPath = PrintfFormat<(int -> string),unit,string,string,int>
let withParam (key,value) path = sprintf "%s?%s=%s" path key value

let home = "/"

module Store =
    let overview = "/store"
    let browse = "/store/browse"
    let browseKey = "genre"
    let details : IntPath = "/store/details/%d"