using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

public class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Speed = 10;
    public int Radius = 20;
    public int HitboxRadius = 26;
    public int Score = 0;

    public Player(int startX, int startY)
    {
        X = startX;
        Y = startY;
    }

    public void Update(int width, int height, List<Wall> walls)
    {
        int nextX = X;
        int nextY = Y;

        if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D)) { nextX += Speed; }
        if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)) { nextX -= Speed; }
        if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W)) { nextY -= Speed; }
        if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S)) { nextY += Speed; }

        if (nextX - Radius < 0) { nextX = Radius; }
        if (nextX + Radius > width) { nextX = width - Radius; }
        if (nextY - Radius < 0) { nextY = Radius + 20; }
        if (nextY + Radius > height) { nextY = height - Radius; }

        bool collisionX = false;
        foreach (Wall wal in walls)
        {
            if (Raylib.CheckCollisionCircleRec(new Vector2(nextX, Y), HitboxRadius, wal.Rectangle)) { collisionX = true; break; }
        }
        if (!collisionX) { X = nextX; }

        bool collisionY = false;
        foreach (Wall wal in walls)
        {
            if (Raylib.CheckCollisionCircleRec(new Vector2(X, nextY), HitboxRadius, wal.Rectangle)) { collisionY = true; break; }
        }
        if (!collisionY) { Y = nextY; }
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void ResetPosition(int startX, int startY)
    {
        X = startX;
        Y = startY;
    }

    public void Draw()
    {
        int playerSize = 55;
        Rectangle sourcePlayer = new Rectangle(0, 0, SpriteManager.playerSprite.Width, SpriteManager.playerSprite.Height);
        Rectangle destPlayer = new Rectangle(X, Y, playerSize, playerSize);
        Vector2 originPlayer = new Vector2(playerSize / 2, playerSize / 2);

        Raylib.DrawTexturePro(SpriteManager.playerSprite, sourcePlayer, destPlayer, originPlayer, 0f, Color.White);
    }
}