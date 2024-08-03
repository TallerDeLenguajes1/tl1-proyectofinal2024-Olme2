# DOCUMENTACION DE PROYECTO FINAL VALENTINO OLMEDO
TEMATICA DEL JUEGO
Mi juego de consola trata de un torneo de peleas de marvel el cual dependiendo de la dificultad facil, medio o dificil, empieza desde las instancias octavos, cuartos y semifinales, respectivamente. Al iniciar el programa muestra un mensaje de bienvenida con el historial de los 10 mejores ganadores (basados en el daño hecho en una partida entera). Luego habiendo ya colocado tu nombre para luego guardarlo en el historial de jugadores, seleccionas la dificultad y el personaje. Luego se generan los personajes con la fabrica de personajes, cada uno con sus respectivas caracteristicas dependiendo del tipo de personaje que sean, dependiendo de la dificultad son: 
Facil: 1 personaje usuario y 3 npc 
Medio: 1 personaje usuario y 5 npc
Dificil: 1 personaje usuario y 7npc
El personaje usuario toma el nombre elegido, mientras que los npc son generados aleatoriamente, dependiendo del nombre que obtentan, se le asigna un tipo que ya viene asociado a ese nombre, por ejemplo ironman humano.
Luego se crean instancias para los personajes dependiendo de la dificultad, en el caso de facil se crean semifinales, enfrentando aleatoriamente a los npcs entre ellos y al personaje con un npc.
Luego se muestra el actual fixture dependiendo de las instancias que sean del torneo. Luego comienza el combate, usando la formula proporcionada por la catedra, los personajes pelean por turnos, cada "round" es un turno de los personajes, los valores de los daños varian en base a valores aleatorios de velocidad, destreza, fuerza, defensa y eficiencia del golpe. Se va mostrando la vida de los personajes en cada round y el daño que le ocaciona uno al otro hasta que uno de los dos pierda. Si se gana la el combate aparece un mensaje de victoria y se continua con enfrentamientos de "npc" que serian los personajes generados por el juego sin mostrar todo el combate, solo el ganador y los rounds. Y si por el contrario se pierde el combate aparece un mensaje de derrota, usando un insulto de una api salta un mensaje de en que instancia perdiste junto con un game over.
Si se gana la batalla al personaje se le aumenta 5 de cada caracteristica y se muestra el upgrade por pantalla, esto tambien sucede con los combates npc. 
Tambien por cada instancia se va aumentando vida a los personajes, para equilibrar y que los combates no sean tan cortos. Si se pasa la primera instancia sube de 100 a 200, si se pasa una segunda instancia de 200 a 350, y si se llega a la gran final en dificil se sube de 350 a 500.
Una vez ganado el torneo, hace las conmemoraciones correspondientes, el personaje dice un insulto y se muestran las caracteristicas con las cuales acabo ese personaje.
Luego, antes de finalizar el programa, se agrega el nombre de usuario, nombre de personaje, dificultad y daño acumulado (que seria el daño total que hizo en la partida) a modo de puntuacion, para luego tener un ranking.

APIS USADAS
Se uso una api de insultos, la cual es generada con el siguiente link "https://evilinsult.com/generate_insult.php?lang=es&type=json". Si se realiza correctamente la operacion se utiliza el insulto, sino devuelve "hijo de puta" como insulto predeterminado, asi no nos quedamos sin insulto durante el programa.

PROGRAMAS DEL PROYECTO
Apis.cs: Aqui se encuentran las clases y el metodo para usar la api
Batallas.cs: Aqui se encuentra el codigo para correr las batallas
FuncionesJson.cs: Este es el codigo para guardar y leer el historial Json de Ganadores
Personajes.cs: Todo el codigo referido a personajes, tanto caracteristicas como datos, fabrica de personajes y los nombres predeterminados con sus tipos
Torneo.cs: Aqui se encuentra toda la organizacion del torneo, es el segundo programa mas importante luego del main program.

EXPLICACION DE USO
La interfaz es muy facil de entender, asi que no hay mucho que explicar, utiliza dotnet run y juega!
