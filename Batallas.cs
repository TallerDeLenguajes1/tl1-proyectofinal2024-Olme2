using System.Text.Json;
using System.Text.Json.Nodes;

public class Batalla{
        public static Random random = new Random();
        public static double dañoProvocado(Caracteristicas atacante, Caracteristicas defensor){
            double ataque=atacante.Destreza*atacante.Fuerza*atacante.Nivel;
            double efectividad=random.Next(1,100);
            double defensa=defensor.Armadura*defensor.Velocidad;
            const double constanteDeAjuste=500;
            double dañoProvocado=Math.Abs(Math.Round(((ataque*efectividad)-defensa)/constanteDeAjuste,1));
            return dañoProvocado;
        }
        public static Personaje? generarBatallaUsuario(Personaje? usuario, Personaje? npc, bool Final){
            int largoNombreUsuario=usuario.DatosPersonaje.Nombre.Length;
            int largoNombreNpc=npc.DatosPersonaje.Nombre.Length;
            Console.WriteLine($"\nSiguiente batalla, {usuario.DatosPersonaje.Nombre} vs {npc.DatosPersonaje.Nombre}");
            Thread.Sleep(1000);
            Console.WriteLine("\n¡Empieza el combate!");
            Thread.Sleep(3000);
            int round=1;
            int i;
            int saludInicialPersonaje=(int)usuario.CarPersonaje.Salud;
            int saludInicialNpc=(int)npc.CarPersonaje.Salud;
            while(usuario.CarPersonaje.Salud>0 && npc.CarPersonaje.Salud>0){
                Console.Clear();
                Console.Write(usuario.DatosPersonaje.Nombre);
                for(i=0; i < largoNombreNpc; i++){
                    Console.Write(" ");
                }
                for(i=0; i<usuario.CarPersonaje.Salud; i+=saludInicialPersonaje/20){
                    Console.Write("/");
                }
                Console.Write("\n");
                Console.Write(npc.DatosPersonaje.Nombre);
                for(i=0; i < largoNombreUsuario; i++){
                    Console.Write(" ");
                }
                for(i=0; i<npc.CarPersonaje.Salud; i+=saludInicialNpc/20){
                    Console.Write("/");
                }
                Console.Write("\n\n");
                double dañoANPC=dañoProvocado(usuario.CarPersonaje, npc.CarPersonaje);
                Console.WriteLine($"¡Round "+round+"!\n");
                if(round<=10){
                    Thread.Sleep(500);
                }
                if(round>10 && round<=25){
                    Thread.Sleep(250);
                }
                if(round>25 && round<=50){
                    Thread.Sleep(100);
                    dañoANPC*=2;
                }
                if(round>50){
                    Thread.Sleep(100);
                    dañoANPC*=5;
                }
                usuario.CarPersonaje.DañoAcumulado+=dañoANPC;
                npc.CarPersonaje.Salud-=dañoANPC;
                Console.WriteLine($"Le has provocado {dañoANPC} de daño a {npc.DatosPersonaje.Nombre}\n");
                if(round<=10){
                    Thread.Sleep(500);
                }
                if(round>10 && round<=25){
                    Thread.Sleep(250);
                }
                if(round>25){
                    Thread.Sleep(100);
                }
                if(npc.CarPersonaje.Salud<=0){
                    Console.Clear();
                    Console.Write(usuario.DatosPersonaje.Nombre);
                    for(i=0; i < largoNombreNpc; i++){
                    Console.Write(" ");
                    }
                    for(i=0; i<usuario.CarPersonaje.Salud; i+=saludInicialPersonaje/20){
                    Console.Write("/");
                    }
                    Console.Write("\n");
                    Console.Write(npc.DatosPersonaje.Nombre);
                    Console.Write("\n\n");
                    Console.WriteLine($"¡Round "+round+"!\n");
                    Console.WriteLine($"Le has provocado {dañoANPC} de daño a {npc.DatosPersonaje.Nombre}\n");
                    Thread.Sleep(1000);
                    Console.WriteLine($"¡{npc.DatosPersonaje.Nombre} ha muerto!");
                    Thread.Sleep(3000);
                    break;
                }
                double dañoAPersonaje=dañoProvocado(npc.CarPersonaje,usuario.CarPersonaje);
                if(round>25 && round<=50){
                    dañoAPersonaje*=2;
                }
                if(round>50){
                    dañoAPersonaje*=5;
                }
                usuario.CarPersonaje.Salud-=dañoAPersonaje;
                Console.WriteLine($"{npc.DatosPersonaje.Nombre} te provocó {dañoAPersonaje} de daño");
                if(round<=25){
                    Thread.Sleep(500);
                }
                if(round>25){
                    Thread.Sleep(250);
                }
                if(usuario.CarPersonaje.Salud<=0){
                    Console.Clear();
                    Console.Write(usuario.DatosPersonaje.Nombre);
                    Console.Write("\n");
                    Console.Write(npc.DatosPersonaje.Nombre);
                    for(i=0; i < largoNombreUsuario; i++){
                    Console.Write(" ");
                    }
                    for(i=0; i<npc.CarPersonaje.Salud; i+=saludInicialNpc/20){
                        Console.Write("/");
                    }
                    Console.Write("\n\n");
                    Console.WriteLine($"¡Round "+round+"!\n");
                    Console.WriteLine($"Le has provocado {dañoANPC} de daño a {npc.DatosPersonaje.Nombre}\n");
                    Console.WriteLine($"{npc.DatosPersonaje.Nombre} te provocó {dañoAPersonaje} de daño\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("¡Has muerto!");
                    Thread.Sleep(3000);
                    break;
                }
                round++;
            }
            if(npc.CarPersonaje.Salud<=0){
                Thread.Sleep(2000);
                Console.WriteLine($"\n¡Fin del combate, {npc.DatosPersonaje.Nombre} ha sido derrotado!¡Enhorabuena, has ganado!");
                Thread.Sleep(4000);
                if(!Final){
                    Console.WriteLine("\nMEJORAS DE PERSONAJE:");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Velocidad: {usuario.CarPersonaje.Velocidad} -> {usuario.CarPersonaje.Velocidad+5}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Destreza: {usuario.CarPersonaje.Destreza} -> {usuario.CarPersonaje.Destreza+5}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Fuerza: {usuario.CarPersonaje.Fuerza} -> {usuario.CarPersonaje.Fuerza+5}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Armadura: {usuario.CarPersonaje.Armadura} -> {usuario.CarPersonaje.Armadura+5}");
                    Thread.Sleep(1000);
                    usuario.CarPersonaje.aumentarNivel(5,5,5,5);
                }
                Torneo.presionaEnter();
                Console.Clear();
                return usuario;
            }else{
                Console.WriteLine($"\n¡Has sido derrotado!");
                Thread.Sleep(5000);
                Console.Clear();
                Console.WriteLine("/////////////////");
                Thread.Sleep(500);
                Console.WriteLine("////GAME OVER////");
                Thread.Sleep(500);
                Console.WriteLine("/////////////////");
                Thread.Sleep(500);
                for(i=0; i<5; i++){
                    Console.Clear();
                    Console.Write("\n\n\n");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("/////////////////\n////GAME OVER////\n/////////////////");
                    Thread.Sleep(500);
                }
                Console.Clear();
                return npc;
            }
        }
        public static Personaje? generarBatallaNPC(Personaje? npc1, Personaje? npc2){
            Console.WriteLine($"Siguiente batalla: {npc1.DatosPersonaje.Nombre} vs {npc2.DatosPersonaje.Nombre}");
            Thread.Sleep(2000);
            int round=1;
            while(npc1.CarPersonaje.Salud>0 && npc2.CarPersonaje.Salud>0){
                double dañoANPC2=dañoProvocado(npc1.CarPersonaje, npc2.CarPersonaje);
                npc2.CarPersonaje.Salud-=dañoANPC2;
                if(npc2.CarPersonaje.Salud<=0){
                    break;
                }                
                double dañoANPC1=dañoProvocado(npc2.CarPersonaje,npc1.CarPersonaje);
                npc1.CarPersonaje.Salud-=dañoANPC1;
                if(npc1.CarPersonaje.Salud<=0){
                    break;
                }
                round++;
            }
            if(npc2.CarPersonaje.Salud<=0){
                Console.WriteLine($"\n¡El ganador es {npc1.DatosPersonaje.Nombre} despues de {round} rounds!\n");
                Thread.Sleep(2000);
                npc1.CarPersonaje.aumentarNivel(5,5,5,5);
                return npc1;
            }else{
                Console.WriteLine($"\n¡El ganador es {npc2.DatosPersonaje.Nombre} despues de {round} rounds!\n");
                Thread.Sleep(2000);
                npc2.CarPersonaje.aumentarNivel(5,5,5,5);
                return npc2;
            }
        }      
}