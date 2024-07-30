using Newtonsoft.Json;

public class APIinsultos{
     private class InsultoResponse{
            public string ? Insult { get; set; }
        }
        private static readonly HttpClient client=new HttpClient();
        public static async Task<string> GetInsulto(){
            var url="https://evilinsult.com/generate_insult.php?lang=es&type=json";
            HttpResponseMessage response=await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody=await response.Content.ReadAsStringAsync();
            var insultoData=System.Text.Json.JsonSerializer.Deserialize<InsultoResponse>(responseBody);
            return insultoData?.Insult??"¡Insulto no disponible!";
        }
 }
