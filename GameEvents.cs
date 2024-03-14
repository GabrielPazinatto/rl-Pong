
using rl_pong;

public class GameEvents
{
    private bool paused = false;

    private void ResetBall()
    {

        Program.ball.SetDirection(-1, 0);

        Program.ball.SetPos(
            Program.screenWidth / 2,
            Program.screenHeight/2);

        Program.ball.SetLastCollision(Program.screenWidth / 2, Program.screenHeight / 2);

        Program.player.SetPos(Program.screenHeight / 2 - Program.player.GetSize()/2);
        Program.cpu.SetPos(Program.screenHeight/ 2 - Program.cpu.GetSize());

    }

    private void ResetCooldown()
    {
        int i = 255;
        int j = 3;
        Color color = WHITE;

        while (true)
        {
            color.a = System.Convert.ToByte(i);

            Raylib.BeginDrawing();

            Raylib.DrawRectangle(
                (Program.screenWidth / 2 - Raylib.MeasureText(j.ToString(), 100)) - 10,
                Program.screenHeight / 2 - 50,
                100,
                100,
                DARKGRAY
                );

            Raylib.DrawText(
                j.ToString(),
                (Program.screenWidth / 2) -Raylib.MeasureText(j.ToString(), 100)/2,
                Program.screenHeight/2 - 50,
                100,
                WHITE);

            i -= 255/Raylib.GetMonitorRefreshRate(0);

            if (i < 1)
            {
                i = 255;
                j--;
            }

            Raylib.EndDrawing();

            if (j == 0) break;

            
        }
    }

    public void CheckResetGame()
    {
        if (!Raylib.IsKeyPressed(KeyboardKey.KEY_R)) return;

        Program.player.SetPoints(0);
        Program.cpu.SetPoints(0);

        ResetBall();
        ResetCooldown();
    }

    public void CheckIfScored()
    {
        Ball b = Program.ball;

        if (b.GetPos().X - b.GetRadius() <= b.GetRadius())
        {
            Program.cpu.IncPoints();
            ResetBall();
            this.ResetCooldown();
        }

        else if (b.GetPos().X + b.GetRadius() > Program.screenWidth - b.GetRadius())
        {
            Program.player.IncPoints();
            ResetBall();
            this.ResetCooldown();
        }
    }

    public void CheckPauseGame()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
            this.paused = !this.paused;

        Color color = new(100, 100, 100, 10);

        while (this.paused)
        {
            Raylib.BeginDrawing();

            Raylib.DrawRectangle(
                0,
                0,
                Program.screenWidth,
                Program.screenHeight,
                color
                );

            Raylib.EndDrawing();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
                this.paused = !this.paused;
        }


    }




}
