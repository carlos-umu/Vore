/*
TODO: SEGUIR POR AQUI
*/

using System.Numerics;
using Raylib_cs;

public class GameScreen
{
   /*Sprites and Textures*/
   private static Texture2D playerSprite;
   private static Texture2D wallSprite;
   private static Texture2D foodSprite;
   private static bool recursosCargados = false;

   /*Player Attributes*/
   private static int playerX = 150;
   private static int playerY = 150;
   private static int playerSpeed = 5;
   private static int radius = 20;
   private static int hitboxRadius = 12;


   /*Food Attributes*/
   private static int score = 0;
   private static int scorePerFood = 10;
   private static int maxScore = 40;
   private static int foodRadius = 20;
   private static int maxFood = 50;
   private static List<Vector2> foodPositions = new List<Vector2>();

   /*Enemy Attributes*/
   private static int enemySpeed = 3;
   private static int enemyRadius = 20;
   private static int enemyHitboxRadius = 14;
   private static int maxEnemy = 1;
   private static List<Vector2> enemyPositions = new List<Vector2>();

   /*Walls Attributes*/
   private static List<Rectangle> walls = new List<Rectangle>();
   private static List<Vector2> whiteSpaces = new List<Vector2>();

   /*Other Attributes*/
   private static Random randomGenerator = new Random();
   private static bool firstTime = true;
   private static int nivelActual = 1;

   public static GameState Update(int width, int height)
   {
      if (!recursosCargados)
      {
         playerSprite = Raylib.LoadTexture("../../../Assets/FirstPlayer.png");
         wallSprite = Raylib.LoadTexture("../../../Assets/Wall2.png");
         foodSprite = Raylib.LoadTexture("../../../Assets/BurgerFood.png");
         recursosCargados = true;
      }

      if (firstTime)
      {
         string[][] allLevels = new string[][]
         {
             Levels.level1, Levels.level2, Levels.level3, Levels.level4, Levels.level5,
             Levels.level6, Levels.level7, Levels.level8, Levels.level9, Levels.level10
         };

         string[] currentMap = allLevels[nivelActual - 1];

         walls.Clear();
         whiteSpaces.Clear();
         int titleSize = 60;

         /*Read level Data*/
         for (int row = 0; row < currentMap.Length; row++)
         {
            for (int col = 0; col < currentMap[row].Length; col++)
            {
               char square = currentMap[row][col];
               int posX = col * titleSize;
               int posY = row * titleSize;
               if (square == 'X')
               {
                  walls.Add(new Rectangle(posX, posY, titleSize, titleSize));
               }
               else if (square == ' ')
               {
                  whiteSpaces.Add(new Vector2(posX + titleSize / 2, posY + titleSize / 2));
               }
            }
         }
         /*Generate Food Positions ONLY in white spaces*/
         for (int i = 0; i < maxFood; i++)
         {
            int gap = randomGenerator.Next(whiteSpaces.Count);
            foodPositions.Add(whiteSpaces[gap]);
         }

         /*Generate Enemy Positions ONLY in white spaces*/
         for (int i = 0; i < maxEnemy; i++)
         {
            int gap = randomGenerator.Next(whiteSpaces.Count);
            enemyPositions.Add(whiteSpaces[gap]);
         }

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
         if (Raylib.CheckCollisionCircleRec(new Vector2(nextX, playerY), hitboxRadius, wal)) { collisionX = true; break; }
      }
      if (!collisionX) { playerX = nextX; }

      bool collisionY = false;
      foreach (Rectangle wal in walls)
      {
         /*Check ActualY with FutureX*/
         if (Raylib.CheckCollisionCircleRec(new Vector2(playerX, nextY), hitboxRadius, wal)) { collisionY = true; break; }
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

            /*When food is eaten, generate a new one in a random white space*/
            int randomGap = randomGenerator.Next(whiteSpaces.Count);
            foodPositions.Add(whiteSpaces[randomGap]);
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
            nivelActual = 1;
            RestartGame();
            return GameState.GameOver;
         }
      }

      /*Win Condition*/
      if (score >= maxScore)
      {
         nivelActual++;
         if (nivelActual > 10)
         {
            nivelActual = 1;
            RestartGame();
            return GameState.Win;
         }
         else
         {
            RestartGame();
            return GameState.Playing;
         }
      }

      return GameState.Playing;

   }

   public static void Draw()
   {
      /*Food Draw Part*/
      foreach (Vector2 foodPosition in foodPositions)
      {
         int foodSize = 50; /*Force to 50X50 pixels*/

         Rectangle source = new Rectangle(0, 0, foodSprite.Width, foodSprite.Height);
         Rectangle dest = new Rectangle(foodPosition.X, foodPosition.Y, foodSize, foodSize);
         Vector2 origin = new Vector2(foodSize / 2, foodSize / 2);

         Raylib.DrawTexturePro(foodSprite, source, dest, origin, 0f, Color.White);
      }

      foreach (Vector2 enemyPosition in enemyPositions)
      {
         Raylib.DrawCircle((int)enemyPosition.X, (int)enemyPosition.Y, enemyRadius, Color.Yellow);
      }

      foreach (Rectangle wall in walls)
      {
         Raylib.DrawTexture(wallSprite, (int)wall.X, (int)wall.Y, Color.White);
      }

      /*Player Draw Part*/
      int playerSize = 60; /*Force to 60x60 pixels*/
      Rectangle sourcePlayer = new Rectangle(0, 0, playerSprite.Width, playerSprite.Height);
      Rectangle destPlayer = new Rectangle(playerX, playerY, playerSize, playerSize);
      Vector2 originPlayer = new Vector2(playerSize / 2, playerSize / 2);
      Raylib.DrawTexturePro(playerSprite, sourcePlayer, destPlayer, originPlayer, 0f, Color.White);




      Raylib.DrawText("Use Arrow Keys or WASD to Move", 100, 100, 20, Color.White);
      Raylib.DrawText($"Score: {score}", 1800, 100, 20, Color.Green);
   }

   public static void RestartGame()
   {
      firstTime = true;
      score = 0;
      playerX = 150;
      playerY = 150;
      foodPositions.Clear();
      enemyPositions.Clear();
   }

}