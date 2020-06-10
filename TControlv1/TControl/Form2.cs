using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TControl
{
    public partial class Form2 : Form
    {
        private int Length = 20; //单位格大小--视觉上
        private int StepX = 10;//X轴每一格的值
        private int StepY = 2;//Y轴每一格的值
        private int StartX = 0;//X轴开始值
        private int StartY = 0;//Y轴开始值
        private const int Y_Max = 100;//Y轴最大值
        private const int StartPrint = 32;//点坐标偏移量
        /****************************第一条线*******************************/
        public List<float> DataList1 = new List<float>();//数据结构--线性链表
        private Pen ListsPen1 = new Pen(Color.Red);  //波形1颜色
        /****************************第二条线*******************************/
        public List<float> DataList2 = new List<float>();//数据结构--线性链表
        private Pen ListsPen2 = new Pen(Color.Orange);  //波形2颜色
        /****************************第三条线*******************************/
        public List<float> DataList3 = new List<float>();//数据结构--线性链表
        private Pen ListsPen3 = new Pen(Color.Fuchsia);  //波形3颜色
        /****************************第四条线*******************************/
        public List<float> DataList4 = new List<float>();//数据结构--线性链表
        private Pen ListsPen4 = new Pen(Color.Blue);//波形4颜色 ...... 还可以创建更多
        /****************************栅格颜色*******************************/
        private Pen TablePen = new Pen(Color.BlueViolet);

        public Form2()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);//双缓冲
            this.UpdateStyles();
            InitializeComponent();
        }
        private void Form2_Paint(object sender, PaintEventArgs e)//画整体图像
        {
            this.Height = 600;
            this.Width = 1500;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            e.Graphics.FillRectangle(Brushes.Azure, e.Graphics.ClipBounds);//背景填充
            /******************显示1号温度目标值**********************/
            gp.AddString("1号暖房目标温度：" + Convert.ToString(Form1.SetT1), this.Font.FontFamily,
                                   (int)(FontStyle.Regular), 13, new RectangleF(StartPrint, 0, 400, 50), null);
            /******************显示2号温度目标值**********************/
            gp.AddString("2号暖房目标温度：" + Convert.ToString(Form1.SetT2), this.Font.FontFamily,
                                   (int)(FontStyle.Regular), 13, new RectangleF(StartPrint + 160, 0, 400, 50), null);
            /******************显示1号温度实际值**********************/
            gp.AddString("1号暖房实际温度：" + Convert.ToString(Form1.T1_Value), this.Font.FontFamily,
                                   (int)(FontStyle.Regular), 13, new RectangleF(StartPrint + 320, 0, 400, 50), null);
            /******************1号暖房温度报警**********************/
            if (Form1.T1_Value >= 80)//2号暖房上限温度
                gp.AddString("1号暖房温度超标 请及时关闭！！！", this.Font.FontFamily,
                                             (int)(FontStyle.Regular), 13, new RectangleF(StartPrint + 960, 0, 400, 50), null);
            /******************显示2号温度实际值**********************/
            gp.AddString("2号暖房实际温度：" + Convert.ToString(Form1.T2_Value), this.Font.FontFamily,
                                   (int)(FontStyle.Regular), 13, new RectangleF(StartPrint + 480, 0, 400, 50), null);
            /******************2号暖房温度报警**********************/
            if (Form1.T1_Value >= 80)//2号暖房上限温度
                gp.AddString("2号暖房温度超标 请及时关闭！！！", this.Font.FontFamily,
                                             (int)(FontStyle.Regular), 13, new RectangleF(StartPrint + 1200, 0, 400, 50), null);
            /******************显示1号PID输出值**********************/
            gp.AddString("1号PID输出值：" + Convert.ToString(Form1.PID_Value1), this.Font.FontFamily,
                                   (int)(FontStyle.Regular), 13, new RectangleF(StartPrint + 640, 0, 400, 50), null);
            /******************显示2号PID输出值**********************/
            gp.AddString("2号PID输出值：" + Convert.ToString(Form1.PID_Value2), this.Font.FontFamily,
                                   (int)(FontStyle.Regular), 13, new RectangleF(StartPrint + 800, 0, 400, 50), null);
            /***************************Y轴画线*************************/
            for (int i = 0; i <= (this.ClientRectangle.Height - 2 * StartPrint) / Length; i++) //上下两个间距
            {
                e.Graphics.DrawLine(TablePen, StartPrint, StartPrint + i * Length, //横向画线
                              this.ClientRectangle.Width, StartPrint + i * Length);
                /******************************************显示Y轴数据***************************************************/
                gp.AddString(Convert.ToString(StepY * ((this.ClientRectangle.Height - 2 * 32) / Length - i) + StartY), this.Font.FontFamily,
                                    (int)(FontStyle.Regular), 13, new RectangleF(10, StartPrint + i * Length - 8, 400, 50), null);
            }
            /***************************X轴画线*************************/
            for (int i = 0; i <= (this.ClientRectangle.Width - StartPrint) / Length; i++)
            {
                e.Graphics.DrawLine(TablePen, StartPrint + i * Length, StartPrint,//纵向画线
                                              StartPrint + i * Length, (int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint);

                /******************************************获取时间数据***************************************************/
                int hour = System.DateTime.Now.Hour; int minute = System.DateTime.Now.Minute; int second = System.DateTime.Now.Second;
                string str = hour + "." + minute + "." + second + ".";
                /******************************************显示X轴数据***************************************************/
                if (i % 5 == 0) //要显示时间
                    gp.AddString(Convert.ToString(i * StepX + StartX) + "s", this.Font.FontFamily,
                                        (int)(FontStyle.Regular), 10, new RectangleF(StartPrint + i * Length - 8, this.ClientRectangle.Height - Length, 400, 50), null);
            }
            e.Graphics.DrawPath(Pens.Pink, gp);//显示X Y 轴数据，可设置其颜色
            /***************************波形画线*************************/
            for (int i = 1; i < DataList1.Count; i++)
            {
                e.Graphics.DrawLine(ListsPen1, StartPrint + (i - StartX - 1) * Length / StepX, (float)((int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint - (DataList1[i - 1] - StartY) * Length / StepY),
                                               StartPrint + (i - StartX) * Length / StepX, (float)((int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint - (DataList1[i] - StartY) * Length / StepY));
                //(实际值-最小值)/(最大值-最小值) = 实际值的高/最大值的高 ====== 传输实数也是可以显示的 
            }
            for (int i = 1; i < DataList2.Count; i++)
            {
                e.Graphics.DrawLine(ListsPen2, StartPrint + (i - StartX - 1) * Length / StepX, (float)((int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint - (DataList2[i - 1] - StartY) * Length / StepY),
                                               StartPrint + (i - StartX) * Length / StepX, (float)((int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint - (DataList2[i] - StartY) * Length / StepY));
                //(实际值-最小值)/(最大值-最小值) = 实际值的高/最大值的高 ====== 传输实数也是可以显示的 
            }
            for (int i = 1; i < DataList3.Count; i++)
            {
                e.Graphics.DrawLine(ListsPen3, StartPrint + (i - StartX - 1) * Length / StepX, (float)((int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint - (DataList3[i - 1] - StartY) * Length / StepY),
                                               StartPrint + (i - StartX) * Length / StepX, (float)((int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint - (DataList3[i] - StartY) * Length / StepY));
                //(实际值-最小值)/(最大值-最小值) = 实际值的高/最大值的高 ====== 传输实数也是可以显示的 
            }
            for (int i = 1; i < DataList4.Count; i++)
            {
                e.Graphics.DrawLine(ListsPen4, StartPrint + (i - StartX - 1) * Length / StepX, (float)((int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint - (DataList4[i - 1] - StartY) * Length / StepY),
                                               StartPrint + (i - StartX) * Length / StepX, (float)((int)((this.ClientRectangle.Height - 2 * StartPrint) / Length) * Length + StartPrint - (DataList4[i] - StartY) * Length / StepY));
                //(实际值-最小值)/(最大值-最小值) = 实际值的高/最大值的高 ====== 传输实数也是可以显示的 
            }
        }
        /***************************定时器*************************/
        private void timer1_Tick(object sender, EventArgs e)
        {
            Add_Value(Form1.T1_Value, Form1.T2_Value, Form1.SetT1, Form1.SetT2);//打开波形显示时，发送数据
        }
        /****************************************按键控制***************************************************/
        private  bool Key_Shift=false, Key_Up = false, Key_Down = false, Key_Left = false, Key_Right = false;
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Shift) Key_Shift = true;
            else        Key_Shift = false;
            switch (e.KeyCode)
            {
               case Keys.Up:    Key_Up    = true; break;
               case Keys.Down:  Key_Down  = true; break;     
               case Keys.Left:  Key_Left  = true; break;      
               case Keys.Right: Key_Right = true; break;
            }
        }
        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (Key_Shift == true)//按住Shift放大Y X轴
            {
                if (Key_Up == true)    { StepY++; Key_Up    = false; }
                if (Key_Down == true)  { StepY--; Key_Down  = false; }
                if (Key_Right == true) { StepX++; Key_Right = false; }
                if (Key_Left == true)  { StepX--; Key_Left  = false; }
                Key_Shift = false;
            }
            else                      //直接按上下左右平移Y X轴
            {
                if (Key_Up == true)    { StartY+= StepY; Key_Up    = false; }
                if (Key_Down == true)  { StartY-= StepY; Key_Down  = false; }
                if (Key_Right == true) { StartX+= StepX; Key_Right = false; }
                if (Key_Left == true)  { StartX-= StepX; Key_Left  = false; }
            }
        }
        /******************************信号值输入******************************/
        public void Add_Value(float num1, float num2, float num3, float num4) //四个参数  ---- 四条曲线
        {
            DataList1.Add(num1);
            DataList2.Add(num2);
            DataList3.Add(num3);
            DataList4.Add(num4);
            Invalidate();//刷新------相当于再画一次图像
        }
        public void Add_Value(float num1, float num2, float num3)//三个参数  ---- 三条曲线
        {
            DataList1.Add(num1);
            DataList2.Add(num2);
            DataList3.Add(num3);
            Invalidate();//刷新------相当于再画一次图像
        }
        public void Add_Value(float num1, float num2)//二个参数  ---- 二条曲线
        {
            DataList1.Add(num1);
            DataList2.Add(num2);
            Invalidate();//刷新------相当于再画一次图像
        }
        public void Add_Value(float num1)//一个参数  ----  一条曲线
        {
            DataList1.Add(num1);
            Invalidate();//刷新------相当于再画一次图像
        }
    }
}
