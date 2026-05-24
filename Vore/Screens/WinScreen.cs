using Raylib_cs;

public class WinScreen 
{

     public static GameState Update(int width, int height)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            return GameState.Menu;
        }        
        return GameState.Win;
       
    }

    public static void Draw( int width, int height)
    {
        
        int titleY = height / 2 - 15;     
        int titleX = width / 2- Raylib.MeasureText("WIN", 30) / 2;
        Raylib.DrawText("WIN", titleX, titleY, 30, Color.Red);
        Raylib.DrawText("Press Enter to Return to Menu", titleX - 50, titleY + 80, 20, Color.White);
        Raylib.DrawText("By: @9C", 1800, 990, 20, Color.Red);
    }
    
   
}