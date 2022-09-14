using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nbradhamMinesweeper {

    /// <summary>
    /// Handles all game code.
    /// </summary>
    public partial class Form1:Form {

        private const string FILE_SAVE = "game.dat";
        private const sbyte ID_MINE = -1;

        private readonly short boardWidth, boardHeight, mineCount;
        private readonly Random random = new Random();
        private readonly sbyte[,] gameBoard;
        private readonly List<float> winTimes = new List<float>();
        private readonly SoundPlayer[] digPlayers = new SoundPlayer[4], damagePlayers = new SoundPlayer[4], flagPlayers = new SoundPlayer[4],
            bigDigPlayers = new SoundPlayer[3];
        private readonly SoundPlayer winPlayer = new SoundPlayer(@"sounds\levelup.wav"), clickPlayer = new SoundPlayer(@"sounds\click.wav");
        private float time = 0;
        private short lossCount = 0;

        /// <summary>
        /// Creates window, starts game, and reads user stats.
        /// </summary>
        public Form1(short width,short height,short mineTotal) {
            boardWidth=width;
            boardHeight=height;
            mineCount=mineTotal;
            gameBoard=new sbyte[boardWidth,boardHeight];
            InitializeComponent();

            //Read save file.
            if(File.Exists(FILE_SAVE)) {
                StreamReader reader = new StreamReader(FILE_SAVE);
                lossCount=short.Parse(reader.ReadLine());
                string line = reader.ReadLine();
                reader.Close();
                if(line!=null) {
                    string[] readTimes = line.Split(' ');
                    foreach(string str in readTimes)
                        try {
                            winTimes.Add(float.Parse(str));
                        } catch(FormatException e) { Console.WriteLine(e); }
                }
            }

            //Load sounds.
            for(byte i = 0;i<4;i++) {
                digPlayers[i]=new SoundPlayer($@"sounds\dig{i}.wav");
                damagePlayers[i]=new SoundPlayer($@"sounds\explode{i}.wav");
                flagPlayers[i]=new SoundPlayer($@"sounds\flag{i}.wav");
            }
            for(byte i = 0;i<3;i++)
                bigDigPlayers[i]=new SoundPlayer($@"sounds\bigDig{i}.wav");
        }

        /// <summary>
        /// Generates a new board, calculates tile values and sets the GUI labels.
        /// </summary>
        private void NewGame(short skipX,short skipY) {
            //Generate Board
            for(short i = 0;i<mineCount;i++) {

                //Get valid cords.
                int x, y;
                do {
                    x=random.Next(boardWidth);
                    y=random.Next(boardHeight);
                } while(gameBoard[x,y]==ID_MINE||(x==skipX&&y==skipY));

                //Place mine.
                gameBoard[x,y]=ID_MINE;
                labels[x,y].ForeColor=Color.Crimson;

                //Increment surrounding tiles.
                for(int addX = x-1;addX<=x+1;addX++)
                    if(addX>=0&&addX<boardWidth)
                        for(int addY = y-1;addY<=y+1;addY++)
                            if(addY>=0&&addY<boardHeight&&gameBoard[addX,addY]!=ID_MINE)
                                switch(++gameBoard[addX,addY]) {
                                case 1:
                                    labels[addX,addY].ForeColor=Color.Black;
                                    break;
                                case 2:
                                    labels[addX,addY].ForeColor=Color.Violet;
                                    break;
                                case 3:
                                    labels[addX,addY].ForeColor=Color.Indigo;
                                    break;
                                case 4:
                                    labels[addX,addY].ForeColor=Color.Blue;
                                    break;
                                case 5:
                                    labels[addX,addY].ForeColor=Color.Green;
                                    break;
                                case 6:
                                    labels[addX,addY].ForeColor=Color.YellowGreen;
                                    break;
                                case 7:
                                    labels[addX,addY].ForeColor=Color.Orange;
                                    break;
                                case 8:
                                    labels[addX,addY].ForeColor=Color.Red;
                                    break;
                                default:
                                    labels[addX,addY].ForeColor=Color.Pink;
                                    break;
                                }
            }

            //Update labels
            for(byte x = 0;x<boardWidth;x++)
                for(byte y = 0;y<boardHeight;y++)
                    switch(gameBoard[x,y]) {
                    case ID_MINE:
                        labels[x,y].Text="M";
                        break;
                    case 0:
                        labels[x,y].Text="";
                        break;
                    default:
                        labels[x,y].Text=gameBoard[x,y].ToString();
                        break;
                    }
        }

        /// <summary>
        /// Handles displaying stats on click.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ShowStatsToolStripMenuItem_Click(object sender,EventArgs e) {
            clickPlayer.Play();

            short sum = 0;
            foreach(short t in winTimes)
                sum+=t;

            MessageBox.Show(
                $"Wins: {winTimes.Count()}\nLosses: {lossCount}\nRatio: {(float)winTimes.Count()/lossCount}\nAverage time: {sum/winTimes.Count()}s"
                );
        }

        /// <summary>
        /// Handles restarting the game on click.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void RestartToolStripMenuItem_Click(object sender,EventArgs e) {
            clickPlayer.Play();

            foreach(GridButton button in buttons) {
                button.Visible=true;
                button.Text="";
            }

            for(byte x = 0;x<boardWidth;x++)
                for(byte y = 0;y<boardHeight;y++)
                    gameBoard[x,y]=0;

            timer1.Stop();
            time=0;
            toolStripStatusLabel1.Text="Game Time: 0s";
        }

        /// <summary>
        /// Handles closing the program.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ExitToolStripMenuItem_Click(object sender,EventArgs e) {
            Dispose();
        }

        /// <summary>
        /// Handles displaying instructions on click.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void InstructionsToolStripMenuItem_Click(object sender,EventArgs e) {
            clickPlayer.Play();
            MessageBox.Show(
                "Uncover a tile by clicking it. Right click to flag/unflag it. A number will tell you how many mines are adjacent to the tile. Clear out all safe tiles to win.\nYou can run this program from the command line with <width> <height> <mineCount> arguments for a custom board."
                );
        }

        /// <summary>
        /// Handles showing about info.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void AboutToolStripMenuItem_Click(object sender,EventArgs e) {
            clickPlayer.Play();
            MessageBox.Show("Made by: Nickolas S. Bradham\nReleased: July 20, 2021\nMade for: SUMMER 2021 CS 3020 001");
        }

        /// <summary>
        /// Handles when a tile button is clicked.
        /// </summary>
        /// <param name="sender">The clicked GridButton.</param>
        /// <param name="e">Ignored.</param>
        private void Button1_Click(object sender,EventArgs e) {
            GridButton button = (GridButton)sender;
            if(time==0)
                NewGame(button.GridX,button.GridY);
            timer1.Start();
            //Don't do anything if the button is flagged.
            if(button.Text.Equals("F"))
                return;

            Reveal(button.GridX,button.GridY,true);

            //Check if mine.
            if(gameBoard[button.GridX,button.GridY]==ID_MINE) {
                timer1.Stop();
                damagePlayers[random.Next(damagePlayers.Length)].Play();
                MessageBox.Show("KABOOM!");
                lossCount++;
                GameEnd();
                return;
            }

            //Check if only covered mines remain.
            bool winner = true;
            foreach(GridButton b in buttons)
                if(b.Visible&&gameBoard[b.GridX,b.GridY]!=ID_MINE) {
                    winner=false;
                    break;
                }

            if(winner) {
                timer1.Stop();
                winPlayer.Play();
                winTimes.Add(time);
                MessageBox.Show("Winner!");
                GameEnd();
            }
        }

        /// <summary>
        /// Reveals a tile and all adjacent tiles if the revealed tile is empty.
        /// </summary>
        /// <param name="x">Grid x position to reveal.</param>
        /// <param name="y">Grid y position to reveal.</param>
        /// <param name="playSound">Weather the sound should be played.</param>
        private void Reveal(int x,int y,bool playSound) {
            if(playSound)
                digPlayers[random.Next(digPlayers.Length)].Play();
            buttons[x,y].Visible=false;
            if(gameBoard[x,y]==0) {
                bool dugMult = false;
                for(int rx = x-1;rx<=x+1;rx++)
                    if(rx>=0&&rx<boardWidth)
                        for(int ry = y-1;ry<=y+1;ry++)
                            if(ry>=0&&ry<boardHeight&&buttons[rx,ry].Visible) {
                                Reveal(rx,ry,false);
                                dugMult=true;
                            }
                if(dugMult&&playSound)
                    bigDigPlayers[random.Next(bigDigPlayers.Length)].Play();
            }
        }

        /// <summary>
        /// Handles stopping the timer, revealing the field, and writing user stats.
        /// </summary>
        private void GameEnd() {
            try {
                File.WriteAllText(FILE_SAVE,$"{lossCount}\n{string.Join(" ",winTimes)}");
            } catch(IOException e) { Console.WriteLine(e); }
            foreach(GridButton gb in buttons)
                gb.Visible=false;
        }

        /// <summary>
        /// Handles flagging tiles on right click.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Mouse event details.</param>
        private void Button_Right(object sender,MouseEventArgs e) {
            if(e.Button==MouseButtons.Right) {
                flagPlayers[random.Next(flagPlayers.Length)].Play();
                ((Button)sender).Text=((Button)sender).Text.Equals("F") ? "" : "F";
            }
        }

        /// <summary>
        /// Handles every tick of the timer.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void Timer1_Tick(object sender,EventArgs e) {
            toolStripStatusLabel1.Text=$"Game Time: {(time+=.1f).ToString("#.0")}s";
        }
    }
}
