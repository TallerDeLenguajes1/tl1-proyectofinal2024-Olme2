using System.Text.Json;
using System.Text.Json.Nodes;

public class Batalla{
        public static Random random = new Random();
        public static float dañoProvocado(Caracteristicas atacante, Caracteristicas defensor){
            int ataque=atacante.Destreza*atacante.Fuerza*atacante.Nivel;
            int efectividad=random.Next(1,100);
            int defensa=defensor.Armadura*defensor.Velocidad;
            const int constanteDeAjuste=500;
            float dañoProvocado=((ataque*efectividad)-defensa)/constanteDeAjuste;
            return dañoProvocado;
        }
        public static Personaje generarBatallaUsuario(Personaje usuario, Personaje npc){
            Console.WriteLine($"\nSiguiente batalla, {usuario.DatosPersonaje.Nombre} vs {npc.DatosPersonaje.Nombre}");
            Console.WriteLine("\n¡Empieza el combate!");
            Thread.Sleep(3000);
            int round=1;
            while(usuario.CarPersonaje.Salud>0 && npc.CarPersonaje.Salud>0){
                Console.Clear();
                Console.WriteLine($"\n¡Round "+round+"!");
                if(round<=10){
                    Thread.Sleep(500);
                }
                if(round>10 && round<=25){
                    Thread.Sleep(250);
                }
                if(round>25){
                    Thread.Sleep(100);
                }
                float dañoANPC=dañoProvocado(usuario.CarPersonaje, npc.CarPersonaje);
                npc.CarPersonaje.Salud-=dañoANPC;
                Console.WriteLine($"Le has provocado {dañoANPC} de daño a {npc.DatosPersonaje.Nombre}");
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
                    Thread.Sleep(1000);
                    Console.WriteLine($"¡{npc.DatosPersonaje.Nombre} ha muerto!");
                    Thread.Sleep(3000);
                    break;
                }
                float dañoAPersonaje=dañoProvocado(npc.CarPersonaje,usuario.CarPersonaje);
                usuario.CarPersonaje.Salud-=dañoAPersonaje;
                Console.WriteLine($"{npc.DatosPersonaje.Nombre} te provocó {dañoAPersonaje} de daño");
                if(round<=25){
                    Thread.Sleep(500);
                }
                if(round>25){
                    Thread.Sleep(250);
                }
                if(usuario.CarPersonaje.Salud<=0){
                    Thread.Sleep(1000);
                    Console.WriteLine("¡Has muerto!");
                    Thread.Sleep(3000);
                    break;
                }
                round++;
            }
            Console.Clear();
            if(npc.CarPersonaje.Salud<=0){
                Thread.Sleep(2000);
                Console.WriteLine($"¡Fin del combate, {npc.DatosPersonaje.Nombre} ha sido derrotado!¡Enhorabuena, has ganado!");
                usuario.CarPersonaje.aumentarNivel(5,5,5,5);
                return usuario;
            }else{
                Console.WriteLine($"\n¡Has sido derrotado!\n\n// GAME OVER //");
                Thread.Sleep(5000);
                Console.Clear();
                return npc;
            }
        }
        public static Personaje generarBatallaNPC(Personaje npc1, Personaje npc2){
            Console.WriteLine($"\nSiguiente batalla: {npc1.DatosPersonaje.Nombre} vs {npc2.DatosPersonaje.Nombre}");
            Thread.Sleep(2000);
            int round=1;
            while(npc1.CarPersonaje.Salud>0 && npc2.CarPersonaje.Salud>0){
                float dañoANPC2=dañoProvocado(npc1.CarPersonaje, npc2.CarPersonaje);
                npc2.CarPersonaje.Salud-=dañoANPC2;
                if(npc2.CarPersonaje.Salud<=0){
                    break;
                }                
                float dañoANPC1=dañoProvocado(npc2.CarPersonaje,npc1.CarPersonaje);
                npc1.CarPersonaje.Salud-=dañoANPC1;
                if(npc1.CarPersonaje.Salud<=0){
                    break;
                }
                round++;
            }
            if(npc2.CarPersonaje.Salud<=0){
                Console.WriteLine($"\n¡Ganador: {npc1.DatosPersonaje.Nombre} Despues de {round} rounds!");
                Thread.Sleep(2000);
                npc1.CarPersonaje.aumentarNivel(5,5,5,5);
                return npc1;
            }else{
                Console.WriteLine($"\n¡Ganador: {npc2.DatosPersonaje.Nombre} Despues de {round} rounds!");
                Thread.Sleep(2000);
                npc2.CarPersonaje.aumentarNivel(5,5,5,5);
                return npc2;
            }
        }
    }