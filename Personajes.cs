public class Personaje{
    Caracteristicas CarPersonaje{get;set;}
    Datos DatosPersonaje{get;set;}
    public Personaje(Caracteristicas caracteristicas, Datos datos){
        CarPersonaje=caracteristicas;
        DatosPersonaje=datos;
    }
}
public class Caracteristicas{
    public int velocidad{get;set;}
    public int destreza{get;set;}
    public int fuerza{get;set;}
    public int nivel{get;set;}
    public int armadura{get;set;}
    public float salud{get;set;}

    public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura){
        Velocidad=velocidad;
        Destreza=destreza;
        Fuerza=fuerza;
        Nivel=nivel;
        Armadura=armadura;
        Salud=100;
    }

    public reiniciarSalud(){
        Salud=100;
    }

    public aumentarNivel(int masVelocidad, int masDestreza, int masFuerza, int masArmadura){
        Velocidad+=masVelocidad;
        Destreza+=masDestreza;
        Fuerza+=masFuerza;
        nivel++;
        Armadura+=masArmadura
    }


}
public class Datos{
    public Tipos Tipo{get; set;}
    public string Nombre{get; set;}
    public Date Nacimiento{get;set;}
    public int Edad{get;set;}
    public Datos(Tipo tipo, string nombre, Dato nacimiento, int edad){
        Tipo=tipo;
        Nombre=nombre;
        Nacimiento=nacimiento;
        Edad=edad;
    }
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
Dictionary<Nombres, Tipos> personajeTipos = new Dictionary<Nombres, Tipos>
        {
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

public class GenerarNPCs(){
    public static List<Personaje> Generar(int cantidad){
        List<Personaje> npcs= new List<Personaje>();
        Random random=new Random();
        Array nombresValues=Enum.GetValues(typeof(Nombres));
        for(int i=0; i<cantidad; i++){
            Nombres nombre=(Nombres)nombresValues.GetValue(ramdom.Next(nombresValues.Lenght));
            Tipo tipo=personajeTipos[nombre];
            Caracteristicas caracteristicas=GenerarCaracteristicas(tipo);
            Datos dato=new Dato(tipo, nombre.ToString(), DateTime.Now.)
        }
    }
}