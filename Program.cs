
using Raylib_cs;

namespace rl_pong
{
    public class Program
    {
        public static LocalPlayer player = new();
        public static CPUPlayer cpu = new();

        public static Ball ball = new();

        public static int screenWidth = 1200;
        public static int screenHeight = 900;

        public static void Main()
        {
            Draw.DrawGame draw = new();

            Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(0));
            Raylib.InitWindow(Program.screenWidth, Program.screenHeight, "Pong");;

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DarkGray);

                draw.DrawBall(Program.ball);
                draw.DrawPlayer(Program.player);
                draw.DrawPlayer(Program.cpu);

                Program.ball.Move();
                Program.player.Move();
                Program.cpu.Move();

                Raylib.EndDrawing();
            }
        }
    }
}