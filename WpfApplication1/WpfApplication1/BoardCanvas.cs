using System.Windows.Controls;

namespace WpfApplication1
{
    public enum BoardType
    {
        Go,
        Chess
    }
    internal class BoardCanvas
    {
        protected double CellWidth { get; private set; }         //一つのcellの幅
        protected double CellHeight { get; private set; }           //一つのcellの高さ
        protected int YSize { get; private set; }                   //縦方向のcellの数
        protected int XSize { get; private set; }                   //横方向のcellの数
        protected BoardType BoardType { get; private set; }        //罫線の種類（碁盤かチェス盤か）
        protected Panel Panel { get; private set; }                 //対象となるPanelオブジェクト
        protected Board Board { get; private set; }                 //対象となるBoardオブジェクト
    
        //コンストラクタ
        public BoardCanvas(Panel panel,Board board)
        {
            this.Board = board;
            this.Panel = panel;
            YSize = board.YSize;
            XSize = board.XSize;

            //1cellの幅 = panelの幅 ÷ boardの幅
            CellWidth = (panel.ActualWidth - 1) / XSize;
            CellHeight = (panel.ActualHeight - 1) / YSize;
            ****
            foreach(var loc in board.GetValidLocations())
            {
                UpdatePiece(loc, board[loc]);
            }
        }
    }
}