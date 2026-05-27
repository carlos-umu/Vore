
using Raylib_cs;

public class SpriteManager
{
    /*Sprites and Textures*/
    public static Texture2D playerSprite;
    public static Texture2D wallSprite;
    public static Texture2D foodSprite;
    public static Texture2D enemySprite;

    public static bool isLoaded = false;

    public static void LoadSprites()
    {
        if (!isLoaded)
        {
            playerSprite = Raylib.LoadTexture("../../../Assets/ThirdPlayer.png");
            wallSprite = Raylib.LoadTexture("../../../Assets/Wall3.png");
            foodSprite = Raylib.LoadTexture("../../../Assets/BlueFood.png");
            enemySprite = Raylib.LoadTexture("../../../Assets/EnemyPlayer.png");
            isLoaded = true;
        }
    }

    public static void UnloadSprites()
    {
        if (isLoaded)
        {
            Raylib.UnloadTexture(playerSprite);
            Raylib.UnloadTexture(wallSprite);
            Raylib.UnloadTexture(foodSprite);
            Raylib.UnloadTexture(enemySprite);
            isLoaded = false;
        }
    }
}