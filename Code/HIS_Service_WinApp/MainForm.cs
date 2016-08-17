using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using HIS_BLL;
using HIS_Model;
using HIS_IDAL;

namespace HIS_Service_WinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //实例化定时器
            _calltimer = new System.Threading.Timer(CallTimerHander, null, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            //_calltimer = new System.Threading.Timer(CallTimerHander, null, 0, _callinterval);

            //初始化客户端状态集合
            for (int i = minBedNo; i <= minBedNo; i++)
            {
                _cclientStatus.Add(minBedNo, ClientStatus.MissingListenInfo);
            }

        }

        /// <summary>
        /// 客户端回调引用的集合
        /// </summary>
        private Dictionary<int, IRateInjector> _calbackref;

        /// <summary>
        /// 实例化客户端状态集合
        /// </summary>
        private Dictionary<int, ClientStatus> _cclientStatus = new Dictionary<int, ClientStatus>();

        /// <summary>
        /// 保持客户端病人状态集合
        /// </summary>
        private Dictionary<int, PatientStatus> _patientStatus = new Dictionary<int, PatientStatus>();

        /// <summary>
        /// 最小床号
        /// </summary>
        private const int minBedNo = 1;

        /// <summary>
        /// 最大床号
        /// </summary>
        private const int maxBedNo = 5;

        /// <summary>
        /// 对象锁 
        /// </summary>
        private object lockobj = new object();

        //注射状态默认颜色，green
        private static readonly Color InServiceColor = Color.Green;

        //非注射状态默认颜色,gray
        private static readonly Color OutServiceColor = Color.Gray;

        //呼叫请求闪烁的颜色
        private static readonly Color CallingColor = Color.Red;

        //闪烁的暗色
        private static readonly Color CallingColorBack = Color.FromArgb(255, 230, 230, 216);

        /// <summary>
        /// 用户控制呼叫服务的定时器
        /// </summary>
        private System.Threading.Timer _calltimer;

        /// <summary>
        /// 呼叫服务的闪烁间隔时间
        /// </summary>
        private static readonly long _callinterval = 500;

        /// <summary>
        /// 用户呼叫时使用的委托类型
        /// </summary>
        private delegate void CallDelegate();

        /// <summary>
        /// 状态标示
        /// </summary>
        private bool flashflag = false;

        /// <summary>
        /// 定时器回调处理事件的方法，使用BeginInvoke间接调用窗口控件
        /// </summary>
        /// <param name="sender"></param> 
        private void CallTimerHander(object sender)
        {
            BeginInvoke(new CallDelegate(CallFlash));
        }

        /// <summary>
        /// 控制控件颜色显示
        /// </summary>
        private void CallFlash()
        {
            lock (lockobj)
            {
                int count = 0;
                foreach (int bedNo in _cclientStatus.Keys)
                {
                    if (_cclientStatus[bedNo] == ClientStatus.Calling)
                    {
                        count++;
                        Control cont = GetControlByNo(bedNo);
                        if (!flashflag)
                        {
                            cont.BackColor = CallingColor;
                        }
                        else
                        {
                            cont.BackColor = CallingColorBack;
                        }
                    }
                }
                //if (true)
                //{
                //    count++;
                //    Control cont = GetControlByNo(2);
                //    if (!flashflag)
                //    {
                //        cont.BackColor = CallingColor;
                //    }
                //    else
                //    {
                //        cont.BackColor = CallingColorBack;
                //    }
                //}
                if (count == 0)
                {
                    //_calltimer = new System.Threading.Timer(CallTimerHander, null, 0, _callinterval);
                    _calltimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                }
                else
                {
                    flashflag = true;
                }
            }
        }

        /// <summary>
        /// 根据指定的床位返回对应控件
        /// </summary>
        /// <param name="bedNo"></param>
        /// <returns></returns>
        private Control GetControlByNo(int bedNo)
        {
            Control ctr = new Control();
            if (bedNo >= minBedNo && bedNo <= maxBedNo)
            {
                string names = "btnNo" + bedNo;
                //MainForm.ControlCollection controls = new ControlCollection(); 
                if (this.Controls != null && this.Controls.Count > 0)
                {
                    foreach (Control ct in this.Controls)
                    {
                        if (ct.Name == names)
                        {
                            ctr = ct;
                        }
                    }
                }
            } 
            return ctr;

        }



        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="callbaclref"></param>
        public MainForm(Dictionary<int, IRateInjector> callbaclref)
            : this()
        {
            _calbackref = callbaclref;
        }

        /// <summary>
        /// 窗口启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Control ctr = GetControlByNo(1);
            //ctr.BackColor = CallingColorBack;
        }

        /// <summary>
        /// 注射事件实现方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void startInfusionHandle(object sender, ClientEcentArg arg)
        {
            //获取床号对应控件
            Control ctr = GetControlByNo(arg.BedNo);
            //改变背景色
            ctr.BackColor = InServiceColor;
            _cclientStatus[arg.BedNo] = ClientStatus.Injecting;
        }
        /// <summary>
        /// 结束注射事件实现方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void endInfusionHandle(object sender, ClientEcentArg arg)
        {

            //获取床号对应控件
            Control ctr = GetControlByNo(arg.BedNo);
            //改变背景色
            ctr.BackColor = OutServiceColor;
            _cclientStatus[arg.BedNo] = ClientStatus.On;
        }

        /// <summary>
        /// 呼叫事件实现方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void EmergenCallHandle(object sender, ClientEcentArg arg)
        {

            //获取床号对应控件
            Control ctr = GetControlByNo(arg.BedNo);
            //改变背景色
            ctr.BackColor = InServiceColor;
            _cclientStatus[arg.BedNo] = ClientStatus.Injecting;

        }
        /// <summary>
        /// 结束呼叫事件实现方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void endEmergenCallHandle(object sender, ClientEcentArg arg)
        {

            //获取床号对应控件
            Control ctr = GetControlByNo(arg.BedNo);
            //改变背景色
            _calltimer.Change(0, _callinterval);
            _cclientStatus[arg.BedNo] = ClientStatus.Calling;
        }
        /// <summary>
        /// 监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void _ListenHandlers(object sender, ClientEcentArg arg)
        { 
            //获取床号对应控件
            Control ctr = GetControlByNo(arg.BedNo);
            ctr.BackColor = CallingColor;
            _cclientStatus[arg.BedNo] = ClientStatus.MissingListenInfo;
        }
        /// <summary>
        /// 监听丢失事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void _missingListenHandlers(object sender, ClientEcentArg arg)
        {
            //如果从丢失监听信息状态恢复正常，设置对应控件演示及状态
            if (_cclientStatus[arg.BedNo] == ClientStatus.MissingListenInfo)
            { 
                //获取床号对应控件
                Control ctr = GetControlByNo(arg.BedNo);
                ctr.BackColor = OutServiceColor;
                _cclientStatus[arg.BedNo] = ClientStatus.On;
            }
            //保存病人状态
            if (arg.Status != null)
            {
                _patientStatus[arg.BedNo] = arg.Status;
            }
        }

        /// <summary>
        /// 获取详细信息
        /// </summary>
        private void PopDetail(int bedNo)
        {
           
            if (_cclientStatus[bedNo] == ClientStatus.On)
            {
                MessageBox.Show("未开始注射，不能查看详细");
                return;
            }
            if (_cclientStatus[bedNo] == ClientStatus.MissingListenInfo)
            {
                MessageBox.Show("通讯异常，客户端异常");
                return;
            }
            IRateInjector irateinject=_calbackref[bedNo];
            if (irateinject == null || _patientStatus.Keys.Contains(bedNo))
            {
                MessageBox.Show("客户端正在启动，请稍后再试");
            }
            Detail detail = new Detail(_patientStatus[bedNo], irateinject);
            detail.ShowDialog();
        }

        /// <summary>
        /// 1号床按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo1_Click(object sender, EventArgs e)
        {
            PopDetail(1);
        }
        /// <summary>
        /// 2号床按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo2_Click(object sender, EventArgs e)
        {

            PopDetail(2);
        }
        /// <summary>
        /// 3号床按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo3_Click(object sender, EventArgs e)
        {
            PopDetail(3);
        }
        /// <summary>
        /// 4号床按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo4_Click(object sender, EventArgs e)
        {
            PopDetail(4);
        }
        /// <summary>
        /// 5号床按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo5_Click(object sender, EventArgs e)
        {
            PopDetail(5);
        }
    }
}
