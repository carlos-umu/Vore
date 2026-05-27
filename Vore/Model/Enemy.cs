
using System.Numerics;
using Raylib_cs;

public class Enemy
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Radius = 20;
    public float Speed = 3;
    public float HitboxRadius = 14;

    private Vector2 direction;
    private float timer = 0;
    private Random rnd = new Random();

    public Enemy(float startX, float startY)
    {
        X = startX;
        Y = startY;
    }

    public void Update(Player player, List<Wall> walls)
    {
        /*Enemy Detection Radius */
        float detectionRadius = 800f;
        float distanceToPlayer = Vector2.Distance(new Vector2(X, Y), new Vector2(player.X, player.Y));

        Vector2 targetDirection;

        if (distanceToPlayer < detectionRadius && !IsWallBetween(player, walls))
        {
            /*Player Detection run to player*/
            targetDirection = Vector2.Normalize(new Vector2(player.X - X, player.Y - Y));
        }
        else
        {
            if (direction == Vector2.Zero) direction = new Vector2(1, 0); // Inicio
            targetDirection = direction;
        }

        float nextX = X + (targetDirection.X * Speed);
        float nextY = Y + (targetDirection.Y * Speed);

        bool wallCollision = false;
        foreach (Wall wal in walls)
        {
            if (Raylib.CheckCollisionCircleRec(new Vector2(nextX, nextY), HitboxRadius, wal.Rectangle))
            {
                wallCollision = true;
                break;
            }
        }

        if (!wallCollision)
        {
            X = nextX;
            Y = nextY;
            direction = targetDirection;
        }
        else
        {
            direction = GetRandomDirection();
        }
    }

    private bool IsWallBetween(Player player, List<Wall> walls)
    {
        Vector2 start = new Vector2(X, Y);
        Vector2 end = new Vector2(player.X, player.Y);
        Vector2 collisionPoint = new Vector2();

        foreach (Wall wall in walls)
        {
            Rectangle r = wall.Rectangle;

            if (Raylib.CheckCollisionLines(start, end, new Vector2(r.X, r.Y), new Vector2(r.X + r.Width, r.Y), ref collisionPoint) ||
                Raylib.CheckCollisionLines(start, end, new Vector2(r.X + r.Width, r.Y), new Vector2(r.X + r.Width, r.Y + r.Height), ref collisionPoint) ||
                Raylib.CheckCollisionLines(start, end, new Vector2(r.X + r.Width, r.Y + r.Height), new Vector2(r.X, r.Y + r.Height), ref collisionPoint) ||
                Raylib.CheckCollisionLines(start, end, new Vector2(r.X, r.Y + r.Height), new Vector2(r.X, r.Y), ref collisionPoint))
            {
                return true;
            }
        }
        return false;
    }

    private Vector2 GetRandomDirection()
    {
        Random rnd = new Random();
        int r = rnd.Next(4);
        return r switch { 0 => new Vector2(1, 0), 1 => new Vector2(-1, 0), 2 => new Vector2(0, 1), _ => new Vector2(0, -1) };
    }

    public void Draw()
    {
        int enemySize = 55;

        Rectangle source = new Rectangle(0, 0, SpriteManager.enemySprite.Width, SpriteManager.enemySprite.Height);
        Rectangle dest = new Rectangle((int)X, (int)Y, enemySize, enemySize);
        Vector2 origin = new Vector2(enemySize / 2, enemySize / 2);
        Raylib.DrawTexturePro(SpriteManager.enemySprite, source, dest, origin, 0f, Color.White);
    }
}