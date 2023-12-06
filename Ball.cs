using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlledPong
{
    internal class Ball
    {
        private int width;
        private int height;
        private int xPos;
        private int yPos;

        private int xVel = -5;
        private int yVel = 0;


        public Ball(int width, int height, int xPos, int yPos)
        {
            this.width = width;
            this.height = height;

            this.xPos = xPos;
            this.yPos = yPos;
        }


        public void move()
        {
            xPos += xVel;
            yPos += yVel;
        }

        public Rectangle getRect()
        {
            return new Rectangle(xPos, yPos, width, height);
        }

        public void invertYVelocity()
        {
            yVel *= -1;
        }
        public void invertXVelocity()
        {
            xVel *= -1;
        }
    }
}
