
using System.Numerics;
using Raylib_cs;

namespace rl_pong
{
    public class Ball
    {
        private readonly int radius = 10;

        private Vector2 pos = new(600, 450);               
        private Vector2 direction = new(-1, 0);           // unitary Vector2 (starts as -1, 0 but defaults as 1, 1)
        private Vector2 speed = new(4,3);                 // direction speed multiplier
        private Vector2 lastCollision = 
            new(Program.screenWidth/2,Program.screenHeight/2);
        private Vector2[] vectors = new Vector2[3];
        private bool drawVectors = false;

 

        /*-------------------------
                   GETTERS
         -------------------------*/


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

        private Vector2 GetInstantSpeed()                 //returns speed*direction
        {
            Vector2 spd;

            spd.X = this.speed.X * this.direction.X;
            spd.Y = this.speed.Y * this.direction.Y;

            return spd;
        }

        /*-------------------------
                SETTERS
        -------------------------*/
        
        public void SetLastCollision(float x, float y)
        {
            this.lastCollision = new(x, y);
        }

        public void SetPos(float x, float y)
        {
            this.pos = new(x, y);
        }

        public void SetDirection(float x, float y)
        {
            this.direction.X = x;
            this.direction.Y = y;
        }


        /*-------------------------
           OTHER FUNCTIONS
        -------------------------*/

        private void CheckOutOfScreen()                     //changes movement direction if ball leaves the screen
        {
            float speedX = this.GetInstantSpeed().X;
            float speedY = this.GetInstantSpeed().Y;

            //predicts future position adding speed to current position
            float futurePosX = this.pos.X + speedX;
            float futurePosY = this.pos.Y + speedY;

            //if future position is out of screen, inverts direction
            if (futurePosX + this.radius > Program.screenWidth || futurePosX - this.radius < 0)
            {
                this.direction.X *= -1;
                this.lastCollision = this.pos;

            }

            if (futurePosY + this.radius > Program.screenHeight || futurePosY - this.radius < 0)
            {
                this.direction.Y *= -1;
                this.lastCollision = this.pos;

            }
        }

        public void DrawVectors()
        {

            if (Raylib.IsKeyPressed(KeyboardKey.V))
                this.drawVectors = !this.drawVectors;


            if(!this.drawVectors) return;

            Color color = Color.White;
            color.A = 50;

            Raylib.DrawTriangleLines(
                this.vectors[0],
                this.vectors[1],
                this.vectors[2],
                color
                );
        }

        private void CalculateSpeed(Rectangle collider)
        {

            Vector2 dst = this.pos;
            Vector2 src = lastCollision;
            Vector2 a = new(Program.screenWidth, this.pos.Y);

            bool negativeSpeedX = this.direction.X < 0;
            bool reverseSpeedY = this.pos.Y < collider.Position.Y + (collider.Height / 2);

            float hip = System.Numerics.Vector2.Distance(dst, src);
            float cat2 = System.Numerics.Vector2.Distance(dst, a);
            float cat = System.Numerics.Vector2.Distance(src, a);


            if (hip != 0 && cat != 0 && cat2 != 0)
            {
                this.direction.X = -1 * (cat / hip);
                this.direction.Y = 1 - (cat2 / hip);
            }

            if (negativeSpeedX) this.direction.X *= -1;

            if (reverseSpeedY) this.direction.Y *= -1;

            this.vectors[0] = dst;
            this.vectors[1] = src;
            this.vectors[2] = a;

            Console.WriteLine(this.direction.ToString());

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
                    this.CalculateSpeed(playerRec);
                    this.lastCollision = this.pos;
                    this.pos.X = p.GetOffset() + p.BarWidth + this.radius;
                }

            Rectangle CPURec = cpu.GetRectangle();

            if (Raylib.CheckCollisionCircleRec(
                this.pos,
                this.radius,
                CPURec))
                {
                    this.CalculateSpeed(CPURec);
                    this.lastCollision = this.pos;
                    this.pos.X = cpu.GetOffset() - cpu.BarWidth - this.radius;
                }

            //Console.WriteLine(this.pos.ToString());

        }

        public void Move()
        {
            this.CheckOutOfScreen();
            this.CheckPlayerCollision();

            //speed normalization avoids object moving faster diagonally
            this.direction = System.Numerics.Vector2.Normalize(this.direction);

            this.pos.X += this.GetInstantSpeed().X;
            this.pos.Y += this.GetInstantSpeed().Y;
        }

    }
}
