
using System.Numerics;
using Raylib_cs;

public class Food
{
    /*Food Attributes*/
    public Vector2 Position { get; private set; }
    public int Radius { get; private set; }

    public Food(Vector2 pos, int radius = 20)
    {
        Position = pos;
        Radius = radius;
    }

    public void Draw()
    {
        int foodSize = 50; /*Force to 50X50 pixels*/

        Rectangle source = new Rectangle(0, 0, SpriteManager.foodSprite.Width, SpriteManager.foodSprite.Height);
        Rectangle dest = new Rectangle((int)Position.X, (int)Position.Y, foodSize, foodSize);
        Vector2 origin = new Vector2(foodSize / 2, foodSize / 2);
        Raylib.DrawTexturePro(SpriteManager.foodSprite, source, dest, origin, 0f, Color.White);
    }
}