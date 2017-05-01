using LaeLaChess.Assets.ChessPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LaeLaChess.GamePlan
{
    public class PawnMovement : PieceMovement
    {
        public static string PawnPosition { get; set; }
        public static bool HasTakenFirstMove { get; set; }
        public static  string PawnCol { get; set; }
        //public static (string leftA, string rightA) AtkPos { get; set; }
        public static void GetPawnCol( string col)
        {
            PawnCol = col;
        }
        
       // public static void GetAttackPawnPosition() { AtkPos }
        public static void GetCurrentPawnPosition(string pawnposition){ PawnPosition = pawnposition; }
        public static void CheckFirstMove(bool firstmove) { HasTakenFirstMove = firstmove; }
        public List<string> AttackPosition()
        {
            string boardLoc = PawnPosition;
            System.Diagnostics.Debug.WriteLine(boardLoc);
            char firstAplhabet = boardLoc[0];
            char secondAplhabet = boardLoc[1];
            var returnRedSet = new List<string>();

            int n = 1;
           
            int left = -2;
            Int16 acount = new Int16();
            var storetepBoardTRans = new List<string>();
            var getcount = new Int16();
            foreach (var item2 in BoardTranscription)
            {
                acount++;
                storetepBoardTRans.Add(item2.Key);
                if (item2.Key == firstAplhabet.ToString())
                    getcount = acount;
                    
            }
            if (PawnCol != "Black") n = -1;


            try
            {
                //right hand side
                var input = storetepBoardTRans[getcount];
                returnRedSet.Add((input).ToString() + ((int.Parse(secondAplhabet.ToString())) + n).ToString());

            }
            catch (Exception iorEx){/*do nothing it is normal*/}
            try
            {
                //left hand side
                var input = storetepBoardTRans[getcount + left];
                returnRedSet.Add((input).ToString() + ((int.Parse(secondAplhabet.ToString())) + n).ToString());
            }
            catch (Exception iorEx) { /* do nothing it is normal */}
           
            
            return returnRedSet;
        }
        public override List<string>HighlightMovementPath()
        {
            var hold = base.HighlightMovementPath();
            string boardLoc = PawnPosition;
            System.Diagnostics.Debug.WriteLine(boardLoc);
            char firstAplhabet = boardLoc[0];
            char secondAplhabet = boardLoc[1];
            var returnGreenSet = new List<string>();
            int n = new int();
            int m = new int();
            if (PawnCol == "Black")
            {
                n = 2;
                m = 1;
            }

            else
            {
                n = -1;
                m = -2;
            }

            foreach (var item2 in BoardTranscription)
                if (item2.Key == firstAplhabet.ToString())
                {
                    if (HasTakenFirstMove == new bool())
                    {
                        for (int i = m; i <= n; i++)
                        {
                            returnGreenSet.Add(item2.Key + (int.Parse(secondAplhabet.ToString()) + i) as string);
                        }
                    }
                    else
                    {
                        if (n > -1)
                            n = m;
                        returnGreenSet.Add(item2.Key + (int.Parse(secondAplhabet.ToString()) + n) as string);
                    }
                }
            var ret = returnGreenSet;

            return ret;

        }

        public static void MovePawn(object theSender, Grid ChessBoard, out Dictionary<StackPanel, Brush> prevBoxCol)
        {
            var previousOriginalBoxColors = new Dictionary<StackPanel, Brush>();
            var pieceLoc = theSender as StackPanel;
            PawnMovement pm = new PawnMovement();
            PawnMovement.GetCurrentPawnPosition(pieceLoc.Name);
            BlackPawn locChildB;
            WhitePawn locChildW;
            if (pieceLoc.Children[0].GetType() == typeof(BlackPawn))
            {
                locChildB = (BlackPawn)pieceLoc.Children[0];
                PawnMovement.CheckFirstMove(locChildB.HasTakenFirstMove);
                GetPawnCol(locChildB.PieceColor);
            }
            else
            {
                locChildW = (WhitePawn)pieceLoc.Children[0];
                PawnMovement.CheckFirstMove(locChildW.HasTakenFirstMove);
                GetPawnCol(locChildW.PieceColor);
            }
            
            var grenColorPlacement = pm.HighlightMovementPath();
            var attckPlacement = pm.AttackPosition();
            var list = grenColorPlacement.ToList<string>().Distinct().ToList<string>();
            var list2 = attckPlacement.ToList<string>().Distinct().ToList<string>();
            foreach (var item in list)
            {
                System.Diagnostics.Debug.WriteLine(item);
                foreach (var item2 in ChessBoard.Children)
                    if (item2.GetType() == typeof(StackPanel))
                    {

                        var item3 = (StackPanel)item2;
                        {
                            if ((item3.Name == item))
                            {
                                {
                                     previousOriginalBoxColors.Add(item3, item3.Background);
                                    item3.Background = new SolidColorBrush(Colors.Green);
                                    break;
                                }
                            }
                        }
                    }
                

            }
            foreach (var item in list2)
            {
                foreach (var item2 in ChessBoard.Children)
                    if (item2.GetType() == typeof(StackPanel))
                    {

                        var item3 = (StackPanel)item2;
                        {
                            if ((item3.Name == item))
                            {
                                if(item3.Children.Count > 0)
                                {
                                    var myClanType = item3.Children[0].GetType();
                                    switch (myClanType.Name)
                                    {
                                        case "BlackPawn":
                                            {
                                                var colorMember = (BlackPawn)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                    
                                                }
                                            }
                                            break;
                                        case "BlackKnight":
                                            {
                                                var colorMember = (BlackKnight)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "BlackRook":
                                            {
                                                var colorMember = (BlackRook)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "BlackQueen":
                                            {
                                                var colorMember = (BlackQueen)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "BlackKing":
                                            {
                                                var colorMember = (BlackKing)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "BlackBishop":
                                            {
                                                var colorMember = (BlackBishop)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "WhitePawn":
                                            {
                                                var colorMember = (WhitePawn)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "WhiteKnight":
                                            {
                                                var colorMember = (WhiteKnight)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "WhiteRook":
                                            {
                                                var colorMember = (WhiteRook)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "WhiteQueen":
                                            {
                                                var colorMember = (WhiteQueen)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "WhiteKing":
                                            {
                                                var colorMember = (WhiteKing)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;
                                        case "WhiteBishop":
                                            {
                                                var colorMember = (WhiteBishop)item3.Children[0];
                                                if (colorMember.PieceColor != PawnCol)
                                                {
                                                    previousOriginalBoxColors.Add(item3, item3.Background);
                                                    item3.Background = new SolidColorBrush(Colors.Red);
                                                }
                                            }
                                            break;

                                        default:
                                            break;
                                    }

                                    
                                    
                                    
                                   
                                    break;
                                }
                            }
                        }
                    }
            }
            prevBoxCol = previousOriginalBoxColors;

           
        }

        public static bool PawnPromotion(StackPanel SP)
        {
            var ans = new bool();
            if (SP.Children[0].GetType() == typeof(BlackPawn))
            {
                if (SP.Name[1] == '8')
                {
                    ans = true;
                }
            }
            if (SP.Children[0].GetType() == typeof(WhitePawn))
            {
                if (SP.Name[1] == '1')
                {
                    ans = true;
                }
            }
            return ans;

        }
        public static void PawnPromotion(string promoteTo, Type type, StackPanel currentSender, out StackPanel _currentSender)
        {
            
            switch (promoteTo)
            {
                case "Queen":

                    if (type == typeof(BlackPawn))
                    {
                        currentSender.Children.RemoveAt(0);
                        currentSender.Children.Add(new BlackQueen());
                    }
                    if (type == typeof(WhitePawn))
                    {
                        currentSender.Children.RemoveAt(0);
                        currentSender.Children.Add(new WhiteQueen());
                    }

                    break;
                case "Bishop":

                    if (type == typeof(BlackPawn))
                    {
                        currentSender.Children.RemoveAt(0);
                        currentSender.Children.Add(new BlackBishop());
                    }
                    if (type == typeof(WhitePawn))
                    {
                        currentSender.Children.RemoveAt(0);
                        currentSender.Children.Add(new WhiteBishop());
                    }

                    break;

                case "Knight":

                    if (type == typeof(BlackPawn))
                    {
                        currentSender.Children.RemoveAt(0);
                        currentSender.Children.Add(new BlackKnight());
                    }
                    if (type == typeof(WhitePawn))
                    {
                        currentSender.Children.RemoveAt(0);
                        currentSender.Children.Add(new WhiteKnight());
                    }

                    break;

                case "Rook":

                    if (type == typeof(BlackPawn))
                    {
                        currentSender.Children.RemoveAt(0);
                        currentSender.Children.Add(new BlackRook());
                    }
                    if (type == typeof(WhitePawn))
                    {
                        currentSender.Children.RemoveAt(0);
                        currentSender.Children.Add(new WhiteRook());
                    }

                    break;

                default:
                    break;
            }
            _currentSender = currentSender;
        }
        public PawnMovement() { }
       
    }
}
