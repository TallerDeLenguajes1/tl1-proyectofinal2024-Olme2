public class Dificultad{
    public enum Dificultades{
        Facil,
        Medio,
        Dificil
    }
    public static List<Dificultades> dificultades = Enum.GetValues(typeof(Dificultades)).Cast<Dificultades>().ToList();
    public static int cantidadDeParticipantes(Dificultades dificultad){
        int cantidad=0;
        switch(dificultad){
            case Dificultades.Facil:
                cantidad=4;
            break;
            case Dificultades.Medio:
                cantidad=8;
            break;
            case Dificultades.Dificil:
                cantidad=16;
            break;
        }
        return cantidad;
    }
}
public class Torneo{
    private static Random random = new Random();
    public class Instancia{
        public string? NombreInstancia{get;set;}
        public Personaje? Personaje1{get;set;}
        public Personaje? Personaje2{get;set;}
        public Instancia(string nombreInstancia, Personaje personaje1, Personaje personaje2){
            NombreInstancia=nombreInstancia;
            Personaje1=personaje1;
            Personaje2=personaje2;
        }
        public static void CrearInstanciasIniciales(Dificultad.Dificultades dificultad, Personaje PersonajePrincipal, List<Personaje> npcs){
            List<Personaje> npcsUsados=new List<Personaje>();
            switch(dificultad){
                case Dificultad.Dificultades.Facil:
                    Personaje npc1;
                    Personaje npc2;
                    npc1=npcs[random.Next(npcs.Count)];
                    npcsUsados.Add(npc1);
                    new Instancia("1° cuarto de final", PersonajePrincipal, npc1);
                    for(int i=0; i<3; i++){
                        do{
                            npc1=npcs[random.Next(npcs.Count)];
                        }while(npcsUsados.Contains(npc1));
                        npcsUsados.Add(npc1);
                        do{
                            npc2=npcs[random.Next(npcs.Count)];
                        }while(npcsUsados.Contains(npc2));
                        npcsUsados.Add(npc2);
                        new Instancia($"{i+2}° cuarto de final", npc1, npc2);
                    }
                break;
                case Dificultad.Dificultades.Medio:

                break;
                case Dificultad.Dificultades.Dificil:

                break;
            }
        }
    }
    public void iniciarTorneo(){
    do{
        Console.WriteLine
    }while()
    }
}