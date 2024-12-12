using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class FlappyBird : Form
    {
        // Game elements
        private PictureBox bird;
        private PictureBox pipeTop;
        private PictureBox pipeBottom;
        private Timer gameTimer;
        private Label scoreLabel;
        private Button resumeButton;

        // Game state variables
        private int pipeSpeed = 8;
        private int gravity = 10;
        private int score = 0;

        private bool isGamePaused = false;

        public FlappyBird()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Set up the game window
            this.Width = 800;
            this.Height = 600;
            this.Text = "Flappy Bird";
            this.BackColor = Color.SkyBlue;

            // Create bird
            bird = new PictureBox()
            {
                Width = 50,
                Height = 50,
                BackColor = Color.Yellow,
                Top = 200,
                Left = 100
            };
            this.Controls.Add(bird);

            // Create top pipe
            pipeTop = new PictureBox()
            {
                Width = 100,
                Height = 200,
                BackColor = Color.Green,
                Top = 0,
                Left = 400
            };
            this.Controls.Add(pipeTop);

            // Create bottom pipe
            pipeBottom = new PictureBox()
            {
                Width = 100,
                Height = 200,
                BackColor = Color.Green,
                Top = 400,
                Left = 400
            };
            this.Controls.Add(pipeBottom);

            // Create score label
            scoreLabel = new Label()
            {
                Text = "Score: 0",
                Font = new Font("Arial", 16),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true,
                Top = 10,
                Left = 10
            };
            this.Controls.Add(scoreLabel);

            // Set up timer
            gameTimer = new Timer()
            {
                Interval = 20 // Game loop interval (milliseconds)
            };
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            // Create the Resume button (Initially hidden)
            resumeButton = new Button()
            {
                Text = "Resume Game",
                Width = 200,
                Height = 50,
                Top = this.Height / 2 - 25, // Center the button
                Left = this.Width / 2 - 100,
                Visible = false // Hide the button initially
            };
            resumeButton.Click += ResumeButton_Click;
            this.Controls.Add(resumeButton);

            // Key event handlers
            this.KeyDown += FlappyBird_KeyDown;
            this.KeyUp += FlappyBird_KeyUp;
        }

        private void FlappyBird_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !isGamePaused)
            {
                gravity = -10; // Move the bird upward when space is pressed
            }
        }

        private void FlappyBird_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !isGamePaused)
            {
                gravity = 10; // Apply gravity when key is released
            }
        }

        private void GameLoop(object sender, EventArgs e)
        {
            if (isGamePaused) return;

            // Move bird
            bird.Top += gravity;

            // Move pipes
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;

            // Check if pipes have gone off screen
            if (pipeTop.Left < -pipeTop.Width)
            {
                pipeTop.Left = this.Width;
                pipeBottom.Left = this.Width;

                // Randomize pipe positions
                Random rnd = new Random();
                int gap = 150;
                int pipeHeight = rnd.Next(50, 300);
                pipeTop.Height = pipeHeight;
                pipeBottom.Top = pipeTop.Height + gap;

                // Update score
                score++;
                scoreLabel.Text = $"Score: {score}";
            }

            // Check for collisions
            if (bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Top < 0 ||
                bird.Bottom > this.ClientSize.Height)
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            MessageBox.Show($"Game Over! Your score: {score}", "Flappy Bird", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Show the Resume button
            resumeButton.Visible = true;
            isGamePaused = true;
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            // Reset game state variables
            bird.Top = 200;
            pipeTop.Left = 400;
            pipeBottom.Left = 400;
            pipeTop.Height = 200;
            pipeBottom.Top = 400;
            score = 0;
            scoreLabel.Text = "Score: 0";

            // Reset gravity to its default value (downward)
            gravity = 10;

            // Hide the Resume button
            resumeButton.Visible = false;

            // Restart the game timer
            gameTimer.Start();

            // Unpause the game
            isGamePaused = false;
        }


        //[STAThread]
        //public static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new FlappyBird());
        //}
    }
}
