global using Raylib_CsLo;
global using System.Numerics;

global using static Raylib_CsLo.Raylib;
global using static Raylib_CsLo.RayGui;
using System.Security.Authentication.ExtendedProtection;
using System.Linq.Expressions;
using Draw;

namespace rl_pong
{
    public class Program
    {
        public static LocalPlayer player = new(); 
        public static CPUPlayer cpu = new();
        public static Ball ball = new();
        public static Draw.DrawGame draw = new();
        public static GameEvents game = new();

        public readonly static int screenWidth = 400;
        public readonly static int screenHeight = 300;
        public readonly static int refreshRate = 60;

        public static void Main()
        {


            Raylib.SetTargetFPS(60);                     // sets FPS
            Raylib.InitWindow(Program.screenWidth, Program.screenHeight, "Pong");     // 


            while (!Raylib.WindowShouldClose() && !IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                draw.DrawMainMenu();
            }

            /*-------------------
                GAME STARTS HERE
            ---------------------*/

            game.CheckResetGame(true);

            while (!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();
                Raylib.ClearBackground(DARKGRAY);

                /*-------------------
                        DRAWING
                --------------------*/

                draw.DrawBall(Program.ball);
                draw.DrawPlayer(Program.player);
                draw.DrawPlayer(Program.cpu);
                draw.DrawHUD();
                draw.DrawControls();

                /*-------------------
                        UPDATING
                --------------------*/

                game.CheckIfScored();
                game.CheckResetGame();
                game.CheckPauseGame();
                Program.ball.Move();
                Program.player.Move();
                Program.cpu.Move();
                Program.ball.DrawVectors();

                Raylib.EndDrawing();
            }
            
        }
    }
}