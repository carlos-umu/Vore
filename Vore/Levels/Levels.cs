
public class Levels
{
    // Tu nivel 1 original
    public static string[] level1 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X  XXXXX  XXXXXXXXXX  XXXXXXX  X",
        "X  X               X        X  X",
        "X  X  XXXXXX  XXX  XXXXXXX  X  X",
        "X  X       X    X           X  X",
        "X  XXXXXX  XXXXXXXXX  XXXXXXX  X",
        "X                              X",
        "X  XXXXXX  XXX  XXX  XXXXXXXX  X",
        "X       X    X    X         X  X",
        "X  XXX  X    X    X  XXXXX  X  X",
        "X    X  X    X    X  X      X  X",
        "X  XXX  XXXXXX    X  X  XXXXX  X",
        "X  X              X  X         X",
        "X  X  XXXXXXXXXXXXX  XXXXXXXX  X",
        "X  X                           X",
        "X  XXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X" // Zona UI
    };

    // Nivel 2: Los Cuadrantes
    public static string[] level2 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X  XXXXXXXXXX      XXXXXXXXXX  X",
        "X  XXXXXXXXXX      XXXXXXXXXX  X",
        "X  XX                      XX  X",
        "X  XX  XXXXXX      XXXXXX  XX  X",
        "X  XX  XXXXXX      XXXXXX  XX  X",
        "X                              X",
        "X                              X",
        "X  XX  XXXXXX      XXXXXX  XX  X",
        "X  XX  XXXXXX      XXXXXX  XX  X",
        "X  XX                      XX  X",
        "X  XXXXXXXXXX      XXXXXXXXXX  X",
        "X  XXXXXXXXXX      XXXXXXXXXX  X",
        "X                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };

    // Nivel 3: La Espiral (Cuidado con los atascos)
    public static string[] level3 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X      XXXXXXXXXXXXXXXXXXXXXX  X",
        "X  X                        X  X",
        "X  X  XXXXXXXXXXXXXXXXXXXX  X  X",
        "X  X  X                  X  X  X",
        "X  X  X  XXXXXXXXXXXXXX  X  X  X",
        "X  X  X  X            X  X  X  X",
        "X  X  X  X  XXXXXXXX  X  X  X  X",
        "X  X  X  X         X  X  X  X  X",
        "X  X  X  XXXXXXXXXXX  X  X  X  X",
        "X  X  X               X  X  X  X",
        "X  X  XXXXXXXXXXXXXXXXX  X  X  X",
        "X  X                     X     X",
        "X  XXXXXXXXXXXXXXXXXXXXXXXXX   X",
        "X                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };

    // Nivel 4: Pasillos Horizontales
    public static string[] level4 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X   XXXXXXXXXXXXXXXXXXXXXXXXXX X",
        "X   X                          X",
        "X XXXXXXXXXXXXXXXXXXXXXXXXXX   X",
        "X X                            X",
        "X   XXXXXXXXXXXXXXXXXXXXXXXXXX X",
        "X   X                          X",
        "X XXXXXXXXXXXXXXXXXXXXXXXXXX   X",
        "X X                            X",
        "X   XXXXXXXXXXXXXXXXXXXXXXXXXX X",
        "X   X                          X",
        "X XXXXXXXXXXXXXXXXXXXXXXXXXX   X",
        "X X                            X",
        "X   XXXXXXXXXXXXXXXXXXXXXXXXXX X",
        "X                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };

    // Nivel 5: La Ciudad (Bloques Pequeños)
    public static string[] level5 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X                              X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X                              X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X                              X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X                              X",
        "X   XXXX  XXXX  XXXX  XXXX     X",
        "X                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };

    // Nivel 6: La Fortaleza Concentrica
    public static string[] level6 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X   XXXXXXXXXXXXXXXXXXXXXXXX   X",
        "X   X                      X   X",
        "X   X   XXXXXXXXXXXXXXXX   X   X",
        "X   X   X              X   X   X",
        "X   X   X   XXXXXXXX   X   X   X",
        "X   X   X   X      X   X   X   X",
        "X   X   X   X      X   X   X   X",
        "X   X   X   X      X   X   X   X",
        "X   X   X   XXXXXXXX   X   X   X",
        "X   X   X              X   X   X",
        "X   X   XXXXXXXXXXXXXXXX   X   X",
        "X   X                      X   X",
        "X   XXXXXXXXXXXXXXXXXXXXXXXX   X",
        "X                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };

    // Nivel 7: Arena de Combate (Mucho espacio abierto)
    public static string[] level7 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X  X                        X  X",
        "X                              X",
        "X      X                X      X",
        "X                              X",
        "X          X        X          X",
        "X                              X",
        "X              XX              X",
        "X              XX              X",
        "X                              X",
        "X          X        X          X",
        "X                              X",
        "X      X                X      X",
        "X                              X",
        "X  X                        X  X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };

    // Nivel 8: Diamantes y Diagonales
    public static string[] level8 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X     XX       XX       XX     X",
        "X    XXXX     XXXX     XXXX    X",
        "X   XX  XX   XX  XX   XX  XX   X",
        "X  XX    XX XX    XX XX    XX  X",
        "X XX      XXX      XXX      XX X",
        "X XX      XXX      XXX      XX X",
        "X  XX    XX XX    XX XX    XX  X",
        "X   XX  XX   XX  XX   XX  XX   X",
        "X    XXXX     XXXX     XXXX    X",
        "X     XX       XX       XX     X",
        "X    XXXX     XXXX     XXXX    X",
        "X   XX  XX   XX  XX   XX  XX   X",
        "X  XX    XX XX    XX XX    XX  X",
        "X                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };

    // Nivel 9: Pasillos Verticales (Serpiente)
    public static string[] level9 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X  X   XXXX   XXXX   XXXX   XX X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  X   X  X   X  X   X  X   X  X",
        "X  XXXXX  XXXXX  XXXXX  XXXXX  X",
        "X                              X",
        "X                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };

    // Nivel 10: El Laberinto Final (Caótico)
    public static string[] level10 = new string[]
    {
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X",
        "X  XXX  XXXXX  XXX  XXXXX  XXX X",
        "X  X    X      X    X        X X",
        "X  X  XXX  XXXXX  XXX  XXXXXXX X",
        "X  X  X    X      X    X       X",
        "X  X  X  XXX  XXXXX  XXX  XXXX X",
        "X     X  X    X      X    X    X",
        "X  XXXX  X  XXX  XXXXX  XXX  X X",
        "X  X     X  X    X      X    X X",
        "X  X  XXXX  X  XXX  XXXXX  XXX X",
        "X  X  X     X  X    X      X   X",
        "X  X  X  XXXX  X  XXX  XXXXX  XX",
        "X  X  X  X     X  X    X       X",
        "X  X  X  X  XXXX  X  XXX  XXXX X",
        "X                              X",
        "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        "X                              X"
    };
}