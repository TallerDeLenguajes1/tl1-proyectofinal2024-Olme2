﻿using Newtonsoft.Json;
using System.Web;
HttpClient client=new HttpClient();
HttpResponseMessage response=await client.GetAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
response.EnsureSuccessStatusCode();
NewT responseBody=await response.Content.ReadAsStringAsync();
APIinsultos.Insulto insulto=JsonSerializer.Deserialize<APIinsultos.Insulto>(responseBody);
Console.WriteLine(insulto);
int i;
int j=0;
Dificultad.Dificultades dificultadSeleccionada = Dificultad.dificultades[0];    
int totalDificultades=Dificultad.dificultades.Count;
Console.WriteLine("¡Bienvenido a UCM fights!\n");
Thread.Sleep(2000);
Console.WriteLine("HISTORIAL DE GANADORES:");
Thread.Sleep(2000);
Console.WriteLine("\nSeleccione una dificultad:");
Thread.Sleep(1000);  
while (true){
    if(j!=0){
        Console.WriteLine("¡Bienvenido a UCM fights!\n");
        Console.WriteLine("HISTORIAL DE GANADORES:");
        Console.WriteLine("\nSeleccione una dificultad:");  
    }  
    for (i = 0; i < 3; i++){
        if (Dificultad.dificultades[i] == dificultadSeleccionada){
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        Console.WriteLine(Dificultad.dificultades[i]);
        Console.ResetColor();
    }
    var tecla = Console.ReadKey(true);
    if (tecla.Key == ConsoleKey.UpArrow){
        int currentIndex = Dificultad.dificultades.IndexOf(dificultadSeleccionada);
        dificultadSeleccionada = Dificultad.dificultades[(currentIndex - 1 + totalDificultades) % totalDificultades];
    }else if (tecla.Key == ConsoleKey.DownArrow){
        int currentIndex = Dificultad.dificultades.IndexOf(dificultadSeleccionada);
        dificultadSeleccionada = Dificultad.dificultades[(currentIndex + 1) % totalDificultades];
    }else if (tecla.Key == ConsoleKey.Enter){
        break;
    }
    j++;
    Console.Clear();
}
Datos.Nombres PersonajeSeleccionado = Datos.NombresPersonajes[0];
int totalPersonajes = Datos.NombresPersonajes.Count;
j=0;
Console.Clear();
Console.WriteLine($"\nDificultad seleccionada: {dificultadSeleccionada}\n");
Thread.Sleep(2000);
Console.WriteLine("¡Elige a tu personaje!\n");
Thread.Sleep(1000);
while (true){
    if(j!=0){
        Console.WriteLine($"\nDificultad seleccionada: {dificultadSeleccionada}\n");
        Console.WriteLine("¡Elige a tu personaje!\n");
    }
    for ( i = 0; i < totalPersonajes; i++)
    {
        if (Datos.NombresPersonajes[i] == PersonajeSeleccionado)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        Console.Write($"{Datos.NombresPersonajes[i]} \n");
        Console.ResetColor();
    }
    var tecla = Console.ReadKey(true);
    if (tecla.Key == ConsoleKey.UpArrow){
        int currentIndex = Datos.NombresPersonajes.IndexOf(PersonajeSeleccionado);
        PersonajeSeleccionado = Datos.NombresPersonajes[(currentIndex - 1 + totalPersonajes) % totalPersonajes];
    }else if (tecla.Key == ConsoleKey.DownArrow){
        int currentIndex = Datos.NombresPersonajes.IndexOf(PersonajeSeleccionado);
        PersonajeSeleccionado = Datos.NombresPersonajes[(currentIndex + 1) % totalPersonajes];
    }else if (tecla.Key == ConsoleKey.Enter){
        break;
    }
    j++;
    Console.Clear();
}
Console.Clear();
Personaje PersonajePrincipal= FabricaDePersonajes.generarPersonajePrincipal(PersonajeSeleccionado);
List<Personaje>npcs=FabricaDePersonajes.GenerarNpc(dificultadSeleccionada);
Console.WriteLine($"\nDificultad seleccionada: {dificultadSeleccionada}\n");
Console.WriteLine($"Tu personaje es: {PersonajeSeleccionado}");
Console.WriteLine($"Participantes de este torneo ({Dificultad.cantidadDeParticipantes(dificultadSeleccionada)}):");
Thread.Sleep(2000);
Personaje.mostrarPersonaje(PersonajePrincipal);
foreach(Personaje npc in npcs){
    if(dificultadSeleccionada==Dificultad.Dificultades.Dificil){
        Thread.Sleep(500);
    }
    if(dificultadSeleccionada==Dificultad.Dificultades.Medio){
        Thread.Sleep(1000);
    }
    if(dificultadSeleccionada==Dificultad.Dificultades.Facil){
        Thread.Sleep(2000);
    }
    Personaje.mostrarPersonaje(npc);
}
Torneo.Instancia.CrearInstanciasIniciales(dificultadSeleccionada, PersonajePrincipal, npcs);
Thread.Sleep(2000);
Torneo.escribirFixture(Torneo.Instancia.instancias);
Console.WriteLine("¿Listo para empezar? Presiona enter cuando estes listo");
while(true){
    var tecla=Console.ReadKey();
    if(tecla.Key==ConsoleKey.Enter){
        break;
    }
}
for (i=3;i>0;i--){
    Console.Write($"\r{i}"); 
    Thread.Sleep(1000); 
}
Console.WriteLine("\r¡A luchar!");
Thread.Sleep(2000);
Console.Clear();
await Torneo.iniciarTorneo(Torneo.Instancia.instancias);
Thread.Sleep(2000);
Console.WriteLine("\n¡Ha terminado el torneo, gracias por jugar!");