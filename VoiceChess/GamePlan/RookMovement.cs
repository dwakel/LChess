using VoiceChess.Assets.ChessPieces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace VoiceChess.GamePlan
{

    public class RookMovement : PieceMovement
    {
        public static string RookPosition { get; set; }
        private static bool shouldContinueHighlighting = true;
        private static bool metBlack = false;
        private static bool metWhite = false;
        private static bool hasFirstChangedTakenPlace = false;
        private static byte countFirstChange = 0;


        public static void GetRookPosition(string rookposition)
        {
            RookPosition = rookposition;
        }
        //private static bool checkingMove;
        //public bool CheckingMove { get; set; }

        public override List<string> HighlightMovementPath()
        {
            var baseVal = base.HighlightMovementPath();

            char firstAlphabet = RookPosition[0];
            char secondAlphabet = RookPosition[1];
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
                    for (int n = 1; n <= 7; n++)
                    {
                        
                            AssignTheColor(0, n);
                            AssignTheColor(0, -n);

                    }

                    for (int m = 1; m <= 7; m++)
                    {
                        AssignTheColor(m, 0);
                        AssignTheColor(-m, 0);
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

        public static void MoveRook(StackPanel pieceLoc, Grid ChessBoard, out Dictionary<StackPanel, Brush> prevBoxCol)
        {
            
            var previousOriginalBoxColors = new Dictionary<StackPanel, Brush>();
            var rm = new RookMovement();
            GetRookPosition(pieceLoc.Name);

            var grenColorPlacement = rm.HighlightMovementPath();
            List<string> list = grenColorPlacement.ToList<string>().Distinct().ToList<string>();
            var fstAlp = list[0][0];
             
            foreach (var item in list)
            {
                System.Diagnostics.Debug.WriteLine(item);
                foreach (var item2 in ChessBoard.Children)
                    if (item2.GetType() == typeof(StackPanel))
                    {
                        
                        var item3 = (StackPanel)item2;
                        bool didFirstChangeJustHappen = false;
                        //// foreach (StackPanel item2 in ChessBoard.Children) 
                        ////for(int i = 0; i < ChessBoard.Children.Capacity; i++) 
                        var typeOfPieceLoc = pieceLoc.Children[0].GetType();
                        if ((item3.Name == item))
                        {
                            
                                if (didFirstChangeJustHappen == false)
                                {
                                    if (item3.Name[0] != fstAlp)
                                    {
                                        didFirstChangeJustHappen = true;
                                        metWhite = false;
                                        metBlack = false;
                                    }
                                }

                            if (countFirstChange < 1)
                            {
                                if (didFirstChangeJustHappen == true)
                                {
                                    shouldContinueHighlighting = true;
                                    countFirstChange = 1;
                                }
                            }

                            if (typeOfPieceLoc == typeof(BlackRook))
                            {
                                if (item3.Children.Count > 0)
                                {
                                    //Black Piece
                                    if ((item3.Children.Count > 0) && (item3.Children[0].GetType() == typeof(BlackPawn)) ||
                                    (item3.Children[0].GetType() == typeof(BlackQueen)) ||
                                    (item3.Children[0].GetType() == typeof(BlackKnight))||
                                    (item3.Children[0].GetType() == typeof(BlackKing)) ||
                                    (item3.Children[0].GetType() == typeof(BlackRook)) ||
                                    (item3.Children[0].GetType() == typeof(BlackBishop)))
                                    {
                                        metBlack = true;
                                        if (hasFirstChangedTakenPlace == false)
                                            if (item3.Name[0] != fstAlp)
                                                hasFirstChangedTakenPlace = true;
                                       
                                        shouldContinueHighlighting = false;
                                        break;
                                    }

                                    //White piece
                                    else if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(WhiteRook) ||
                                    item3.Children[0].GetType() == typeof(WhiteQueen) ||
                                    item3.Children[0].GetType() == typeof(WhiteKnight) ||
                                    item3.Children[0].GetType() == typeof(WhitePawn) ||
                                    item3.Children[0].GetType() == typeof(WhiteBishop) ||
                                    item3.Children[0].GetType() == typeof(WhiteKing))
                                         {
                                            if (hasFirstChangedTakenPlace == false)
                                            {
                                                if ((item3.Name[0] != fstAlp) && (shouldContinueHighlighting == true))
                                                {

                                                    if (metBlack | metWhite)
                                                        shouldContinueHighlighting = false;

                                                    else
                                                    {
                                                        shouldContinueHighlighting = false;
                                                        previousOriginalBoxColors.Add(item3, item3.Background);
                                                        item3.Background = new SolidColorBrush(Colors.Red);

                                                    }
                                                    break;

                                                }

                                                if((item3.Name[0] != fstAlp) && (shouldContinueHighlighting == false))
                                                {
                                                    
                                                    break;
                                                }

                                            }
                                            else
                                            {
                                                if ((shouldContinueHighlighting == true))
                                                {

                                                if (metBlack || metWhite)
                                                    shouldContinueHighlighting = false;

                                                else
                                                {
                                                    shouldContinueHighlighting = false;
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);

                                                }
                                                break;

                                            }
                                                if ((shouldContinueHighlighting == false))
                                                {
                                                    
                                                    break;
                                                }
                                            }



                                            shouldContinueHighlighting = false;
                                            metWhite = true;
                                         }
                                }

                                //Empty space
                                else
                                {
                                    if (hasFirstChangedTakenPlace == false)
                                    {
                                        if ((item3.Name[0] == fstAlp) && (shouldContinueHighlighting == true))
                                        {
                                            if (metBlack || metWhite)
                                                shouldContinueHighlighting = false;

                                            else
                                            {
                                                shouldContinueHighlighting = true;
                                                previousOriginalBoxColors.Add(item3, item3.Background);
                                                item3.Background = new SolidColorBrush(Colors.Green);
                                                
                                            }
                                            break;
                                        }
                                        if ((item3.Name[0] != fstAlp) && (shouldContinueHighlighting == false))
                                        {
                                            shouldContinueHighlighting = false;
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        if ((shouldContinueHighlighting == true))
                                        {

                                            if (metBlack | metWhite)
                                                shouldContinueHighlighting = false;

                                            else
                                            {
                                                shouldContinueHighlighting = true;
                                                previousOriginalBoxColors.Add(item3, item3.Background);
                                                item3.Background = new SolidColorBrush(Colors.Green);

                                            }
                                            break;

                                        }
                                        if ((shouldContinueHighlighting == false))
                                        {

                                            break;
                                        }
                                    }


                                }

                               
                            }

#region white
                            if (typeOfPieceLoc == typeof(WhiteRook))
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
                                        if (hasFirstChangedTakenPlace == false)
                                        {
                                            if ((item3.Name[0] != fstAlp) && (shouldContinueHighlighting == true))
                                            {

                                                if (metBlack | metWhite)
                                                    shouldContinueHighlighting = false;

                                                else
                                                {
                                                    shouldContinueHighlighting = false;
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);

                                                }
                                                break;

                                            }

                                            if ((item3.Name[0] != fstAlp) && (shouldContinueHighlighting == false))
                                            {

                                                break;
                                            }

                                        }
                                        else
                                        {
                                            if ((shouldContinueHighlighting == true))
                                            {

                                                if (metBlack || metWhite)
                                                    shouldContinueHighlighting = false;

                                                else
                                                {
                                                    shouldContinueHighlighting = false;
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);

                                                }
                                                break;

                                            }
                                            if ((shouldContinueHighlighting == false))
                                            {

                                                break;
                                            }
                                        }



                                        shouldContinueHighlighting = false;
                                        metBlack = true;
                                       
                                    }
                                    else if (item3.Children.Count > 0 && item3.Children[0].GetType() == typeof(WhitePawn) ||
                                          item3.Children[0].GetType() == typeof(WhiteQueen) ||
                                          item3.Children[0].GetType() == typeof(WhiteKnight) ||
                                          item3.Children[0].GetType() == typeof(WhiteRook) ||
                                          item3.Children[0].GetType() == typeof(WhiteBishop) ||
                                          item3.Children[0].GetType() == typeof(WhiteKing))
                                         {

                                        metWhite = true;
                                        if (hasFirstChangedTakenPlace == false)
                                            if (item3.Name[0] != fstAlp)
                                                hasFirstChangedTakenPlace = true;

                                        shouldContinueHighlighting = false;
                                        break;
                                    }
                                }
                                else
                                {
                                     if (hasFirstChangedTakenPlace == false)
                                    {
                                        if ((item3.Name[0] == fstAlp) && (shouldContinueHighlighting == true))
                                        {
                                            if (metBlack || metWhite)
                                                shouldContinueHighlighting = false;

                                            else
                                            {
                                                shouldContinueHighlighting = true;
                                                previousOriginalBoxColors.Add(item3, item3.Background);
                                                item3.Background = new SolidColorBrush(Colors.Green);
                                                
                                            }
                                            break;
                                        }
                                        if ((item3.Name[0] != fstAlp) && (shouldContinueHighlighting == false))
                                        {
                                            shouldContinueHighlighting = false;
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        if ((shouldContinueHighlighting == true))
                                        {

                                            if (metBlack | metWhite)
                                                shouldContinueHighlighting = false;

                                            else
                                            {
                                                shouldContinueHighlighting = true;
                                                previousOriginalBoxColors.Add(item3, item3.Background);
                                                item3.Background = new SolidColorBrush(Colors.Green);

                                            }
                                            break;

                                        }
                                        if ((shouldContinueHighlighting == false))
                                        {

                                            break;
                                        }
                                    }
                                }
                            }
#endregion
                        }

                    }
                
            }
            prevBoxCol = previousOriginalBoxColors;
            // code was here
            shouldContinueHighlighting = true;
            metBlack = false;
            metWhite = false;

        }

    }

}