using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 工业智能控制系统.运动;

namespace 工业智能控制系统
{
    public partial class FrMain : Form
    {
        public FrMain()
        {
            InitializeComponent();
        }

        private void FrMain_Load(object sender, EventArgs e)
        {
            运动控制_雷赛 _运动 = new 运动控制_雷赛();
            _运动.卡.卡数据.Add("卡号", "0");
            _运动.卡扩展.IO操作参数.Add("IO编号", 1);
            _运动.卡扩展.IO操作参数.Add("延时翻转时间", 1.5);
            _运动.IO输出延时翻转(_运动.卡扩展);
        }
    }
}
