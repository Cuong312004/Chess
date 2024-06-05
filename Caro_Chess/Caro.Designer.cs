using System.Drawing;

namespace Caro_Chess
{
    partial class Caro
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.pctbMark = new System.Windows.Forms.PictureBox();
            this.txbPlayerName = new System.Windows.Forms.TextBox();
            this.txbIP2 = new System.Windows.Forms.TextBox();
            this.txbConnect = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1191, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlChessBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChessBoard.Location = new System.Drawing.Point(204, 34);
            this.pnlChessBoard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(760, 629);
            this.pnlChessBoard.TabIndex = 0;
            this.pnlChessBoard.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnPlay);
            this.panel3.Controls.Add(this.txbIP);
            this.panel3.Location = new System.Drawing.Point(587, 366);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 178);
            this.panel3.TabIndex = 2;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Orchid;
            this.btnPlay.Location = new System.Drawing.Point(44, 110);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(215, 45);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(44, 57);
            this.txbIP.Margin = new System.Windows.Forms.Padding(4);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(215, 22);
            this.txbIP.TabIndex = 3;
            this.txbIP.Text = "127.0.0.1";
            // 
            // pctbMark
            // 
            this.pctbMark.BackColor = System.Drawing.Color.MidnightBlue;
            this.pctbMark.Location = new System.Drawing.Point(1035, 157);
            this.pctbMark.Margin = new System.Windows.Forms.Padding(4);
            this.pctbMark.Name = "pctbMark";
            this.pctbMark.Size = new System.Drawing.Size(156, 128);
            this.pctbMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbMark.TabIndex = 2;
            this.pctbMark.TabStop = false;
            this.pctbMark.Visible = false;
            // 
            // txbPlayerName
            // 
            this.txbPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPlayerName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txbPlayerName.Location = new System.Drawing.Point(993, 34);
            this.txbPlayerName.Margin = new System.Windows.Forms.Padding(4);
            this.txbPlayerName.Name = "txbPlayerName";
            this.txbPlayerName.ReadOnly = true;
            this.txbPlayerName.Size = new System.Drawing.Size(185, 22);
            this.txbPlayerName.TabIndex = 0;
            this.txbPlayerName.Visible = false;
            // 
            // txbIP2
            // 
            this.txbIP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIP2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txbIP2.Location = new System.Drawing.Point(993, 74);
            this.txbIP2.Margin = new System.Windows.Forms.Padding(4);
            this.txbIP2.Name = "txbIP2";
            this.txbIP2.ReadOnly = true;
            this.txbIP2.Size = new System.Drawing.Size(185, 22);
            this.txbIP2.TabIndex = 4;
            this.txbIP2.Visible = false;
            // 
            // txbConnect
            // 
            this.txbConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbConnect.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txbConnect.Location = new System.Drawing.Point(993, 116);
            this.txbConnect.Margin = new System.Windows.Forms.Padding(4);
            this.txbConnect.Name = "txbConnect";
            this.txbConnect.ReadOnly = true;
            this.txbConnect.Size = new System.Drawing.Size(185, 22);
            this.txbConnect.TabIndex = 6;
            this.txbConnect.Visible = false;
            // 
            // Caro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Caro_Chess.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1191, 676);
            this.Controls.Add(this.txbConnect);
            this.Controls.Add(this.txbIP2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txbPlayerName);
            this.Controls.Add(this.pnlChessBoard);
            this.Controls.Add(this.pctbMark);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Caro";
            this.Text = "Game Caro LAN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Caro_FormClosing);
            this.Load += new System.EventHandler(this.Caro_Load);
            this.Shown += new System.EventHandler(this.Caro_Shown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Caro_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.PictureBox pctbMark;
        private System.Windows.Forms.TextBox txbPlayerName;
        private System.Windows.Forms.TextBox txbIP2;
        private System.Windows.Forms.TextBox txbConnect;
    }
}

