using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工业智能控制系统.数据
{
    public class 控制卡数据 : 数据基类
    {
        private Dictionary<string, string> _卡数据;
        /// <summary>
        /// 控制卡数据字典,Key=参数名称,Value=参数值
        /// </summary>
        public Dictionary<string, string> 卡数据
        {
            get
            {
                return _卡数据;
            }

            set
            {
                _卡数据 = value;
            }
        }
    }
    public class 卡扩展数据 : 控制卡数据
    {
        private Dictionary<string, double> _IO操作参数;
        private Dictionary<int, bool> _通用IO列表;
        private Dictionary<int, bool> _专用IO列表;
        private Dictionary<string, double> _PWM;
        private Dictionary<int, double> _模拟量列表;
        private Dictionary<string, int> _密码管理;
        private Dictionary<string, int> _文件管理;
        private Dictionary<string, int> _寄存器操作;
        private Dictionary<string, int> _模拟量操作;

        /// <summary>
        /// 通用IO列表字典,Key=IO序号,Value=IO值
        /// </summary>
        public Dictionary<int, bool> 通用IO列表
        {
            get
            {
                return _通用IO列表;
            }

            set
            {
                _通用IO列表 = value;
            }
        }
        /// <summary>
        /// 专用IO别表字典,Key=IO序号,Value=IO值
        /// </summary>
        public Dictionary<int, bool> 专用IO列表
        {
            get
            {
                return _专用IO列表;
            }

            set
            {
                _专用IO列表 = value;
            }
        }
        /// <summary>
        /// PWM数据,Key=参数名称,Value=参数值
        /// </summary>
        public Dictionary<string, double> PWM
        {
            get
            {
                return _PWM;
            }

            set
            {
                _PWM = value;
            }
        }

        public Dictionary<int, double> 模拟量列表
        {
            get
            {
                return _模拟量列表;
            }

            set
            {
                _模拟量列表 = value;
            }
        }

        public Dictionary<string, int> 密码管理
        {
            get
            {
                return _密码管理;
            }

            set
            {
                _密码管理 = value;
            }
        }

        public Dictionary<string, int> 文件管理
        {
            get
            {
                return _文件管理;
            }

            set
            {
                _文件管理 = value;
            }
        }

        public Dictionary<string, int> 寄存器操作
        {
            get
            {
                return _寄存器操作;
            }

            set
            {
                _寄存器操作 = value;
            }
        }

        public Dictionary<string, int> 模拟量操作
        {
            get
            {
                return _模拟量操作;
            }

            set
            {
                _模拟量操作 = value;
            }
        }

        public Dictionary<string, double> IO操作参数
        {
            get
            {
                return _IO操作参数;
            }

            set
            {
                _IO操作参数 = value;
            }
        }
    }


    public class 轴数据 : 控制卡数据
    {
        private Dictionary<string, int> _轴列表;
        /// <summary>
        /// 轴列表字典,Key=轴名称,Value=轴编号
        /// </summary>
        public Dictionary<string, int> 轴列表
        {
            get
            {
                return _轴列表;
            }

            set
            {
                _轴列表 = value;
            }
        }
    }
    public class 轴扩展数据:轴数据
    {
        private Dictionary<string, double> _编码器;
        private Dictionary<string, int> _高速位置锁存;
        private Dictionary<string, int> _原点锁存;
        private Dictionary<string, int> _EZ锁存;
        private Dictionary<string, int> _位置比较;
        private Dictionary<string, int> _高速位置比较;
        private Dictionary<string, int> _运动异常停止;
        private Dictionary<string, int> _轴IO映射;
        private Dictionary<string, double> _运动;
        private Dictionary<string, double> _回原点;
        private Dictionary<string, int> _总线IO及轴控制;
        private Dictionary<string, int> _总线配置;
        private Dictionary<string, int> _总线错误代码;
        private Dictionary<string, int> _软硬件限位;
        public Dictionary<string, int> 高速位置锁存
        {
            get
            {
                return _高速位置锁存;
            }

            set
            {
                _高速位置锁存 = value;
            }
        }

        public Dictionary<string, int> 原点锁存
        {
            get
            {
                return _原点锁存;
            }

            set
            {
                _原点锁存 = value;
            }
        }

        public Dictionary<string, int> EZ锁存
        {
            get
            {
                return _EZ锁存;
            }

            set
            {
                _EZ锁存 = value;
            }
        }

        public Dictionary<string, double> 编码器
        {
            get
            {
                return _编码器;
            }

            set
            {
                _编码器 = value;
            }
        }

        public Dictionary<string, int> 位置比较
        {
            get
            {
                return _位置比较;
            }

            set
            {
                _位置比较 = value;
            }
        }

        public Dictionary<string, int> 高速位置比较
        {
            get
            {
                return _高速位置比较;
            }

            set
            {
                _高速位置比较 = value;
            }
        }

        public Dictionary<string, int> 运动异常停止
        {
            get
            {
                return _运动异常停止;
            }

            set
            {
                _运动异常停止 = value;
            }
        }

        public Dictionary<string, int> 轴IO映射
        {
            get
            {
                return _轴IO映射;
            }

            set
            {
                _轴IO映射 = value;
            }
        }

        public Dictionary<string, double> 运动
        {
            get
            {
                return _运动;
            }

            set
            {
                _运动 = value;
            }
        }

        public Dictionary<string, double> 回原点
        {
            get
            {
                return _回原点;
            }

            set
            {
                _回原点 = value;
            }
        }

        public Dictionary<string, int> 总线IO及轴控制
        {
            get
            {
                return _总线IO及轴控制;
            }

            set
            {
                _总线IO及轴控制 = value;
            }
        }

        public Dictionary<string, int> 总线配置
        {
            get
            {
                return _总线配置;
            }

            set
            {
                _总线配置 = value;
            }
        }

        public Dictionary<string, int> 总线错误代码
        {
            get
            {
                return _总线错误代码;
            }

            set
            {
                _总线错误代码 = value;
            }
        }

        public Dictionary<string, int> 软硬件限位
        {
            get
            {
                return _软硬件限位;
            }

            set
            {
                _软硬件限位 = value;
            }
        }
    }

    public class 返回值数据 : 数据基类
    {
        private Dictionary<string, string> _返回值;
        /// <summary>
        /// 返回值列表字典,Key=返回值名称,Value=返回值
        /// </summary>
        public Dictionary<string, string> 返回值
        {
            get
            {
                return _返回值;
            }

            set
            {
                _返回值 = value;
            }
        }
    }
    public class 异常代码数据 : 数据基类
    {
        private Dictionary<int, string> _代码对照表;
        /// <summary>
        /// 异常代码字典,Key=异常代码,Value=异常描述
        /// </summary>
        public Dictionary<int, string> 代码对照表
        {
            get
            {
                return _代码对照表;
            }

            set
            {
                _代码对照表 = value;
            }
        }
    }
}
