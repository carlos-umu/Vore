/*
TODO: SEGUIR POR AQUI
*/

using Raylib_cs;

public class GameScreen 
{
   /*Player Attributes*/
   private static int playerX = 100;
   private static int playerY = 100;
   private static int playerSpeed = 50;
   private static int radius = 20;


   /*Lee de teclado y mover el jugador*/
   public static GameState Update(int width, int height)
   {
      /*Right and Left Movement inside the window*/
      if(Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D)){ playerX += playerSpeed;}
      if(Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)){ playerX -= playerSpeed;}
      /*Up and Down Movement inside the window*/
      if(Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W)){ playerY -= playerSpeed;}
      if(Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S)){ playerY += playerSpeed;}

      /*Prevent player from going outside the window*/
      if(playerX -radius < 0){ playerX = radius;}
      if(playerX +radius > width){ playerX = width - radius;}
      /*TODO CHAPUZA MOCKEADO EL 1O*/
      if(playerY - radius < 0){ playerY = radius + 20;}
      if(playerY + radius > height){ playerY = height - radius;}


    return GameState.Playing;
   }

   public static void Draw()
   {
    Raylib.DrawCircle(playerX, playerY, radius, Color.Red);
    Raylib.DrawText("Use Arrow Keys or WASD to Move", 100, 100, 20, Color.White);
   }
    


}