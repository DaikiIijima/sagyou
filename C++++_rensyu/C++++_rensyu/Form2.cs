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
        // ﾌｫｰﾑﾛｰﾄﾞ時用ｲﾍﾞﾝﾄ
        private void Form2_Load(object sender, EventArgs e)
        {
            pic.initialize();

            //出てくるものの登録
            initializa();
           
        }

        //ボールの初期化
        public void initializa()
        {
            //キャラクターの登録
            pic.CharaList.Add(_myBall);

            Random random = new Random();
            //敵キャラの登録
            for (int i = 0; i < 2; i++)
            {
                //ランダムに動かす
                int x = random.Next(100, pic.Width - 100);
                int y = random.Next(100, pic.Height - 100);
                //方向をランダムにする
                //?は条件演算子
                //0のdx,dyが0の場合-1を返して、それ以外の場合は1を返す
                int dx = random.Next(0, 2) == 0 ? -1 : 1;
                int dy = random.Next(0, 2) == 0 ? -1 : 1;

                EnemyBall enemyball = (new EnemyBall(x, y, dx, dy));

                //描画用ピクチャーボックスに登録
                pic.CharaList.Add(enemyball);

                //あたり判定リストに敵を追加
                _EnemyBallList.Add(enemyball);
            }
        }


        //時機
        Ball _myBall = new MyBall(0,0,0,0);

        //敵キャラリスト
        List<Ball> _EnemyBallList = new List<Ball>();

        //タイマーイベント
        private void timer1_Tick(object sender, EventArgs e)
        {
            //描画
            pic.draw();
          
        }

        Point _oldPoint = Point.Empty;

        //マウスムーブイベント
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            //マウスカーソルの取得
            //System.Windows.Forms.Cursor.Position
        }

        public void move()
        {
            //マウスカーソルの中が空だったら位置を入れる
            if(_oldPoint == Point.Empty)
            {
                _oldPoint = System.Windows.Forms.Cursor.Position;
                return;
            }

            //移動量の算出
            int dx = Cursor.Position.X - _oldPoint.X;
            int dy = Cursor.Position.Y - _oldPoint.Y;

            //位置の移動
            _myBall._xy.X = _myBall._xy.X + dx;
            _myBall._xy.Y = _myBall._xy.Y + dy;

            //範囲指定(飛び出さないように)
            if (_myBall._xy.X < 0) _myBall._xy.X = 0;
            if (_myBall._xy.Y < 0) _myBall._xy.Y = 0;

            if (_myBall._xy.X + _myBall._size.Width > pic.Width)
                _myBall._xy.X = pic.Width -  _myBall._size.Width;
            if (_myBall._xy.Y + _myBall._size.Height > pic.Height)
                _myBall._xy.Y = pic.Height - _myBall._size.Height;

            //前回の位置として、今回の位置を設定
            _oldPoint = System.Windows.Forms.Cursor.Position;
        }

        //スコア
        int _score = 0;

        //キャラを動かすようのタイマー
        private void Movetimer_Tick(object sender, EventArgs e)
        {
            //時機を動かすよう
            move();

            //点数の加算
            _score = _score + 1;

            //点数の表示]
            label2.Text = _score.ToString();
        }

        
        //あたり判定用のタイマー
        private void timerChec_Tick(object sender, EventArgs e)
        {
            
            Rectangle myrect = new Rectangle(_myBall._xy.X, _myBall._xy.Y, _myBall._size.Width, _myBall._size.Height);
            
            foreach (var enemyBall in _EnemyBallList)
            {
                /*
                //時機の左端<= 敵の右端
                //時機の右端 >= 敵の左端
                //あたり判定(難しいバージョン)
                if((_myBall._xy.X <= enemyBall._xy.X + enemyBall._size.Width)&&
                    (_myBall._xy.X + _myBall._size.Width >= enemyBall._xy.X)&&
                    (_myBall._xy.Y <= enemyBall._xy.Y + enemyBall._size.Height)&&
                    (_myBall._xy.Y + _myBall._size.Height >= enemyBall._xy.Y))
                {
                    timerChec.Enabled = false;
                    MessageBox.Show("Hit");
                    
                }
                */

                //あたり判定(簡単バージョン)
                
                Rectangle enemyrect = new Rectangle(enemyBall._xy.X +5, enemyBall._xy.Y+5, enemyBall._size.Width - 10, enemyBall._size.Height - 10);
                if(myrect.IntersectsWith(enemyrect))
                {   
                    if (isGameover) return;

                    isGameover = true;
                    GameOver();
                    return;
                }
                
            }
        }

        bool isGameover = false;
        private void GameOver()
        {
            //タイマーの停止
            timer1.Enabled = false;
            timerChec.Enabled = false;
            Movetimer.Enabled = false;

            MessageBox.Show("GAME OVER : "+_score.ToString());

            //ゲームオーバーフラグ戻す
            isGameover = false;

            //描画用ピクチャーボックスからクリア
            pic.CharaList.Clear();

            //あたり判定リストからクリア
            _EnemyBallList.Clear();

            //ゲーム再スタート
            label2.Text = "0";
            _score = 0;

            //敵の作成
            initializa();

            //時機の位置リセット
            _myBall._xy.X = 0;
            _myBall._xy.Y = 0;

            _oldPoint = Point.Empty;

            timer1.Enabled = true;
            timerChec.Enabled = true;
            Movetimer.Enabled = true;

        }
    }
}
