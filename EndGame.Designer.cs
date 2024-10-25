﻿
namespace funkyBubbles
{
    partial class EndGame
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label scoreLabel;
            System.Windows.Forms.Label statusLabel;
            this.scoringBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new funkyBubbles.ModelDataSet();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.scoreTextBox = new System.Windows.Forms.TextBox();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.scoringTableAdapter = new funkyBubbles.ModelDataSetTableAdapters.scoringTableAdapter();
            this.tableAdapterManager = new funkyBubbles.ModelDataSetTableAdapters.TableAdapterManager();
            this.playAgain = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.request = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            scoreLabel = new System.Windows.Forms.Label();
            statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scoringBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.Location = new System.Drawing.Point(78, 95);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(62, 24);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "name:";
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            scoreLabel.Location = new System.Drawing.Point(78, 135);
            scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new System.Drawing.Size(59, 24);
            scoreLabel.TabIndex = 5;
            scoreLabel.Text = "score:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusLabel.Location = new System.Drawing.Point(78, 175);
            statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(65, 24);
            statusLabel.TabIndex = 7;
            statusLabel.Text = "status:";
            // 
            // scoringBindingSource
            // 
            this.scoringBindingSource.DataMember = "scoring";
            this.scoringBindingSource.DataSource = this.modelDataSet;
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scoringBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(144, 91);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(178, 26);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // scoreTextBox
            // 
            this.scoreTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.scoreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scoringBindingSource, "score", true));
            this.scoreTextBox.Location = new System.Drawing.Point(144, 131);
            this.scoreTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scoreTextBox.Name = "scoreTextBox";
            this.scoreTextBox.ReadOnly = true;
            this.scoreTextBox.Size = new System.Drawing.Size(178, 26);
            this.scoreTextBox.TabIndex = 6;
            this.scoreTextBox.TextChanged += new System.EventHandler(this.scoreTextBox_TextChanged);
            // 
            // statusTextBox
            // 
            this.statusTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scoringBindingSource, "status", true));
            this.statusTextBox.Font = new System.Drawing.Font("ROG Fonts", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTextBox.Location = new System.Drawing.Point(144, 171);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(214, 56);
            this.statusTextBox.TabIndex = 8;
            this.statusTextBox.TextChanged += new System.EventHandler(this.statusTextBox_TextChanged);
            // 
            // scoringTableAdapter
            // 
            this.scoringTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.scoringTableAdapter = this.scoringTableAdapter;
            this.tableAdapterManager.UpdateOrder = funkyBubbles.ModelDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // playAgain
            // 
            this.playAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.playAgain.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgain.Location = new System.Drawing.Point(447, 82);
            this.playAgain.Name = "playAgain";
            this.playAgain.Size = new System.Drawing.Size(97, 46);
            this.playAgain.TabIndex = 12;
            this.playAgain.Text = "play again";
            this.playAgain.UseVisualStyleBackColor = false;
            this.playAgain.Click += new System.EventHandler(this.playAgain_Click);
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Quit.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quit.Location = new System.Drawing.Point(447, 157);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(101, 38);
            this.Quit.TabIndex = 13;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.save.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Location = new System.Drawing.Point(259, 281);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(149, 60);
            this.save.TabIndex = 14;
            this.save.Text = "Save Results";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // request
            // 
            this.request.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.request.Location = new System.Drawing.Point(144, 25);
            this.request.Name = "request";
            this.request.ReadOnly = true;
            this.request.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.request.Size = new System.Drawing.Size(233, 30);
            this.request.TabIndex = 15;
            this.request.Text = "Please save your data first!";
            // 
            // EndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 692);
            this.Controls.Add(this.request);
            this.Controls.Add(this.save);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.playAgain);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(scoreLabel);
            this.Controls.Add(this.scoreTextBox);
            this.Controls.Add(statusLabel);
            this.Controls.Add(this.statusTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EndGame";
            this.Text = "Endgame";
            this.Load += new System.EventHandler(this.EndGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scoringBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource scoringBindingSource;
        private ModelDataSetTableAdapters.scoringTableAdapter scoringTableAdapter;
        private ModelDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox scoreTextBox;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button playAgain;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox request;
    }
}