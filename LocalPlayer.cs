using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rl_pong
{
    public class LocalPlayer : Player
    {

        public LocalPlayer() : base("local") { }

        public void Move()
        {
            if (Raylib.IsKeyDown(KeyboardKey.Up))
                this.IncrementPosition(this.GetSpeed() * -1);
           
            else if (Raylib.IsKeyDown(KeyboardKey.Down))
                this.IncrementPosition(this.GetSpeed());

            if (this.GetPos() < 0) this.SetPos(0);


            //Console.WriteLine(this.GetPos().ToString());
        }
    }
}
