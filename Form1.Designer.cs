
namespace funkyBubbles
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ScoreBox = new System.Windows.Forms.TextBox();
            this.start_request = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1200, 692);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // ScoreBox
            // 
            this.ScoreBox.BackColor = System.Drawing.Color.SeaGreen;
            this.ScoreBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScoreBox.Font = new System.Drawing.Font("ROG Fonts", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ScoreBox.Location = new System.Drawing.Point(16, 17);
            this.ScoreBox.Multiline = true;
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.ReadOnly = true;
            this.ScoreBox.Size = new System.Drawing.Size(184, 78);
            this.ScoreBox.TabIndex = 1;
            this.ScoreBox.TextChanged += new System.EventHandler(this.ScoreBox_TextChanged);
            // 
            // start_request
            // 
            this.start_request.BackColor = System.Drawing.SystemColors.MenuText;
            this.start_request.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.start_request.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_request.ForeColor = System.Drawing.SystemColors.Window;
            this.start_request.Location = new System.Drawing.Point(518, 0);
            this.start_request.Name = "start_request";
            this.start_request.ReadOnly = true;
            this.start_request.Size = new System.Drawing.Size(156, 21);
            this.start_request.TabIndex = 3;
            this.start_request.Text = "Please click to start";
            this.start_request.TextChanged += new System.EventHandler(this.start_request_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.start_request);
            this.Controls.Add(this.ScoreBox);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox ScoreBox;
        private System.Windows.Forms.TextBox start_request;
    }
}

