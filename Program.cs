
using Raylib_cs;

namespace rl_pong
{
    public class Program
    {
        public static Player player = new();
        public static Ball ball = new();

        public static int screenWidth = 1200;
        public static int screenHeight = 900;

        public static void Main()
        {
            Draw.DrawGame draw = new();

            Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(0));
            Raylib.InitWindow(screenWidth, screenHeight, "Pong");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DarkGray);

                draw.DrawBall(ball);
                draw.DrawPlayer(player);

                ball.Move();
                player.Move();

                Raylib.EndDrawing();
            }
        }
    }
}