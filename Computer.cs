using System;
using System.Drawing;

namespace VoiceControlledPong
{
    internal class Computer : Paddle
    {
        private int ySpeed;

        public Computer(int width, int height, int xPos, int yPos) : base(width, height, xPos, yPos)
        {
            ySpeed = 2;
        }

        public void trackBall(Ball ball)
        {
            // Check if the ball is above the center of the computer paddle
            if (ball.getRect().Top + ball.getRect().Height / 2 < getRect().Top + getRect().Height / 2)
            {
                // Set yVel to a negative value to move the computer paddle up
                yVel = -ySpeed;
            }
            // Check if the ball is below the center of the computer paddle
            else if (ball.getRect().Top + ball.getRect().Height / 2 > getRect().Top + getRect().Height / 2)
            {
                // Set yVel to a positive value to move the computer paddle down
                yVel = ySpeed;
            }
            else
            {
                // If the ball is within the paddle, stop movement
                yVel = 0;
            }
        }

        public override void move(int windowHeight)
        {
            // Update the yPos based on the yVel
            yPos += yVel;

            // Ensure the computer paddle stays within the screen boundaries
            yPos = Math.Max(0, Math.Min(windowHeight - height, yPos));
        }
    }
}
