using System.Text.Json;
using System.Text.Json.Nodes;

public class Batalla{
        Random random = new Random();
        public float dañoProvocado(Caracteristicas atacante, Caracteristicas defensor){
            int ataque=atacante.Destreza*atacante.Fuerza*atacante.Nivel;
            int efectividad=random.Next(1,100);
            int defensa=defensor.Armadura*defensor.Velocidad;
            const int constanteDeAjuste=500;
            float dañoProvocado=((ataque*efectividad)-defensa)/constanteDeAjuste;
            return dañoProvocado;
        }
       
        public int generarBatallaUsuario(Personaje usuario, Personaje npc){
            Console.WriteLine($"Siguiente batalla, {usuario.DatosPersonaje.Nombre} vs {npc.DatosPersonaje.Nombre}");
            string ? insulto=APIinsultos.GetInsulto().ToString();
            Console.WriteLine($"{usuario.DatosPersonaje.Nombre}: {insulto}");
            Console.WriteLine($"{npc.DatosPersonaje.Nombre}: {insulto}");
            Console.WriteLine("¡Empieza el combate!");
            int round=0;
            while(usuario.CarPersonaje.Salud>0 && npc.CarPersonaje.Salud>0){
                Console.WriteLine($"¡Round "+round+"!");
                float dañoANPC=dañoProvocado(usuario.CarPersonaje, npc.CarPersonaje);
                npc.CarPersonaje.Salud-=dañoANPC;
                Console.WriteLine($"{usuario.DatosPersonaje.Nombre} le provocó {dañoANPC} de daño a {npc.DatosPersonaje.Nombre}");
                if(npc.CarPersonaje.Salud<=0){
                    break;
                }
                float dañoAPersonaje=dañoProvocado(npc.CarPersonaje,usuario.CarPersonaje);
                usuario.CarPersonaje.Salud-=dañoAPersonaje;
                Console.WriteLine($"{npc.DatosPersonaje.Nombre} le provocó {dañoAPersonaje} de daño a {usuario.DatosPersonaje.Nombre}");
                if(usuario.CarPersonaje.Salud<=0){
                    break;
                }
            }
            if(npc.CarPersonaje.Salud<0){
                Console.WriteLine($"¡{npc.DatosPersonaje.Nombre} ha sido derrotado!¡Enhorabuena!");
                usuario.CarPersonaje.aumentarNivel(5,5,5,5);
                return 1;
            }else{
                Console.WriteLine($"¡Has sido derrotado!\n// GAME OVER //");
                return 0;
            }
        }
        public Personaje generarBatallaNPC(Personaje npc1, Personaje npc2){
            Console.WriteLine($"Siguiente batalla: {npc1.DatosPersonaje.Nombre} vs {npc1.DatosPersonaje.Nombre}");
            int round=1;
            while(npc1.CarPersonaje.Salud>0 && npc2.CarPersonaje.Salud>0){
                Console.WriteLine($"Round {round}, ¡FIGHT!");
                float dañoANPC2=dañoProvocado(npc1.CarPersonaje, npc2.CarPersonaje);
                npc2.CarPersonaje.Salud-=dañoANPC2;
                if(npc2.CarPersonaje.Salud<0){
                    break;
                }                
                float dañoANPC1=dañoProvocado(npc2.CarPersonaje,npc1.CarPersonaje);
                npc1.CarPersonaje.Salud-=dañoANPC1;
                if(npc1.CarPersonaje.Salud<0){
                    break;
                }
                round++;
            }
            if(npc2.CarPersonaje.Salud<=0){
                Console.WriteLine($"¡Ganador: {npc1.DatosPersonaje.Nombre} Despues de {round} rounds!");
                npc1.CarPersonaje.aumentarNivel(5,5,5,5);
                return npc1;
            }else{
                Console.WriteLine($"¡Ganador: {npc2.DatosPersonaje.Nombre} Despues de {round} rounds!");
                npc2.CarPersonaje.aumentarNivel(5,5,5,5);
                return npc2;
            }
        }
    }