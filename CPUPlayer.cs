
namespace rl_pong
{
    public class CPUPlayer : Player
    {
        public CPUPlayer() : base("cpu") { }

        public void Move()
        {
            Ball target = Program.ball;
            bool canMove = Math.Abs(this.GetPos() - target.GetPos().Y) > this.GetSpeed();

            //Console.WriteLine(target.GetDirection().ToString());

            if (target.GetDirection().X > 0 && canMove) {

                if (this.GetPos() > target.GetPos().Y - this.GetSize()/2)
                    this.IncrementPosition(-this.GetSpeed());

                else this.IncrementPosition(this.GetSpeed());

            }
        
            else if(target.GetDirection().X < 0 && canMove)
            {
                if (this.GetPos() > 400) this.IncrementPosition(-this.GetSpeed());
                if (this.GetPos() < 400) this.IncrementPosition(this.GetSpeed());
            }

        
        }
    }
}
