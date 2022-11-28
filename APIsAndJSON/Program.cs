using Newtonsoft.Json.Linq;

var client = new HttpClient();

var kanyeURL = "http://api.kanye.rest/";
var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

var cont = true;
do
{

    var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

    var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

    Console.WriteLine($"Kanye says: \"{kanyeQuote}\"\n");


    var ronResponse = client.GetStringAsync(ronURL).Result;

    var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

    Console.WriteLine($"Ron says: {ronQuote}\n");

    Console.WriteLine("Continue? Y or N?");
    cont = (Console.ReadLine().ToLower() == "n") ? false : true;

} while (cont);