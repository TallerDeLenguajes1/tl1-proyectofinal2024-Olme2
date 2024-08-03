Console.Clear();
int i;
int j=0;
Dificultad.Dificultades dificultadSeleccionada = Dificultad.dificultades[0];    
int totalDificultades=Dificultad.dificultades.Count;
Console.WriteLine("¡Bienvenido a UCM fights!\n");
Thread.Sleep(3000);
Console.WriteLine("HISTORIAL DE GANADORES:\n");
Thread.Sleep(1000);
await HistorialJson.mostrarGanadores("ganadores.json");
Console.Write("\nPresiona enter para empezar");
Thread.Sleep(500);
while(true){
    Console.Write("\r                           ");
    if(Console.KeyAvailable){
        var tecla=Console.ReadKey(intercept: true);
        if(tecla.Key==ConsoleKey.Enter){
            break;
        }
    }
    Thread.Sleep(500);
    Console.Write("\rPresiona enter para empezar");
    if(Console.KeyAvailable){
        var tecla=Console.ReadKey(intercept: true);
        if(tecla.Key==ConsoleKey.Enter){
            break;
        }
    }
    Thread.Sleep(500);
}
string? usuario;
do{
    Console.Clear();
    Console.Write("Escriba su nombre: ");
    usuario=Console.ReadLine();
}while(string.IsNullOrWhiteSpace(usuario));
usuario=usuario.ToUpper();
Console.Clear();
Console.WriteLine($"USUARIO: {usuario}\n");
Thread.Sleep(2000);
Console.WriteLine("Seleccione una dificultad:\n");
Thread.Sleep(1000);  
while (true){
    if(j!=0){
        Console.WriteLine("USUARIO: "+usuario);
        Console.WriteLine("\nSeleccione una dificultad:\n");  
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
Console.WriteLine($"Dificultad seleccionada: {dificultadSeleccionada}\n");
Thread.Sleep(2000);
Console.WriteLine("¡Elige a tu personaje!\n");
Thread.Sleep(1000);
while (true){
    if(j!=0){
        Console.WriteLine($"Dificultad seleccionada: {dificultadSeleccionada}\n");
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
Console.WriteLine($"Dificultad seleccionada: {dificultadSeleccionada}\n");
Console.WriteLine($"Tu personaje es: {PersonajeSeleccionado}");
Thread.Sleep(2000);
Console.WriteLine($"\nParticipantes de este torneo ({Dificultad.cantidadDeParticipantes(dificultadSeleccionada)}):\n");
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
Thread.Sleep(1000);
Torneo.presionaEnter();
Console.Clear();
Torneo.escribirFixture(Torneo.Instancia.instancias);
for (i=3;i>0;i--){
    Console.Write($"\r{i}"); 
    Thread.Sleep(1000); 
}
Console.Write("\r¡A luchar!");
Thread.Sleep(2000);
Console.Clear();
await Torneo.iniciarTorneo(Torneo.Instancia.instancias, usuario, $"{dificultadSeleccionada}");
Thread.Sleep(2000);
Console.WriteLine($"\n¡Ha terminado el torneo, gracias por jugar {usuario.ToLower()}!");
Thread.Sleep(2000);