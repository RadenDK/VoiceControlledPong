using System;

namespace VoiceControlledPong
{
    internal class Computer : Paddle
    {
        private int yVelSpeed;

        public Computer(int width, int height, int xPos, int yPos) : base(width, height, xPos, yPos)
        {
            yVelSpeed = 3;
        }

        public void trackBall(Ball ball)
        {

        }

        public override void move()
        {

        }
    }
}