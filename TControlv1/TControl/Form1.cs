using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //串口库
namespace TControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames(); // 串口
            /*******************暖房选择***********************/
            Num.Items.Add("1号暖房");
            Num.SelectedItem = Num.Items[0];
            Num.Items.Add("2号暖房");
            /********************com显示**********************/
            USART_Name.Items.AddRange(ports);
            if (ports.Length > 0)
                USART_Name.SelectedItem = USART_Name.Items[0];
            else
                MessageBox.Show("没有可用的串口!");
        }
        SerialPort ser = new SerialPort(); //串口
        byte[] Flag = new byte[6]; // 保存发送的数据  
        //第一个字节 0000 000  最后一位 0为1号暖房   1为2号暖房
        //第二个字节 最高位 0为正1为负  0到6位 为手动值
        //第三个字节 最高位 0为自1为手  0到6位 为目标值
        //第四个字节 Kc取值
        //第五个字节 Ti取值
        //第六个字节 Td取值
        private void Mode_Click(object sender, EventArgs e)//模式切换 自动 和 手动
        {
            if (Mode.Text == "目前自动模式")
            {//手动模式
                Manual_value.Enabled = true;
                SetT.Enabled = false;
                Mode.Text = "目前手动模式";
                Mode.BackColor = System.Drawing.Color.Gold; //背景颜色->橙色
            }
            else //自动模式
            {
                Manual_value.Enabled = false;
                SetT.Enabled = true;
                Mode.Text = "目前自动模式";
                Mode.BackColor = System.Drawing.Color.Green; //背景颜色->绿色
            }
        }
        private void FS_Click(object sender, EventArgs e)
        {
            Int16 nums = 0;
            SetTData();//保存1号暖房和2号暖房串口数据值
            if (ser.IsOpen)
            {
                try
                {
                    /********************获取各个数据位的值**********************/
                    if (Num.SelectedItem.ToString() == "1号暖房")
                    { Flag[0] = 0x00; }
                    else { Flag[0] = 0x01; }
                    if (Mode.Text == "目前自动模式")//
                    {
                        Flag[1] = 0x00; //最高位置0
                        Flag[2] = Convert.ToByte(SetT.Text);
                    }
                    else
                    {
                        nums = Convert.ToInt16(Manual_value.Text);
                        if (nums >= 0)
                        { Flag[1] = (byte)nums; }
                        else
                        { Flag[1] = (byte)(-1 * nums); Flag[1] |= 0x80; }//最高位置1
                        Flag[2] |= 0x80;//最高位置1
                    }
                    Flag[3] = Convert.ToByte(Kc_Value.Text);
                    Flag[4] = Convert.ToByte(Ti_Value.Text);
                    Flag[5] = Convert.ToByte(Td_Value.Text);
                    /********************通过串口传输数据**********************/
                    ser.Write(Flag, 0, 6);//传输数据
                }
                catch
                { MessageBox.Show("传输有误!"); }
            }
            else { MessageBox.Show("请打开串口!"); }
        }
        public Form2 form2 = null;
        private void Wave_Click(object sender, EventArgs e)
        {
            if (ser.IsOpen)
            {
                if (form2 == null|| form2.IsDisposed)
                {
                    form2 = new Form2();
                    
                }
                form2.Show();
            }
        }
        private void Open_Click(object sender, EventArgs e)
        {
            if (SerialPort.GetPortNames().Length > 0) //有串口时
            {
                try
                {
                    if (!ser.IsOpen)
                    {
                        //串口配置
                        /*************************COM口******************************/
                        ser.PortName = USART_Name.SelectedItem.ToString();
                        /*************************波特率*****************************/
                        ser.BaudRate = 9600;
                        /*************************数据位*****************************/
                        ser.DataBits = 8;
                        /*************************停止位*****************************/
                        ser.StopBits = StopBits.One;
                        /*************************校验位*****************************/
                        ser.Parity = Parity.None; //无
                        ser.Open();
                        ser.DataReceived += S_DataReceived; //声明和调用这个事件
                        Open.Text = "关闭串口";
                        Open.BackColor = System.Drawing.Color.Red; //背景颜色->红色
                    }
                    else
                    {
                        ser.Close();
                        ser.DataReceived -= S_DataReceived;
                        Open.Text = "打开串口";
                        Open.BackColor = System.Drawing.Color.Green; //背景颜色->绿色
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); }
            }
            else { };
        }
        public static int PID_Value1 = 0, PID_Value2 = 0;//pid输出
        public static float T1_Value = 0, T2_Value = 0;
        public float T1 = 0, T2 = 0;
        byte[] buff = new byte[6];int num = 0;
        public void S_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /**************跨线程访问**************/
            this.Invoke((EventHandler)(delegate
            {
                try
                {
                    for (int i = 0; i < 6; i++)
                    {  buff[i] = (byte)ser.ReadByte(); }
                    if (num >= 6)
                    {
                        /************************PID1***********************************/
                        if (buff[0] >= 0X80) PID_Value1 = -1 * (buff[0] - 0X80);//有正反
                        else PID_Value1 = buff[0];
                        /*************************T1***  *********************************/
                         T1_Value = buff[1] + (float)buff[2] / 10; 
                        /************************PID2***********************************/
                        if (buff[3] >= 0X80) PID_Value2 = -1 * (buff[3] - 0X80);
                        else PID_Value2 = buff[3];
                        /*************************T2************************************/
                        T2_Value = buff[4] + (float)buff[5] / 10; 
                        num = 0;
                    } 
                      num++;
                    //下位机发送协议：PID1输出 实际温度值1 PID2输出 实际温度值2 
                    //                一个字节   两个字节  一个字节   两个字节
                }
                catch
                { MessageBox.Show("接收错误！"); }
            }));
            if(T1 != 0)
            {
                if (((T1 - T1_Value>2)|| (T1_Value - T1 > 2)))
                { T1_Value = T1; ser.Close(); ser.Open(); }
            }
            if (T2 != 0)
            {
                if ((T2 - T2_Value > 2) || (T2_Value - T2 > 2))
                { T2_Value = T2; ser.Close(); ser.Open(); }
            }
            T1_Value = (T1 + T1_Value) / 2;//滤波，和前一个值取平均数
            T2_Value = (T2 + T2_Value) / 2;//滤波，和前一个值取平均数
            T1 = T1_Value; T2 = T2_Value;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ser.Close();
            Open.Text = "打开串口";
            Open.BackColor = System.Drawing.Color.Green; //背景颜色->绿色

            Mode.Text = "目前自动模式";
            Mode.BackColor = System.Drawing.Color.Green; //背景颜色->绿色
            Manual_value.Enabled = false;//不用手动值
            SetT.Enabled = true;//使用自动值

            Manual_value.Text = "0";
            SetT.Text = "30";
            Kc_Value.Text = "0";
            Ti_Value.Text = "0";
            Td_Value.Text = "0";
        }
        private void Res_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); // 串口
            USART_Name.Items.AddRange(ports);
            if (ports.Length > 0)
                USART_Name.SelectedItem = USART_Name.Items[0];
        }
        private void Num_DropDown(object sender, EventArgs e)
        {
             SetTData();//下拉暖房选择菜单键 保存当前值
        }
        private void Num_SelectedIndexChanged(object sender, EventArgs e)
        {
           ReadTData(); //下拉暖房选择菜单键后再复选 写入当前值
        }
        /**************方便暖房切换后数据保存*****************/
        public static Int16 SetT1 = 30, SetT2 = 30;  //温度设定值
        public Int16 SdOut1 = 0, SdOut2 = 0;//温度手动值
        public UInt16 Kc1 = 0, Kc2 = 0;//Kc值
        public UInt16 Ti1 = 0, Ti2 = 0;//Ti值
        public UInt16 Td1 = 0, Td2 = 0;//Td值
        string Mode1 = " ", Mode2 = "目前自动模式";
        void SetTData()//保存值
        {
            if (Num.SelectedItem.ToString() == "1号暖房")
            {
                SetT1 = Convert.ToByte(SetT.Text);
                SdOut1 = Convert.ToInt16(Manual_value.Text);
                Mode1 = Mode.Text;
                Kc1 = Convert.ToByte(Kc_Value.Text);
                Ti1 = Convert.ToByte(Ti_Value.Text);
                Td1 = Convert.ToByte(Td_Value.Text);
            }
            else
            {
                SetT2 = Convert.ToByte(SetT.Text);
                SdOut2 = Convert.ToInt16(Manual_value.Text);
                Mode2 = Mode.Text;
                Kc2 = Convert.ToByte(Kc_Value.Text);
                Ti2 = Convert.ToByte(Ti_Value.Text);
                Td2 = Convert.ToByte(Td_Value.Text);
            }
        }
        void ReadTData()//保存值
        {
            if (Num.SelectedItem.ToString() == "1号暖房")
            {
                SetT.Text = Convert.ToString(SetT1);
                Manual_value.Text = Convert.ToString(SdOut1);
                Mode.Text = Mode1;
                Kc_Value.Text = Convert.ToString(Kc1);
                Ti_Value.Text = Convert.ToString(Ti1);
                Td_Value.Text = Convert.ToString(Td1);
            }
            else
            {
                SetT.Text = Convert.ToString(SetT2);
                Manual_value.Text = Convert.ToString(SdOut2);
                Mode.Text = Mode2;
                Kc_Value.Text = Convert.ToString(Kc2);
                Ti_Value.Text = Convert.ToString(Ti2);
                Td_Value.Text = Convert.ToString(Td2);
            }

            if (Mode.Text == "目前自动模式")
            {//手动模式
                Manual_value.Enabled = false;
                SetT.Enabled = true;
                Mode.BackColor = System.Drawing.Color.Green; //背景颜色->绿色
            }
            else //自动模式
            {
                Manual_value.Enabled = true;
                SetT.Enabled = false;
                Mode.BackColor = System.Drawing.Color.Gold; //背景颜色->橙色
            }
        }
    }
}
