using System.Linq.Expressions;

public class Personaje{
    public Caracteristicas CarPersonaje{get;set;}
    public Datos DatosPersonaje{get;set;}
    public Personaje(Caracteristicas caracteristicas, Datos datos){
        CarPersonaje=caracteristicas;
        DatosPersonaje=datos;
    }
    public static void mostrarPersonaje(Personaje personaje){
        Console.WriteLine($"{personaje.DatosPersonaje.Nombre}:\n");
        Console.WriteLine("///////// Biografia /////////");
        Console.WriteLine($"Nombre: {personaje.DatosPersonaje.Nombre}");
        Console.WriteLine($"Nacimiento: {personaje.DatosPersonaje.Nacimiento.Year}");
        Console.WriteLine($"Edad: {personaje.DatosPersonaje.Edad} años");
        Console.WriteLine($"Tipo: {personaje.DatosPersonaje.Tipo}");
        Console.WriteLine("/////////////////////////////");
        Console.WriteLine("////// Caracteristicas //////");
        Console.WriteLine($"Velocidad: {personaje.CarPersonaje.Velocidad}");
        Console.WriteLine($"Fuerza: {personaje.CarPersonaje.Fuerza}");
        Console.WriteLine($"Destreza: {personaje.CarPersonaje.Destreza}");
        Console.WriteLine($"Armadura: {personaje.CarPersonaje.Armadura}");
        Console.WriteLine($"/////////////////////////////\n");
    }
}
public class Caracteristicas{
    public int Velocidad{get;set;}
    public int Destreza{get;set;}
    public int Fuerza{get;set;}
    public int Nivel{get;set;}
    public int Armadura{get;set;}
    public double Salud{get;set;}
    public double DañoAcumulado{get;set;}

    public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura){
        Velocidad=velocidad;
        Destreza=destreza;
        Fuerza=fuerza;
        Nivel=nivel;
        Armadura=armadura;
        Salud=100;
        DañoAcumulado=0;
    }

    public void aumentarA200Salud(){
        Salud=200;
    }

    public void aumentarA350Salud(){
        Salud=350;
    }
    
    public void aumentarA500Salud(){
        Salud=500;
    }

    public void aumentarNivel(int masVelocidad, int masDestreza, int masFuerza, int masArmadura){
        Velocidad+=masVelocidad;
        Destreza+=masDestreza;
        Fuerza+=masFuerza;
        Nivel++;
        Armadura+=masArmadura;
    }
    public static Caracteristicas GenerarCaracteristicas(Datos.Tipos tipo){
        Random random = new Random();
        switch (tipo){
            case Datos.Tipos.Humano:
                return new Caracteristicas(random.Next(1, 10), random.Next(1, 10), random.Next(1, 10), 1, random.Next(5, 10));
            case Datos.Tipos.Dios:
                return new Caracteristicas(random.Next(1, 10), random.Next(1, 10), random.Next(5, 10), 1, random.Next(1, 10));
            case Datos.Tipos.Mutante:
                return new Caracteristicas(random.Next(5, 10), random.Next(1, 10), random.Next(1, 10), 1, random.Next(1, 10));
            case Datos.Tipos.Soldado:
                return new Caracteristicas(random.Next(1, 10), random.Next(5, 10), random.Next(1, 10), 1, random.Next(1, 10));
            case Datos.Tipos.GuardianDeLaGalaxia:
                return new Caracteristicas(random.Next(1, 10), random.Next(1, 10), random.Next(1, 10), 1, random.Next(1, 10));
            case Datos.Tipos.Mago:
                return new Caracteristicas(random.Next(1, 10), random.Next(1, 10), random.Next(5, 10), 1, random.Next(1, 10));
            case Datos.Tipos.Alienigena:
                return new Caracteristicas(random.Next(5, 10), random.Next(1, 10), random.Next(1, 10), 1, random.Next(1, 10));
            default:
                return new Caracteristicas(random.Next(1, 10), random.Next(1, 10), random.Next(1, 10), 1, random.Next(1, 5));
        }
    }
    
}
public class Datos{
    public Tipos Tipo{get; set;}
    public string? Nombre{get; set;}
    public DateTime Nacimiento{get;set;}
    public int Edad{get;set;}
    public Datos(Tipos tipo, string nombre, DateTime nacimiento, int edad){
        Tipo=tipo;
        Nombre=nombre;
        Nacimiento=nacimiento;
        Edad=edad;
    }
    public enum Tipos{
        Humano,
        Dios,
        Mutante,
        Soldado,
        GuardianDeLaGalaxia,
        Mago,
        Alienigena
    }
    public enum Nombres{
        CapitanAmerica,
        IronMan,
        Thor,
        Hulk,
        SpiderMan,
        DoctorStrange,
        Deadpool,
        BlackWidow,
        BlackPanter,
        CaptainMarvel,
        Gamora,
        StarLord,
        ScarletWitch,
        HawkEye,
        Thanos,
        Wolverine,
        AntMan,
        Venom,
        Rocket,
        GreenGoblin,
        Falcon,
        TorchMan,
        Groot,
        Drax,
        Loki,
        WinterSoldier
    }
    public static List<Datos.Nombres> NombresPersonajes = Enum.GetValues(typeof(Datos.Nombres)).Cast<Datos.Nombres>().ToList();
    public static Dictionary<Nombres, Tipos> personajeTipos = new Dictionary<Nombres, Tipos>{
                { Nombres.CapitanAmerica, Tipos.Soldado },
                { Nombres.WinterSoldier, Tipos.Soldado},
                { Nombres.IronMan, Tipos.Humano },
                { Nombres.Thor, Tipos.Dios },
                { Nombres.Hulk, Tipos.Mutante },
                { Nombres.SpiderMan, Tipos.Mutante },
                { Nombres.DoctorStrange, Tipos.Mago },
                { Nombres.Deadpool, Tipos.Mutante },
                { Nombres.BlackWidow, Tipos.Humano },
                { Nombres.BlackPanter, Tipos.Mutante },
                { Nombres.CaptainMarvel, Tipos.Dios },
                { Nombres.Gamora, Tipos.GuardianDeLaGalaxia },
                { Nombres.StarLord, Tipos.GuardianDeLaGalaxia },
                { Nombres.ScarletWitch, Tipos.Mago },
                { Nombres.HawkEye, Tipos.Humano },
                { Nombres.Thanos, Tipos.Alienigena },
                { Nombres.Wolverine, Tipos.Mutante },
                { Nombres.AntMan, Tipos.Humano },
                { Nombres.Venom, Tipos.Alienigena },
                { Nombres.Rocket, Tipos.GuardianDeLaGalaxia },
                { Nombres.GreenGoblin, Tipos.Mutante },
                { Nombres.Falcon, Tipos.Soldado },
                { Nombres.TorchMan, Tipos.Mutante },
                { Nombres.Groot, Tipos.GuardianDeLaGalaxia },
                { Nombres.Drax, Tipos.GuardianDeLaGalaxia },
                { Nombres.Loki, Tipos.Dios }
            };
}

public class FabricaDePersonajes{
    private static Random random = new Random();
    private static HashSet<Datos.Nombres> nombresUsados = new HashSet<Datos.Nombres>();
    public static Personaje generarPersonajePrincipal(Datos.Nombres nombre){
        nombresUsados.Add(nombre);
        Datos.Tipos tipo=Datos.personajeTipos[nombre];
        Caracteristicas caracteristicas=Caracteristicas.GenerarCaracteristicas(tipo);
        DateTime nacimiento;
        switch(tipo){
            case Datos.Tipos.Dios:
                nacimiento = DateTime.Now.AddYears(-2023);
            break;
            case Datos.Tipos.Alienigena:
                nacimiento = DateTime.Now.AddYears(-random.Next(100, 500));
            break;
            default:
                nacimiento = DateTime.Now.AddYears(-random.Next(20, 40));
            break;
        }
        int edad=DateTime.Now.Year-nacimiento.Year;
        Datos dato=new Datos(tipo, nombre.ToString(), nacimiento, edad);
        return new Personaje(caracteristicas, dato);
    }
    public static Personaje GenerarPersonajeAleatorio(){
        Array nombresValues=Enum.GetValues(typeof(Datos.Nombres));
        Datos.Nombres nombre;
        if (nombresUsados.Count >= nombresValues.Length){
            throw new InvalidOperationException("No quedan nombres únicos disponibles.");
        }
        do{
        #pragma warning disable CS8605 // Conversión unboxing a un valor posiblemente NULL.
            nombre = (Datos.Nombres)nombresValues.GetValue(random.Next(nombresValues.Length));
        #pragma warning restore CS8605 // Conversión unboxing a un valor posiblemente NULL.
        } while (nombresUsados.Contains(nombre));
        nombresUsados.Add(nombre);
        Datos.Tipos tipo=Datos.personajeTipos[nombre];
        Caracteristicas caracteristicas=Caracteristicas.GenerarCaracteristicas(tipo);
        DateTime nacimiento;
        switch(tipo){
            case Datos.Tipos.Dios:
                nacimiento = DateTime.Now.AddYears(-2023);
            break;
            case Datos.Tipos.Alienigena:
                nacimiento = DateTime.Now.AddYears(-random.Next(100, 500));
            break;
            default:
                nacimiento = DateTime.Now.AddYears(-random.Next(20, 40));
            break;
        }
        int edad = DateTime.Now.Year - nacimiento.Year;
        Datos dato=new Datos(tipo, nombre.ToString(), nacimiento, edad);
        return new Personaje(caracteristicas, dato);
    }
    public static List<Personaje> GenerarNpc(Dificultad.Dificultades dificultad){
        List<Personaje> npcs=new List<Personaje>();
        int n;
        switch(dificultad){
            case Dificultad.Dificultades.Facil:
                n=3;
            break;
            case Dificultad.Dificultades.Medio:
                n=7;
            break;
            case Dificultad.Dificultades.Dificil:
                n=15;
            break;
            default:
                n=0;
            break;
        }
        for(int i=0; i<n; i++){
            npcs.Add(GenerarPersonajeAleatorio());
        }
        return npcs;
    }
}