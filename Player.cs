
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

        /*-------------------------
                CONSTRUCTOR
        -------------------------*/

        protected Player(string type)
        {
            if(type == "cpu")
            {
                this.speed = 1;
                this.HorizontalPosOffset = 1100;
                this.BarWidth = 10;
                this.points = 0;
            }

            if(type == "local")
            {
                this.speed = 2;
                this.HorizontalPosOffset = 100;
                this.BarWidth = 10;
                this.points = 0;
            }
        }

        /*-------------------------
                GETTERS
        -------------------------*/

        public float GetWidth()
        {
            return this.BarWidth;
        }

        public int GetPoints()
        {
            return this.points;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public float GetPos()
        {
            return pos;
        }

        public float GetSize()
        {
            return size;
        }

        public int GetOffset()
        {
            return this.HorizontalPosOffset;
        }


        public Rectangle GetRectangle()
        {
            Rectangle r = new Rectangle
            {
                width = BarWidth,
                X = HorizontalPosOffset,
                Y = this.pos,
                height = this.size
            };

            return r;
        }

        /*-------------------------
                SETTERS
        -------------------------*/

        public void SetPos(float pos)
        {
            this.pos = pos;
        }

        public void SetPoints(int points)
        {
            this.points = points;
        }

        public void SetSize(float size)
        {
            this.size = size;
        }

        /*-------------------------
            OTHER FUNCTIONS
        -------------------------*/

        public void IncrementPosition(float x)
        {
            this.pos += x;
        }

        public void IncPoints()
        {
            points++;
        }
    }
}
