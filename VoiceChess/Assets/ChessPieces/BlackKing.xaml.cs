using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for BlackKing.xaml
    /// </summary>
    public partial class BlackKing : UserControl
    {
        public BlackKing()
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
