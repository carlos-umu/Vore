using System.Numerics;
using Raylib_cs;

public class Wall
{
    public Rectangle Rectangle { get; private set; }

    public Wall(int x, int y, int width, int height)
    {
        Rectangle = new Rectangle(x, y, width, height);
    }

    public void Draw()
    {
        Rectangle sourceWall = new Rectangle(0, 0, SpriteManager.wallSprite.Width, SpriteManager.wallSprite.Height);
        Rectangle destWall = new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
        Vector2 originWall = new Vector2(0, 0);
        Raylib.DrawTexturePro(SpriteManager.wallSprite, sourceWall, destWall, originWall, 0f, Color.White);
    }

}