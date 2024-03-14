
using Raylib_cs;

namespace rl_pong
{
    public abstract class Player
    {
        internal readonly int HorizontalPosOffset = 100;
        internal readonly int BarWidth = 10;

        private int points = 0;
        private float speed = 1;
        private float size = 150;
        private float pos = 400;

        protected Player(string type)
        {
            if(type == "cpu")
            {
                this.speed = 1.2f;
                this.HorizontalPosOffset = 1100;
                this.BarWidth = 10;
            }

            if(type == "local")
            {
                this.speed = 2;
                this.HorizontalPosOffset = 100;
                this.BarWidth = 10;
            }
        }


        public float GetWidth()
        {
            return this.BarWidth;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void SetPos(float pos)
        {
            this.pos = pos;
        }

        public void GetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void IncrementPosition(float x) {
            this.pos += x;
        }

        public float GetPos()
        {
            return pos;
        }

        public float GetSize()
        {
            return size;
        }

        public void SetSize(float size)
        {
            this.size = size;
        }

        public void IncPoints()
        {
            points++;
        }

        public Rectangle GetRectangle()
        {
            Rectangle r = new Rectangle
            {
                Width = BarWidth,
                X = HorizontalPosOffset,
                Y = this.pos,
                Height = this.size
            };

            return r;
        }

        public int GetOffset()
        {
            return this.HorizontalPosOffset;
        }


    }
}
