using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_____rensyu
{
    //ボール（円）の描画クラス
    class Ball : Ichara
    {
        //位置
        public Point _xy = new Point();

        //サイズ
        public Size _size = new Size();

        //ベクトル
        protected vec _vec = new vec(10, 10);

        //色
        public int _color = 0;//0:時機 1:敵

        //カウント
        protected int _animationcount = 0;

        public Ball()
        {

        }

        public Ball(int color, int x, int y, int dx, int dy)
        {
            _xy = new Point(x, y);
            _size = new Size(50, 50);
            _vec = new vec(dx, dy);

        }

        public void draw(Graphics g)
        {

            Brush brush;
            Pen pen;

            //円を描画
            //1.塗りつぶし
            //2.枠みたいに上から空の円を描く
            if (_color == 0)
            {
                brush = Brushes.Blue;
                pen = Pens.BlueViolet;

            }
            else
            {
                brush = Brushes.Red;
                pen = Pens.Red;

            }

            g.FillEllipse(brush, _xy.X, _xy.Y, _size.Width, _size.Height);
            g.DrawEllipse(pen, _xy.X, _xy.Y, _size.Width, _size.Height);

        }

        public virtual void animation(chara_picturBOX pic)
        {

            
            //右端かどうか
            if (_xy.X + _size.Width > pic.Width)
            {
                //右端の場合
                _vec.dx = -(_vec.dx);
            }
            //左端かどうか
            if (_xy.X < 0)
            {
                //左端の場合
                _vec.dx = -(_vec.dx);
            }
            //下端かどうか
            if (_xy.Y + _size.Height > pic.Height)
            {
                //下端の場合
                _vec.dy = -(_vec.dy);
            }
            //上端かどうか
            if (_xy.Y < 0)
            {
                //上端の場合
                _vec.dy = -(_vec.dy);
            }
        }
    }

        class MyBall : Ball
        {
            //MyBallが呼ばれたときに、上のballのコンストラクタにその情報を入れ込むのがbase
            public MyBall(int x, int y, int dx, int dy) : base(0, x, y, dx, dy)
            {
                _color = 0;
            }

    }

        class EnemyBall : Ball
        {
            public EnemyBall(int x, int y, int dx, int dy) : base(0, x, y, dx, dy){
                _color = 1;
            }

        //ボールの速さを変えるためにanimationをオーバーライドしている
        public override void animation(chara_picturBOX pic)
        {
            _animationcount++;
            _xy.X = _xy.X + _vec.dx + _vec.dx * _animationcount / 150;
            _xy.Y = _xy.Y + _vec.dy + _vec.dy * _animationcount / 150;

            //最後に元のやつを動かさないとボールが出てく
            base.animation(pic);
        }
    }
    
}
