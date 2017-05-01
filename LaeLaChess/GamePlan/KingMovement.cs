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
    public class KingMovement :PieceMovement
    {

        public static string KingPosition { get; set; }

        public static void GetCurrentKingPosition(string kingpostion)
        {
            KingPosition = kingpostion;

        }


        public override List<string> HighlightMovementPath()
        {

            var baseVal = base.HighlightMovementPath();

            //string boardLoc = KnightPosition;
            char firstAlphabet = KingPosition[0];
            char secondAlphabet = KingPosition[1];
            var returnColorSet = new List<string>();
            char firstDigHolder;
            byte firstAlpha = new byte();
            short n_count = 0;

            foreach (var item in BoardTranscription) {
                if (item.Key == firstAlphabet.ToString())
                    firstAlpha = (byte)item.Value;

                if (!firstAlpha.Equals(new byte())) {
                    // int n = new int();//initialized to 0
                   
                    //////first intance

                    AssigningTheColor(0, 1);
                    AssigningTheColor(0, -1);

                    AssigningTheColor(1, 0);
                    AssigningTheColor(-1, 0);


                    AssigningTheColor(1, 1);
                    AssigningTheColor(1, -1);
                    AssigningTheColor(-1, 1);
                    AssigningTheColor(-1, -1);



                }





            }


            void AssigningTheColor(int m, int n)
            {
                foreach (KeyValuePair<string, int> digit in BoardTranscription) {
                    firstDigHolder = char.Parse((m + firstAlpha).ToString());
                    if (digit.Value == int.Parse((firstDigHolder).ToString()))
                        switch (digit.Key) {
                            case "A": {
                                    firstDigHolder = 'A';
                                    returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                    n_count += 1;
                                }
                                break;
                            case "B": {
                                    firstDigHolder = 'B';
                                    returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                    n_count += 1;
                                }
                                break;
                            case "C": {
                                    firstDigHolder = 'C';
                                    returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                    n_count += 1;
                                }
                                break;
                            case "D": {
                                    firstDigHolder = 'D';
                                    returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                    n_count += 1;
                                }
                                break;
                            case "E": {
                                    firstDigHolder = 'E';
                                    returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                    n_count += 1;
                                }
                                break;
                            case "F": {
                                    firstDigHolder = 'F';
                                    returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                    n_count += 1;
                                }
                                break;
                            case "G": {
                                    firstDigHolder = 'G';
                                    returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                    n_count += 1;
                                }
                                break;
                            case "H": {
                                    firstDigHolder = 'H';
                                    returnColorSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                    n_count += 1;
                                }
                                break;
                        }
                }
            }


            return returnColorSet;
            
        }


        public static void MoveKing(StackPanel pieceLoc, Grid ChessBoard, out Dictionary<StackPanel, Brush> prevBoxCol)
        {
            var previousOriginalBoxColors = new Dictionary<StackPanel, Brush>();
            var km = new KingMovement();
            // MessageBox.Show("Hello" + pieceLoc.Name);
            GetCurrentKingPosition(pieceLoc.Name);
            var grenColorPlacement = km.HighlightMovementPath();
            var list = grenColorPlacement.ToList<string>().Distinct().ToList<string>();
            var fstAlp = list[0][0];
            var shouldContinueHighlighting = true;
            foreach (var item in list)
            {
                System.Diagnostics.Debug.WriteLine(item);
                foreach (var item2 in ChessBoard.Children)
                    if (item2.GetType() == typeof(StackPanel))
                    {

                        var item3 = (StackPanel)item2;

                        /// foreach (StackPanel item2 in ChessBoard.Children)
                        ////for(int i = 0; i < ChessBoard.Children.Capacity; i++)
                        var typeOfPieceLoc = pieceLoc.Children[0].GetType();
                            if ((item3.Name == item))
                            {
                                    if (typeOfPieceLoc == typeof(BlackKing))
                                    {
                                    if (item3.Children.Count > 0)
                                    {
                                        if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(BlackPawn) ||
                                            item3.Children[0].GetType() == typeof(BlackQueen) ||
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


                            if (typeOfPieceLoc == typeof(WhiteKing))
                            {
                                if (item3.Children.Count > 0)
                                {
                                    if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(BlackPawn) ||
                                            item3.Children[0].GetType() == typeof(BlackQueen) ||
                                            item3.Children[0].GetType() == typeof(BlackKnight) ||
                                            item3.Children[0].GetType() == typeof(BlackRook) ||
                                            item3.Children[0].GetType() == typeof(BlackBishop))
                                    {
                                        previousOriginalBoxColors.Add(item3, item3.Background);
                                        item3.Background = new SolidColorBrush(Colors.Red);
                                        break;
                                    }

                                    else if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(WhitePawn) ||
                                            item3.Children[0].GetType() == typeof(WhiteQueen) ||
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
