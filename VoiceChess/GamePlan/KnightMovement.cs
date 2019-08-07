using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace VoiceChess.GamePlan
{
    public class KnightMovement : PieceMovement
    {
        public static string KnightPosition { get; set; }
        public static void GetCurrentKnightPosition(string knightposition)
        {
            KnightPosition = knightposition;
        }

        public override List<string> HighlightMovementPath()
        {
            var baseVal = base.HighlightMovementPath(); 
            
            //string boardLoc = KnightPosition;
            char firstAlphabet = KnightPosition[0];
            char secondAlphabet = KnightPosition[1];
            var returnGreenSet = new List<string>();
            char firstDigHolder;
            byte firstAlpha = new byte();
            short n_count = -1;

            foreach (var item in BoardTranscription)
            {
                if (item.Key == firstAlphabet.ToString())
                    firstAlpha = (byte)item.Value;

                if (!firstAlpha.Equals(new byte()))
                {
                    int n = new int();
                    int m = 1;
                /////FIRST INSTANCE OF THE LOOP
                    for (int i = 0 ; i <= 1; i++)
                    {
                        n = 2;
                        
                        //System.Diagnostics.Debug.WriteLine(firstDigHolder);
                        foreach (KeyValuePair<string, int> digit in BoardTranscription)
                        {
                            firstDigHolder = char.Parse((m + firstAlpha).ToString());
                            if (digit.Value == int.Parse((firstDigHolder).ToString()))
                                switch (digit.Key)
                                {
                                    case "A":
                                        {
                                            firstDigHolder = 'A';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "B":
                                        {
                                            firstDigHolder = 'B';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "C":
                                        {
                                            firstDigHolder = 'C';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "D":
                                        {
                                            firstDigHolder = 'D';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "E":
                                        {
                                            firstDigHolder = 'E';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "F":
                                        {
                                            firstDigHolder = 'F';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "G":
                                        {
                                            firstDigHolder = 'G';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "H":
                                        {
                                            firstDigHolder = 'H';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count+=2;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            if(returnGreenSet.Count == n_count)
                                break;
                        }

                    }
                    //// SECOND INSTANCE OF THE LOOPS
                    for (int i = 0; i <= 1; i++)
                    {
                        n = -2;
                        n_count--;
                        
                        foreach (KeyValuePair<string, int> digit in BoardTranscription)
                        {
                            firstDigHolder = char.Parse((m + firstAlpha).ToString());
                            if (digit.Value == int.Parse(firstDigHolder.ToString()))
                                switch (digit.Key)
                                {
                                    case "A":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'A';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "B":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'B';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "C":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'C';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "D":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'D';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "E":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'E';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "F":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'F';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "G":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'G';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "H":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'H';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            if (returnGreenSet.Count == n_count)
                                break;
                        }
                           // (n + int.Parse(secondAlphabet.ToString())).ToString();
                    }

                    m = -1;
                    /////THIRD INSTANCE OF THE LOOP
                    for (int i = 0; i <= 1; i++)
                    {
                        n = 2;
                        firstDigHolder = char.Parse((m + firstAlpha).ToString());
                        foreach (KeyValuePair<string, int> digit in BoardTranscription)
                        {
                            firstDigHolder = char.Parse((m + firstAlpha).ToString());
                            if (digit.Value == int.Parse(firstDigHolder.ToString()))
                                switch (digit.Key)
                                {
                                    case "A":
                                        {
                                            firstDigHolder = 'A';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "B":
                                        {
                                            firstDigHolder = 'B';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "C":
                                        {
                                            firstDigHolder = 'C';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "D":
                                        {
                                            firstDigHolder = 'D';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "E":
                                        {
                                            firstDigHolder = 'E';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "F":
                                        {
                                            firstDigHolder = 'F';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "G":
                                        {
                                            firstDigHolder = 'G';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    case "H":
                                        {
                                            firstDigHolder = 'H';
                                            returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                            n_count += 2;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            if (returnGreenSet.Count == n_count)
                                break;
                        }
                    }
                    //// FORTH INSTANCE OF THE LOOPS
                    for (int i = 0; i <= 1; i++)
                    {
                        n = -2;
                        
                        foreach (KeyValuePair<string, int> digit in BoardTranscription)
                        {
                            firstDigHolder = char.Parse((m + firstAlpha).ToString());
                            if (digit.Value == int.Parse(firstDigHolder.ToString()))
                                switch (digit.Key)
                                {
                                    case "A":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'A';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "B":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'B';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "C":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'C';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "D":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'D';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "E":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'E';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "F":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'F';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "G":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'G';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    case "H":
                                        {
                                            if (int.Parse(secondAlphabet.ToString()) + n <= 0)
                                            {
                                                n_count += 1;
                                                break;
                                            }
                                            else
                                            {
                                                firstDigHolder = 'H';
                                                returnGreenSet.Add(firstDigHolder + ((int.Parse(secondAlphabet.ToString()) + n).ToString()));
                                                n_count += 2;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            if (returnGreenSet.Count == n_count)
                                break;
                        }
                    }
            }
            }
            var ret = returnGreenSet;

            return ret;
         }



        public static void MoveKnight(StackPanel pieceLoc, Grid ChessBoard, out Dictionary<StackPanel, Brush> prevBoxCol)
        {
            var previousOriginalBoxColors = new Dictionary<StackPanel, Brush>();
            var km = new KnightMovement();
            // MessageBox.Show("Hello" + pieceLoc.Name);
            KnightMovement.GetCurrentKnightPosition(pieceLoc.Name);
            var grenColorPlacement = km.HighlightMovementPath();
            var list = grenColorPlacement.ToList<string>().Distinct();
            foreach (var item in list)
            {
                System.Diagnostics.Debug.WriteLine(item);
                foreach (var item2 in ChessBoard.Children)
                    if (item2.GetType() == typeof(StackPanel))
                    {

                        var item3 = (StackPanel)item2;
                        System.Diagnostics.Debug.WriteLine(item3);
                        System.Diagnostics.Debug.WriteLine(item3.Name);
                        /// foreach (StackPanel item2 in ChessBoard.Children)
                        ////for(int i = 0; i < ChessBoard.Children.Capacity; i++)
                        {
                            if ((item3.Name == item))
                            {
                                previousOriginalBoxColors.Add(item3, item3.Background);
                                item3.Background = new SolidColorBrush(Colors.Green);
                                break;



                            }
                        }
                    }
            }

            prevBoxCol = previousOriginalBoxColors;
        }


    }
        }