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
                Color.Yellow
                );
        }

    }
}
