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


   /*Food Attributes*/
   private static int score = 0;
   private static int scorePerFood = 10;
   private static int maxScore = 40;
   private static int foodRadius = 10;
   private static int maxFood = 5;
   private static List<Vector2> foodPositions = new List<Vector2>();

   /*Enemy Attributes*/
   private static int enemySpeed = 5;
   private static int enemyRadius = 20;
   private static int maxEnemy = 5;
   private static List<Vector2> enemyPositions = new List<Vector2>();


   /*Other Attributes*/
   private static Random randomGenerator = new Random();
   private static bool firstTime = true;

   public static GameState Update(int width, int height)
   {
      /*Generate Food Positions*/
      if (firstTime)
      {
         for (int i = 0; i < maxFood; i++)
         {
            int foodX = randomGenerator.Next(foodRadius, width - radius);
            int foodY = randomGenerator.Next(foodRadius, height - radius);
            foodPositions.Add(new Vector2(foodX, foodY));
         }

         for (int i = 0; i < maxEnemy; i++)
         {
            int enemyX = randomGenerator.Next(enemyRadius, width - enemyRadius);
            int enemyY = randomGenerator.Next(enemyRadius, height - enemyRadius);
            enemyPositions.Add(new Vector2(enemyX, enemyY));
         }

         firstTime = false;
      }


      /*Right and Left Movement inside the window*/
      if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D)) { playerX += playerSpeed; }
      if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)) { playerX -= playerSpeed; }
      /*Up and Down Movement inside the window*/
      if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W)) { playerY -= playerSpeed; }
      if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S)) { playerY += playerSpeed; }

      /*Prevent player from going outside the window*/
      if (playerX - radius < 0) { playerX = radius; }
      if (playerX + radius > width) { playerX = width - radius; }
      /*TODO CHAPUZA MOCKEADO EL 1O*/
      if (playerY - radius < 0) { playerY = radius + 20; }
      if (playerY + radius > height) { playerY = height - radius; }

      /*Collision between player and food*/
      Vector2 playerPosition = new Vector2(playerX, playerY);

      for (int i = foodPositions.Count - 1; i >= 0; i--)
      {
         if (Raylib.CheckCollisionCircles(playerPosition, radius, foodPositions[i], foodRadius))
         {
            score += scorePerFood;
            foodPositions.RemoveAt(i);

            int randomX = randomGenerator.Next(foodRadius, width - radius);
            int randomY = randomGenerator.Next(foodRadius, height - radius);
            foodPositions.Add(new Vector2(randomX, randomY));
         }
      }

      /*Enemy Movement*/
      for (int i = 0; i < enemyPositions.Count; i++)
      {
         Vector2 enemyPosition = enemyPositions[i];
         if (enemyPosition.X < playerX) { enemyPosition.X += enemySpeed; }
         if (enemyPosition.X > playerX) { enemyPosition.X -= enemySpeed; }
         if (enemyPosition.Y < playerY) { enemyPosition.Y += enemySpeed; }
         if (enemyPosition.Y > playerY) { enemyPosition.Y -= enemySpeed; }
         enemyPositions[i] = enemyPosition;

         if (Raylib.CheckCollisionCircles(playerPosition, radius, enemyPosition, enemyRadius))
         {
            RestartGame();
            return GameState.GameOver;
         }
      }

      /*Collision between player and enemy*/
      for (int i = 0; i < enemyPositions.Count; i++)
      {
         Vector2 enemyPosition = enemyPositions[i];
         if (Raylib.CheckCollisionCircles(playerPosition, radius, enemyPosition, enemyRadius))
         {
            RestartGame();
            return GameState.GameOver;
         }
      }


      /*Win Condition*/
      if (score >= maxScore)
      {
         RestartGame();
         return GameState.Win;
      }

      return GameState.Playing;
   }

   public static void Draw()
   {

      foreach (Vector2 foodPosition in foodPositions)
      {
         Raylib.DrawCircle((int)foodPosition.X, (int)foodPosition.Y, foodRadius, Color.Green);
      }
      foreach (Vector2 enemyPosition in enemyPositions)
      {
         Raylib.DrawCircle((int)enemyPosition.X, (int)enemyPosition.Y, enemyRadius, Color.Yellow);
      }

      Raylib.DrawCircle(playerX, playerY, radius, Color.Red);
      Raylib.DrawText("Use Arrow Keys or WASD to Move", 100, 100, 20, Color.White);
      Raylib.DrawText($"Score: {score}", 1800, 100, 20, Color.Green);
   }

   public static void RestartGame()
   {
      firstTime = true;
      score = 0;
      playerX = 100;
      playerY = 100;
      foodPositions.Clear();
      enemyPositions.Clear();
   }

}