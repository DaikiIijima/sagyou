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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //============
        // ﾒﾝﾊﾞｰ変数
        // 画像オブジェクト
        private Image BackgroundImg; // 背景画像
        private Image CharacterImg; // ｷｬﾗｸﾀｰ画像
        // ｷｬﾗｸﾀｰ位置
        private Point CharaPosition; // ｷｬﾗｸﾀｰ位置
        // ｷｬﾗｸﾀｰの速度
        private int CharaSpeed;
        // キーが下がっているのか、上がっているのか、その状態を示すフラグ
        private bool LeftKeyCondition;    // 左ｷｰ押下状態(true:押下 / false:非押下)
        private bool RightKeyCondition;   // 右ｷｰ押下状態(true:押下 / false:非押下)
        private bool TopKeyCondition;     // 上ｷｰ押下状態(true:押下 / false:非押下)
        private bool BottomKeyCondition;  // 下ｷｰ押下状態(true:押下 / false:非押下)


        //============
        // ﾌｫｰﾑﾛｰﾄﾞ時用ｲﾍﾞﾝﾄ
        private void Form1_Load(object sender, EventArgs e)
        {
            // 画像指定
            BackgroundImg = new Bitmap("C:\\Users\\Daiki\\Documents\\Visual Studio 2015\\Projects\\C++++_rensyu\\背景.bmp"); // 背景画像
            CharacterImg = new Bitmap("C:\\Users\\Daiki\\Documents\\Visual Studio 2015\\Projects\\C++++_rensyu\\キャラクター.bmp"); // ｷｬﾗｸﾀｰ画像
            // ｷｬﾗｸﾀｰ位置指定
            CharaPosition = new Point(); // ｷｬﾗｸﾀｰ位置
            CharaPosition.X = 0;    // x座標位置を0で初期化
            CharaPosition.Y = 0;    // y座標位置を0で初期化
            // ｷｬﾗｸﾀｰの速度
            CharaSpeed = 2;
            // ﾀｲﾏｰ初期化設定
            timer1.Interval = 100; // ﾀｲﾏｰｲﾍﾞﾝﾄの間隔
            timer1.Enabled = true; // ﾀｲﾏｰ作動開始の状態で初期化
            // キーが下がっているのか、上がっているのか、その状態を示すフラグ
            LeftKeyCondition = false;  // 左ｷｰ押下状態(true:押下 / false:非押下)
            RightKeyCondition = false; // 右ｷｰ押下状態(true:押下 / false:非押下)
            TopKeyCondition = false;   // 上ｷｰ押下状態(true:押下 / false:非押下)
            BottomKeyCondition = false; // 下ｷｰ押下状態(true:押下 / false:非押下)
            // 背景画像とキャラクター画像の合成
            pictureBox1.Image = ComposeBackgroundImgAndCharacterImg(
                BackgroundImg,
                CharacterImg,
                CharaPosition);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 下がったキーがDキーの場合
            // すなわち、キャラクターを右移動させる指示が出た場合
            if (e.KeyCode == Keys.D)
            {
                // キャラクターがステージ右側の壁をまだ越えてはいない場合
                //if (CharaPosition.X < (pictureBox1.Width - CharacterImg.Width))
                    RightKeyCondition = true;//右キー押した状態
            }
            // 下がったキーがAキーの場合
            // すなわち、キャラクターを左移動させる指示が出た場合
            else if (e.KeyCode == Keys.A)
            {
                //if (CharaPosition.X > 0)
                    LeftKeyCondition = true;
            }
            // 下がったキーがWキーの場合
            // すなわち、キャラクターを上移動させる指示が出た場合
            else if (e.KeyCode == Keys.W)
            {
               // if (CharaPosition.Y > 0)
                    TopKeyCondition = true;
            }
            // 下がったキーがZキーの場合
            // すなわち、キャラクターを下移動させる指示が出た場合
            else if (e.KeyCode == Keys.S)
            {
                // キャラクターを移動
               // if(CharaPosition.Y < (pictureBox1.Height - CharacterImg.Height))
                    BottomKeyCondition = true;
            }
            // 下がったキーが、その他のキーの場合
            else
            {
                // 未処理
                // (移動はしない)
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // 上がったキーがDキーの場合
            // すなわち、キャラクターを右移動させる指示が出た場合
            if (e.KeyCode == Keys.D)
            {
                RightKeyCondition = false; // 右ｷｰ押下状態(true:押下 / false:非押下)
            }
            // 上がったキーがAキーの場合
            // すなわち、キャラクターを左移動させる指示が出た場合
            else if (e.KeyCode == Keys.A)
            {
                LeftKeyCondition = false; // 左ｷｰ押下状態(true:押下 / false:非押下)
            }
            // 上がったキーがWキーの場合
            // すなわち、キャラクターを上移動させる指示が出た場合
            else if (e.KeyCode == Keys.W)
            {
                TopKeyCondition = false; // 上ｷｰ押下状態(true:押下 / false:非押下)
            }
            // 上がったキーがZキーの場合
            // すなわち、キャラクターを下移動させる指示が出た場合
            else if (e.KeyCode == Keys.S)
            {
                BottomKeyCondition = false; // 下ｷｰ押下状態(true:押下 / false:非押下)
            }
            // 上がったキーが、その他のキーの場合
            else
            {
                // 未処理
            }
        }

        //============
        // 背景画像とキャラクター画像の合成
        // 第１引数: 合成する背景画像
        // 第２引数: 合成するキャラクター画像
        // 第３引数: キャラクターの位置座標
        // 戻り値: 合成後の画像
        public Image ComposeBackgroundImgAndCharacterImg(
            Image Background_Img,
            Image Character_Img,
            Point Chara_Position)
        {
            // 合成を行なうためのイメージ画像を作成
            // (背景画像を新規作成のイメージ画像にコピー)
            Image ImageWork = (Image)Background_Img.Clone();
            // グラフィック用オブジェクトを生成
            Graphics gr = Graphics.FromImage(ImageWork);
            // 透明色指定(白を指定)
            System.Drawing.Imaging.ImageAttributes ImgAttr = new System.Drawing.Imaging.ImageAttributes();
            ImgAttr.SetColorKey(Color.FromArgb(230, 230, 230), Color.FromArgb(255, 255, 255));  // 真白から白(少し黒よりの白)までの範囲を指定
            // ｷｬﾗｸﾀｰ画像の描画
            gr.DrawImage(CharacterImg, new Rectangle(CharaPosition, CharacterImg.Size), 0, 0, CharacterImg.Width, CharacterImg.Height, GraphicsUnit.Pixel, ImgAttr);
            // 合成後のイメージ画像を返却
            return ImageWork;
        }


        //============
        // タイマーで定期時間ごとに発生するイベントにおけるイベントプロシージャ
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // 右キー押下時処理
            if (RightKeyCondition) // 右ｷｰ押下状態(true:押下 / false:非押下)
            {
                // キャラクターを移動
                CharaPosition.X += CharaSpeed;
            }
            // 左キー押下時処理
            if (LeftKeyCondition) // 左ｷｰ押下状態(true:押下 / false:非押下)
            {
                // キャラクターを移動
                CharaPosition.X -= CharaSpeed;
            }
            // 上キー押下時処理)
            if (TopKeyCondition) // 上ｷｰ押下状態(true:押下 / false:非押下)
            {
                // キャラクターを移動
                CharaPosition.Y -= CharaSpeed;
            }
            // 下キー押下時処理
            if (BottomKeyCondition) // 下ｷｰ押下状態(true:押下 / false:非押下)
            {
                // キャラクターを移動
                CharaPosition.Y += CharaSpeed;
            }

            // 背景画像とキャラクター画像の合成
            pictureBox1.Image = ComposeBackgroundImgAndCharacterImg(
                BackgroundImg,
                CharacterImg,
                CharaPosition);
        }
    }
}
