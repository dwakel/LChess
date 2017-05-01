using LaeLaChess.Assets.ChessPieces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaeLaChess.GamePlan
{
    public class BishopMovement : PieceMovement
    {
        public static string BishopPosition { get; set; }

        public static void GetBishopPosition(string bishopposition)
        {
            BishopPosition = bishopposition;
        }

        public override List<string> HighlightMovementPath()
        {
            var baseVal = base.HighlightMovementPath();

            char firstAlphabet = BishopPosition[0];
            char secondAlphabet = BishopPosition[1];
            var returnGreenSet = new List<string>();
            char firstDigHolder = new char();
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

                    
                    


                }

                
            }
            return returnGreenSet;


            void AssignTheColor(int m, int n)
            {
                foreach (KeyValuePair<string, int> digit in BoardTranscription)
                {
                    if ((m + firstAlpha < 10) && (m + firstAlpha > 0))
                    {
                        firstDigHolder = char.Parse((m + firstAlpha).ToString());
                        if (digit.Value == int.Parse((firstDigHolder).ToString()))
                            switch (digit.Key)
                            {
                                case "A":
                                    {
                                        firstDigHolder = 'A';
                                        returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "B":
                                    {
                                        firstDigHolder = 'B';
                                        returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "C":
                                    {
                                        firstDigHolder = 'C';
                                        returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "D":
                                    {
                                        firstDigHolder = 'D';
                                        returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "E":
                                    {
                                        firstDigHolder = 'E';
                                        returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "F":
                                    {
                                        firstDigHolder = 'F';
                                        returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "G":
                                    {
                                        firstDigHolder = 'G';
                                        returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                                case "H":
                                    {
                                        firstDigHolder = 'H';
                                        returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                        n_count += 1;
                                    }
                                    break;
                            }
                    }
                }
            }

        }
        public static void MoveBishop(StackPanel pieceLoc, Grid ChessBoard, out Dictionary<StackPanel, Brush> prevBoxCol)
        {
            var previousOriginalBoxColors = new Dictionary<StackPanel, Brush>();
            var rm = new BishopMovement();
            GetBishopPosition(pieceLoc.Name);

            var grenColorPlacement = rm.HighlightMovementPath();
            List<string> list = grenColorPlacement.ToList<string>().Distinct().ToList<string>();
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

                            if (typeOfPieceLoc == typeof(BlackBishop))
                            {
                                if (item3.Children.Count > 0)
                                {
                                    if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(BlackPawn) ||
                                        item3.Children[0].GetType() == typeof(BlackQueen) ||
                                        item3.Children[0].GetType() == typeof(BlackKnight) ||
                                        item3.Children[0].GetType() == typeof(BlackKing) ||
                                        item3.Children[0].GetType() == typeof(BlackRook) ||
                                        item3.Children[0].GetType() == typeof(BlackBishop))
                                    {
                                       
                                      

                                        break;
                                    }
                                    else if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(WhiteRook) ||
                                              item3.Children[0].GetType() == typeof(WhiteQueen) ||
                                              item3.Children[0].GetType() == typeof(WhiteKnight) ||
                                              item3.Children[0].GetType() == typeof(WhitePawn) ||
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


                            if (typeOfPieceLoc == typeof(WhiteBishop))
                            {
                                if (item3.Children.Count > 0)
                                {
                                    if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(BlackPawn) ||
                                            item3.Children[0].GetType() == typeof(BlackQueen) ||
                                            item3.Children[0].GetType() == typeof(BlackKnight) ||
                                            item3.Children[0].GetType() == typeof(BlackRook) ||
                                            item3.Children[0].GetType() == typeof(BlackKing) ||
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
