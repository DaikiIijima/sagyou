using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_____rensyu
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //新しいウィンドウを作ったらここに記述しないと動かない
            //Application.Run(new Form1());
            //Application.Run(new Form2());
            Application.Run(new MainForm1());
        }
    }
}
