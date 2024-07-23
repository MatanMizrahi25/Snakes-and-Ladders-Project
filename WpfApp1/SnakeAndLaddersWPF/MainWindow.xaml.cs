using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using LadderAndSnakes;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;


namespace SnakeAndLaddersWPF
{

    enum cellSize
    {
        WIDTH = 60,
        HEIGHT = 60,
    };
    enum playerSize
    {
        WIDTH = 30,
        HEIGHT = 30,
    };

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string SERIALIZE_FILE_PATH = @"c:\output\winnerData.dat";

        Game game = new Game();
        List<Rectangle> gameCells = new List<Rectangle>();
        Rectangle player, pcPlayer, activePlayer;
        Queue<Rectangle> playersQueue = new Queue<Rectangle>();

        bool isGameEnded; 

        public MainWindow()
        {
            InitializeComponent();
            initGame();
        }
        private void initGame()
        {
            setDiceValue(6);
            printGameBoard();
            addPlayers();
            setupPlayers();
            this.game.start();
        }
        private void OnLastWinnerCick(object sender, RoutedEventArgs e)
        {
            if (File.Exists(SERIALIZE_FILE_PATH))
            {
                string latestWinner = getLatestWinnerName();
                MessageBox.Show("The latest winner is:" + latestWinner, "Congratulations Alert");
                return;
            }
            MessageBox.Show("This is the first time you're playing.");

        }
        private void printGameBoard()
        {
            int gameRows = this.game.board.getWidth();
            int gameColumns = this.game.board.getHeight();

            for (int row = 0; row < gameRows; row++)
            {
                if( row % 2 == 0)
                {
                    for (int column = 0; column < gameColumns; column++)
                    {

                        Rectangle gameCell = buildGameCell(row, column);
                        gameCells.Add(gameCell);

                        Canvas.SetLeft(gameCell, column * (int)cellSize.WIDTH);
                        Canvas.SetBottom(gameCell,  row * (int)cellSize.HEIGHT);
                    }
                }
                else
                {
                    for (int column = gameColumns - 1; column >= 0; column--)
                    {

                        Rectangle gameCell = buildGameCell(row, column);
                        gameCells.Add(gameCell);

                        Canvas.SetRight(gameCell, column * (int)cellSize.WIDTH);
                        Canvas.SetBottom(gameCell, row * (int)cellSize.HEIGHT);
                    }
                }
            }
        }
        private Rectangle buildGameCell(int row, int column)
        {
            ImageBrush tileImages = new ImageBrush();
            tileImages.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + row + "_" + column + ".jpg"));

            Rectangle box = new Rectangle
            {
                Height = (int)cellSize.HEIGHT,
                Width = (int)cellSize.WIDTH,
                Fill = tileImages,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            box.Name = "cell_" + row.ToString() + column.ToString();

            box.Tag = new CellPosition(row, column);
            this.RegisterName(box.Name, box);
            gameBoardCanvas.Children.Add(box);
            return box;
        }
        private void setPlayerPosition(Rectangle playerToMove, CellPosition destination)
        {
            Rectangle landingRec = gameCells.Last();
            foreach (Rectangle rectangle in gameCells)
            {
                if ((CellPosition)rectangle.Tag == destination)
                {
                    landingRec = rectangle;
                }
            }

            if(destination.ROW % 2 == 0 )
            {
                Canvas.SetLeft(playerToMove, Canvas.GetLeft(landingRec) + playerToMove.Width / 2);
            }
            else
            {
                Canvas.SetLeft(playerToMove, Canvas.GetLeft(landingRec) + playerToMove.Height / 2);
                Canvas.SetRight(playerToMove, Canvas.GetRight(landingRec) + playerToMove.Height / 2);
            }
            Canvas.SetBottom(playerToMove, Canvas.GetBottom(landingRec) + playerToMove.Height / 2);
        }
        private void moveActivePlayer(CellPosition position)
        {
            setPlayerPosition(this.activePlayer, position);
        }
        private Rectangle createPlayerObject(bool isPCPlayer = false)
        {
            string imageName = "player.gif";
            if (isPCPlayer) imageName = "opponent.gif";

            ImageBrush playerImage = new ImageBrush();
            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + imageName));

            Rectangle player = new Rectangle
            {
                Height = (int)playerSize.HEIGHT,
                Width = (int)playerSize.WIDTH,
                Fill = playerImage,
                StrokeThickness = 2
            };
            gameBoardCanvas.Children.Add(player);

            return player;
        }
        private void addPlayers()
        {
            this.player = this.createPlayerObject();
            this.pcPlayer = this.createPlayerObject(true);
        }
        private void setupPlayers()
        {
            setPlayerPosition(this.pcPlayer, new CellPosition(0, 0));
            setPlayerPosition(this.player, new CellPosition(0, 0));

            addPlayerToQueue(this.player);
            addPlayerToQueue(this.pcPlayer);
        }
        private void addPlayerToQueue(Rectangle player)
        {
            this.playersQueue.Enqueue(player);
        }
        private void setDiceValue(int diceValue)
        {
            diceImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/dice/dice_" + diceValue + ".jpg"));
        }
        public Rectangle getNextPlayer()
        {
            return this.playersQueue.Dequeue();
        }
        private void setFunnyMessages(int diceValue)
        {
            int min = 0;
            int max = 3;
            
            if(diceValue >= 3)
            {
                min = 4;
                max = 7;
            }

            string[] funnyMessages =
            {
                "Ohhhh, noooo :(",
                "Ooops! ",
                "Are you serious?",
                "OMG! Why???",
                "Welll Done!",
                "I am so good :)",
                "Wooooow",
                "HAHAHA PC"
            };

            Random random = new Random();
            int randomIndex = random.Next(min, max);

            funnyMessagesLabel.Content = funnyMessages[randomIndex];
        }
        private void setActivePlayerLabel(string activePlayer = "")
        {
            activePlayerNameLabel.Content = activePlayer;
        }
        private void startRound()
        {
            this.activePlayer = getNextPlayer();

            int diceValue = this.game.rollDice();

            this.setDiceValue(diceValue);
            this.setFunnyMessages(diceValue);

            CellPosition destination = this.game.startRound();

            moveActivePlayer(destination);

            if (this.game.isGameEnded()) handleGameEnd();

            setActivePlayerLabel(this.game.getActivePlayerName() + " Is playing now");

            this.playersQueue.Enqueue(this.activePlayer);
        }
        private void DiceRoll_Click(object sender, RoutedEventArgs e)
        {
            if (this.isGameEnded) return;

            this.startRound();
        }
        private void handleGameEnd()
        {
            isGameEnded = true;
            startRoundBtn.IsEnabled = false;
            this.playersQueue.Clear();
            OpenWinnerDialog(this.game.getActivePlayerName());
            this.SerializeWinner();

        }
        private void SerializeWinner()
        {
            Stream stream = File.Open(SERIALIZE_FILE_PATH, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this.game.getActivePlayer());
            stream.Close();
        }
        private string getLatestWinnerName()
        {

            Stream stream = File.Open(SERIALIZE_FILE_PATH, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            Player latestWinner = (Player)bf.Deserialize(stream);
            stream.Close();

            return latestWinner.getName();
            
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developed by Ofek Sinai and Matan Mizrahi, HIT College", "About");
        }
        private void Start_New_Game_Click(object sender, RoutedEventArgs e)
        {
            isGameEnded = false;
            this.game = new Game();
            setDiceValue(1);
            setupPlayers();
            this.game.start();

            startRoundBtn.IsEnabled = true;
        }
        private void OpenWinnerDialog(string winnerPlayerName)
        {          
            MessageBox.Show(winnerPlayerName + " is the round winner! Congratulations! ", "Congratulations Alert");
        }
    }
}
