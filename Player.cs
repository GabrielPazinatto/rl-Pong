using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace rl_pong
{
    public class Player
    {
        private const int HorizontalPosOffset = 100;
        private const int BracketWidth = 10;

        private int points = 0;
        private float speed = 1;
        private float size = 100;
        private float pos = 400;
    
        public int GetPoints()
        {
            return points;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void GetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void GetPoints(int points) 
        {
            this.points = points;
        }

        public float GetPos()
        {
            return pos;
        }
        public void SetPos(float pos)
        {
            this.pos = pos;
        }

        public float GetSize()
        {
            return size;
        }

        public void SetSize(float size)
        {
            this.size = size;
        }

        public void Move() {
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                this.pos -= this.speed;
            }

            else if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                this.pos += this.speed;
            }
        }

        public Rectangle GetRectangle()
        {
            Rectangle r = new Rectangle
            {
                Width = BracketWidth,
                X = HorizontalPosOffset,
                Y = this.pos,
                Height = this.size
            };

            return r;
        }


    }
}
