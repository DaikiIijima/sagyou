using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_____rensyu
{
    public interface Ichara
    {
        //描画
        void draw(Graphics g);

        //アニメーション処理
        //ピクチャボックスの大きさを取得する為に引数を取得
        void animation(chara_picturBOX pic);
    }
}
