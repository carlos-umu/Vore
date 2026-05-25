using System.Numerics;
using Raylib_cs;

public class Launcher
{
    private static void Main(string[] args)
    {
        //Atributes of the window
        int width = 1920;
        int height = 1080;
        //int fontSize = 50;
        string title = "Vore";
        //string author = "By: @9C";


        Raylib.InitWindow(width, height, title);
        Raylib.ToggleFullscreen();
        Raylib.SetTargetFPS(60);
        GameState currentState = GameState.Menu;

        while (!Raylib.WindowShouldClose())
        {
            if (currentState == GameState.Menu)
            {
                currentState = MenuScreen.Update(width, height);
            }
            else if (currentState == GameState.Playing)
            {
                currentState = GameScreen.Update(width, height);
            }
            else if (currentState == GameState.Win)
            {
                currentState = WinScreen.Update(width, height);
            }
            else if (currentState == GameState.GameOver)
            {
                currentState = GameOverScreen.Update(width, height);
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Blue);

            /*Background Load*/
            Texture2D background = Raylib.LoadTexture("../../../Assets/Background.jpg");
            Rectangle sourceFondo = new Rectangle(0, 0, background.Width, background.Height);
            Rectangle destFondo = new Rectangle(0, 0, width, height);
            Raylib.DrawTexturePro(background, sourceFondo, destFondo, new Vector2(0, 0), 0f, Color.White);

            if (currentState == GameState.Menu)
            {
                MenuScreen.Draw(width, height);
            }
            else if (currentState == GameState.Playing)
            {
                GameScreen.Draw();
            }
            else if (currentState == GameState.Win)
            {
                WinScreen.Draw(width, height);
            }
            else if (currentState == GameState.GameOver)
            {
                GameOverScreen.Draw(width, height);
            }

            Raylib.EndDrawing();
        }


        Raylib.CloseWindow();
    }
}
