using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for BlackQueen.xaml
    /// </summary>
    public partial class BlackQueen : UserControl
    {
        public BlackQueen()
        {
            InitializeComponent();
        }
        private string _color = "Black";
        public string PieceColor
        {
            get { return this._color; }
        }
    }
}
