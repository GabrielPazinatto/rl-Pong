
namespace rl_pong
{
    public class LocalPlayer : Player
    {

        public LocalPlayer() : base("local") { }

        public void Move()
        {
            //moves the bar up and down with up and down arrows
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                this.IncrementPosition(this.GetSpeed() * -1);
           
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                this.IncrementPosition(this.GetSpeed());
            
            //prevents bar from leaving the screen
            if (this.GetPos() < 0) this.SetPos(0);
            if (this.GetPos() + this.GetSize() > Program.screenHeight) 
                this.SetPos(Program.screenHeight -this.GetSize());
        }
    }
}
