using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_____rensyu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //============
        // ﾒﾝﾊﾞｰ変数
        // グラフィック用オブジェクト
        // o-o-o-o-o
        private Graphics gr;
        // *** ***
        // 画像オブジェクト
        private Image BackgroundImg; // 背景画像
        private Image CharacterImg; // ｷｬﾗｸﾀｰ画像
        // 透明色指定用オブジェクト
        private System.Drawing.Imaging.ImageAttributes ImgAttr;
        // ｷｬﾗｸﾀｰ位置
        private Point CharaPosition; // ｷｬﾗｸﾀｰ位置
        private Point BackPosition; // ｷｬﾗｸﾀｰ位置
        // ｷｬﾗｸﾀｰx、y軸進行方向
        private bool XDirection; // ｷｬﾗｸﾀｰx軸進行方向(true:右 / false:左)
        private bool YDirection; // ｷｬﾗｸﾀｰy軸進行方向(true:下 / false:上)



        //============
        // ﾌｫｰﾑﾛｰﾄﾞ時用ｲﾍﾞﾝﾄ
        private void Form2_Load(object sender, EventArgs e)
        {
            // グラフィック用オブジェクトを生成
            gr = pictureBox1.CreateGraphics();

            //画像指定
            BackgroundImage = new Bitmap("C:\\Users\\Daiki\\Documents\\Visual Studio 2015\\Projects\\C++++_rensyu\\背景.bmp");//背景
            CharacterImg = new Bitmap("C:\\Users\\Daiki\\Documents\\Visual Studio 2015\\Projects\\C++++_rensyu\\キャラクター.bmp");//キャラ
            
            //透明色指定(白を指定)
            ImgAttr = new System.Drawing.Imaging.ImageAttributes();
            ImgAttr.SetColorKey(Color.White, Color.White);//白から白までの範囲

            //キャラクターポジションの初期化
            CharaPosition = new Point();
            CharaPosition.X = 0;
            CharaPosition.Y = 0;

            BackPosition = new Point();
            BackPosition.X = 0;
            BackPosition.Y = 0;
            //タイマー初期化
            timer1.Enabled = false;//タイマー停止状態で初期化
            timer1.Interval = 100;//タイマーイベントの間隔
        }

        //============
        // ﾌｫｰﾑ終了時用ｲﾍﾞﾝﾄ
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //各種画像用リソースを解放
            BackgroundImage.Dispose();
            CharacterImg.Dispose();
        }

        //============
        // ﾎﾞﾀﾝｸﾘｯｸ用ｲﾍﾞﾝﾄ
        private void button1_Click(object sender, EventArgs e)
        {
            //タイマースタート
            timer1.Enabled = true;//タイマー作動開始
        }

        //============
        // ﾀｲﾏｰ用ｲﾍﾞﾝﾄ
        private void timer1_Tick(object sender, EventArgs e)
        {
            //背景画像の描画
            gr.DrawImage(BackgroundImage, new Rectangle(BackPosition, pictureBox1.Size));

            //キャラクターの描画
            gr.DrawImage(CharacterImg, new Rectangle(CharaPosition,CharacterImg.Size),0,0,CharacterImg.Width,CharacterImg.Height,GraphicsUnit.Pixel,ImgAttr);

            MovePosition();
        }

        public void MovePosition()
        {

        }
    }
}
