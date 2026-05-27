using Raylib_cs;
using System.Numerics;

public class LevelSelectorScreen
{
    public static GameState Update(int width, int height)
    {
        Vector2 mousePos = Raylib.GetMousePosition();

        int totalLevels = Levels.AllLevels.Length;
        int columns = 10;
        int radius = 45;
        int spacing = 30;

        int cellSize = (radius * 2) + spacing;

        int startX = (width - (columns * cellSize - spacing)) / 2 + radius;
        int startY = 300 + radius;

        for (int i = 0; i < totalLevels; i++)
        {
            int row = i / columns;
            int col = i % columns;

            Vector2 buttonCenter = new Vector2(startX + col * cellSize, startY + row * cellSize);

            if (Raylib.CheckCollisionPointCircle(mousePos, buttonCenter, radius))
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    GameScreen.SetNivel(i + 1);
                    return GameState.Playing;
                }
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Escape)) { return GameState.Menu; }

        return GameState.LevelSelector;
    }

    public static void Draw(int width, int height)
    {
        Raylib.DrawRectangle(0, 0, width, height, new Color(0, 0, 0, 150));
        string titleText = "S E L E C T   A   L E V E L";
        int titleSize = 50;
        int titleX = width / 2 - Raylib.MeasureText(titleText, titleSize) / 2;


        Raylib.DrawText(titleText, titleX + 4, 80 + 4, titleSize, Color.Black);
        Raylib.DrawText(titleText, titleX, 80, titleSize, Color.Red);
        Raylib.DrawText("ESC to exit", 50, 50, 25, Color.Gray);

        Vector2 mousePos = Raylib.GetMousePosition();
        int totalLevels = Levels.AllLevels.Length;
        int columns = 10;
        int radius = 45;
        int spacing = 30;

        int cellSize = (radius * 2) + spacing;
        int startX = (width - (columns * cellSize - spacing)) / 2 + radius;
        int startY = 300 + radius;

        for (int i = 0; i < totalLevels; i++)
        {
            int row = i / columns;
            int col = i % columns;

            Vector2 buttonCenter = new Vector2(startX + col * cellSize, startY + row * cellSize);


            bool isHovering = Raylib.CheckCollisionPointCircle(mousePos, buttonCenter, radius);

            Color btnColor = isHovering ? Color.DarkBlue : Color.Red;
            Color borderColor = isHovering ? Color.White : Color.White;
            int borderThickness = isHovering ? 4 : 2;

            Raylib.DrawCircleV(buttonCenter, radius + borderThickness, borderColor);

            Raylib.DrawCircleV(buttonCenter, radius, btnColor);

            string levelText = (i + 1).ToString();
            int textWidth = Raylib.MeasureText(levelText, 40);

            Raylib.DrawText(levelText, (int)buttonCenter.X - textWidth / 2, (int)buttonCenter.Y - 20, 40, Color.White);
        }
    }
}
