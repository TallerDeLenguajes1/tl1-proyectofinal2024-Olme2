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
        public Instancia(string nombreInstancia, Personaje? personaje1, Personaje? personaje2){
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
    public static void escribirFixture(List<Instancia?>? instancias){
        Console.WriteLine("FIXTURE DEL TORNEO:\n");
        Thread.Sleep(2000);
        foreach(Instancia? instancia in instancias){
            Console.WriteLine(instancia.NombreInstancia+":");
            Console.WriteLine(instancia.Personaje1.DatosPersonaje.Nombre+" vs "+instancia.Personaje2.DatosPersonaje.Nombre+"\n");
            Thread.Sleep(1000);
        }
    }
    public static List<Instancia?> generarOctavos(List<Instancia?> instancias){
        List<Personaje?> npcsGanadores=new List<Personaje?>();
        int i,j;
        Console.WriteLine("OCTAVOS DE FINAL");
        Thread.Sleep(2000);
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
    public static List<Instancia?> generarCuartos(List<Instancia?> instancias){
        List<Personaje?> npcsGanadores=new List<Personaje?>();
        int i,j;
        Console.WriteLine("CUARTOS DE FINAL");
        Thread.Sleep(2000);
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
    public static List<Instancia?> generarSemis(List<Instancia?> instancias){
        Console.WriteLine("SEMIFINAL");
        Thread.Sleep(2000);
        Personaje? personajePrincipal=Batalla.generarBatallaUsuario(instancias[0].Personaje1, instancias[0].Personaje2);
        if(personajePrincipal!=instancias[0].Personaje1){
            instancias.Clear();
            return instancias;
        }
        Personaje? npcFinalista=Batalla.generarBatallaNPC(instancias[1].Personaje1, instancias[1].Personaje2);
        instancias.Clear();
        if(personajePrincipal.CarPersonaje.Salud>0){
            instancias.Add(new Instancia("Final", personajePrincipal, npcFinalista));
        }
        return instancias;
    }
    public static async Task generarFinal(Personaje? personajePrincipal, Personaje? finalBoss){
        Thread.Sleep(250);
        Console.WriteLine("GRAN FINAL");
        Thread.Sleep(1000);
        Console.WriteLine("LLEGO EL TAN ESPERADO COMBATE...");
        Thread.Sleep(2000);
        Personaje? ganador=Batalla.generarBatallaUsuario(personajePrincipal, finalBoss);
        if(ganador==personajePrincipal){
            await mensajeVictoria(personajePrincipal);
            //codigo guardar personaje
        }else{
            Console.Clear();
            await mensajeDerrota();
        }
        Thread.Sleep(5000);
    }
    public static async Task mensajeVictoria(Personaje? personajePrincipal){
        APIinsultos.Insulto? insulto=await APIinsultos.generarInsulto();
        Thread.Sleep(2000);
        Console.WriteLine("¡GANASTE EL JUEGO!¡ENHORABUENA!\n");
        Thread.Sleep(1000);
        Console.WriteLine($"{personajePrincipal.DatosPersonaje.Nombre}: ¡Soy el mejor, {insulto.insult.ToLower()}!\n");
        Thread.Sleep(1000);
        Console.WriteLine("ASI TERMINO TU PERSONAJE:\n");
        Thread.Sleep(1000);
        Personaje.mostrarPersonaje(personajePrincipal);
    }
    public static async Task mensajeDerrota(){
        APIinsultos.Insulto? insulto=await APIinsultos.generarInsulto();
        Thread.Sleep(1000);
        Console.WriteLine($"Oh {insulto.insult.ToLower()}, perdiste en la final, que lastima");
    }
    public static async Task iniciarTorneo(List<Instancia?> instancias){
        APIinsultos.Insulto? insulto=await APIinsultos.generarInsulto();
        if(instancias.Count==8){
            instancias=generarOctavos(instancias);
            if(instancias.Count==0){
                Console.WriteLine($"Oh que lastima {insulto.insult.ToLower()}, has sido derrotado en octavos, ¡suerte la proxima!\n");
                return;
            }
            Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("SIGUIENTE ESTANCIA: CUARTOS DE FINAL\n\nPresiona enter para continuar");
            while(true){
                var tecla=Console.ReadKey();
                if(tecla.Key==ConsoleKey.Enter){
                break;
                }   
            }
            Console.Clear();
            foreach(Instancia? instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA200Salud();
                instancia.Personaje2.CarPersonaje.aumentarA200Salud();
            }
            escribirFixture(instancias);
            Thread.Sleep(5000);
            Console.Clear();
            instancias=generarCuartos(instancias);
            if(instancias.Count==0){
                Console.WriteLine($"Oh que lastima {insulto.insult.ToLower()}, has sido derrotado en cuartos, ¡suerte la proxima!\n");
                return;
            }
            Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("SIGUIENTE ESTANCIA: SEMIFINALES\n\nPresiona enter para continuar");
            while(true){
                var tecla=Console.ReadKey();
                if(tecla.Key==ConsoleKey.Enter){
                break;
                }   
            }
            Console.Clear();
            foreach(Instancia? instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA350Salud();
                instancia.Personaje2.CarPersonaje.aumentarA350Salud();
            }
            escribirFixture(instancias);
            Thread.Sleep(5000);
            Console.Clear();
            instancias=generarSemis(instancias);
            foreach(Instancia? instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA500Salud();
                instancia.Personaje2.CarPersonaje.aumentarA500Salud();
            }
        }else if(instancias.Count==4){
            instancias=generarCuartos(instancias);
            if(instancias.Count==0){
                Console.WriteLine($"Oh que lastima {insulto.insult.ToLower()}, has sido derrotado en cuartos , ¡suerte la proxima!\n");
                return;
            }
            foreach(Instancia? instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA200Salud();
                instancia.Personaje2.CarPersonaje.aumentarA200Salud();
            }
            Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("SIGUIENTE ESTANCIA: SEMIFINALES\n\nPresiona enter para continuar");
            while(true){
                var tecla=Console.ReadKey();
                if(tecla.Key==ConsoleKey.Enter){
                break;
                }   
            }
            Console.Clear();
            escribirFixture(instancias);
            Thread.Sleep(5000);
            Console.Clear();
            instancias=generarSemis(instancias);
            foreach(Instancia? instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA350Salud();
                instancia.Personaje2.CarPersonaje.aumentarA350Salud();
            }
        }else{
            instancias=generarSemis(instancias);
            foreach(Instancia? instancia in instancias){
                instancia.Personaje1.CarPersonaje.aumentarA200Salud();
                instancia.Personaje2.CarPersonaje.aumentarA200Salud();
            }
        }
        if(instancias.Count==0){
            Console.WriteLine($"Oh que lastima {insulto.insult.ToLower()}, has sido derrotado en semifinales , ¡suerte la proxima!\n");
            return;
        }
        Thread.Sleep(4000);
        Console.Clear();
        Console.WriteLine("SIGUIENTE ESTANCIA: ¡FINAL!\n\nPresiona enter para continuar con la FINAL");
            while(true){
                var tecla=Console.ReadKey();
                if(tecla.Key==ConsoleKey.Enter){
                break;
                }   
            }
        Console.Clear();
        await generarFinal(instancias[0].Personaje1,instancias[0].Personaje2);
    }
}