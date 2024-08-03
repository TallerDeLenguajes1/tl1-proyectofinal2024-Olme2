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
        public Insulto(){
            number="";
            language="";
            insult="Hijo de puta";
            created="";
            shown="";
            createdby="";
            active="";
            comment="";
        }
    }
    public static async Task<Insulto?> generarInsulto(){
            Insulto? insulto=new Insulto();
        try{
            HttpResponseMessage response = await client.GetAsync("https://evilinsult.com/generate_insult.php?lang=es&type=json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrWhiteSpace(responseBody)){
                insulto=JsonSerializer.Deserialize<Insulto>(responseBody);   
            }
                return insulto;
            }
            catch{
                return insulto;
            }
    }
}
