using System;
using Raylib_cs;
using rl_pong;


namespace Draw
{
    public class DrawGame
    {

        public void DrawPlayer(Player player)
        {
            Raylib.DrawRectangleRec(player.GetRectangle(), Color.White);
        }

        public void DrawBall(Ball ball)
        {
            Raylib.DrawCircleV(
                ball.GetPos(),
                ball.GetRadius(),
                Color.Green
                );
        }

        public void DrawHUD()
        {
            Raylib.DrawRectangle(
                0,
                0,
                10,
                Program.screenHeight,
                Color.Green
                );

            Raylib.DrawRectangle(
                Program.screenWidth - 10,
                0,
                10,
                Program.screenHeight,
                Color.Green);
        }


    }
}
