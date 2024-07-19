public class Personaje{
    Caracteristicas CarPersonaje{get;set;}
    Datos DatosPersonaje{get;set;}
    public Personaje(Caracteristicas caracteristicas, Datos datos){
        CarPersonaje=caracteristicas;
        DatosPersonaje=datos;
    }
}
public class Caracteristicas{
    public int Velocidad{get;set;}
    public int Destreza{get;set;}
    public int Fuerza{get;set;}
    public int Nivel{get;set;}
    public int Armadura{get;set;}
    public float Salud{get;set;}

    public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura){
        Velocidad=velocidad;
        Destreza=destreza;
        Fuerza=fuerza;
        Nivel=nivel;
        Armadura=armadura;
        Salud=100;
    }

    public void reiniciarSalud(){
        Salud=100;
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
                return new Caracteristicas(random.Next(5, 10), random.Next(5, 10), random.Next(5, 10), 1, random.Next(1, 5));
            case Datos.Tipos.Dios:
                return new Caracteristicas(random.Next(8, 10), random.Next(8, 10), random.Next(8, 10), 1, random.Next(5, 10));
            case Datos.Tipos.Mutante:
                return new Caracteristicas(random.Next(6, 10), random.Next(6, 10), random.Next(6, 10), 1, random.Next(3, 7));
            case Datos.Tipos.Soldado:
                return new Caracteristicas(random.Next(6, 9), random.Next(6, 9), random.Next(6, 9), 1, random.Next(4, 8));
            case Datos.Tipos.GuardianDeLaGalaxia:
                return new Caracteristicas(random.Next(6, 10), random.Next(6, 10), random.Next(6, 10), 1, random.Next(4, 8));
            case Datos.Tipos.Mago:
                return new Caracteristicas(random.Next(4, 8), random.Next(7, 10), random.Next(3, 6), 1, random.Next(2, 5));
            case Datos.Tipos.Alienigena:
                return new Caracteristicas(random.Next(7, 10), random.Next(6, 9), random.Next(7, 10), 1, random.Next(5, 9));
            default:
                return new Caracteristicas(random.Next(5, 10), random.Next(5, 10), random.Next(5, 10), 1, random.Next(1, 5));
        }
    }
}
public class Datos{
    public Tipos Tipo{get; set;}
    public string Nombre{get; set;}
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
    private static Random random=new Random();
    public static Personaje GenerarPersonaje(){
        Array nombresValues=Enum.GetValues(typeof(Datos.Nombres));
        Datos.Nombres nombre=(Datos.Nombres)nombresValues.GetValue(random.Next(nombresValues.Length));
        Datos.Tipos tipo=Datos.personajeTipos[nombre];
        Caracteristicas caracteristicas=Caracteristicas.GenerarCaracteristicas(tipo);
        DateTime nacimiento;
        switch(tipo){
            case
        }
    }
}