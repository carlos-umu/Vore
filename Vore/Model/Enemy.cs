
using System.Numerics;
using Raylib_cs;

public class Enemy
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Radius = 20;
    public float Speed = 3;
    public float HitboxRadius = 14;

    public Enemy(float startX, float startY)
    {
        X = startX;
        Y = startY;
    }

    public void Update(Player player, List<Wall> walls)
    {
        float nextX = X;
        float nextY = Y;

        if (X < player.X) { nextX += Speed; }
        if (X > player.X) { nextX -= Speed; }
        if (Y < player.Y) { nextY += Speed; }
        if (Y > player.Y) { nextY -= Speed; }

        bool colX = false;
        foreach (Wall wal in walls)
        {
            if (Raylib.CheckCollisionCircleRec(new Vector2(nextX, Y), HitboxRadius, wal.Rectangle)) { colX = true; break; }
        }
        if (!colX) { X = nextX; }

        bool colY = false;
        foreach (Wall wal in walls)
        {
            if (Raylib.CheckCollisionCircleRec(new Vector2(X, nextY), HitboxRadius, wal.Rectangle)) { colY = true; break; }
        }
        if (!colY) { Y = nextY; }
    }

    public void Draw()
    {
        int enemySize = 55; /*Force to 55X55 pixels*/

        Rectangle source = new Rectangle(0, 0, SpriteManager.enemySprite.Width, SpriteManager.enemySprite.Height);
        Rectangle dest = new Rectangle((int)X, (int)Y, enemySize, enemySize);
        Vector2 origin = new Vector2(enemySize / 2, enemySize / 2);
        Raylib.DrawTexturePro(SpriteManager.enemySprite, source, dest, origin, 0f, Color.White);
    }
}