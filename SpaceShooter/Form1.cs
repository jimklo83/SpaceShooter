using WMPLib;
namespace SpaceShooter
{
    public partial class Form1 : Form
    {

        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootMedia;
        WindowsMediaPlayer explosion;

        PictureBox[] stars;
        int backgroundSpeed;
        int playerSpeed;

        PictureBox[] munitions;
        int munitionsSpeed;

        PictureBox[] enemies;
        int enemiesSpeed;

        PictureBox[] enemyMunitions;
        int enemyMunitionsSpeed;

        Random rnd;

        int score;
        int level;
        int difficulty;
        bool pause;
        bool gameOver;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundSpeed = 4;
            playerSpeed = 4;
            enemiesSpeed = 4;
            munitionsSpeed = 20;
            enemyMunitionsSpeed = 4;

            pause = false;
            gameOver = false;
            score = 0;
            level = 1;
            difficulty = 9;

            munitions = new PictureBox[3];


            Image munition = Image.FromFile(@"assets/munition.png");

            Image enemy1 = Image.FromFile(@"assets/E1.png");
            Image enemy2 = Image.FromFile(@"assets/E2.png");
            Image enemy3 = Image.FromFile(@"assets/E3.png");
            Image boss1 = Image.FromFile(@"assets/Boss1.png");
            Image boss2 = Image.FromFile(@"assets/Boss2.png");

            enemies = new PictureBox[10];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BackColor = Color.Transparent;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            enemies[0].Image = boss1;
            enemies[1].Image = enemy2;
            enemies[2].Image = enemy3;
            enemies[3].Image = enemy3;
            enemies[4].Image = enemy1;
            enemies[5].Image = enemy3;
            enemies[6].Image = enemy2;
            enemies[7].Image = enemy3;
            enemies[8].Image = enemy2;
            enemies[9].Image = boss2;

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(8, 8);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }

            gameMedia = new WindowsMediaPlayer();
            shootMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();

            gameMedia.URL = "sounds//Gamesong.mp3";
            shootMedia.URL = "sounds//shoot.mp3";
            explosion.URL = "sounds//boom.mp3";

            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 5;
            shootMedia.settings.volume = 1;
            explosion.settings.volume = 6;

            stars = new PictureBox[15];
            rnd = new Random();

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 500), rnd.Next(-10, 400));

                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }

                this.Controls.Add(stars[i]);
            }

            enemyMunitions = new PictureBox[10];

            for (int i = 0; i < enemyMunitions.Length; i++)
            {
                enemyMunitions[i] = new PictureBox();
                enemyMunitions[i].Size = new Size(2, 25);
                enemyMunitions[i].Visible = false;
                enemyMunitions[i].BackColor = Color.Red;
                int z = rnd.Next(0, 10);
                enemyMunitions[i].Location = new Point(enemies[z].Location.X, enemies[z].Location.Y - 20);
                this.Controls.Add(enemyMunitions[i]);
            }

            gameMedia.controls.play();
        }

        private void MoveBackground_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundSpeed;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundSpeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void LeftMove_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void RightMove_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 550)
            {
                Player.Left += playerSpeed;
            }
        }

        private void UpMove_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void DownMove_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightMove.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftMove.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMove.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMove.Start();
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightMove.Stop();
            LeftMove.Stop();
            UpMove.Stop();
            DownMove.Stop();

            if (e.KeyCode == Keys.Space)
            {
                if (!gameOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        label.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        label.Location = new Point(this.Width / 2 - 120, 150);
                        label.Text = "PAUSED";
                        label.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }
        }

        private void MoveMunitions_Tick(object sender, EventArgs e)
        {
            shootMedia.controls.play();
            for (int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= munitionsSpeed;

                    Collision();
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }
            }
        }

        private void MoveEnemies_Tick(object sender, EventArgs e)
        {
            EnemiesMovement(enemies, enemiesSpeed);
        }

        private void EnemiesMovement(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemies[i].Bounds)
                    || munitions[1].Bounds.IntersectsWith(enemies[i].Bounds)
                    || munitions[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.controls.play();
                    enemies[i].Location = new Point((i + 1) * 50, -100);
                    score += 1;
                    scorelabel.Text = (score < 10) ? "0" + score.ToString() : score.ToString();

                    if (score % 30 == 0)
                    {
                        level += 1;
                        lvllabel.Text = (level < 10) ? "0" + level.ToString() : level.ToString();

                        if (enemiesSpeed <= 10 && enemyMunitionsSpeed <= 10 && difficulty >= 0)
                        {
                            difficulty--;
                            enemiesSpeed++;
                            enemyMunitionsSpeed++;
                        }

                        if (level == 10)
                        {
                            GameOver("GREAT JOB!");
                        }
                    }
                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }

                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void GameOver(string str)
        {
            label.Text = str;
            label.Location = new Point(145, 120);
            label.Visible = true;
            ReplayBtn.Visible = true;
            ExitBtn.Visible = true;

            gameMedia.controls.stop();
            StopTimers();
        }

        private void StopTimers()
        {
            MoveBackground.Stop();
            MoveEnemies.Stop();
            MoveMunitions.Stop();
            EnemyMunitions.Stop();
        }

        private void StartTimers()
        {
            MoveBackground.Start();
            MoveEnemies.Start();
            MoveMunitions.Start();
            EnemyMunitions.Start();
        }

        private void EnemyMunitions_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < enemyMunitions.Length - difficulty; i++)
            {
                if (enemyMunitions[i].Top < this.Height)
                {
                    enemyMunitions[i].Visible = true;
                    enemyMunitions[i].Top += enemyMunitionsSpeed;

                    CollisionWithEnemyMunitions();
                }
                else
                {
                    enemyMunitions[i].Visible = false;
                    int y = rnd.Next(0, 10);
                    enemyMunitions[i].Location = new Point(enemies[y].Location.X + 20, enemies[y].Location.Y + 30);
                }
            }
        }

        private void CollisionWithEnemyMunitions()
        {
            for (int i = 0; i < enemyMunitions.Length; i++)
            {
                if (enemyMunitions[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemyMunitions[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void ReplayBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }


        /*private void MoveBackground_Tick(object sender, EventArgs e)
        {
            string backgroundImagePath = GetBackgroundImagePath(level);
            BackgroundImage = Image.FromFile(backgroundImagePath);

            // Rest of your background movement code
        }*/

        private string GetBackgroundImagePath(int level)
        {
            switch (level)
            {
                case 2:
                    return @"assets/background1.jpg";
                case 3:
                    return @"assets/background2.jpg";
                default:
                    return @"assets/default_background.jpg";
            }
        }

    }
}