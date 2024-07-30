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
        public static List<Instancia> instancias=new List<Instancia>();
        public static void CrearInstanciasIniciales(Dificultad.Dificultades dificultad, Personaje PersonajePrincipal, List<Personaje> npcs){
            List<Personaje> npcsUsados=new List<Personaje>();
            Personaje npc1;
            Personaje npc2;
            switch(dificultad){
                case Dificultad.Dificultades.Facil:
                    npc1=npcs[random.Next(npcs.Count)];
                    npcsUsados.Add(npc1);
                    instancias.Add(new Instancia("1° Semifinal", PersonajePrincipal, npc1));
                    do{
                        npc1=npcs[random.Next(npcs.Count)];
                    }while(npcsUsados.Contains(npc1));
                    npcsUsados.Add(npc1);
                    do{
                        npc2=npcs[random.Next(npcs.Count)];
                    }while(npcsUsados.Contains(npc2));
                    npcsUsados.Add(npc2);
                    instancias.Add(new Instancia("2° Semifinal", npc1, npc2));
                break;
                case Dificultad.Dificultades.Medio:
                    npc1=npcs[random.Next(npcs.Count)];
                    npcsUsados.Add(npc1);
                    instancias.Add(new Instancia("1° Cuarto de final", PersonajePrincipal, npc1));
                    for(int i=0; i<3; i++){
                        do{
                            npc1=npcs[random.Next(npcs.Count)];
                        }while(npcsUsados.Contains(npc1));
                        npcsUsados.Add(npc1);
                        do{
                            npc2=npcs[random.Next(npcs.Count)];
                        }while(npcsUsados.Contains(npc2));
                        npcsUsados.Add(npc2);
                        instancias.Add(new Instancia($"{i+2}° Cuarto de final", npc1, npc2));
                    }
                break;
                case Dificultad.Dificultades.Dificil:
                    npc1=npcs[random.Next(npcs.Count)];
                    npcsUsados.Add(npc1);
                    instancias.Add(new Instancia("1° Octavo de final", PersonajePrincipal, npc1));
                    for(int i=0; i<7; i++){
                        do{
                            npc1=npcs[random.Next(npcs.Count)];
                        }while(npcsUsados.Contains(npc1));
                        npcsUsados.Add(npc1);
                        do{
                            npc2=npcs[random.Next(npcs.Count)];
                        }while(npcsUsados.Contains(npc2));
                        npcsUsados.Add(npc2);
                        instancias.Add(new Instancia($"{i+2}° Octavo de final", npc1, npc2));
                    }
                break;
            }
        }
    }
    public static void escribirFixture(List<Instancia> instancias){
        Console.WriteLine("FIXTURE DEL TORNEO:\n");
        Thread.Sleep(2000);
        foreach(Instancia instancia in instancias){
            Console.WriteLine(instancia.NombreInstancia+":");
            Console.WriteLine(instancia.Personaje1.DatosPersonaje.Nombre+" vs "+instancia.Personaje2.DatosPersonaje.Nombre+"\n");
            Thread.Sleep(1000);
        }
    }
    public static void generarOctavos(List<Instancia?> instancias){
        List<Personaje>? npcsGanadores=new List<Personaje>();
        int i,j;
        Console.WriteLine("BATALLA OCTAVOS DE FINAL:");
        Personaje? personajePrincipal=Batalla.generarBatallaUsuario(instancias[0].Personaje1, instancias[0].Personaje2);
        for(i=1; i<instancias.Count; i++){
            Personaje? npcGanador=Batalla.generarBatallaNPC(instancias[i].Personaje1, instancias[i].Personaje2);
            npcsGanadores.Add(npcGanador);
        }
        instancias.Clear();
        if(personajePrincipal.CarPersonaje.Salud>0){
            instancias.Add(new Instancia("1° Cuartos", personajePrincipal, npcsGanadores[0]));
        }else{
            return;
        }
        j=2;
        for(i=1; i<npcsGanadores.Count; i=i+2){
            instancias.Add(new Instancia($"{j}° Cuartos", npcsGanadores[i], npcsGanadores[i+1]));
            j++;
        }
    }
    public static void generarCuartos(List<Instancia?> instancias){
        List<Personaje> npcsGanadores=new List<Personaje>();
        int i,j;
        Console.WriteLine("BATALLA CUARTOS DE FINAL:");
        Personaje? personajePrincipal=Batalla.generarBatallaUsuario(instancias[0].Personaje1, instancias[0].Personaje2);
        if(instancias.Count>1){
            for(i=1; i<instancias.Count; i++){
                Personaje? npcGanador=Batalla.generarBatallaNPC(instancias[i].Personaje1, instancias[i].Personaje2);
                npcsGanadores.Add(npcGanador);
            }
        }
        instancias.Clear();
        if(personajePrincipal.CarPersonaje.Salud>0){
            instancias.Add(new Instancia("1° Semifinal", personajePrincipal, npcsGanadores[0]));
        }
        j=2;
        for(i=1; i<npcsGanadores.Count; i=i+2){
            instancias.Add(new Instancia($"{j}° Semifinal", npcsGanadores[i], npcsGanadores[i+1]));
            j++;
        }

    }
    public static void generarSemis(List<Instancia> instancias){
        Console.WriteLine("BATALLA SEMIFINAL:");
        Personaje personajePrincipal=Batalla.generarBatallaUsuario(instancias[0].Personaje1, instancias[0].Personaje2);
        Personaje npcFinalista=Batalla.generarBatallaNPC(instancias[1].Personaje1, instancias[2].Personaje2);
        if(personajePrincipal.CarPersonaje.Salud>0){
            instancias.Add(new Instancia("Final", personajePrincipal, npcFinalista));
        }
    }
    public static void generarFinal(Personaje personajePrincipal, Personaje finalBoss){
        Console.WriteLine("BATALLA FINAL");
        Console.WriteLine("LLEGO EL TAN ESPERADO COMBATE...");
        Personaje ganador=Batalla.generarBatallaUsuario(personajePrincipal, finalBoss);
        if(ganador==personajePrincipal){
            mensajeVictoria(personajePrincipal);
        }else{
            mensajeDerrota();
        }
        Thread.Sleep(5000);
    }
    public static void mensajeVictoria(Personaje personajePrincipal){
        Console.WriteLine("¡GANASTE EL JUEGO!¡ENHORABUENA!");
        Console.WriteLine("ASI TERMINO TU PERSONAJE:");
        Personaje.mostrarPersonaje(personajePrincipal);
    }
    public static void mensajeDerrota(){
        Console.WriteLine("Oh, perdiste en la final, que lastima");
    }
    public static void jugarDeVuelta(){

        Console.WriteLine("¿Deseas jugar de vuelta?");
    }

}