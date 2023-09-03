using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        const int mapSize = 8;
        const int cellSize = 50;
        bool isOnePlayer;
        private int timer;
        int whitetimer;
        int blacktimer;
        int currentPlayer;

        List<Button> simpleSteps = new List<Button>();
        List<Button>White = new List<Button>();
        List<Button>Black=new List<Button>();
        List<Button>AiPossibleSteps = new List<Button>();

        int countEatSteps = 0;
        int whitePawns = 12;
        int blackPawns = 12;
        Button prevButton;
        Button pressedButton;
        bool isContinue = false;
        
        bool isMoving;

        int[,] map = new int[mapSize, mapSize];
        int whiteKings = 0;
        int blackKings = 0;

        Button[,] buttons = new Button[mapSize, mapSize];

        Image whiteFigure;
        Image blackFigure;
        Image whiteKingFigure;
        Image blackKingFigure;
        Image whiteCircle;
        Form4 form4;
        public Form1()
        {
            InitializeComponent();

            whiteFigure = new Bitmap(new Bitmap(Resources.crven), new Size(cellSize - 10, cellSize - 10));
            blackFigure = new Bitmap(new Bitmap(Resources.crn), new Size(cellSize - 10, cellSize - 10));
            whiteKingFigure = new Bitmap(new Bitmap(Resources.crvenkral), new Size(cellSize - 10, cellSize - 10));
            blackKingFigure = new Bitmap(new Bitmap(Resources.crnkral), new Size(cellSize - 10, cellSize - 10));
            whiteCircle= new Bitmap(new Bitmap(Resources.circle), new Size(cellSize - 10, cellSize - 10));
            this.Text = "Checkers";

            Init();
            StartGame();
        }

        public void Init()
        {
            currentPlayer = 1;
            isMoving = false;
            prevButton = null;

            map = new int[mapSize, mapSize] {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };

            CreateMap();
        }

        public void Winner(List<Move>legalmovesplayer1,List<Move>legalmovesplayer2)
        {
            
            bool player1 = false;
            bool player2 = false;

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 1)
                        player1 = true;
                    if (map[i, j] == 2)
                        player2 = true;
                }
            }
            
            if(legalmovesplayer1.Count == 0 && legalmovesplayer2.Count == 0)
            {
                
                form4 = new Form4("The game ends in a draw. It's a tie!");

                form4.ShowDialog();
                this.Close();
                     

            }
            if(!player1 || legalmovesplayer1.Count==0)
            {
               
                form4 =new Form4("Player 2 wins! Congratulations!");
                form4.ShowDialog();
                this.Close();
                
                    

            }
            if (!player2 || legalmovesplayer2.Count == 0)
            {
                form4 = new Form4("Player 1 wins! Congratulations!");
                form4.ShowDialog();
                this.Close();
                    

            }
        }

        public void CreateMap()
        {
            

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.Click += new EventHandler(OnFigurePress);
                    if (map[i, j] == 1)
                    {
                        White.Add(button);
                        button.Image = whiteFigure;
                    }
                    else if (map[i, j] == 2)
                    {
                        Black.Add(button);
                        button.Image = blackFigure;
                    }

                    button.BackColor = GetPrevButtonColor(button);
                    button.ForeColor = Color.White;

                    buttons[i, j] = button;

                    this.Controls.Add(button);
                }
            }
            
           
        }

        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            List<Move>legalmovesplayer1= new List<Move>();
            List<Move> legalmovesplayer2 = new List<Move>();
            legalmovesplayer1 = GenerateLegalMoves(1);
            legalmovesplayer2= GenerateLegalMoves(2);
            if (currentPlayer == 2 && isOnePlayer==true) {
                AiMove();
                
            }
            Winner(legalmovesplayer1,legalmovesplayer2);
        }
        public int[,] ApplyMove(int[,] board, Move move)
        {
            int[,] newBoard = (int[,])board.Clone(); // Create a copy of the current board

            // Move the piece from the start position to the end position
            int piece = newBoard[move.StartRow, move.StartCol];
            newBoard[move.StartRow, move.StartCol] = 0; // Empty the start position
            newBoard[move.EndRow, move.EndCol] = piece; // Place the piece in the end position


            // Check for and perform captures (if any)
            int rowDiff = Math.Abs(move.StartRow - move.EndRow);
            int colDiff = Math.Abs(move.StartCol - move.EndCol);

            if (rowDiff == 2 && colDiff == 2)
            {
                // Capture move, remove the captured piece
                int capturedRow = (move.StartRow + move.EndRow) / 2;
                int capturedCol = (move.StartCol + move.EndCol) / 2;
                newBoard[capturedRow, capturedCol] = 0; // Set the captured piece to empty
            }
            

            return newBoard;
        }

        public int EvaluatePosition()
        {
            int whiteScore = 0;
            int blackScore = 0;

            // Piece and king values
            int pawnValue = 1;
            int kingValue = 3;

            // Positional weights (adjust these as needed)
            int centerControlWeight = 2; // Controlling the center of the board
            int edgeControlWeight = 1;   // Controlling the edges of the board
            int advancedPawnWeight = 1;  // Advancement of pawns towards the opponent's king row

            // Piece count for both players
            int whitePieces = whitePawns + whiteKings;
            int blackPieces = blackPawns + blackKings;

            // Calculate the score based on piece and king counts
            whiteScore = whitePieces * pawnValue + whiteKings * kingValue;
            blackScore = blackPieces * pawnValue + blackKings * kingValue;

            // Positional evaluation
            for (int row = 0; row < mapSize; row++)
            {
                for (int col = 0; col < mapSize; col++)
                {
                    int piece = map[row, col];

                    if (piece != 0)
                    {
                        int pieceValue = (piece == 1) ? pawnValue : kingValue;

                        // Control of center
                        if (row >= 2 && row <= 5 && col >= 2 && col <= 5)
                        {
                            if (piece == 1)
                                whiteScore += centerControlWeight * pieceValue;
                            else
                                blackScore += centerControlWeight * pieceValue;
                        }

                        // Control of edges
                        if (row == 0 || row == mapSize - 1 || col == 0 || col == mapSize - 1)
                        {
                            if (piece == 1)
                                whiteScore += edgeControlWeight * pieceValue;
                            else
                                blackScore += edgeControlWeight * pieceValue;
                        }

                        // Pawn advancement
                        if (piece == 1 && row < mapSize - 1)
                            whiteScore += advancedPawnWeight * pieceValue;
                        else if (piece == 2 && row > 0)
                            blackScore += advancedPawnWeight * pieceValue;
                    }
                }
            }

            // Return the final evaluation score
            Console.WriteLine(whiteScore - blackScore);
            return whiteScore - blackScore; // Positive score favors white, negative favors black
        }

        private void UpdateUIAfterAIMove(Move move)
        {
            // Assuming you have buttons corresponding to the game board cells
            Button startButton = buttons[move.StartRow, move.StartCol];
            Button endButton = buttons[move.EndRow, move.EndCol];

            
            endButton.Image = startButton.Image;
            endButton.Text = startButton.Text;
            
            if(move.CaptureRow!= -1 && move.CaptureCol != -1)
            {
                
                Button captureButton = buttons[move.CaptureRow, move.CaptureCol];
                captureButton.Image = null;
                captureButton.Text = "";
               White.Remove(captureButton);
                map[move.CaptureRow,move.CaptureCol]=0;
                
                whitePawns--;
            }

            startButton.Image = null;
            startButton.Text = "";
            startButton.BackColor= Color.FromArgb(80,80,80);
            if (move.EndRow == 0)
            {
                map[move.EndRow, move.EndCol] = 2;
                SwitchButtonToCheat(buttons[move.EndRow, move.EndCol]);
            }
        }
        public List<Move> GenerateLegalMoves(int player)
        {
            List<Move> legalMoves = new List<Move>();

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == player)
                    {
                        // Check regular forward diagonal moves for non-kings
                        if (player == 1 || buttons[i, j].Text == "D")
                        {
                            TryAddMove(i, j, i + 1, j - 1, legalMoves);
                            TryAddMove(i, j, i + 1, j + 1, legalMoves);
                        }


                        if (player == 2 || buttons[i, j].Text == "D")
                        {
                            TryAddMove(i, j, i - 1, j - 1, legalMoves);
                            TryAddMove(i, j, i - 1, j + 1, legalMoves);
                        }

                        // Check for jump moves
                        TryAddJump(i, j, i - 1, j - 1, i - 2, j - 2, legalMoves);
                        TryAddJump(i, j, i - 1, j + 1, i - 2, j + 2, legalMoves);
                        TryAddJump(i, j, i + 1, j - 1, i + 2, j - 2, legalMoves);
                        TryAddJump(i, j, i + 1, j + 1, i + 2, j + 2, legalMoves);
                        if (buttons[i, j].Image == whiteKingFigure || buttons[i, j].Image == blackKingFigure)
                        {
                            TryAddMovesInDirection(i, j, -1, -1, legalMoves);
                            TryAddMovesInDirection(i, j, -1, 1, legalMoves);
                            TryAddMovesInDirection(i, j, 1, -1, legalMoves);
                            TryAddMovesInDirection(i, j, 1, 1, legalMoves);
                        }

                    }
                }
            }
           
            List<Move> mustCapture = new List<Move>();
            foreach (Move move in legalMoves)
            {
                if (move.CaptureRow != -1 && move.CaptureCol != -1)
                {
                    mustCapture.Add(move);
                }
            }
            if (mustCapture.Count > 0)
                return mustCapture;
            return legalMoves;
        }

        private void TryAddMovesInDirection(int fromRow, int fromCol, int rowIncrement, int colIncrement, List<Move> legalMoves)
        {
            int currentRow = fromRow + rowIncrement;
            int currentCol = fromCol + colIncrement;
           

            while (IsInsideBorders(currentRow, currentCol))
            {
               
                    
                    TryAddJump(fromRow, fromCol, currentRow, currentCol, currentRow + rowIncrement * 2, currentCol + colIncrement * 2, legalMoves);
              

                // Add the move to legalMoves
                legalMoves.Add(new Move(fromRow, fromCol, currentRow, currentCol, this));

                // Move further in the same direction
                currentRow += rowIncrement;
                currentCol += colIncrement;
            }

           
           
        }

      

        private void TryAddMove(int fromRow, int fromCol, int toRow, int toCol, List<Move> legalMoves)
        {
            if (IsValidMove(fromRow, fromCol, toRow, toCol))
            {
                legalMoves.Add(new Move(fromRow, fromCol, toRow, toCol,this));
            }
        }

        private void TryAddJump(int fromRow, int fromCol, int jumpRow, int jumpCol, int toRow, int toCol, List<Move> legalMoves)
        {
            if (IsValidJump(fromRow, fromCol, jumpRow, jumpCol, toRow, toCol))
            {
                legalMoves.Add(new Move(fromRow, fromCol, toRow, toCol, jumpRow, jumpCol,this));
            }
        }

        private bool IsValidMove(int fromRow, int fromCol, int toRow, int toCol)
        {
            // Check if the move is within the board boundaries
            if (!IsInsideBorders(toRow, toCol))
            {
                return false;
            }

            // Check if the destination square is empty
            if (map[toRow, toCol] != 0)
            {
                return false;
            }

            // Check if the move is diagonal
            int rowDiff = Math.Abs(toRow - fromRow);
            int colDiff = Math.Abs(toCol - fromCol);
            if (rowDiff != colDiff || rowDiff != 1)
            {
                return false;
            }

           


            return true;
        }

        private bool IsValidJump(int fromRow, int fromCol, int jumpRow, int jumpCol, int toRow, int toCol)
        {
            // Check if the jump is within the board boundaries
            if (!IsInsideBorders(jumpRow, jumpCol) || !IsInsideBorders(toRow, toCol))
            {
                return false;
            }

            // Check if the destination square is empty
            if (map[toRow, toCol] != 0)
            {
                return false;
            }

            // Check if the square being jumped over contains an opponent's piece
            int jumpedPlayer = map[jumpRow, jumpCol];
            int currentPlayer = map[fromRow, fromCol];

            if (jumpedPlayer == 0 || jumpedPlayer == currentPlayer)
            {
                return false;
            }

            // Check if the move is diagonal and covers a distance of exactly 2 squares
            int rowDiff = Math.Abs(toRow - fromRow);
            int colDiff = Math.Abs(toCol - fromCol);

            if ((rowDiff != 2 || colDiff != 2 || rowDiff != colDiff) && (buttons[fromRow, fromCol].Image != whiteKingFigure && buttons[fromRow, fromCol].Image != blackKingFigure))
            {
                return false;
            }

            // Check if non-kings only jump forward
            if (currentPlayer == 1 && fromRow > toRow && (buttons[fromRow, fromCol].Image != whiteKingFigure && buttons[fromRow, fromCol].Image != blackKingFigure))
            {
                return false;
            }

            if (currentPlayer == 2 && fromRow < toRow && (buttons[fromRow, fromCol].Image != whiteKingFigure && buttons[fromRow, fromCol].Image != blackKingFigure))
            {
                return false;
            }

            return true;
        }
        public void AiMove()
        {
            
            int depth = 5; // Adjust the depth of the search as needed
            Move bestMove = new Move(-1, -1, -1, -1, this); // Pass currentPlayer and this

            // Use the Minimax method of the bestMove object to find the best move
            int alpha = int.MinValue;
            int beta = int.MaxValue;
            bestMove = bestMove.Minimax(map, currentPlayer, depth, alpha, beta, this);


            // Apply the best move to the game board using ApplyMove
            if (bestMove != null)
            {
               // buttons[bestMove.EndRow, bestMove.EndCol].BackColor = Color.Blue;
                map = ApplyMove(map, bestMove);
                // Update the game board
                UpdateUIAfterAIMove(bestMove);
                SwitchPlayer();
                // Update the UI or any other necessary actions
            }
        }
        public Color GetPrevButtonColor(Button prevButton)
        {
            if ((prevButton.Location.Y / cellSize % 2) != 0)
            {
                if ((prevButton.Location.X / cellSize % 2) == 0)
                {
                    return Color.FromArgb(20, 20, 20);
                }
            }
            if ((prevButton.Location.Y / cellSize) % 2 == 0)
            {
                if ((prevButton.Location.X / cellSize) % 2 != 0)
                {
                    return Color.FromArgb(20, 20, 20);
                }
            }
            return Color.Red;
        }
        private void StartTimer()
        {
            
            int minutes = whitetimer / 60;
            int seconds = whitetimer % 60;

            string timeString = $"{minutes:D2}:{seconds:D2}";
            whitetimertb.Text = timeString;
            blacktimertb.Text = timeString;

            timer1.Start();
        }
        public void OnFigurePress(object sender, EventArgs e)
        {
            
            if (prevButton != null)
                prevButton.BackColor = GetPrevButtonColor(prevButton);

            pressedButton = sender as Button;

            if (map[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] != 0 && map[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == currentPlayer )
            {
                CloseSteps();
                pressedButton.BackColor = Color.White;
                DeactivateAllButtons();
                pressedButton.Enabled = true;
                countEatSteps = 0;
                if (pressedButton.Image == whiteKingFigure || pressedButton.Image == blackKingFigure)
                    ShowSteps(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize, false);
                else ShowSteps(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);

                if (isMoving)
                {
                    CloseSteps();
                    pressedButton.BackColor = GetPrevButtonColor(pressedButton);
                    ShowPossibleSteps();
                    isMoving = false;
                }
                else
                    isMoving = true;
            }
            else
            {
                if (isMoving)
                {
                    isContinue = false;
                    if (Math.Abs(pressedButton.Location.X / cellSize - prevButton.Location.X / cellSize) > 1)
                    {
                        isContinue = true;
                        DeleteEaten(pressedButton, prevButton);
                    }
                    int temp = map[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize];
                    map[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = map[prevButton.Location.Y / cellSize, prevButton.Location.X / cellSize];
                    map[prevButton.Location.Y / cellSize, prevButton.Location.X / cellSize] = temp;
                    pressedButton.Image = prevButton.Image;
                    prevButton.Image = null;
                    pressedButton.Text = prevButton.Text;
                    prevButton.Text = "";
                    SwitchButtonToCheat(pressedButton);
                    countEatSteps = 0;
                    isMoving = false;
                    CloseSteps();
                    
                    
                    
                    if (countEatSteps == 0 || !isContinue)
                    {
                        
                        
                        SwitchPlayer();
                        

                        ShowPossibleSteps();
                        
                        isContinue = false;
                    }
                   
                    else if (isContinue)
                    {
                        pressedButton.BackColor = Color.White;
                        pressedButton.Enabled = true;
                        isMoving = true;
                    }
                }
            }

            prevButton = pressedButton;
            
        }
        public void ShowPossibleSteps()
        {
            bool isOneStep = true;
            bool isEatStep = false;
            DeactivateAllButtons();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == currentPlayer)
                    {
                        if (buttons[i, j].Image == whiteKingFigure || buttons[i, j].Image == blackKingFigure)
                            isOneStep = false;
                        else isOneStep = true;
                        if (IsButtonHasEatStep(i, j, isOneStep, new int[2] { 0, 0 }))
                        {
                            isEatStep = true;
                            buttons[i, j].Enabled = true;
                        }
                    }
                }
            }
            if (!isEatStep)
                ActivateAllButtons();
        }

        public void SwitchButtonToCheat(Button button)
        {
            if (map[button.Location.Y / cellSize, button.Location.X / cellSize] == 1 && button.Location.Y / cellSize == mapSize - 1)
            {
                
                button.Image = null;
                button.Image = whiteKingFigure;
                whiteKings++;

            }
            if (map[button.Location.Y / cellSize, button.Location.X / cellSize] == 2 && button.Location.Y / cellSize == 0)
            {
 
                button.Image = null;
                button.Image = blackKingFigure;
                blackKings++;
            }
        }

        public void DeleteEaten(Button endButton, Button startButton)
        {
            int count = Math.Abs(endButton.Location.Y / cellSize - startButton.Location.Y / cellSize);
            int startIndexX = endButton.Location.Y / cellSize - startButton.Location.Y / cellSize;
            int startIndexY = endButton.Location.X / cellSize - startButton.Location.X / cellSize;
            startIndexX = startIndexX < 0 ? -1 : 1;
            startIndexY = startIndexY < 0 ? -1 : 1;
            int currCount = 0;
            int i = startButton.Location.Y / cellSize + startIndexX;
            int j = startButton.Location.X / cellSize + startIndexY;
            while (currCount < count - 1)
            {
                map[i, j] = 0;
                buttons[i, j].Image = null;
                buttons[i, j].Text = "";
                i += startIndexX;
                j += startIndexY;
                currCount++;
            }
            if(currentPlayer==1)
            {
                blackPawns--;
            }
        }

        public void ShowSteps(int iCurrFigure, int jCurrFigure, bool isOnestep = true)
        {
            simpleSteps.Clear();
            ShowDiagonal(iCurrFigure, jCurrFigure, isOnestep);
            if (countEatSteps > 0)
                CloseSimpleSteps(simpleSteps);
        }

        public void ShowDiagonal(int IcurrFigure, int JcurrFigure, bool isOneStep = false)
        {
            int j = JcurrFigure + 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure + 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (IsInsideBorders(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }

        public bool DeterminePath(int ti, int tj)
        {
            
            if (map[ti, tj] == 0 && !isContinue)
            {
                buttons[ti, tj].Image=whiteCircle;
                buttons[ti, tj].Enabled = true;
                simpleSteps.Add(buttons[ti, tj]);
            }
            else
            {

                if (map[ti, tj] != currentPlayer)
                {
                    if (pressedButton.Image == whiteKingFigure || pressedButton.Image == blackKingFigure)
                        ShowProceduralEat(ti, tj, false);
                    else ShowProceduralEat(ti, tj);
                }

                return false;
            }
            return true;
        }

        public void CloseSimpleSteps(List<Button> simpleSteps)
        {
            if (simpleSteps.Count > 0)
            {
                for (int i = 0; i < simpleSteps.Count; i++)
                {
                    simpleSteps[i].BackColor = GetPrevButtonColor(simpleSteps[i]);
                    simpleSteps[i].Enabled = false;
                    if (simpleSteps[i].Image == whiteCircle)
                    {
                        simpleSteps[i].Image = null;
                    }
                }
            }
        }
        public void ShowProceduralEat(int i, int j, bool isOneStep = true)
        {
            int dirX = i - pressedButton.Location.Y / cellSize;
            int dirY = j - pressedButton.Location.X / cellSize;
            dirX = dirX < 0 ? -1 : 1;
            dirY = dirY < 0 ? -1 : 1;
            int il = i;
            int jl = j;
            bool isEmpty = true;
            while (IsInsideBorders(il, jl))
            {
                if (map[il, jl] != 0 && map[il, jl] != currentPlayer)
                {
                    isEmpty = false;
                    break;
                }
                il += dirX;
                jl += dirY;

                if (isOneStep)
                    break;
            }
            if (isEmpty)
                return;
            List<Button> toClose = new List<Button>();
            bool closeSimple = false;
            int ik = il + dirX;
            int jk = jl + dirY;
            while (IsInsideBorders(ik, jk))
            {
                if (map[ik, jk] == 0)
                {
                    if (IsButtonHasEatStep(ik, jk, isOneStep, new int[2] { dirX, dirY }))
                    {
                        closeSimple = true;
                    }
                    else
                    {
                        toClose.Add(buttons[ik, jk]);
                    }
                    buttons[ik, jk].Image=whiteCircle;
                    buttons[ik, jk].Enabled = true;
                    countEatSteps++;
                }
                else break;
                if (isOneStep)
                    break;
                jk += dirY;
                ik += dirX;
            }
            if (closeSimple && toClose.Count > 0)
            {
                CloseSimpleSteps(toClose);
            }

        }

        public bool IsButtonHasEatStep(int IcurrFigure, int JcurrFigure, bool isOneStep, int[] dir)
        {
            bool eatStep = false;
            int j = JcurrFigure + 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (dir[0] == 1 && dir[1] == -1 && !isOneStep) break;
                if (IsInsideBorders(i, j))
                {
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i - 1, j + 1))
                            eatStep = false;
                        else if (map[i - 1, j + 1] != 0)
                            eatStep = false;
                        else return eatStep;
                    }
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (currentPlayer == 1 && isOneStep && !isContinue) break;
                if (dir[0] == 1 && dir[1] == 1 && !isOneStep) break;
                if (IsInsideBorders(i, j))
                {
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i - 1, j - 1))
                            eatStep = false;
                        else if (map[i - 1, j - 1] != 0)
                            eatStep = false;
                        else return eatStep;
                    }
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (dir[0] == -1 && dir[1] == 1 && !isOneStep) break;
                if (IsInsideBorders(i, j))
                {
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i + 1, j - 1))
                            eatStep = false;
                        else if (map[i + 1, j - 1] != 0)
                            eatStep = false;
                        else return eatStep;
                    }
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure + 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (currentPlayer == 2 && isOneStep && !isContinue) break;
                if (dir[0] == -1 && dir[1] == -1 && !isOneStep) break;
                if (IsInsideBorders(i, j))
                {
                    if (map[i, j] != 0 && map[i, j] != currentPlayer)
                    {
                        eatStep = true;
                        if (!IsInsideBorders(i + 1, j + 1))
                            eatStep = false;
                        else if (map[i + 1, j + 1] != 0)
                            eatStep = false;
                        else return eatStep;
                    }
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
            return eatStep;
        }

        public void CloseSteps()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    buttons[i, j].BackColor = GetPrevButtonColor(buttons[i, j]);
                    if (buttons[i,j].Image == whiteCircle)
                    {
                        buttons[i, j].Image = null;
                    }
                }
            }
            
        }

        public bool IsInsideBorders(int ti, int tj)
        {
            if (ti >= mapSize || tj >= mapSize || ti < 0 || tj < 0)
            {
                return false;
            }
            return true;
        }

        public void ActivateAllButtons()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    buttons[i, j].Enabled = true;
                }
            }
        }

        public void DeactivateAllButtons()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    
                    buttons[i, j].Enabled = false;
                    GetPrevButtonColor(buttons[i, j]);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            
            
        }
        private void StartGame()
        {
            Form2 gameStarter = new Form2();
            gameStarter.ShowDialog();
            this.isOnePlayer = gameStarter.isOnePlayer;
            this.timer = gameStarter.timer;
            whitetimer = timer * 60; blacktimer = timer * 60;
            StartTimer();
            gameStarter.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(currentPlayer==1)
            {
                whitetimer--;
                int minutes = whitetimer / 60;
                int seconds = whitetimer % 60;

                string timeString = $"{minutes:D2}:{seconds:D2}";
                whitetimertb.Text = timeString;
            }
            else
            {
                blacktimer--;
                int minutes = blacktimer / 60;
                int seconds = blacktimer % 60;

                string timeString = $"{minutes:D2}:{seconds:D2}";
                blacktimertb.Text = timeString;
            }
        }

       
    }
}