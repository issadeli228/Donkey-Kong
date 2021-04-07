
namespace Donkey_Kong
{
    partial class Form1
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.controlsButton = new System.Windows.Forms.Button();
            this.escapeLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreNumberLabel = new System.Windows.Forms.Label();
            this.controlsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Niagara Engraved", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.titleLabel.Location = new System.Drawing.Point(94, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(517, 212);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Donkey Kong";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.startButton.Location = new System.Drawing.Point(261, 272);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(168, 60);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // controlsButton
            // 
            this.controlsButton.BackColor = System.Drawing.Color.Transparent;
            this.controlsButton.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.controlsButton.Location = new System.Drawing.Point(261, 380);
            this.controlsButton.Name = "controlsButton";
            this.controlsButton.Size = new System.Drawing.Size(168, 60);
            this.controlsButton.TabIndex = 2;
            this.controlsButton.Text = "Controls";
            this.controlsButton.UseVisualStyleBackColor = false;
            this.controlsButton.Click += new System.EventHandler(this.controlsButton_Click);
            // 
            // escapeLabel
            // 
            this.escapeLabel.AutoSize = true;
            this.escapeLabel.BackColor = System.Drawing.Color.Transparent;
            this.escapeLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escapeLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.escapeLabel.Location = new System.Drawing.Point(219, 530);
            this.escapeLabel.Name = "escapeLabel";
            this.escapeLabel.Size = new System.Drawing.Size(272, 28);
            this.escapeLabel.TabIndex = 3;
            this.escapeLabel.Text = "Press Escape to Exit";
            this.escapeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(608, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(65, 25);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Score";
            // 
            // scoreNumberLabel
            // 
            this.scoreNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreNumberLabel.ForeColor = System.Drawing.Color.Red;
            this.scoreNumberLabel.Location = new System.Drawing.Point(574, 34);
            this.scoreNumberLabel.Name = "scoreNumberLabel";
            this.scoreNumberLabel.Size = new System.Drawing.Size(127, 44);
            this.scoreNumberLabel.TabIndex = 5;
            this.scoreNumberLabel.Text = "0";
            this.scoreNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // controlsLabel
            // 
            this.controlsLabel.BackColor = System.Drawing.Color.Transparent;
            this.controlsLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsLabel.ForeColor = System.Drawing.Color.White;
            this.controlsLabel.Location = new System.Drawing.Point(130, 221);
            this.controlsLabel.Name = "controlsLabel";
            this.controlsLabel.Size = new System.Drawing.Size(444, 305);
            this.controlsLabel.TabIndex = 6;
            this.controlsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.controlsLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.scoreNumberLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.escapeLabel);
            this.Controls.Add(this.controlsButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.controlsLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button controlsButton;
        private System.Windows.Forms.Label escapeLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreNumberLabel;
        private System.Windows.Forms.Label controlsLabel;
    }
}

