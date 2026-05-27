
using System.Numerics;
using Raylib_cs;

public class MenuScreen
{
    /*Only draw on screen*/
    public static void Draw(int width, int height)
    {

        int titleY = height / 2 - 15;
        Rectangle PlayButton = new Rectangle(width / 2 - 100, titleY + 80, 200, 50);

        int titleX = width / 2 - Raylib.MeasureText("Vore", 30) / 2;
        Raylib.DrawText("Vore", titleX, titleY, 30, Color.Red);

        /*Button Hover*/
        Vector2 mousePosition = Raylib.GetMousePosition();
        Color buttonColor = Color.Red;

        if (Raylib.CheckCollisionPointRec(mousePosition, PlayButton))
        {
            buttonColor = Color.Orange;
        }

        Raylib.DrawRectangleRec(PlayButton, buttonColor);
        int playWidth = Raylib.MeasureText("PLAY", 20);
        Raylib.DrawText("PLAY", width / 2 - playWidth / 2, titleY + 95, 20, Color.White);


        Raylib.DrawText("By: @9C", 1800, 990, 20, Color.Red);

    }

    /*Only calculates the game state based on user input*/
    public static GameState Update(int width, int height)
    {
        int titleY = height / 2 - 15;
        /*Area of the play button invisible*/
        Rectangle botonPlay = new Rectangle(width / 2 - 100, titleY + 80, 200, 50);
        /*Coordinates of the mouse*/
        Vector2 posicionRaton = Raylib.GetMousePosition();

        /*Logic of the pressed button*/
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