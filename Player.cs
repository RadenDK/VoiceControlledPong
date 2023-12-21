using System;

namespace VoiceControlledPong
{
    internal class Player : Paddle
    {

        private string currentCommand;

        private readonly int yVelSpeed;

        public Player(int width, int height, int xPos, int yPos) : base(width, height, xPos, yPos)
        {
            yVelSpeed = 3;
        }

        public void setCommand(string command)
        {
            currentCommand = command;
            interpretCurrentCommand();
        }

        private void interpretCurrentCommand()
        {
            if (currentCommand == "Up")
            {
                yVel = -yVelSpeed;
            }
            else if (currentCommand == "Down")
            {
                yVel = +yVelSpeed;
            }
            else if (currentCommand == "Stop")
            {
                yVel = 0;
            }
        }

        public override void move(int windowHeight)
        {
          
            yPos += yVel;

            yPos = Math.Max(0, Math.Min(windowHeight - height, yPos));
        }


    }
}