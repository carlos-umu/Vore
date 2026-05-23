using Raylib_cs;

internal class Launcher
{
    private static void Main(string[] args)
    {
        //Atributes of the window
        int width = 1920;
        int height = 1080;
        int fontSize = 50;
        string title = "Vore";
        string author = "By: @9C";
        

        Rectangle playButton = new Rectangle(width / 2 - 150, height / 2 + 100, 300, 100);
        bool startGame = false;

        Raylib.InitWindow(width, height, title);
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawText(title, width / 2 - Raylib.MeasureText(title, fontSize) / 2, height / 2 - fontSize / 2, fontSize, Color.Red);
            Raylib.DrawText(author, 1800, 980, 10, Color.Red);

            if (DrawButton(playButton, "JUGAR"))
            {
                startGame = true;
                // Aquí puedes iniciar tu lógica de juego real o cambiar de escena.
            }

            if (startGame)
            {
                Raylib.DrawText("¡Comenzó el juego!", 50, 50, 30, Color.GREEN);
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private static bool DrawButton(Rectangle rect, string text)
    {
        bool hover = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rect);
        Color fill = hover ? Color.DARKGRAY : Color.GRAY;

        Raylib.DrawRectangleRec(rect, fill);
        Raylib.DrawRectangleLinesEx(rect, 4, Color.WHITE);

        int buttonFontSize = 40;
        int textWidth = Raylib.MeasureText(text, buttonFontSize);
        Raylib.DrawText(text, (int)(rect.x + rect.width / 2 - textWidth / 2), (int)(rect.y + rect.height / 2 - buttonFontSize / 2), buttonFontSize, Color.WHITE);

        return hover && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);
    }
}