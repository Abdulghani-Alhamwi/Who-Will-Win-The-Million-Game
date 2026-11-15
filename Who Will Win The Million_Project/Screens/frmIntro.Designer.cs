namespace Who_Will_Win_The_Million_Game
{
    partial class frmIntro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntro));
            this.btnStartNewGame = new System.Windows.Forms.Button();
            this.tmStartGame = new System.Windows.Forms.Timer(this.components);
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadSavedGame = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartNewGame
            // 
            this.btnStartNewGame.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStartNewGame.BackColor = System.Drawing.Color.Purple;
            this.btnStartNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartNewGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnStartNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnStartNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartNewGame.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.btnStartNewGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnStartNewGame.Location = new System.Drawing.Point(394, 736);
            this.btnStartNewGame.Name = "btnStartNewGame";
            this.btnStartNewGame.Size = new System.Drawing.Size(311, 63);
            this.btnStartNewGame.TabIndex = 0;
            this.btnStartNewGame.Text = "Start New Game";
            this.btnStartNewGame.UseVisualStyleBackColor = false;
            this.btnStartNewGame.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStartNewGame.MouseHover += new System.EventHandler(this.btnStart_MouseHover);
            // 
            // tmStartGame
            // 
            this.tmStartGame.Interval = 32;
            this.tmStartGame.Tick += new System.EventHandler(this.tmStartGame_Tick);
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2CircleProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guna2CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2CircleProgressBar1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(130, 14);
            this.guna2CircleProgressBar1.Minimum = 0;
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ProgressColor = System.Drawing.Color.Purple;
            this.guna2CircleProgressBar1.ProgressColor2 = System.Drawing.Color.LawnGreen;
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(831, 831);
            this.guna2CircleProgressBar1.TabIndex = 1;
            this.guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnStartNewGame);
            this.panel1.Controls.Add(this.guna2CircleProgressBar1);
            this.panel1.Location = new System.Drawing.Point(1, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1058, 850);
            this.panel1.TabIndex = 2;
            // 
            // btnLoadSavedGame
            // 
            this.btnLoadSavedGame.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLoadSavedGame.BackColor = System.Drawing.Color.Purple;
            this.btnLoadSavedGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadSavedGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnLoadSavedGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLoadSavedGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadSavedGame.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.btnLoadSavedGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnLoadSavedGame.Location = new System.Drawing.Point(362, 648);
            this.btnLoadSavedGame.Name = "btnLoadSavedGame";
            this.btnLoadSavedGame.Size = new System.Drawing.Size(375, 65);
            this.btnLoadSavedGame.TabIndex = 1;
            this.btnLoadSavedGame.Text = "Load Saved Game";
            this.btnLoadSavedGame.UseVisualStyleBackColor = false;
            this.btnLoadSavedGame.Click += new System.EventHandler(this.btnLoadSavedGame_Click);
            this.btnLoadSavedGame.MouseHover += new System.EventHandler(this.btnStart_MouseHover);
            // 
            // frmIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = global::Who_Will_Win_The_Million_Game.Properties.Resources.Who_Win_The_Million;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1099, 864);
            this.Controls.Add(this.btnLoadSavedGame);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 24F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIntro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Who Will Win The Million";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIntroLifeCycle_FormClosed);
            this.Load += new System.EventHandler(this.frmIntroLifeCycle_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartNewGame;
        private System.Windows.Forms.Timer tmStartGame;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadSavedGame;
    }
}

