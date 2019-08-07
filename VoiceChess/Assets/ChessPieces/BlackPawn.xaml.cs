using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for BlackPawn.xaml
    /// </summary>
    public partial class BlackPawn : UserControl
    {
        public BlackPawn()
        {
            InitializeComponent();
        }

        private string _color = "Black";
        private bool _firstmove = new bool();

        public bool HasTakenFirstMove
        {
            get { return this._firstmove; }
            set { this._firstmove = value; }
        }
        
        public string PieceColor
        {
            get { return this._color; }
        }

    }
}
