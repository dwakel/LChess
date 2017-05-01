using LaeLaChess.Assets.ChessPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaeLaChess.GamePlan
{
     public class QueenMovement : PieceMovement
     {
        public static string QueenPosition { get; set; }

        public static void GetCurrentQueenPosition(string queenpostion)
        {
            QueenPosition = queenpostion;

        }
        public override List<string> HighlightMovementPath()
        {
            var baseVal = base.HighlightMovementPath();

            //string boardLoc = KnightPosition;
            char firstAlphabet = QueenPosition[0];
            char secondAlphabet = QueenPosition[1];
            var returnColorSet = new List<string>();
            char firstDigHolder;
            byte firstAlpha = new byte();
            short n_count = 0;

            foreach (var item in BoardTranscription)
            {
                if (item.Key == firstAlphabet.ToString())
                    firstAlpha = (byte)item.Value;

                if (!firstAlpha.Equals(new byte()))
                {
                    for (int m = 0; m <= 7; m++)
                    {
                        for (int n = 0; n <= 7; n++)
                        {
                            if (m == n)
                            {
                                AssignTheColor(m, n);
                                AssignTheColor(-m, n);
                                AssignTheColor(m, -n);
                                AssignTheColor(-m, -n);
                            }
                        }
                    }

                    for (int m = 0; m <= 7; m++)
                    {
                        AssignTheColor(m, 0);
                        AssignTheColor(-m, 0);
                    }

                    for (int n = 0; n <= 7; n++)
                    {
                        AssignTheColor(0, n);
                        AssignTheColor(0, -n);
                    }

                }


            }


            void AssignTheColor(int m, int n)
            {
                foreach (KeyValuePair<string, int> digit in BoardTranscription)
                {
                    System.Diagnostics.Debug.WriteLine((m + firstAlpha).ToString());
                    if (m + firstAlpha < 9 && m + firstAlpha > 0)
                    {
                        firstDigHolder = char.Parse((m + firstAlpha).ToString());
                        if (digit.Value == int.Parse((firstDigHolder).ToString()))
                            switch (digit.Key)
                            {
                                case "A":
                                    {
                                        firstDigHolder = 'A';
                                        returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "B":
                                    {
                                        firstDigHolder = 'B';
                                        returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "C":
                                    {
                                        firstDigHolder = 'C';
                                        returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "D":
                                    {
                                        firstDigHolder = 'D';
                                        returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "E":
                                    {
                                        firstDigHolder = 'E';
                                        returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "F":
                                    {
                                        firstDigHolder = 'F';
                                        returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "G":
                                    {
                                        firstDigHolder = 'G';
                                        returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "H":
                                    {
                                        firstDigHolder = 'H';
                                        returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                            }
                    }
                }
            }
            return returnColorSet;
        }


        public static void MoveQueen(StackPanel pieceLoc, Grid ChessBoard, out Dictionary<StackPanel, Brush> prevBoxCol)
        {
            var previousOriginalBoxColors = new Dictionary<StackPanel, Brush>();
            var qm = new QueenMovement();
            // MessageBox.Show("Hello" + pieceLoc.Name);
            GetCurrentQueenPosition(pieceLoc.Name);
            var grenColorPlacement = qm.HighlightMovementPath();
            var list = grenColorPlacement.ToList<string>().Distinct().ToList<string>();
            var fstAlp = list[0][0];
            var shouldContinueHighlighting = true;
            foreach (var item in list)
            {
                foreach (var item2 in ChessBoard.Children)
                    if (item2.GetType() == typeof(StackPanel))
                    {

                        var item3 = (StackPanel)item2;

                        /// foreach (StackPanel item2 in ChessBoard.Children)
                        ////for(int i = 0; i < ChessBoard.Children.Capacity; i++)
                        var typeOfPieceLoc = pieceLoc.Children[0].GetType();
                        if ((item3.Name == item))
                        {
                            if (typeOfPieceLoc == typeof(BlackQueen))
                            {
                                if (item3.Children.Count > 0)
                                {
                                    if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(BlackPawn) ||
                                        item3.Children[0].GetType() == typeof(BlackKing) ||
                                        item3.Children[0].GetType() == typeof(BlackKnight) ||
                                        item3.Children[0].GetType() == typeof(BlackRook) ||
                                        item3.Children[0].GetType() == typeof(BlackBishop))
                                    {
                                        if (item3.Name[0] != fstAlp)
                                        {
                                            shouldContinueHighlighting = false;
                                            fstAlp = item3.Name[0];
                                            break;
                                        }
                                        shouldContinueHighlighting = new bool();
                                        break;
                                    }





                                    else if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(WhitePawn) ||
                                            item3.Children[0].GetType() == typeof(WhiteQueen) ||
                                            item3.Children[0].GetType() == typeof(WhiteKnight) ||
                                            item3.Children[0].GetType() == typeof(WhiteRook) ||
                                            item3.Children[0].GetType() == typeof(WhiteBishop) ||
                                            item3.Children[0].GetType() == typeof(WhiteKing))
                                    {
                                        previousOriginalBoxColors.Add(item3, item3.Background);
                                        item3.Background = new SolidColorBrush(Colors.Red);
                                        break;
                                    }


                                }
                                else
                                {
                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                    item3.Background = new SolidColorBrush(Colors.Green);
                                    break;
                                }
                            }


                            if (typeOfPieceLoc == typeof(WhiteQueen))
                            {
                                if (item3.Children.Count > 0)
                                {
                                    if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(BlackPawn) ||
                                            item3.Children[0].GetType() == typeof(BlackQueen) ||
                                            item3.Children[0].GetType() == typeof(BlackKnight) ||
                                            item3.Children[0].GetType() == typeof(BlackRook) ||
                                            item3.Children[0].GetType() == typeof(BlackBishop) ||
                                            item3.Children[0].GetType() == typeof(BlackKing))
                                    {
                                        previousOriginalBoxColors.Add(item3, item3.Background);
                                        item3.Background = new SolidColorBrush(Colors.Red);
                                        break;
                                    }

                                    else if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(WhitePawn) ||
                                            item3.Children[0].GetType() == typeof(WhiteKnight) ||
                                            item3.Children[0].GetType() == typeof(WhiteRook) ||
                                            item3.Children[0].GetType() == typeof(WhiteBishop) ||
                                            item3.Children[0].GetType() == typeof(WhiteKing))
                                    {

                                        break;
                                    }
                                }
                                else
                                {
                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                    item3.Background = new SolidColorBrush(Colors.Green);
                                    break;
                                }
                            }
                        }

                    }
            }
            prevBoxCol = previousOriginalBoxColors;
        }
    }
}
