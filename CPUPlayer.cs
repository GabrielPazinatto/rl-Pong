
using Raylib_cs;

namespace rl_pong
{
    public class CPUPlayer : Player
    {
        public CPUPlayer() : base("cpu") { }

        public void Move()
        {
            Ball target = Program.ball;
            bool canMove = Math.Abs(this.GetPos() - target.GetPos().Y) > this.GetSpeed();

            if (target.GetDirection().X > 0 && canMove) {

                if (this.GetPos() > (target.GetPos().Y - this.GetSize()/2))
                    this.IncrementPosition(-this.GetSpeed() );

                else this.IncrementPosition(this.GetSpeed());

            }
        
            else if(target.GetDirection().X < 0 && canMove)
            {
                if (this.GetPos() > (Program.screenHeight / 2) - this.GetSize()/2) this.IncrementPosition(-this.GetSpeed());
                if (this.GetPos() < (Program.screenHeight / 2) - this.GetSize()/2) this.IncrementPosition(this.GetSpeed());
            }

        
        }
    }
}
