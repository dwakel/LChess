using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for BlackBishop.xaml
    /// </summary>
    public partial class BlackBishop : UserControl
    {
        public BlackBishop()
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
