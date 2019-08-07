using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for WhiteQueen.xaml
    /// </summary>
    public partial class WhiteQueen : UserControl
    {
        public WhiteQueen()
        {
            InitializeComponent();
        }

        private string _color = "White";
        public string PieceColor
        {
            get { return this._color; }
        }
    }
}
