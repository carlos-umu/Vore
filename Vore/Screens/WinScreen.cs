using Raylib_cs;

public class WinScreen
{

    public static GameState Update(int width, int height)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            return GameState.LevelSelector;
        }
        return GameState.Win;

    }

    public static void Draw(int width, int height)
    {

        Raylib.DrawRectangle(0, 0, width, height, new Color(0, 0, 0, 200));

        string title = "L E V E L   C O M P L E T E D";
        int titleSize = 100;
        int titleX = width / 2 - Raylib.MeasureText(title, titleSize) / 2;
        int titleY = height / 2 - 100;

        Raylib.DrawText(title, titleX + 6, titleY + 6, titleSize, Color.Black);
        Raylib.DrawText(title, titleX, titleY, titleSize, Color.Green);

        double time = Raylib.GetTime();
        int alpha = (int)((Math.Sin(time * 6) + 1.0) * 127.5);
        Color pulseColor = new Color(255, 255, 255, alpha);

        string enterText = "- Press ENTER to continue -";
        int enterSize = 30;
        int enterX = width / 2 - Raylib.MeasureText(enterText, enterSize) / 2;
        Raylib.DrawText(enterText, enterX, titleY + 150, enterSize, pulseColor);


        Raylib.DrawText("By: @9C", 30, height - 50, 20, Color.Gray);
    }


}