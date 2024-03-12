
using System.Numerics;
using Raylib_cs;

namespace rl_pong
{
    public class Ball
    {
        private readonly int radius = 10;

        private Vector2 pos = new(600, 450);
        private Vector2 direction = new(-1, 1);
        private Vector2 speed = new(2,2);
        private Vector2 lastCollision = new(600, 450);

        private Vector2 GetInstantSpeed()
        {
            Vector2 spd;

            spd.X = this.speed.X * this.direction.X;
            spd.Y = this.speed.Y * this.direction.Y;

            return spd;
        }

        public Vector2 GetPos() 
        { return this.pos; }

        public int GetRadius()
        {
            return this.radius;
        }

        public Vector2 GetDirection()
        {
            return this.direction;
        }

        private void CheckOutOfScreen()
        {
            float speedX = this.GetInstantSpeed().X;
            float speedY = this.GetInstantSpeed().Y;

            //predicts future position
            float futurePosX = this.pos.X + speedX;
            float futurePosY = this.pos.Y + speedY;

            //if future position is out of screen, inverts direction
            if (futurePosX + this.radius > 1200 || futurePosX - this.radius < 0)
            {
                this.direction.X *= -1;
                this.lastCollision = this.pos;
            }

            if (futurePosY + this.radius > 900 || futurePosY - this.radius < 0)
            {
                this.direction.Y *= -1;
                this.lastCollision = this.pos;
            }
        }

        private void CalculateSpeed()
        {
            Vector2 dst = this.pos;
            Vector2 src = lastCollision;
            Vector2 a = new(1200, this.pos.Y);

            float hip = System.Numerics.Vector2.Distance(dst, src);
            float cat = System.Numerics.Vector2.Distance(dst, a);
            float cat2 = System.Numerics.Vector2.Distance(src, a);

            this.direction.X *= -(cat / hip) * 2;
            this.direction.Y *= (cat2 / hip);

        }

        private void CheckPlayerCollision(){
            Rectangle playerRec = Program.player.GetRectangle();
            Player p = Program.player;
            Player cpu = Program.cpu;

            if (Raylib.CheckCollisionCircleRec(
                this.pos,
                this.radius,
                playerRec))
                {
                this.CalculateSpeed();
                this.lastCollision = this.pos;

                this.pos.X = p.GetOffset() + p.BracketWidth + this.radius;

                Console.WriteLine("PLAYER");

                }

            Rectangle CPURec = cpu.GetRectangle();

            if (Raylib.CheckCollisionCircleRec(
                this.pos,
                this.radius,
                CPURec))
                {
                this.CalculateSpeed();
                this.lastCollision = this.pos;

                this.pos.X = cpu.GetOffset() - cpu.BracketWidth - this.radius;

                Console.WriteLine("CPU");

                }

            //Console.WriteLine(this.pos.ToString());

        }

        public void Move()
        {

            this.CheckOutOfScreen();
            this.CheckPlayerCollision();

            //speed normalization avoids object moving faster diagonally
            this.direction = System.Numerics.Vector2.Normalize(this.direction);

           // if (Math.Abs(this.direction.X) < 0.5 && this.direction.X > 0)
                //this.direction.X = 0.5f;

            //if (Math.Abs(this.direction.X) < 0.5 && this.direction.X < 0)
              //  this.direction.X = -0.5f;

            this.pos.X += this.GetInstantSpeed().X;
            this.pos.Y += this.GetInstantSpeed().Y;

        }

    }
}
