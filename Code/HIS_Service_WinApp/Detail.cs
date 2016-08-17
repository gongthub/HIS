using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HIS_Model;
using HIS_IDAL;

namespace HIS_Service_WinApp
{
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 重载构造函数
        /// </summary>
        /// <param name="pateient"></param>
        public Detail(PatientStatus status,IRateInjector inject)
            : this()
        {
            _status = status;
            injector = inject;
            txtPat.Text = status.MyPatient.Id;
            txtDoc.Text = status.MyPatient.MyDoctor.Id;
            txtMtot.Text = status.MyMedication.Id;
            txtcount.Text = status.MyMedication.Amount.ToString();
            txtReman.Text = status.RemainMed.ToString();
            txtRate.Text = status.Rate.ToString();
        }


        /// <summary>
        /// 病人状态
        /// </summary>
        private PatientStatus _status;

        /// <summary>
        /// 回调引用
        /// </summary>
        private IRateInjector injector;

        private void Detail_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 调整速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRate_Click(object sender, EventArgs e)
        {
            //判断调整的速度与病人当前速度是否一致
            if (txtRate.Text.Trim() != _status.Rate.ToString())
            {
                long newRate = 0;
                //判断大于当前剩余量
                if (long.TryParse(txtRate.Text.Trim(), out newRate) && newRate < _status.RemainMed)
                {
                    injector.AjuestRate(newRate);
                }
                else
                {
                    MessageBox.Show("输入格式不正确，或剩余用量已经为0");
                }
            }
        }
    }
}
