using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro_Chess
{
    public partial class Caro : Form
    {
        Chess_Board_Manager ChessBoard;
        SocketManager socket;
        public Caro()
        {
            InitializeComponent();
            ChessBoard = new Chess_Board_Manager(pnlChessBoard, txbPlayerName, pctbMark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            NewGame();
            socket = new SocketManager();

            SetGradient(pnlChessBoard, ColorTranslator.FromHtml("#03d9de"), ColorTranslator.FromHtml("#38aae5"), ColorTranslator.FromHtml("#935bf1"), ColorTranslator.FromHtml("#dc1cfb"));
        }
        void EndGame()
        {
            
            pnlChessBoard.Enabled = false;
        }
        void NewGame()
        { 
            ChessBoard.DrawChessBoard();
        }

        void Quit()
        {
            Application.Exit();
        }

        void ChessBoard_PlayerMarked(object sender, ButtonClickEvent e)
        {
            
            pnlChessBoard.Enabled = false;

            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));

            Listen();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            pnlChessBoard.Enabled = true;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }
        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }
            }
        }

        private void Caro_Shown(object sender, EventArgs e)
        {
            txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            txbIP2.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(txbIP.Text))
            {
                txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
                txbIP2.Text = txbIP.Text;
            }
        }
        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch (Exception e)
                {
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            socket.IP = txbIP.Text;
            btnPlay.Enabled = false;
            txbPlayerName.Visible = true;
            txbIP2.Visible = true;
            panel3.Visible = false;
            pnlChessBoard.Visible = true;

            
            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                pnlChessBoard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnlChessBoard.Enabled = false;
                Listen();
            }
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlChessBoard.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.SEND_POINT:
                        pnlChessBoard.Enabled = true;
                        ChessBoard.OtherPlayerMark(data.Point);
                    break;
                case (int)SocketCommand.END_GAME:
                    break;
                case (int)SocketCommand.QUIT:
                    MessageBox.Show("Đối phương đã thoát");
                    break;
                default:
                    break;
            }

            Listen();
        }

        private void SetGradient(Panel panel, Color color1, Color color2, Color color3, Color color4)
        {
            // Xử lý sự kiện Paint của Panel
            panel.Paint += (sender, e) =>
            {
                // Tạo một đối tượng LinearGradientBrush
                LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, color1, color4, LinearGradientMode.Horizontal);

                // Thiết lập các màu và vị trí cho gradient
                ColorBlend blend = new ColorBlend();
                blend.Positions = new[] { 0, 0.33f, 0.66f, 1 };
                blend.Colors = new[] { color1, color2, color3, color4 };
                brush.InterpolationColors = blend;

                // Vẽ gradient lên Panel
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            };
        }


    }
}
