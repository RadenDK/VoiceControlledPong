using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace VoiceControlledPong
{
    internal class PongGame : Form
    {

        private Paddle player;
        private Paddle computer;
        private Ball ball;


        public PongGame()
        {
            this.Text = "Voice Controlled Pong Game";
            this.Size = new Size(800, 600);

            initBoardObjects();

        }

        private void initBoardObjects()
        {
            int paddleWidth = 10;
            int paddleHeight = 100;
            int paddleBorderPadding = 30; 
            int paddleY = (this.ClientSize.Height - paddleHeight) / 2;


            player = new Paddle(paddleWidth, paddleHeight, paddleBorderPadding, paddleY);
            computer = new Paddle(paddleWidth, paddleHeight, (this.ClientSize.Width - paddleBorderPadding) + paddleWidth - paddleBorderPadding, paddleY);


            int ballWidth = 20;
            int ballHeight = 20;
            int ballX = (this.ClientSize.Width - paddleWidth / 2) / 2;
            int ballY = (this.ClientSize.Height - paddleHeight / 2) / 2;

            ball = new Ball(ballWidth, ballHeight, ballX, ballY);
        }


        public void run()
        {
           
            Application.Run(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;



            g.FillRectangle(Brushes.Red, computer.getRect());
            g.FillRectangle(Brushes.Blue, player.getRect());

            g.FillRectangle(Brushes.Black, ball.getRect());
        }
    }
}
