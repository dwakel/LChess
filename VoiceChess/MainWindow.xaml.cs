using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using VoiceChess.GamePlan;
using VoiceChess.Assets.ChessPieces;
using System.Speech.Recognition;
using System.Speech.Synthesis;


namespace VoiceChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine _sre = new SpeechRecognitionEngine();
        public static Grammar _gr;
        Choices _clist = new Choices();
        SpeechSynthesizer _Ss = new SpeechSynthesizer();
        StackPanel _previousSender = new StackPanel();
        Dictionary<StackPanel, Brush> _previousOriginalBoxColors = new Dictionary<StackPanel, Brush>();
        int numberOfMove = 1;
        bool blackTurn = !new bool();
        bool whiteTurn = new bool();
        public string PromotedTo = string.Empty;
        StackPanel currentSender = new StackPanel();

        //string piecePosition;
        public MainWindow()
        {
            InitializeComponent();
            #region StartUp BlackPiece Arrangment  
            VoiceChess.Assets.ChessPieces.BlackRook Brook1 = new Assets.ChessPieces.BlackRook();
            VoiceChess.Assets.ChessPieces.BlackRook Brook2 = new Assets.ChessPieces.BlackRook();
            VoiceChess.Assets.ChessPieces.BlackKnight BKnight1 = new Assets.ChessPieces.BlackKnight();
            VoiceChess.Assets.ChessPieces.BlackKnight BKnight2 = new Assets.ChessPieces.BlackKnight();
            VoiceChess.Assets.ChessPieces.BlackBishop Bbish1 = new Assets.ChessPieces.BlackBishop();
            VoiceChess.Assets.ChessPieces.BlackBishop Bbish2 = new Assets.ChessPieces.BlackBishop();
            VoiceChess.Assets.ChessPieces.BlackQueen BQueen = new Assets.ChessPieces.BlackQueen();
            VoiceChess.Assets.ChessPieces.BlackKing BKing = new Assets.ChessPieces.BlackKing();
            VoiceChess.Assets.ChessPieces.BlackPawn BPawn1 = new Assets.ChessPieces.BlackPawn();
            VoiceChess.Assets.ChessPieces.BlackPawn BPawn2 = new Assets.ChessPieces.BlackPawn();
            VoiceChess.Assets.ChessPieces.BlackPawn BPawn3 = new Assets.ChessPieces.BlackPawn();
            VoiceChess.Assets.ChessPieces.BlackPawn BPawn4 = new Assets.ChessPieces.BlackPawn();
            VoiceChess.Assets.ChessPieces.BlackPawn BPawn5 = new Assets.ChessPieces.BlackPawn();
            VoiceChess.Assets.ChessPieces.BlackPawn BPawn6 = new Assets.ChessPieces.BlackPawn();
            VoiceChess.Assets.ChessPieces.BlackPawn BPawn7 = new Assets.ChessPieces.BlackPawn();
            VoiceChess.Assets.ChessPieces.BlackPawn BPawn8 = new Assets.ChessPieces.BlackPawn();





            A2.Children.Add(BPawn1);
            B2.Children.Add(BPawn2);
            C2.Children.Add(BPawn3);
            D2.Children.Add(BPawn4);
            E2.Children.Add(BPawn5);
            F2.Children.Add(BPawn6);
            G2.Children.Add(BPawn7);
            H2.Children.Add(BPawn8);

            A1.Children.Add(Brook1);
            B1.Children.Add(BKnight1);
            C1.Children.Add(Bbish1);
            D1.Children.Add(BQueen);
            E1.Children.Add(BKing);
            F1.Children.Add(Bbish2);
            G1.Children.Add(BKnight2);
            H1.Children.Add(Brook2);

            #endregion

            #region WhitePiece Starts here

            VoiceChess.Assets.ChessPieces.WhiteRook WRook1 = new Assets.ChessPieces.WhiteRook();
            VoiceChess.Assets.ChessPieces.WhiteRook Wrook2 = new Assets.ChessPieces.WhiteRook();
            VoiceChess.Assets.ChessPieces.WhiteKnight WKnight1 = new Assets.ChessPieces.WhiteKnight();
            VoiceChess.Assets.ChessPieces.WhiteKnight WKnight2 = new Assets.ChessPieces.WhiteKnight();
            VoiceChess.Assets.ChessPieces.WhiteBishop Wbish1 = new Assets.ChessPieces.WhiteBishop();
            VoiceChess.Assets.ChessPieces.WhiteBishop Wbish2 = new Assets.ChessPieces.WhiteBishop();
            VoiceChess.Assets.ChessPieces.WhiteQueen WQueen = new Assets.ChessPieces.WhiteQueen();
            VoiceChess.Assets.ChessPieces.WhiteKing WKing = new Assets.ChessPieces.WhiteKing();
            VoiceChess.Assets.ChessPieces.WhitePawn WPawn1 = new Assets.ChessPieces.WhitePawn();
            VoiceChess.Assets.ChessPieces.WhitePawn WPawn2 = new Assets.ChessPieces.WhitePawn();
            VoiceChess.Assets.ChessPieces.WhitePawn WPawn3 = new Assets.ChessPieces.WhitePawn();
            VoiceChess.Assets.ChessPieces.WhitePawn WPawn4 = new Assets.ChessPieces.WhitePawn();
            VoiceChess.Assets.ChessPieces.WhitePawn WPawn5 = new Assets.ChessPieces.WhitePawn();
            VoiceChess.Assets.ChessPieces.WhitePawn WPawn6 = new Assets.ChessPieces.WhitePawn();
            VoiceChess.Assets.ChessPieces.WhitePawn WPawn7 = new Assets.ChessPieces.WhitePawn();
            VoiceChess.Assets.ChessPieces.WhitePawn WPawn8 = new Assets.ChessPieces.WhitePawn();

            A8.Children.Add(WRook1);
            B8.Children.Add(WKnight1);
            C8.Children.Add(Wbish1);
            D8.Children.Add(WKing);
            E8.Children.Add(WQueen);
            F8.Children.Add(Wbish2);
            G8.Children.Add(WKnight2);
            H8.Children.Add(Wrook2);


            A7.Children.Add(WPawn1);
            B7.Children.Add(WPawn2);
            C7.Children.Add(WPawn3);
            D7.Children.Add(WPawn4);
            E7.Children.Add(WPawn5);
            F7.Children.Add(WPawn6);
            G7.Children.Add(WPawn7);
            H7.Children.Add(WPawn8);

            #endregion

            //Brook1.MouseMove += Pieces_MouseMove;

            var lang = Speech.CreateGrammar();
            _gr = new Grammar(lang);

          
            try
            {
                this._sre.RequestRecognizerUpdate();
                this._sre.LoadGrammar(_gr);
                this._sre.SpeechRecognized += Sre_SpeechRecognized;
                this._sre.SetInputToDefaultAudioDevice();
                this._sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Exception at grammer builder side", MessageBoxButton.OK);
            }

            
        }

        private void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var recCommands = e.Result;

            InteprateCommad(recCommands);

            void InteprateCommad(RecognitionResult comm)
            {
                if (comm.Text.Contains("move to"))
                {
                    var firstdig = comm.Semantics["firstDig"].Value.ToString();
                    System.Diagnostics.Debug.WriteLine(firstdig);
                    var secondDig = Convert.ToInt32(comm.Semantics["secondDig"].Value).ToString();
                    var commPieceLoc = firstdig.ToUpper() + secondDig;
                    foreach (StackPanel item in ChessBoard.Children)
                    {
                        if (item.Name == commPieceLoc)
                        {
                            Chess_MouseDown(sender: item, e: null);
                        }
                    }
                }

                else if(comm.Text.Contains("select"))
                {
                    var firstdig = comm.Semantics["PositionHighlightCall"].Value.ToString();
                    System.Diagnostics.Debug.WriteLine(firstdig);
                    var secondDig = Convert.ToInt32(comm.Semantics["SecondPositionHighlightCall"].Value).ToString();
                    var commPieceLoc = firstdig.ToUpper() + secondDig;
                    foreach (StackPanel item in ChessBoard.Children)
                    {
                        if (item.Name == commPieceLoc)
                        {

                            Chess_MouseDown(sender: item, e: null);
                          
                            break;
                        }
                    }
                }

                else if(comm.Text.Contains("promote to"))
                {
                    var promotedTo = comm.Semantics["Promotion"].Value.ToString();
                    foreach (Button item in Promotions.Children)
                    {
                        if (item.Name == promotedTo)
                        {
                            Promotion_Click(sender: item, e: null);
                            break;
                        }
                    }
                }

                else if(comm.Text.Contains("reset board"))
                {
                    Reset_Click(sender: null, e: null);
                }
            }
        }



        public StackPanel PreviousSender
        {
            get{ return this._previousSender;}
            set{ this._previousSender = value; }
        }

        private List<StackPanel> PieceSenderRecord = new List<StackPanel>();

        

        private void Chess_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            StackPanel pieceLoc = sender as StackPanel;

            PieceSenderRecord.Add(pieceLoc);

            if (pieceLoc.Children.Count > 0)
            {

                    foreach (var item in this._previousOriginalBoxColors)
                    {
                    if (item.Key.Background.ToString() == "#FFFF0000")
                        break;
                        item.Key.Background = item.Value;
                    }
                    if(pieceLoc.Background.ToString() != "#FFFF0000")
                    this._previousOriginalBoxColors.Clear();
               
                
                var itemType = pieceLoc.Children[0].GetType();
                switch (itemType.Name)
                {
                    case "BlackPawn":
                        if (blackTurn == new bool())
                            break;
                        PawnMovement.MovePawn(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "BlackKnight":
                            if (blackTurn == new bool())
                                break;
                            KnightMovement.MoveKnight(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;

                    case "BlackRook":
                        if (blackTurn == new bool())
                            break;
                        RookMovement.MoveRook(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "BlackQueen":
                        if (blackTurn == new bool())
                            break;
                        QueenMovement.MoveQueen(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "BlackKing":
                        if (blackTurn == new bool())
                            break;
                        KingMovement.MoveKing(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "BlackBishop":
                        if (blackTurn == new bool())
                            break;
                        BishopMovement.MoveBishop(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                        
                    case "WhitePawn":
                        if (whiteTurn == new bool())
                            break;
                        PawnMovement.MovePawn(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "WhiteKing":
                        if (whiteTurn == new bool())
                            break;
                        KingMovement.MoveKing(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "WhiteKnight":
                        if (whiteTurn == new bool())
                            break;
                        KnightMovement.MoveKnight(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "WhiteQueen":
                        if (whiteTurn == new bool())
                            break;
                        QueenMovement.MoveQueen(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "WhiteRook":
                        if (whiteTurn == new bool())
                            break;
                        RookMovement.MoveRook(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    case "WhiteBishop":
                        if (whiteTurn == new bool())
                            BishopMovement.MoveBishop(pieceLoc, ChessBoard, out _previousOriginalBoxColors);
                        break;
                    default:
                        break;
                }
            }

            if (pieceLoc.Background.ToString() == "#FF008000")
            {
                try
                {
                    var piecesenderIndex = PieceSenderRecord.Count;
                    var previousMove = PieceSenderRecord[piecesenderIndex - 2];
                    var childRelay = previousMove.Children[0];
                    previousMove.Children.RemoveAt(0);
                    pieceLoc.Children.Add(childRelay);


                    var shouldPromote = PawnMovement.PawnPromotion(pieceLoc);
                    if (shouldPromote)
                    {

                        Promotions.IsEnabled = true;
                        ChessBoard.IsEnabled = false;

                    }
                    if (childRelay.GetType() == typeof(BlackPawn))
                    {
                        var bP = (BlackPawn)childRelay;
                        bP.HasTakenFirstMove = true;

                    }
                    if (childRelay.GetType() == typeof(WhitePawn))
                    {
                        var wP = (WhitePawn)childRelay;
                        wP.HasTakenFirstMove = true;

                    }
                    if (numberOfMove % 2 == 1)
                    {
                        blackTurn = new bool();
                        whiteTurn = true;
                        numberOfMove++;
                    }
                    else //if (numberOfMove % 2 == 0)
                    {
                        blackTurn = true;
                        whiteTurn = new bool();
                        numberOfMove++;
                    }

                    foreach (var item in this._previousOriginalBoxColors)
                    {
                        item.Key.Background = item.Value;
                    }
                }
                catch (Exception)
                {
                    //do nothing
                }

            }

            if(pieceLoc.Background.ToString() == "#FFFF0000")
            {
                var piecesenderIndex = PieceSenderRecord.Count;
                var previousMove = PieceSenderRecord[piecesenderIndex - 2];
                var childRelay = previousMove.Children[0];
                previousMove.Children.RemoveAt(0);
                var defeatRelay = pieceLoc.Children[0];
                pieceLoc.Children.RemoveAt(0);
                SideBoard.Children.Add(defeatRelay);
                
                pieceLoc.Children.Add(childRelay);
                var shouldPromote = PawnMovement.PawnPromotion(pieceLoc);
                if (shouldPromote)
                {
                    Promotions.IsEnabled = true;
                    ChessBoard.IsEnabled = false;
                    currentSender = pieceLoc;
                }
                if (childRelay.GetType() == typeof(BlackPawn))
                {
                    var bP = (BlackPawn)childRelay;
                    bP.HasTakenFirstMove = true;

                }
                if (childRelay.GetType() == typeof(WhitePawn))
                {
                    var wP = (WhitePawn)childRelay;
                    wP.HasTakenFirstMove = true;

                }

                if (numberOfMove % 2 == 1)
                {
                    blackTurn = new bool();
                    whiteTurn = true;
                    numberOfMove++;
                }
                else//if(numberOfMove % 2 == 0)
                {
                    blackTurn = true;
                    whiteTurn = new bool();
                    numberOfMove++;
                }

                foreach (var item in this._previousOriginalBoxColors)
                {
                    item.Key.Background = item.Value;
                }

                //hasFirstConditionRun = true;
            }
        }

       

        private void Promotion_Click(object sender, RoutedEventArgs e)
        {
            var promoteTo = sender as Button;
            var type = currentSender.Children[0].GetType();

            PawnMovement.PawnPromotion(promoteTo.Name, type, currentSender, out currentSender);

            Promotions.IsEnabled = false; 
            ChessBoard.IsEnabled = true;

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
           
            this.Close();
            mw.ShowDialog();
           
        }
    }
}