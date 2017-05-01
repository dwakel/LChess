using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaeLaChess.Assets.ChessPieces
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
