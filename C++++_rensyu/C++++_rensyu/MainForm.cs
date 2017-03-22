using Smart.Windows.Mvc;
using System.Reflection;
using System.Windows.Forms;
using C_____rensyu.Properties;

namespace C_____rensyu
{

    public partial class MainForm1 : Form
    {

        //画面推移コントローラー
        private readonly Controller controller;

        public MainForm1()
        {
            InitializeComponent();

            //コントローラーの初期化
            controller = new Controller(new ControlViewProvider(ViewPanel));
            controller.Forwarding += OnForwarding;
            controller.Exited += OnExited;

            //画面自動登録
            controller.AutoRegister(Assembly.GetExecutingAssembly());

            //最初の画面へ推移
            Show();
            controller.Forward(Views.Menu);
        }

        //画面推移イベント
        private void OnForwarding(object sender, ViewForwardEventArgs e)
        {

        }

        //コントローラー終了イベント
        private void OnExited(object sender, ViewExitEventArgs e)
        {
            Close();
        }
    }
}
