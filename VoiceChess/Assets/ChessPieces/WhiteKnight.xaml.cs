using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for WhiteKnight.xaml
    /// </summary>
    public partial class WhiteKnight : UserControl
    {
        public WhiteKnight()
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
