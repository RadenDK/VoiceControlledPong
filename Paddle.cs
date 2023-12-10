using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlledPong
{
    
    internal abstract class Paddle
    {
        protected int width;
        protected int height;

        protected int xPos;
        protected int yPos;

        protected int yVel;

        public Paddle(int width, int height, int xPos,  int yPos)
        {
            this.width = width;
            this.height = height;  
            this.xPos = xPos;   
            this.yPos = yPos;
        }

        public Rectangle getRect()
        {
            return new Rectangle(this.xPos, this.yPos, this.width, this.height);
        }

        public abstract void move(int windowHeight);
    }
}
