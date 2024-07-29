Console.WriteLine("¡Bienvenido a UCM fights!");
Console.WriteLine("HISTORIAL DE GANADORES:");
//CODIGO DE HISTORIAL
Console.WriteLine("¡Elige a tu personaje!");
int i=1;
foreach(string nombre in Datos.NombresPersonajes){
    Console.Write($"{i}:{nombre} \t");
    if(i%5==0){
        Console.Write("\n");
    }
    i++;
}
int eleccion=1;
do{
    if(eleccion<1 || eleccion>26){
        Console.WriteLine("Escriba una opcion valida");
        eleccion=int.Parse(Console.ReadLine);
    }
}while(eleccion<1 || eleccion>26);