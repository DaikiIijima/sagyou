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


namespace C_____rensyu.MainForm
{
    //画面IDの登録
    [View(Views.Menu)]

    public partial class MenView : ControlViewBase
    {
        public MenView()
        {
            InitializeComponent();
        }

        //Foo画面へ推移
        private void button1_Click(object sender, EventArgs e)
        {
            Controller.Forward(Views.Foo);
        }

        //Bar画面へ推移
        private void button2_Click(object sender, EventArgs e)
        {
            Controller.Forward(Views.Bar);
        }

        //推移終了
        private void button3_Click(object sender, EventArgs e)
        {
            Controller.Exit();
        }
    }
}
