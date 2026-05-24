/*
TODO: SEGUIR POR AQUI
*/

using Raylib_cs;

public class GameScreen 
{
   public static GameState Update()
   {
    // Aquí iría la lógica del juego, como mover al personaje, detectar colisiones, etc.
    // Por ahora, simplemente vamos a regresar el estado de juego actual.
    return GameState.Playing;
   }

   public static void Draw()
   {
    // Aquí iría el código para dibujar el juego en la pantalla.
    // Por ahora, simplemente vamos a limpiar la pantalla con un color de fondo.
    Raylib.ClearBackground(Color.DarkBlue);
   }
    


}