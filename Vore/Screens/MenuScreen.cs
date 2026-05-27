using System;
using System.Numerics;
using Raylib_cs;

public class MenuScreen
{
    /*Only draw on screen*/
    public static void Draw(int width, int height)
    {
        Raylib.DrawRectangle(0, 0, width, height, new Color(0, 0, 0, 150));

        string title = "V O R E";
        int titleSize = 130;
        int titleX = width / 2 - Raylib.MeasureText(title, titleSize) / 2;
        int titleY = height / 4;

        /*Shadow of the title*/
        Raylib.DrawText(title, titleX + 8, titleY + 8, titleSize, Color.Black);
        Raylib.DrawText(title, titleX, titleY, titleSize, Color.Red);

        /*Play button*/
        int btnWidth = 350;
        int btnHeight = 80;
        Rectangle playButton = new Rectangle(width / 2 - btnWidth / 2, height / 2 + 50, btnWidth, btnHeight);

        Vector2 mousePos = Raylib.GetMousePosition();
        bool isHovering = Raylib.CheckCollisionPointRec(mousePos, playButton);

        Color btnColor = isHovering ? Color.Red : Color.Red;
        Color textColor = isHovering ? Color.Black : Color.White;

        Raylib.DrawRectangleRounded(playButton, 0.4f, 10, btnColor);

        string btnText = "P L A Y";
        int textW = Raylib.MeasureText(btnText, 40);
        Raylib.DrawText(btnText, (int)playButton.X + (btnWidth - textW) / 2, (int)playButton.Y + 20, 40, textColor);

        /*Pulsating "Press Enter" text*/
        double time = Raylib.GetTime();
        int alpha = (int)((Math.Sin(time * 5) + 1.0) * 127.5);
        Color pulseColor = new Color(255, 255, 255, alpha);

        string enterText = "- Press ENTER to Start -";
        int enterW = Raylib.MeasureText(enterText, 25);
        Raylib.DrawText(enterText, width / 2 - enterW / 2, (int)playButton.Y + btnHeight + 40, 25, pulseColor);

        /*Credits*/
        Raylib.DrawText("By: @9C", 30, height - 50, 20, Color.Gray);
        Raylib.DrawText("Version 1.0", width - 150, height - 50, 20, Color.Gray);
    }

    /*Only calculates the game state based on user input*/
    public static GameState Update(int width, int height)
    {
        int btnWidth = 350;
        int btnHeight = 80;
        Rectangle botonPlay = new Rectangle(width / 2 - btnWidth / 2, height / 2 + 50, btnWidth, btnHeight);

        Vector2 posicionRaton = Raylib.GetMousePosition();

        if (Raylib.CheckCollisionPointRec(posicionRaton, botonPlay))
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                return GameState.LevelSelector;
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            return GameState.LevelSelector;
        }

        return GameState.Menu;
    }
}