using Raylib_cs;
using System.Numerics;

public class LevelSelectorScreen
{
    public static GameState Update(int width, int height)
    {
        Vector2 mousePos = Raylib.GetMousePosition();

        int totalLevels = Levels.AllLevels.Length;
        int columns = 5;
        int buttonSize = 100;
        int spacing = 30;

        int startX = (width - (columns * buttonSize + (columns - 1) * spacing)) / 2;
        int startY = 300;

        for (int i = 0; i < totalLevels; i++)
        {
            int row = i / columns;
            int col = i % columns;

            Rectangle buttonRec = new Rectangle(
                startX + col * (buttonSize + spacing),
                startY + row * (buttonSize + spacing),
                buttonSize, buttonSize
            );

            if (Raylib.CheckCollisionPointRec(mousePos, buttonRec))
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
        Raylib.DrawText("SELECCIONA UN NIVEL", width / 2 - 250, 100, 50, Color.Gold);
        Raylib.DrawText("Pulsa ESC para volver", 50, 50, 20, Color.White);

        Vector2 mousePos = Raylib.GetMousePosition();
        int totalLevels = Levels.AllLevels.Length;
        int columns = 5;
        int buttonSize = 100;
        int spacing = 30;

        int startX = (width - (columns * buttonSize + (columns - 1) * spacing)) / 2;
        int startY = 300;

        for (int i = 0; i < totalLevels; i++)
        {
            int row = i / columns;
            int col = i % columns;

            Rectangle buttonRec = new Rectangle(
                startX + col * (buttonSize + spacing),
                startY + row * (buttonSize + spacing),
                buttonSize, buttonSize
            );

            Color btnColor = Raylib.CheckCollisionPointRec(mousePos, buttonRec) ? Color.DarkBlue : Color.Blue;

            Raylib.DrawRectangleRec(buttonRec, btnColor);
            Raylib.DrawRectangleLinesEx(buttonRec, 4, Color.White);

            string levelText = (i + 1).ToString();
            int textWidth = Raylib.MeasureText(levelText, 40);
            Raylib.DrawText(levelText, (int)buttonRec.X + (buttonSize - textWidth) / 2, (int)buttonRec.Y + 30, 40, Color.White);
        }
    }
}