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
        public static List<Instancia?> instancias=new List<Instancia?>();
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
    public static void escribirFixture(List<Instancia?> instancias){
        Console.WriteLine("FIXTURE DEL TORNEO:\n");
        Thread.Sleep(2000);
        foreach(Instancia instancia in instancias){
            Console.WriteLine(instancia.NombreInstancia+":");
            Console.WriteLine(instancia.Personaje1.DatosPersonaje.Nombre+" vs "+instancia.Personaje2.DatosPersonaje.Nombre+"\n");
            Thread.Sleep(1000);
        }
    }
    public static List<Instancia> generarOctavos(List<Instancia?> instancias){
        List<Personaje>? npcsGanadores=new List<Personaje>();
        int i,j;
        Console.WriteLine("BATALLA OCTAVOS DE FINAL:");
        Personaje? personajePrincipal=Batalla.generarBatallaUsuario(instancias[0].Personaje1, instancias[0].Personaje2);
        if(personajePrincipal!=instancias[0].Personaje1){
            instancias.Clear();
            return instancias;
        }
        for(i=1; i<instancias.Count; i++){
            Personaje? npcGanador=Batalla.generarBatallaNPC(instancias[i].Personaje1, instancias[i].Personaje2);
            npcsGanadores.Add(npcGanador);
        }
        instancias.Clear();
        if(personajePrincipal.CarPersonaje.Salud>0){
            instancias.Add(new Instancia("1° Cuartos", personajePrincipal, npcsGanadores[0]));
        }else{
            return instancias;
        }
        j=2;
        for(i=1; i<npcsGanadores.Count; i=i+2){
            instancias.Add(new Instancia($"{j}° Cuartos", npcsGanadores[i], npcsGanadores[i+1]));
            j++;
        }
        return instancias;
    }
    public static List<Instancia> generarCuartos(List<Instancia?> instancias){
        List<Personaje> npcsGanadores=new List<Personaje>();
        int i,j;
        Console.WriteLine("BATALLA CUARTOS DE FINAL:");
        Personaje? personajePrincipal=Batalla.generarBatallaUsuario(instancias[0].Personaje1, instancias[0].Personaje2);
        if(personajePrincipal!=instancias[0].Personaje1){
            instancias.Clear();
            return instancias;
        }
        if(instancias.Count>1){
            for(i=1; i<instancias.Count; i++){
                Personaje? npcGanador=Batalla.generarBatallaNPC(instancias[i].Personaje1, instancias[i].Personaje2);
                npcsGanadores.Add(npcGanador);
            }
        }
        instancias.Clear();
        if(personajePrincipal.CarPersonaje.Salud>0){
            instancias.Add(new Instancia("1° Semifinal", personajePrincipal, npcsGanadores[0]));
        }else{
            return instancias;
        }
        j=2;
        for(i=1; i<npcsGanadores.Count; i=i+2){
            instancias.Add(new Instancia($"{j}° Semifinal", npcsGanadores[i], npcsGanadores[i+1]));
            j++;
        }
        return instancias;
    }
    public static List<Instancia> generarSemis(List<Instancia?> instancias){
        Console.WriteLine("BATALLA SEMIFINAL:");
        Personaje personajePrincipal=Batalla.generarBatallaUsuario(instancias[0].Personaje1, instancias[0].Personaje2);
        if(personajePrincipal!=instancias[0].Personaje1){
            instancias.Clear();
            return instancias;
        }
        Personaje npcFinalista=Batalla.generarBatallaNPC(instancias[1].Personaje1, instancias[1].Personaje2);
        instancias.Clear();
        if(personajePrincipal.CarPersonaje.Salud>0){
            instancias.Add(new Instancia("Final", personajePrincipal, npcFinalista));
        }
        return instancias;
    }
    public static void generarFinal(Personaje personajePrincipal, Personaje finalBoss){
        Thread.Sleep(250);
        Console.WriteLine("BATALLA FINAL");
        Thread.Sleep(1000);
        Console.WriteLine("LLEGO EL TAN ESPERADO COMBATE...");
        Personaje ganador=Batalla.generarBatallaUsuario(personajePrincipal, finalBoss);
        if(ganador==personajePrincipal){
            mensajeVictoria(personajePrincipal);
            //codigo guardar personaje
        }else{
            Console.Clear();
            mensajeDerrota();
        }
        Thread.Sleep(5000);
    }
    public static async void mensajeVictoria(Personaje personajePrincipal){
        string insulto= await APIinsultos.GetInsulto();
        Thread.Sleep(2000);
        Console.WriteLine("\n¡GANASTE EL JUEGO!¡ENHORABUENA!");
        Thread.Sleep(1000);
        Console.WriteLine($"{personajePrincipal.DatosPersonaje.Nombre}: ¡Soy el mejor, {insulto}!");
        Thread.Sleep(1000);
        Console.WriteLine("ASI TERMINO TU PERSONAJE:");
        Thread.Sleep(1000);
        Personaje.mostrarPersonaje(personajePrincipal);
    }
    public static async void mensajeDerrota(){
        Thread.Sleep(1000);
        string insulto=await APIinsultos.GetInsulto();
        Console.WriteLine($"\nOh {insulto}, perdiste en la final, que lastima");
    }
    public static async Task iniciarTorneo(List<Instancia?> instancias){
        string insulto= await APIinsultos.GetInsulto();
        if(instancias.Count==8){
            instancias=generarOctavos(instancias);
            if(instancias.Count==0){
                Console.WriteLine($"Oh que lastima, has sido derrotado en octavos {insulto}, ¡suerte la proxima!");
                return;
            }
            Console.WriteLine("\nSiguiente instancia: Cuartos de final\nPresiona enter para continuar");
            while(true){
                var tecla=Console.ReadKey();
                if(tecla.Key==ConsoleKey.Enter){
                break;
                }   
            }
            Console.Clear();
            foreach(Instancia instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA200Salud();
                instancia.Personaje2.CarPersonaje.aumentarA200Salud();
            }
            escribirFixture(instancias);
            instancias=generarCuartos(instancias);
            if(instancias.Count==0){
                Console.WriteLine($"Oh que lastima, has sido derrotado en cuartos {insulto}, ¡suerte la proxima!");
                return;
            }
            Console.WriteLine("\nSiguiente instancia: Semifinales\nPresiona enter para continuar");
            while(true){
                var tecla=Console.ReadKey();
                if(tecla.Key==ConsoleKey.Enter){
                break;
                }   
            }
            Console.Clear();
            foreach(Instancia instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA350Salud();
                instancia.Personaje2.CarPersonaje.aumentarA350Salud();
            }
            escribirFixture(instancias);
            instancias=generarSemis(instancias);
            foreach(Instancia instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA500Salud();
                instancia.Personaje2.CarPersonaje.aumentarA500Salud();
            }
        }else if(instancias.Count==4){
            instancias=generarCuartos(instancias);
            if(instancias.Count==0){
                Console.WriteLine($"Oh que lastima, has sido derrotado en cuartos {insulto}, ¡suerte la proxima!");
                return;
            }
            foreach(Instancia instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA200Salud();
                instancia.Personaje2.CarPersonaje.aumentarA200Salud();
            }
            Console.WriteLine("\nSiguiente instancia: Semifinales\nPresiona enter para continuar");
            while(true){
                var tecla=Console.ReadKey();
                if(tecla.Key==ConsoleKey.Enter){
                break;
                }   
            }
            Console.Clear();
            escribirFixture(instancias);
            instancias=generarSemis(instancias);
            foreach(Instancia instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA350Salud();
                instancia.Personaje2.CarPersonaje.aumentarA350Salud();
            }
        }else{
            instancias=generarSemis(instancias);
            foreach(Instancia instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA200Salud();
                instancia.Personaje2.CarPersonaje.aumentarA200Salud();
            }
        }
        if(instancias.Count==0){
            Console.WriteLine($"Oh que lastima, has sido derrotado en semifinales {insulto}, ¡suerte la proxima!");
            return;
        }
        Console.WriteLine("\nSiguiente instancia: ¡FINAL!\nPresiona enter para continuar con la FINAL");
            while(true){
                var tecla=Console.ReadKey();
                if(tecla.Key==ConsoleKey.Enter){
                break;
                }   
            }
        Console.Clear();
        generarFinal(instancias[0].Personaje1,instancias[0].Personaje2);
    }
}