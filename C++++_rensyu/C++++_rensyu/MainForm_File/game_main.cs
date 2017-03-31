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

namespace C_____rensyu.MainForm_File
{
    //画面を登録
    [View(Views.Game_main)]

    public partial class game_main : UserControl
    {
        public game_main()
        {
            InitializeComponent();
        }

        private Bitmap bmp;

        private int Pos_X = 0;
        private int Pos_Y = 0;

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)

        {

            Graphics g = e.Graphics;

            g.DrawImage(bmp, Pos_X, Pos_Y);

            g.FillRectangle(Brushes.Black, 100, 260, 100, 100);

        }

        private void game_main_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap("C:\\Users\\Daiki\\Documents\\sagyou\\C++++_rensyu\\キャラクター.bmp");



            // 背景イメージ設定

            this.pictureBox1.BackgroundImage = new Bitmap("C:\\Users\\Daiki\\Documents\\sagyou\\C++++_rensyu\\town.jpg");

            this.Draw_timer.Enabled = true;

            this.Draw_timer.Start();
        }

        private void Draw_Timer(object sender, EventArgs e)
        {
           

            // 再描画

            this.pictureBox1.Invalidate();
        }

        private void move_Timer(object sender, EventArgs e)
        {
            label2.Text = (pictureBox1.Height.ToString());
            // 描画位置変更
            if (A_Key)
                Pos_X--;
            if (D_Key)
                Pos_X++;
            if (Jump_)
                Pos_Y -= 3;
            if (!Jump_)
            { 
                if (Pos_Y < pictureBox1.Height-20)
                    Pos_Y+=3;
            }
        }

        bool A_Key = false;
        bool D_Key = false;
        bool Jump_ = false;

        private void game_main_KeyDown(object sender, KeyEventArgs e)
        {
            Keys K = e.KeyCode;
            
            switch (K)
            {
                case Keys.A:
                    A_Key = true;
                    label1.Text = ("Down_A");
                    break;

                case Keys.D:
                    D_Key = true;
                    label1.Text = ("Down_D");
                    break;

                case Keys.Space:
                    Jump_ = true;
                    label1.Text = ("Down_Jump");
                    break;
            }
        }

        private void game_main_KeyUp(object sender, KeyEventArgs e)
        {
            Keys K = e.KeyCode;

            switch (K)
            {
                case Keys.A:
                    A_Key = false;
                    label1.Text = ("UP_A");
                    break;

                case Keys.D:
                    D_Key = false;
                    label1.Text = ("UP_D");
                    break;

                case Keys.Space:
                    Jump_ = false;
                    label1.Text = (Pos_Y+"Up_Jump");
                    break;
            }
        }
    }
}
