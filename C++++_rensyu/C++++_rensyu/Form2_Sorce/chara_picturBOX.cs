using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_____rensyu
{
    //キャラクターピクチャーボックス
    public class chara_picturBOX : PictureBox
    {
        private Bitmap _bitmap;

        public List<Ichara> CharaList = new List<Ichara>();
        //初期化処理
        public void initialize()
        {
            _bitmap = new Bitmap(this.Width, this.Height);
        }

        public void draw()
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                //クリア
                g.Clear(Color.Black);

                foreach(var character in CharaList)
                {
                    character.draw(g);  
                }

            }

            //アニメーション処理
            foreach (var character in CharaList)
            {
                character.animation(this);
            }

            //ここで上書きする
            this.Image = _bitmap;
        }
    }
}
