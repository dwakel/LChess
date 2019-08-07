using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for WhiteRook.xaml
    /// </summary>
    public partial class WhiteRook : UserControl
    {
        public WhiteRook()
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
