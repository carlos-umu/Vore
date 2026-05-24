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
        Raylib.SetTargetFPS(60);
        GameState currentState = GameState.Menu;

        while (!Raylib.WindowShouldClose())
        {
            if(currentState == GameState.Menu)
            {
                currentState = MenuScreen.Update(width, height);
            }
            else if (currentState == GameState.Playing)
            {
                currentState = GameScreen.Update(width, height);
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            if(currentState == GameState.Menu)
            {
                MenuScreen.Draw(width, height);
            }
            else if (currentState == GameState.Playing)
            {
                GameScreen.Draw();
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
