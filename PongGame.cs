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

        private Timer gameTimer;

        public PongGame()
        {
            this.Text = "Voice Controlled Pong Game";
            this.Size = new Size(800, 600);

            initBoardObjects();

            gameTimer = new Timer();
            gameTimer.Interval = 1000 / 60;
            gameTimer.Tick += new EventHandler(GameUpdate);
            gameTimer.Start();

        }

        private void initBoardObjects()
        {
            int paddleWidth = 10;
            int paddleHeight = 100;
            int paddleBorderPadding = 30;
            int paddleY = (this.ClientSize.Height - paddleHeight) / 2;


            player = new Player(paddleWidth, paddleHeight, paddleBorderPadding, paddleY);
            computer = new Computer(paddleWidth, paddleHeight, (this.ClientSize.Width - paddleBorderPadding) + paddleWidth - paddleBorderPadding, paddleY);


            int ballWidth = 20;
            int ballHeight = 20;
            int ballX = (this.ClientSize.Width - paddleWidth / 2) / 2;
            int ballY = (this.ClientSize.Height - paddleHeight / 2) / 2;

            ball = new Ball(ballWidth, ballHeight, ballX, ballY);
        }

        private void GameUpdate(object sender, EventArgs e)
        {
            ball.move();
            checkBallCollision();
            this.Invalidate(); // Invalidate the form so it redraws
        }

        private void checkBallCollision()
        {
            if (checkBallTopCollision())
            {
                ball.invertYVelocity();
            }
            if (checkBallPaddleCollison())
            {
                ball.invertXVelocity();
            }
        }

        private Boolean checkBallTopCollision()
        {
            Boolean collison = false;
            if (ball.getRect().Bottom >= this.ClientSize.Height)
            {
                collison = true;
            }
            else if (ball.getRect().Top <= 0)
            {
                collison = true;
            }
            return collison;
        }

        private Boolean checkBallPaddleCollison()
        {
            Boolean collison = false;
            // Collides with paddle left side
            if (ball.getRect().Left <= player.getRect().Right && ball.getRect().Left >= player.getRect().Left)
            {
                collison = true;
            }
            else if (ball.getRect().Right >= computer.getRect().Left && ball.getRect().Right <= computer.getRect().Right)
            {
                collison = true;
            }

            return collison;
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (gameTimer != null)
            {
                gameTimer.Stop();
                gameTimer.Dispose();
            }
        }

        

    }
}
