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

        private int xVel;
        private int yVel;


        public Ball(int width, int height, int xPos, int yPos)
        {
            this.width = width;
            this.height = height;

            this.xPos = xPos;
            this.yPos = yPos;
        }

        public Rectangle getRect()
        {
            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
