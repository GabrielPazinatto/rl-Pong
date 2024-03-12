using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace rl_pong
{
    public class Ball
    {
        private readonly int radius = 10;

        private Vector2 pos = new(600, 400);
        private Vector2 direction = new(1, 1);
        private float speed = 1.5f;

        private Vector2 GetInstantSpeed()
        {
            Vector2 spd;

            spd.X = this.speed * this.direction.X;
            spd.Y = this.speed * this.direction.Y;

            return spd;
        }

        public Vector2 GetPos() 
        { return this.pos; }

        public int GetRadius()
        {
            return this.radius;
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
            }

            if (futurePosY + this.radius > 900 || futurePosY - this.radius < 0)
            {
                this.direction.Y *= -1;
            }
        }

        private void CheckPlayerCollision(){
            if (Raylib.CheckCollisionCircleRec(
                this.pos,
                this.radius,
                Program.player.GetRectangle()))

                this.direction.X *= -1;
        }

        public void Move()
        {


            Console.WriteLine(this.pos.ToString());

            //speed normalization avoids object moving faster diagonally
            this.direction = System.Numerics.Vector2.Normalize(this.direction);

            this.CheckOutOfScreen();
            this.CheckPlayerCollision();

            this.pos.X += this.GetInstantSpeed().X;
            this.pos.Y += this.GetInstantSpeed().Y;

            

        }

    }
}
