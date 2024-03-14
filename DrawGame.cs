
using rl_pong;


namespace Draw
{
    public class DrawGame
    {

        public void DrawPlayer(Player player)
        {
            Raylib.DrawRectangleRec(player.GetRectangle(), WHITE);
        }

        public void DrawBall(Ball ball)
        {
            Raylib.DrawCircleV(
                ball.GetPos(),
                ball.GetRadius(),
                GREEN
                );
        }

        public void DrawHUD()
        {

            //draws green bar on the left
            Raylib.DrawRectangle(
                0,
                0,
                10,
                Program.screenHeight,
                GREEN
            );

            //draws green bar on the right
            Raylib.DrawRectangle(
                Program.screenWidth - 10,
                0,
                10,
                Program.screenHeight,
                GREEN
            );

            //draws gray bar in the middle of the screen
            Raylib.DrawRectangle(
                (Program.screenWidth / 2) - 5,
                0,
                5,
                Program.screenHeight,
                new(255, 255, 255, 100)
            );

            //draws points for the players
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

        //draws text for the controls on the bottom left
        public void DrawControls()
        {
            //draws pause key
            Raylib.DrawText(
                "Pause (p)",
                15,
                Program.screenHeight - 20,
                20,
                new(255, 255, 255, 100)
            );

            //draws Draw Vectors key
            Raylib.DrawText(
                "Draw Vectors (v)",
                15,
                Program.screenHeight - 45,
                20,
                new(255, 255, 255, 100)
            );

            //draws reset key
            Raylib.DrawText(
                "Reset (r)",
                15,
                Program.screenHeight - 70,
                20,
                new(255, 255, 255, 100)
            );
        }
    }
}
