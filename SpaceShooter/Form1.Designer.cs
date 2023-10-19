namespace SpaceShooter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MoveBackground = new System.Windows.Forms.Timer(components);
            Player = new PictureBox();
            LeftMove = new System.Windows.Forms.Timer(components);
            RightMove = new System.Windows.Forms.Timer(components);
            UpMove = new System.Windows.Forms.Timer(components);
            DownMove = new System.Windows.Forms.Timer(components);
            MoveMunitions = new System.Windows.Forms.Timer(components);
            MoveEnemies = new System.Windows.Forms.Timer(components);
            EnemyMunitions = new System.Windows.Forms.Timer(components);
            label = new Label();
            ReplayBtn = new Button();
            ExitBtn = new Button();
            scorelabel = new Label();
            lvllabel = new Label();
            scoreword = new Label();
            levelword = new Label();
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            SuspendLayout();
            // 
            // MoveBackground
            // 
            MoveBackground.Enabled = true;
            MoveBackground.Interval = 10;
            MoveBackground.Tick += MoveBackground_Tick;
            // 
            // Player
            // 
            Player.BackColor = Color.Transparent;
            Player.Image = (Image)resources.GetObject("Player.Image");
            Player.Location = new Point(260, 400);
            Player.Name = "Player";
            Player.Size = new Size(50, 50);
            Player.SizeMode = PictureBoxSizeMode.Zoom;
            Player.TabIndex = 0;
            Player.TabStop = false;
            // 
            // LeftMove
            // 
            LeftMove.Interval = 5;
            LeftMove.Tick += LeftMove_Tick;
            // 
            // RightMove
            // 
            RightMove.Interval = 5;
            RightMove.Tick += RightMove_Tick;
            // 
            // UpMove
            // 
            UpMove.Interval = 5;
            UpMove.Tick += UpMove_Tick;
            // 
            // DownMove
            // 
            DownMove.Interval = 5;
            DownMove.Tick += DownMove_Tick;
            // 
            // MoveMunitions
            // 
            MoveMunitions.Enabled = true;
            MoveMunitions.Interval = 20;
            MoveMunitions.Tick += MoveMunitions_Tick;
            // 
            // MoveEnemies
            // 
            MoveEnemies.Enabled = true;
            MoveEnemies.Tick += MoveEnemies_Tick;
            // 
            // EnemyMunitions
            // 
            EnemyMunitions.Enabled = true;
            EnemyMunitions.Interval = 20;
            EnemyMunitions.Tick += EnemyMunitions_Tick;
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label.ForeColor = Color.Crimson;
            label.Location = new Point(197, 67);
            label.Name = "label";
            label.Size = new Size(187, 59);
            label.TabIndex = 1;
            label.Text = "label1";
            label.Visible = false;
            // 
            // ReplayBtn
            // 
            ReplayBtn.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ReplayBtn.ForeColor = Color.Crimson;
            ReplayBtn.Location = new Point(209, 240);
            ReplayBtn.Name = "ReplayBtn";
            ReplayBtn.Size = new Size(150, 50);
            ReplayBtn.TabIndex = 2;
            ReplayBtn.Text = "Replay";
            ReplayBtn.UseVisualStyleBackColor = true;
            ReplayBtn.Visible = false;
            ReplayBtn.Click += ReplayBtn_Click;
            // 
            // ExitBtn
            // 
            ExitBtn.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ExitBtn.ForeColor = Color.Crimson;
            ExitBtn.Location = new Point(209, 335);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(150, 50);
            ExitBtn.TabIndex = 3;
            ExitBtn.Text = "Exit";
            ExitBtn.UseVisualStyleBackColor = true;
            ExitBtn.Visible = false;
            ExitBtn.Click += ExitBtn_Click;
            // 
            // scorelabel
            // 
            scorelabel.AutoSize = true;
            scorelabel.BackColor = Color.Transparent;
            scorelabel.Font = new Font("Haettenschweiler", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            scorelabel.ForeColor = Color.Chartreuse;
            scorelabel.Location = new Point(75, 9);
            scorelabel.Name = "scorelabel";
            scorelabel.Size = new Size(37, 29);
            scorelabel.TabIndex = 4;
            scorelabel.Text = "00";
            // 
            // lvllabel
            // 
            lvllabel.AutoSize = true;
            lvllabel.BackColor = Color.Transparent;
            lvllabel.Font = new Font("Haettenschweiler", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            lvllabel.ForeColor = Color.Chartreuse;
            lvllabel.Location = new Point(537, 9);
            lvllabel.Name = "lvllabel";
            lvllabel.Size = new Size(33, 29);
            lvllabel.TabIndex = 5;
            lvllabel.Text = "01";
            // 
            // scoreword
            // 
            scoreword.AutoSize = true;
            scoreword.BackColor = Color.Transparent;
            scoreword.Font = new Font("Haettenschweiler", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            scoreword.ForeColor = Color.Chartreuse;
            scoreword.Location = new Point(5, 9);
            scoreword.Name = "scoreword";
            scoreword.Size = new Size(75, 29);
            scoreword.TabIndex = 6;
            scoreword.Text = "Score:";
            // 
            // levelword
            // 
            levelword.AutoSize = true;
            levelword.BackColor = Color.Transparent;
            levelword.Font = new Font("Haettenschweiler", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            levelword.ForeColor = Color.Chartreuse;
            levelword.Location = new Point(471, 9);
            levelword.Name = "levelword";
            levelword.Size = new Size(69, 29);
            levelword.TabIndex = 7;
            levelword.Text = "Level:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(582, 453);
            Controls.Add(levelword);
            Controls.Add(scoreword);
            Controls.Add(lvllabel);
            Controls.Add(scorelabel);
            Controls.Add(ExitBtn);
            Controls.Add(ReplayBtn);
            Controls.Add(label);
            Controls.Add(Player);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Space Shooter";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer MoveBackground;
        private PictureBox Player;
        private System.Windows.Forms.Timer LeftMove;
        private System.Windows.Forms.Timer RightMove;
        private System.Windows.Forms.Timer UpMove;
        private System.Windows.Forms.Timer DownMove;
        private System.Windows.Forms.Timer MoveMunitions;
        private System.Windows.Forms.Timer MoveEnemies;
        private System.Windows.Forms.Timer EnemyMunitions;
        private Label label;
        private Button ReplayBtn;
        private Button ExitBtn;
        private Label scorelabel;
        private Label lvllabel;
        private Label scoreword;
        private Label levelword;
    }
}