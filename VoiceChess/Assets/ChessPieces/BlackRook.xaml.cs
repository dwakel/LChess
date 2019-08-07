using System.Windows.Controls;

namespace VoiceChess.Assets.ChessPieces
{
    /// <summary>
    /// Interaction logic for BlackRook.xaml
    /// </summary>
    public partial class BlackRook : UserControl
    {
        public BlackRook()
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
