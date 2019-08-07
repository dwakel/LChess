using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for BlackKnight.xaml
    /// </summary>
    public partial class BlackKnight : UserControl
    {
        public BlackKnight()
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
