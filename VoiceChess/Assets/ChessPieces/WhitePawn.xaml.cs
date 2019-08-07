using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for WhitePawn.xaml
    /// </summary>
    public partial class WhitePawn : UserControl
    {
        public WhitePawn()
        {
            InitializeComponent();
        }
        private string _color = "white";
        private bool _firstmove = new bool();

        public bool HasTakenFirstMove
        {
            get { return this._firstmove; }
            set {this._firstmove = value;}
        }
        public string PieceColor
        {
            get { return this._color; }
        }
    }
}
