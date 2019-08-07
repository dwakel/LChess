using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for WhiteKing.xaml
    /// </summary>
    public partial class WhiteKing : UserControl
    {
        public WhiteKing()
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
