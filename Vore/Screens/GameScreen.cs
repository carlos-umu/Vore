using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

public class GameScreen
{
   /*Game Attributes*/
   private static Player player = new Player(150, 150);
   private static List<Food> foods = new List<Food>();
   private static List<Enemy> enemies = new List<Enemy>();
   private static List<Wall> walls = new List<Wall>();
   private static List<Vector2> whiteSpaces = new List<Vector2>();

   private static Random randomGenerator = new Random();
   private static bool firstTime = true;
   private static int nivelActual = 1;

   /*Game Settings*/
   private static int scorePerFood = 20;
   private static int maxScore = 100;
   private static int maxFood = 50;
   private static int maxEnemy = 5;

   public static GameState Update(int width, int height)
   {
      SpriteManager.LoadSprites();

      /*Generation of Level*/
      if (firstTime)
      {
         string[] currentMap = Levels.AllLevels[nivelActual - 1];

         walls.Clear();
         whiteSpaces.Clear();
         foods.Clear();
         enemies.Clear();
         int titleSize = 60;

         for (int row = 0; row < currentMap.Length; row++)
         {
            for (int col = 0; col < currentMap[row].Length; col++)
            {
               char square = currentMap[row][col];
               int posX = col * titleSize;
               int posY = row * titleSize;

               if (square == 'X') { walls.Add(new Wall(posX, posY, titleSize, titleSize)); }
               else if (square == ' ') { whiteSpaces.Add(new Vector2(posX + titleSize / 2, posY + titleSize / 2)); }
            }
         }

         for (int i = 0; i < maxFood; i++)
         {
            int gap = randomGenerator.Next(whiteSpaces.Count);
            foods.Add(new Food(whiteSpaces[gap]));
         }

         for (int i = 0; i < maxEnemy; i++)
         {
            int gap = randomGenerator.Next(whiteSpaces.Count);
            enemies.Add(new Enemy(whiteSpaces[gap].X, whiteSpaces[gap].Y));
         }

         firstTime = false;
      }

      player.Update(width, height, walls);

      /*Food Collision*/
      Vector2 playerPos = new Vector2(player.X, player.Y);
      for (int i = foods.Count - 1; i >= 0; i--)
      {
         if (Raylib.CheckCollisionCircles(playerPos, player.Radius, foods[i].Position, foods[i].Radius))
         {
            player.AddScore(scorePerFood);
            foods.RemoveAt(i);

            int randomGap = randomGenerator.Next(whiteSpaces.Count);
            foods.Add(new Food(whiteSpaces[randomGap]));
         }
      }

      /*Enemy Logic and Fatal Collision*/
      foreach (Enemy enemy in enemies)
      {
         enemy.Update(player, walls);

         if (Raylib.CheckCollisionCircles(playerPos, player.Radius, new Vector2(enemy.X, enemy.Y), enemy.Radius))
         {
            RestartGame();
            return GameState.GameOver;
         }
      }

      /*Victory Condition*/
      if (player.Score >= maxScore)
      {
         nivelActual++;
         return GameState.LevelSelector;
      }

      return GameState.Playing;
   }

   public static void Draw()
   {
      foreach (Food food in foods) { food.Draw(); }
      foreach (Enemy enemy in enemies) { enemy.Draw(); }
      foreach (Wall wall in walls) { wall.Draw(); }
      player.Draw();

      Raylib.DrawText("Use Arrow Keys or WASD to Move", 100, 100, 20, Color.White);
      Raylib.DrawText($"Score: {player.Score}", 1800, 100, 20, Color.Green);
   }

   public static void RestartGame()
   {
      firstTime = true;
      player.Score = 0;
      player.ResetPosition(150, 150);
      foods.Clear();
      enemies.Clear();
   }
   public static void SetNivel(int nivel)
   {
      nivelActual = nivel;
      RestartGame();
   }
}