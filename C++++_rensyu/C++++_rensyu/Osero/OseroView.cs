using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart.Windows.Mvc;

namespace C_____rensyu.Osero
{
    //画面IDの登録
    [View(Views.Osero)]

    public partial class OseroView : UserControl
    {
        public OseroView()
        {
            InitializeComponent();
        }

        //使用するクラスのインスタンス化
        private OthBoard board = new OthBoard();
        private BoardCanvas bc;

        //初期化
        

    }
}
