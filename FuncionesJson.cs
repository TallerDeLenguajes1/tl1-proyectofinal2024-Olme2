using System.Text.Json;
public class HistorialJson{
    public class GanadorInfo
    {
        public string? NombreUsuario{get;set;}
        public string? NombrePersonaje {get;set;}
        public string? Dificultad {get;set;}
        public double DanoAcumulado {get;set;}
        public GanadorInfo(string? nombreUsuario, string? nombrePersonaje, string? dificultad, double dañoAcumulado){
            NombreUsuario=nombreUsuario;
            NombrePersonaje=nombrePersonaje;
            Dificultad=dificultad;
            DanoAcumulado=dañoAcumulado;
        }
        public GanadorInfo() { }
    }
    public static async Task GuardarGanador(GanadorInfo ganador, string nombreArchivo){
        try{
            List<GanadorInfo> ganadores=new List<GanadorInfo>();
            if(Existe(nombreArchivo)){
                string jsonExistente=await File.ReadAllTextAsync(nombreArchivo);
                if(!string.IsNullOrWhiteSpace(jsonExistente)){
                    ganadores=JsonSerializer.Deserialize<List<GanadorInfo>>(jsonExistente) ?? new List<GanadorInfo>();
                }
            }
            ganadores.Add(ganador);
            string json=JsonSerializer.Serialize(ganadores, new JsonSerializerOptions {WriteIndented=true});
            await File.WriteAllTextAsync(nombreArchivo, json);
        }catch(Exception e){
            Console.WriteLine($"Error al guardar el ganador: {e.Message}");
        }
    }
    public static async Task<List<GanadorInfo>> LeerGanadores(string nombreArchivo){
        var options = new JsonSerializerOptions
        {
            IncludeFields = true
        };
        try{
            if(Existe(nombreArchivo)){
                string json=await File.ReadAllTextAsync(nombreArchivo);
                if(!string.IsNullOrWhiteSpace(json)){
                    return JsonSerializer.Deserialize<List<GanadorInfo>>(json, options) ?? new List<GanadorInfo>();
                }
            }
        }catch(Exception e){
            Console.WriteLine($"Error al leer los ganadores: {e.Message}");
        }
        return new List<GanadorInfo>();
    }

    public static bool Existe(string nombreArchivo){
        try{
            if(File.Exists(nombreArchivo)){
                string json=File.ReadAllText(nombreArchivo);
                return !string.IsNullOrWhiteSpace(json);
            }
        }catch (Exception e){
            Console.WriteLine($"Error al verificar el archivo: {e.Message}");
        }
        return false;
    }
    
    public static async Task mostrarGanadores(string nombreArchivo){
        List<GanadorInfo> ganadores= await LeerGanadores(nombreArchivo);
        var ganadoresFiltrado=ganadores
            .OrderByDescending(g=>g.DanoAcumulado)
            .Take(10)
            .ToList();
        Console.WriteLine("NOMBRE            | PERSONAJE         | DIFICULTAD | PUNTOS DE DAÑO");
        Console.WriteLine("---------------------------------------------------------------------");
        Thread.Sleep(1000);
        foreach(GanadorInfo ganador in ganadoresFiltrado){
            Console.WriteLine($"{ganador.NombreUsuario.ToUpper().PadRight(18)} | {ganador.NombrePersonaje.ToUpper().PadRight(18)} | {ganador.Dificultad.ToUpper().PadRight(10)} | {ganador.DanoAcumulado.ToString().PadLeft(13)}");
            Thread.Sleep(500);
        }
    }
}