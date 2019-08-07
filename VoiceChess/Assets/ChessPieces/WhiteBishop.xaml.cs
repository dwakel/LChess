using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for WhiteBishop.xaml
    /// </summary>
    public partial class WhiteBishop : UserControl
    {
        public WhiteBishop()
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
