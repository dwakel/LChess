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
