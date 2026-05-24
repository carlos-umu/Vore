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

   /*Walls Attributes*/
   private static List<Rectangle> walls = new List<Rectangle>();

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

         walls.Clear();
         walls.Add(new Rectangle(400, 200, 50, 700));
         walls.Add(new Rectangle(1400, 200, 50, 700));
         walls.Add(new Rectangle(700, 500, 500, 50));

         firstTime = false;
      }

      /*Prevent player from going outside the window*/
      if (playerX - radius < 0) { playerX = radius; }
      if (playerX + radius > width) { playerX = width - radius; }
      /*TODO CHAPUZA MOCKEADO EL 1O*/
      if (playerY - radius < 0) { playerY = radius + 20; }
      if (playerY + radius > height) { playerY = height - radius; }


      /*Calculate next position for collision with walls*/

      int nextX = playerX;
      int nextY = playerY;

      if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D)) { nextX += playerSpeed; }
      if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)) { nextX -= playerSpeed; }
      if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W)) { nextY -= playerSpeed; }
      if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S)) { nextY += playerSpeed; }

      if (nextX - radius < 0) { nextX = radius; }
      if (nextX + radius > width) { nextX = width - radius; }
      if (nextY - radius < 0) { nextY = radius + 20; }
      if (nextY + radius > height) { nextY = height - radius; }

      bool collisionX = false;
      foreach (Rectangle wal in walls)
      {
         /*Check ActualX with FutureY*/
         if (Raylib.CheckCollisionCircleRec(new Vector2(nextX, playerY), radius, wal)) { collisionX = true; break; }
      }
      if (!collisionX) { playerX = nextX; }

      bool collisionY = false;
      foreach (Rectangle wal in walls)
      {
         /*Check ActualY with FutureX*/
         if (Raylib.CheckCollisionCircleRec(new Vector2(playerX, nextY), radius, wal)) { collisionY = true; break; }
      }
      if (!collisionY) { playerY = nextY; }



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

         float nextEnemX = enemyPosition.X;
         float nextEnemY = enemyPosition.Y;

         if (enemyPosition.X < playerX) { nextEnemX += enemySpeed; }
         if (enemyPosition.X > playerX) { nextEnemX -= enemySpeed; }
         if (enemyPosition.Y < playerY) { nextEnemY += enemySpeed; }
         if (enemyPosition.Y > playerY) { nextEnemY -= enemySpeed; }

         bool enemColX = false;
         foreach (Rectangle wal in walls)
         {
            if (Raylib.CheckCollisionCircleRec(new Vector2(nextEnemX, enemyPosition.Y), enemyRadius, wal)) { enemColX = true; break; }
         }
         if (!enemColX) { enemyPosition.X = nextEnemX; }


         bool enemColY = false;
         foreach (Rectangle wal in walls)
         {
            if (Raylib.CheckCollisionCircleRec(new Vector2(enemyPosition.X, nextEnemY), enemyRadius, wal)) { enemColY = true; break; }
         }
         if (!enemColY) { enemyPosition.Y = nextEnemY; }

         enemyPositions[i] = enemyPosition;

         /* Collision between player and enemy */
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
      foreach (Rectangle wall in walls)
      {
         Raylib.DrawRectangleRec(wall, Color.Gray);
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