/*
TODO: SEGUIR POR AQUI
*/

using System.Numerics;
using Raylib_cs;

public class GameScreen 
{
   /*Player Attributes*/
   private static int playerX = 100;
   private static int playerY = 100;
   private static int playerSpeed = 20;
   private static int radius = 20;
   private static int score = 0;

   /*Food Attributes*/
   private static int foodX = 300;
   private static int foodY = 300;
   private static int foodRadius = 10;



   private static Random randomGenerator = new Random();

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

      /*Collision between player and food*/
      Vector2 playerPosition = new Vector2(playerX, playerY);
      Vector2 foodPosition = new Vector2(foodX, foodY);

      if(Raylib.CheckCollisionCircles(playerPosition, radius, foodPosition, foodRadius))
      {
         score+=10;
         /*Relocate food to a random position */
         foodX = randomGenerator.Next(foodRadius, width - radius);
         foodY = randomGenerator.Next(foodRadius, height - radius);
      }

    return GameState.Playing;
   }

   public static void Draw()
   {
    Raylib.DrawCircle(foodX, foodY, foodRadius, Color.Green);
     Raylib.DrawCircle(foodX, foodY, foodRadius, Color.Yellow);
      Raylib.DrawCircle(foodX, foodY, foodRadius, Color.Gray);
       Raylib.DrawCircle(foodX, foodY, foodRadius, Color.White);
       
    Raylib.DrawCircle(playerX, playerY, radius, Color.Red);
    Raylib.DrawText("Use Arrow Keys or WASD to Move", 100, 100, 20, Color.White);
    Raylib.DrawText($"Score: {score}", 1800, 100,20, Color.Green);
   }
    


}