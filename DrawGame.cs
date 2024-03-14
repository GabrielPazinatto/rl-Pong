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


            Raylib.DrawRectangle(
                (Program.screenWidth / 2) - 5,
                0,
                5,
                Program.screenHeight,
                new(255, 255, 255, 100)
                );

            String text = Program.player.GetPoints().ToString();
            int fontSize = 100;

            Raylib.DrawText(
                text,
                Program.screenWidth/4 - Raylib.MeasureText(text, fontSize),
                30,
                fontSize,
                new(255, 255, 255, 100)
            );

            text = Program.cpu.GetPoints().ToString();

            Raylib.DrawText(
                text,
                3 * Program.screenWidth / 4 - Raylib.MeasureText(text, fontSize),
                30,
                fontSize,
                new(255, 255, 255, 100)
            );
        }

        public void DrawControls()
        {




        }


    }
}
