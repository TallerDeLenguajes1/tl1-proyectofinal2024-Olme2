using System.Text.Json;
using System.Web;
public class APIinsultos
{
    private static readonly HttpClient client=new HttpClient();
    public class Insulto{
        public string? number{get;set;}
        public string? language{get;set;}
        public string? insult{get;set;}
        public string? created{get;set;}
        public string? shown{get;set;}
        public string? createdby{get;set;}
        public string? active{get;set;}
        public string? comment{get;set;}
    }
    public static async Task<Insulto?> generarInsulto(){
        HttpResponseMessage response=await client.GetAsync("https://evilinsult.com/generate_insult.php?lang=es&type=json");
        response.EnsureSuccessStatusCode();
        string responseBody=await response.Content.ReadAsStringAsync();
        Insulto? insulto=JsonSerializer.Deserialize<APIinsultos.Insulto>(responseBody);
        return insulto;
    }
}
