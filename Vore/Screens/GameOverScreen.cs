using Raylib_cs;

public class GameOverScreen 
{

     public static GameState Update(int width, int height)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            return GameState.Menu;
        }        
        return GameState.GameOver;
       
    }

    public static void Draw( int width, int height)
    {
        
        int titleY = height / 2 - 15;     
        int titleX = width / 2- Raylib.MeasureText("GAME OVER", 30) / 2;
        Raylib.DrawText("GAME OVER", titleX, titleY, 30, Color.Red);
        Raylib.DrawText("Press Enter to Return to Menu", titleX - 50, titleY + 80, 20, Color.White);
        Raylib.DrawText("By: @9C", 1800, 990, 20, Color.Red);
    }
}
    
   