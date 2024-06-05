using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro_Chess
{
    public class Chess_Board_Manager
    {
        private Panel chessBoard;

        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        private List<Player> player;
        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }
        private int currentPlayer;

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        private TextBox playerName;

        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private PictureBox playerMark;

        public PictureBox PlayerMark
        {
            get { return playerMark; }
            set { playerMark = value; }
        }

        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private event EventHandler<ButtonClickEvent> playerMarked;
        public event EventHandler<ButtonClickEvent> PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }

        private Stack<PlayInfo> playTimeLine;

        public Stack<PlayInfo> PlayTimeLine
        {
            get { return playTimeLine; }
            set { playTimeLine = value; }
        }
        public Chess_Board_Manager(Panel chessBoard, TextBox playerName, PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;

            this.player = new List<Player>()
            {
                new Player("Player1", Image.FromFile(Application.StartupPath + "\\Resources\\O_icon_.png")),
                new Player("Player2", Image.FromFile(Application.StartupPath + "\\Resources\\X_icon_.png"))
            };
       

        }

        public void CreatPlayer(TextBox playerName)
        {
            this.player = new List<Player>()
            {
                new Player(playerName.Text, Image.FromFile(Application.StartupPath + "\\Resources\\O.png")),
                new Player("Player2", Image.FromFile(Application.StartupPath + "\\Resources\\X.png"))
            };
        }

        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true;
            ChessBoard.Controls.Clear();

            PlayTimeLine = new Stack<PlayInfo>();
            CurrentPlayer = 0;
            ChangePlayer();

            Matrix = new List<List<Button>>();

            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Constraint.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Constraint.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Constraint.CHESS_WIDTH,
                        Height = Constraint.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BackColor = Color.MidnightBlue,
                        Tag = i.ToString()
                    };

                    btn.Click += btn_Click;
                    ChessBoard.Controls.Add(btn);

                    Matrix[i].Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Constraint.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }


        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return;
            Mark(btn);
            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

            int cur = 0;
            if (playerMarked != null)
                playerMarked(this, new ButtonClickEvent(GetChessPoint(btn)));
            if (isEndGame(btn))
            {
                EndGame();
                ChessBoard.Enabled = false;
                if (currentPlayer == 0)
                    cur = 2;
                else
                    cur = 1;
                MessageBox.Show("Player"+ cur + " là người chiến thắng");
            }
            ChangePlayer();
        }

        public void OtherPlayerMark(Point point)
        {
            Button btn = Matrix[point.Y][point.X];

            if (btn.BackgroundImage != null)
                return;

            Mark(btn);
            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

            ChangePlayer();

            if (isEndGame(btn))
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }

        private bool isEndGame(Button btn)
        {
            return CheckHorizontal(btn) || CheckVertical(btn) || CheckPrimaryDiagonal(btn) || CheckSubDiagonal(btn);
        }
        private Point GetChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal, vertical);

            return point;
        }
        private bool CheckHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }

            int countRight = 0;
            for (int i = point.X + 1; i < Constraint.CHESS_BOARD_WIDTH; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;
            }

            return countLeft + countRight == 5;
        }
        private bool CheckVertical(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = point.Y + 1; i < Constraint.CHESS_BOARD_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == 5;
        }
        private bool CheckPrimaryDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Constraint.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i >= Constraint.CHESS_BOARD_HEIGHT || point.X + i >= Constraint.CHESS_BOARD_WIDTH)
                    break;

                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == 5;
        }
        private bool CheckSubDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > Constraint.CHESS_BOARD_WIDTH || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Constraint.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i >= Constraint.CHESS_BOARD_HEIGHT || point.X - i < 0)
                    break;

                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == 5;
        }

        private void Mark(Button btn)
        {
            btn.BackgroundImage = player[CurrentPlayer].Mark;
        }
        public void ChangePlayer()
        {
            PlayerName.Text = player[CurrentPlayer].Name + " TURN";

            PlayerMark.Image = player[CurrentPlayer].Mark;
        }
    }

    public class ButtonClickEvent : EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint
        {
            get { return clickedPoint; }
            set { clickedPoint = value; }
        }

        public ButtonClickEvent(Point point)
        {
            this.ClickedPoint = point;
        }
    }
}
