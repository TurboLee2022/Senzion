using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 工业智能控制系统.数据;
using Leadshine;

namespace 工业智能控制系统.运动
{
    public class 运动控制_雷赛 : 运动控制卡基类
    {
        /// <summary>
        /// 构造函数
        /// <para>调用本类中方法时,务必按方法注释,输入所需参数,否者执行时会报错!!!</para>
        /// <para>因考量性能原因,某些方法体中未检测字典中是否包含指定键,所以调用之前务必先保证字典中对应键,切记!!!</para>
        /// </summary>
        public 运动控制_雷赛()
        {
            初始化各数据();
            初始化异常代码(ref _异常代码);
        }
        #region 键是否存在检测
        /// <summary>
        /// 检测字典中是否存在指定键
        /// </summary>
        /// <param name="_字典"></param>
        /// <param name="_键列表"></param>
        /// <returns>返回true则全部存在,任何一个键不存在则返回false</returns>
        private bool 是否存在键(Dictionary<string, string> _字典, List<string> _键列表)
        {
            bool res = true;
            foreach (var item in _键列表)
            {
                res = _字典.ContainsKey(item);
                if (!res)
                {
                    break;
                }
            }
            return res;
        }
        /// <summary>
        /// 检测字典中是否存在指定键
        /// </summary>
        /// <param name="_字典"></param>
        /// <param name="_键列表"></param>
        /// <returns>返回true则全部存在,任何一个键不存在则返回false</returns>
        private bool 是否存在键(Dictionary<string, double> _字典, List<string> _键列表)
        {
            bool res = true;
            foreach (var item in _键列表)
            {
                res = _字典.ContainsKey(item);
                if (!res)
                {
                    break;
                }
            }
            return res;
        }
        /// <summary>
        /// 检测字典中是否存在指定键
        /// </summary>
        /// <param name="_字典"></param>
        /// <param name="_键"></param>
        /// <returns>返回true则存在,返回false则不存在</returns>
        private bool 是否存在键(Dictionary<string, string> _字典, string _键)
        {
            return _字典.ContainsKey(_键);
        }

        #endregion

        /// <summary>
        /// 读取所有雷赛异常代码,和系统异常代码
        /// </summary>
        /// <param name="_异常代码">异常代码.代码对照表</param>
        /// <returns>返回值为0,则执行成功</returns>
        public override int 初始化异常代码(ref 异常代码数据 _异常代码)
        {
            _异常代码.代码对照表.Add(0, "操作成功");
            return 0;
        }
        /// <summary>
        /// 控制器链接初始化函数，分配系统资源
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>卡数据["连接类型"]: 1-串口，2-网口</para>
        /// <para>卡数据["连接字符串"]: 对应与控制器的 IP 地址或相应的 COM 口</para>
        /// <para>卡数据["波特率"]: 默认值 115200</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <returns>执行异常代码</returns>
        public override int 初始化连接(控制卡数据 _卡)
        {
            short res = 0;
            ushort _卡号;
            ushort _连接类型;
            string _连接字符串;
            uint _波特率;
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号", "连接类型", "连接字符串", "波特率" }))
            {
                _连接字符串 = _卡.卡数据["连接字符串"];
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号) && ushort.TryParse(_卡.卡数据["连接类型"], out _连接类型) && uint.TryParse(_卡.卡数据["波特率"], out _波特率))
                {
                    res = LTSMC.smc_board_init(_卡号, _连接类型, _连接字符串, _波特率);
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }
        /// <summary>
        /// 控制器高级链接初始化函数，分配系统资源
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>卡数据["连接类型"]: 1-串口，2-网口</para>
        /// <para>卡数据["连接字符串"]: 对应与控制器的 IP 地址或相应的 COM 口</para>
        /// <para>卡数据["波特率"]: 默认值 115200</para>
        /// <para>卡数据["数据位"]: 8</para>
        /// <para>卡数据["校验位"]: 0：无校验、1：奇校验、2：偶校验</para>
        /// <para>卡数据["停止位"]: 1：停止为 1、2：停止位 2</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <returns>执行异常代码</returns>
        public override int 初始化连接_高级(控制卡数据 _卡)
        {
            short res = 0;
            ushort _卡号;
            ushort _连接类型;
            string _连接字符串;
            uint _波特率;
            uint _数据位;
            uint _校验位;
            uint _停止位;
            _连接字符串 = _卡.卡数据["连接字符串"];
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号", "连接类型", "波特率", "数据位", "校验位", "停止位" }))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号) && ushort.TryParse(_卡.卡数据["连接类型"], out _连接类型) && uint.TryParse(_卡.卡数据["波特率"], out _波特率)
     && uint.TryParse(_卡.卡数据["数据位"], out _数据位) && uint.TryParse(_卡.卡数据["校验位"], out _校验位) && uint.TryParse(_卡.卡数据["停止位"], out _停止位))
                {
                    res = LTSMC.smc_board_init_ex(_卡号, _连接类型, _连接字符串, _波特率, _数据位, _校验位, _停止位);
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }
        /// <summary>
        /// 控制器关闭函数，释放系统资源
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <returns>执行异常代码</returns>
        public override int 断开连接(控制卡数据 _卡)
        {
            short res = 0;
            ushort _卡号;
            if (是否存在键(_卡.卡数据,new List<string>() { "卡号" }))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号))
                {
                    res = LTSMC.smc_board_close(_卡号);
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        /// <summary>
        /// 设置网络链接超时时间
        /// <para>需求参数:</para>
        /// <para>卡数据["超时时间"]: 单位 ms，超时时间等于 0 或者没调用过该函数时默认为 5 秒钟</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <returns>执行异常代码</returns>
        public override int 设置连接超时(控制卡数据 _卡)
        {
            short res = 0;
            uint _超时时间;
            if (uint.TryParse(_卡.卡数据["超时时间"], out _超时时间))
            {
                res = LTSMC.smc_set_connect_timeout(_超时时间);
            }
            else
            {
                res = -2;
            }
            return res;
        }

        /// <summary>
        /// 读取发布版本号
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>返回值["发布版本号"]</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <param name="_返回值"></param>
        /// <returns></returns>
        public override int 读取发布版本号(控制卡数据 _卡, ref 返回值数据 _返回值)
        {
            short res = 0;
            ushort _卡号;
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号" }))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号))
                {
                    byte[] _发布版本号 = new byte[128];
                    res = LTSMC.smc_get_release_version(_卡号,  _发布版本号);
                    _返回值.返回值.Add("发布版本号", Encoding.ASCII.GetString(_发布版本号));
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        /// <summary>
        /// 获取控制器硬件版本号
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>返回值["硬件版本号"]</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <param name="_返回值"></param>
        /// <returns>执行异常代码</returns>
        public override int 获取控制器硬件版本号(控制卡数据 _卡, ref 返回值数据 _返回值)
        {
            short res = 0;
            ushort _卡号;
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号" }))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号))
                {
                    uint _硬件版本号 = 0;
                    res = LTSMC.smc_get_card_version(_卡号, ref _硬件版本号);
                    _返回值.返回值.Add("硬件版本号", _硬件版本号.ToString());
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        /// <summary>
        /// 获取控制器固件版本号
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>返回值["固件类型"]</para>
        /// <para>返回值["固件版本号"]</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <param name="_返回值"></param>
        /// <returns>执行异常代码</returns>
        public override int 获取控制器固件版本号(控制卡数据 _卡, ref 返回值数据 _返回值)
        {
            short res = 0;
            ushort _卡号;
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号" }))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号))
                {
                    uint _固件类型 = 0;
                    uint _固件版本号 = 0;
                    res = LTSMC.smc_get_card_soft_version(_卡号, ref _固件类型,ref _固件版本号);
                    _返回值.返回值.Add("固件类型", _固件类型.ToString());
                    _返回值.返回值.Add("固件版本号", _固件版本号.ToString());
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        /// <summary>
        /// 获取控制器动态库文件版本号
        /// <para>返回值["库版本号"]</para>
        /// </summary>
        /// <param name="_返回值"></param>
        /// <returns>执行异常代码</returns>
        public override int 获取控制器动态库文件版本号(ref 返回值数据 _返回值)
        {
            short res = 0;
            uint _库版本号 = 0;
            res = LTSMC.smc_get_card_lib_version( ref _库版本号);
            _返回值.返回值.Add("库版本号", _库版本号.ToString());
            return res;
        }

        /// <summary>
        /// 获取当前控制器的轴数
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>返回值["轴数量"]</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <param name="_返回值"></param>
        /// <returns>执行异常代码</returns>
        public override int 获取当前控制器的轴数(控制卡数据 _卡, ref 返回值数据 _返回值)
        {
            short res = 0;
            ushort _卡号;
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号" }))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号))
                {
                    uint _轴数量 = 0;
                    res = LTSMC.smc_get_total_axes(_卡号, ref _轴数量);
                    _返回值.返回值.Add("轴数量", _轴数量.ToString());
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        /// <summary>
        /// 函数调用打印输出设置
        /// <para>使能打印输出后，可监控运动函数库的调用情况。在用户调用函数时，将输出相关 信息，并保存在指定文件路径中</para>
        /// <para>需求参数:</para>
        /// <para>卡数据["使能"]: 0：禁止，1：使能</para>
        /// <para>卡数据["文件路径"]: 文件保存路径</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <returns>执行异常代码</returns>
        public override int 函数调用打印输出设置(控制卡数据 _卡)
        {
            short res = 0;
            ushort _使能;
            if (是否存在键(_卡.卡数据, new List<string>() { "使能", "文件路径" }))
            {
                if (ushort.TryParse(_卡.卡数据["使能"], out _使能))
                {
                    char[] _文件路径 = _卡.卡数据["文件路径"].ToArray();
                    res = LTSMC.smc_set_debug_mode(_使能, _文件路径);
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        /// <summary>
        /// 读取函数调用打印输出设置
        /// <para>需求参数:</para>
        /// <para>卡数据:无需求</para>
        /// <para>返回值["打印输出使能状态"]: 0：禁止，1：使能</para>
        /// <para>返回值["打印输出使能状态"]: 文件保存路径</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <param name="_返回值"></param>
        /// <returns>执行异常代码</returns>
        public override int 读取函数调用打印输出设置(控制卡数据 _卡, ref 返回值数据 _返回值)
        {
            short res = 0;
            ushort _使能 = 0;
            char[] _文件路径 = new char[1024];
            res = LTSMC.smc_get_debug_mode(ref _使能, _文件路径);
            _返回值.返回值.Add("打印输出使能状态", _使能.ToString());
            _返回值.返回值.Add("打印输出文件路径", new string(_文件路径));
            return res;
        }
        /// <summary>
        /// 设置控制器新 IP 地址
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>卡数据["IP地址"]: 新 IP 地址字符串，如“192.168.5.11”</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <returns>执行异常代码</returns>
        public override int 设置控制器新IP地址(控制卡数据 _卡)
        {
            short res = 0;
            ushort _卡号;
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号","IP地址" }))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号))
                {
                    byte[] _IP地址 = Encoding.ASCII.GetBytes(_卡.卡数据["IP地址"]);
                    res = LTSMC.smc_set_ipaddr(_卡号, _IP地址);
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        /// <summary>
        /// 读取控制器 IP 地址
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>返回值["IP地址"]: 返回 IP 地址字符串，如“192.168.5.11”</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <param name="_返回值"></param>
        /// <returns>执行异常代码</returns>
        public override int 读取控制器IP地址(控制卡数据 _卡, ref 返回值数据 _返回值)
        {
            short res = 0;
            ushort _卡号;
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号"}))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号))
                {
                    byte[] _IP地址 = new byte[64];
                    res = LTSMC.smc_get_ipaddr(_卡号, _IP地址);
                    _返回值.返回值.Add("IP地址", Encoding.ASCII.GetString(_IP地址));
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        /// <summary>
        /// 设置控制器 COM 口参数
        /// <para>需求参数:</para>
        /// <para>卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>卡数据["串口类型"]: com 口:1-RS232、2-RS485</para>
        /// <para>卡数据["波特率"]: 波特率，如 9600、19200、 115200 等。</para>
        /// <para>卡数据["数据位"]: 数据位：7、8。默认值为8 注意：使用 API 函数动态库时，数据位必须为 8 位。</para>
        /// <para>卡数据["校验位"]: 较验位：0-无校验，1-奇校验，2-偶校验</para>
        /// <para>卡数据["停止位"]: 停止位：1,2</para>
        /// </summary>
        /// <param name="_卡"></param>
        /// <returns>执行异常代码</returns>
        public override int 设置控制器COM口参数(控制卡数据 _卡)
        {
            short res = 0;
            ushort _卡号, _串口类型, _数据位, _校验位, _停止位;
            uint _波特率;
            if (是否存在键(_卡.卡数据, new List<string>() { "卡号", "串口类型", "波特率", "数据位", "校验位", "停止位" }))
            {
                if (ushort.TryParse(_卡.卡数据["卡号"], out _卡号) && ushort.TryParse(_卡.卡数据["串口号"], out _串口类型) && uint.TryParse(_卡.卡数据["波特率"], out _波特率)
&& ushort.TryParse(_卡.卡数据["数据位"], out _数据位) && ushort.TryParse(_卡.卡数据["校验位"], out _校验位) && ushort.TryParse(_卡.卡数据["停止位"], out _停止位))
                {
                    res = LTSMC.smc_set_com(_卡号, _串口类型, _波特率, _数据位, _校验位, _停止位);
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }


        /// <summary>
        /// IO 输出延时翻转
        /// <para>需求参数:</para>
        /// <para> 卡数据["卡号"]: 0-7,默认值 0</para>
        /// <para>IO操作参数["IO编号"]: 取值范围：0-控制器本机输出口数-1</para>
        /// <para>IO操作参数["延时翻转时间"]: 单位：s</para>
        /// </summary>
        /// <param name="_IO">卡扩展数据</param>
        /// <returns>执行异常代码</returns>
        public override int IO输出延时翻转(卡扩展数据 _IO)
        {
            short res = 0;
            ushort _卡号;
            if (是否存在键(_IO.卡数据, "卡号") && 是否存在键(_IO.IO操作参数, new List<string>() { "IO编号", "延时翻转时间" }))
            {
                if (ushort.TryParse(_IO.卡数据["卡号"], out _卡号))
                {
                    ushort _IO编号 = (ushort)_IO.IO操作参数["IO编号"];
                    double _延时翻转时间 = _IO.IO操作参数["延时翻转时间"];
                    res = LTSMC.smc_reverse_outbit(_卡号, _IO编号, _延时翻转时间);
                }
                else
                {
                    res = -2;
                }
            }
            else
            {
                res = -1;
            }
            return res;
        }

        public override int PTS模式向指定数据表传送数据(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int PTT模式向指定数据表传送数据(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int PVTS模式向指定数据表传送数据(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int PVT模式向指定数据表传送数据(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 三点圆弧模式扩展的螺旋线插补运动(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 上传FLASH文件到内存文件(卡扩展数据 _文件管理)
        {
            throw new NotImplementedException();
        }

        public override int 上传FLASH文件到本地文件(卡扩展数据 _文件管理)
        {
            throw new NotImplementedException();
        }

        public override int 下载内存文件到FLASH(卡扩展数据 _文件管理)
        {
            throw new NotImplementedException();
        }

        public override int 下载内存文件到RAM_掉电不保存(卡扩展数据 _文件管理)
        {
            throw new NotImplementedException();
        }

        public override int 下载本地文件到FLASH(卡扩展数据 _文件管理)
        {
            throw new NotImplementedException();
        }

        public override int 下载本地文件到RAM_掉电不保存(卡扩展数据 _文件管理)
        {
            throw new NotImplementedException();
        }

        public override int 从控制器内读取指定轴的锁存次数(轴扩展数据 _高速位置锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 从控制器内读取锁存器的值(轴扩展数据 _高速位置锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 修改登陆密码(卡扩展数据 _密码管理)
        {
            throw new NotImplementedException();
        }

        public override int 停止EtherCAT总线运行(轴扩展数据 _总线配置)
        {
            throw new NotImplementedException();
        }

        public override int 停止坐标系内所有轴的运动(轴扩展数据 _运动异常停止)
        {
            throw new NotImplementedException();
        }

        public override int 停止连续插补(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 关闭连续插补缓冲区(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 写位寄存器(卡扩展数据 _寄存器操作)
        {
            throw new NotImplementedException();
        }

        public override int 写入密码(卡扩展数据 _密码管理)
        {
            throw new NotImplementedException();
        }

        public override int 写入序列号(卡扩展数据 _密码管理)
        {
            throw new NotImplementedException();
        }

        public override int 写字寄存器(卡扩展数据 _寄存器操作)
        {
            throw new NotImplementedException();
        }

        public override int 写扩展rxpdo(轴扩展数据 _总线配置)
        {
            throw new NotImplementedException();
        }







        public override int 动态调整连续插补速度比例(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 半径圆弧终点模式扩展的螺旋线插补运动(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 单轴定长运动(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 单轴连续运动(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 发送NMT管理报文(轴扩展数据 _总线配置)
        {
            throw new NotImplementedException();
        }

        public override int 同步运动(轴扩展数据 _总线IO及轴控制)
        {
            throw new NotImplementedException();
        }

        public override int 启动PVT运动(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 回原点完成后设置偏移位置值(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 回原点运动(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 圆心圆弧终点模式扩展的螺旋线插补运动(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 在线改变指定轴的当前目标位置(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 在线改变指定轴的当前运动速度(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 复位CANopen总线(轴扩展数据 _总线配置)
        {
            throw new NotImplementedException();
        }

        public override int 复位锁存器的标志位(轴扩展数据 _高速位置锁存)
        {
            throw new NotImplementedException();
        }

        public override int 密码校验(卡扩展数据 _密码管理)
        {
            throw new NotImplementedException();
        }

        public override int 开始连续插补(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 强制改变指定轴的当前目标位置(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 打开连续插补缓冲区(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 指定轴停止运动(轴扩展数据 _运动异常停止)
        {
            throw new NotImplementedException();
        }

        public override int 控制指定CMP端口的输出(轴扩展数据 _高速位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 控制指定轴的ERC信号输出(轴数据 _轴, 卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 控制指定轴的伺服使能端口的输出(轴数据 _轴, 卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 文件下载进度(卡扩展数据 _文件管理)
        {
            throw new NotImplementedException();
        }



        public override int 暂停连续插补(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 查询连续插补缓冲区剩余插补空间(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 格式化FLASH(卡扩展数据 _文件管理)
        {
            throw new NotImplementedException();
        }

        public override int 检测坐标系的运动状态(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 检测指定轴的运动状态(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 检测连续插补运行是否完成(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 添加_更新高速比较位置(轴扩展数据 _高速位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 添加一维位置比较点(轴扩展数据 _位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 添加二维位置比较点(轴扩展数据 _位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 清除EZ锁存标志(轴扩展数据 _EZ锁存)
        {
            throw new NotImplementedException();
        }

        public override int 清除原点锁存标志(轴扩展数据 _原点锁存)
        {
            throw new NotImplementedException();
        }

        public override int 清除已添加的所有一维位置比较点(轴扩展数据 _位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 清除已添加的所有二维位置比较点(轴扩展数据 _位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 清除已添加的所有高速位置比较点(轴扩展数据 _高速位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 清除总线错误(轴扩展数据 _总线错误代码)
        {
            throw new NotImplementedException();
        }

        public override int 清除报警信号(轴扩展数据 _总线错误代码)
        {
            throw new NotImplementedException();
        }

        public override int 清除指定轴号总线错误代码(轴扩展数据 _总线错误代码)
        {
            throw new NotImplementedException();
        }

        public override int 清除指定链接号总线错误代码(轴扩展数据 _总线错误代码)
        {
            throw new NotImplementedException();
        }

        public override int 清除段内未执行完的IO动作(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 清除轴停止原因(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 登陆密码(卡扩展数据 _密码管理)
        {
            throw new NotImplementedException();
        }

        public override int 直线插补运动(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 紧急停止所有轴(轴扩展数据 _运动异常停止)
        {
            throw new NotImplementedException();
        }

        public override int 置位模拟量输入触发状态(卡扩展数据 _模拟量操作)
        {
            throw new NotImplementedException();
        }

        public override int 获取EtherCAT从站总数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 获取EtherCAT总线模拟量IO点数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 获取EtherCAT轴数字量输入IO状态(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 获取EtherCAT轴数字量输出IO状态(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 获取从站对象字典(轴扩展数据 _总线配置, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }



        public override int 获取心跳报文信息(轴扩展数据 _总线配置, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 获取指定轴总线错误代码(轴扩展数据 _总线错误代码, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 获取指定链接号总线错误代码(轴扩展数据 _总线错误代码, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }





        public override int 获取紧急报文信息(轴扩展数据 _总线配置, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 获取轴IO信息(轴扩展数据 _总线配置, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 设置AB相计数反相(轴扩展数据 _编码器)
        {
            throw new NotImplementedException();
        }

        public override int 设置EL限位信号(轴扩展数据 _软硬件限位)
        {
            throw new NotImplementedException();
        }

        public override int 设置EMG急停信号(轴扩展数据 _运动异常停止)
        {
            throw new NotImplementedException();
        }

        public override int 设置EtherCAT总线轴回零参数(轴扩展数据 _总线IO及轴控制)
        {
            throw new NotImplementedException();
        }

        public override int 设置EtherCAT总线驱动器使能(轴扩展数据 _总线IO及轴控制)
        {
            throw new NotImplementedException();
        }

        public override int 设置EtherCAT总线驱动器禁止使能(轴扩展数据 _总线IO及轴控制)
        {
            throw new NotImplementedException();
        }

        public override int 设置EtherCAT轴数字量输出IO状态(轴扩展数据 _总线IO及轴控制)
        {
            throw new NotImplementedException();
        }

        public override int 设置EZ个数(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置EZ锁存模式(轴扩展数据 _EZ锁存)
        {
            throw new NotImplementedException();
        }

        public override int 设置IO触发减速停止电平信号(轴扩展数据 _运动异常停止)
        {
            throw new NotImplementedException();
        }

        public override int 设置IO计数模式(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 设置ORG原点信号(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 设置PWM立即输出参数(卡扩展数据 _PWM)
        {
            throw new NotImplementedException();
        }

        public override int 设置一维位置比较器(轴扩展数据 _位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 设置二维位置比较器(轴扩展数据 _位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 设置从站对象字典(轴扩展数据 _总线配置)
        {
            throw new NotImplementedException();
        }

        public override int 设置单轴运动速度曲线_时间模式(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 设置单轴速度曲线S段参数值(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 设置原点锁存模式(轴扩展数据 _原点锁存)
        {
            throw new NotImplementedException();
        }

        public override int 设置反向间隙值(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置回原点模式(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 设置回原点速度参数(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }

        public override int 设置圆弧插补限速功能(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置定长运动减速停止时间(轴扩展数据 _运动异常停止)
        {
            throw new NotImplementedException();
        }

        public override int 设置当前工件原点(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置当前指令位置计数器值(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定IO组号的全部输出口的电平(轴扩展数据 _总线IO及轴控制)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定控制器或扩展模块的某个输出端口的电平(轴扩展数据 _总线IO及轴控制)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定控制器的全部输出口的电平(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定控制器的某个输出端口的电平(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定轴的ALM信号(轴数据 _轴, 卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定轴的EZ信号电平(轴扩展数据 _编码器)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定轴的INP信号(轴数据 _轴, 卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定轴的LTC信号(轴扩展数据 _高速位置锁存)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定轴的脉冲输出模式(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置指定轴编码器脉冲计数值(轴扩展数据 _编码器)
        {
            throw new NotImplementedException();
        }

        public override int 设置掉电保存寄存器值(卡扩展数据 _寄存器操作)
        {
            throw new NotImplementedException();
        }



        public override int 设置插补异常减速停止时间参数(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置插补模式及小线段前瞻参数(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置插补运动减速停止时间(轴扩展数据 _运动异常停止)
        {
            throw new NotImplementedException();
        }

        public override int 设置插补运动速度参数_时间模式(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置插补运动速度曲线的平滑时间(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置模拟量参数(卡扩展数据 _模拟量操作)
        {
            throw new NotImplementedException();
        }

        public override int 设置编码器的计数方式(轴扩展数据 _编码器)
        {
            throw new NotImplementedException();
        }

        public override int 设置脉冲当量值(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置虚拟IO映射参数(轴扩展数据 _轴IO映射)
        {
            throw new NotImplementedException();
        }

        public override int 设置软限位(轴扩展数据 _软硬件限位)
        {
            throw new NotImplementedException();
        }

        public override int 设置轴IO映射参数(轴扩展数据 _轴IO映射)
        {
            throw new NotImplementedException();
        }


        public override int 设置连续插补Blend拐角过渡模式使能状态(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 设置连续插补暂停及异常停止时IO输出状态(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 设置锁存方式(轴扩展数据 _高速位置锁存)
        {
            throw new NotImplementedException();
        }

        public override int 设置高速比较模式(轴扩展数据 _高速位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 设置高速比较线性模式参数(轴扩展数据 _高速位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 读位寄存器(卡扩展数据 _寄存器操作, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取AB相计数反相值(轴扩展数据 _编码器, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EL限位信号设置(轴扩展数据 _软硬件限位, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EMG急停信号设置(轴扩展数据 _运动异常停止, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EtherCAT总线AD_DA输入输出口数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EtherCAT总线IO输入输出口数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EtherCAT总线循环周期(轴扩展数据 _总线配置, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EtherCAT总线状态(轴扩展数据 _总线错误代码, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EtherCAT总线轴和虚拟轴轴数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EtherCAT总线轴控制模式(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EtherCAT总线轴状态机(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EZ个数(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EZ锁存值(轴扩展数据 _EZ锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EZ锁存标志(轴扩展数据 _EZ锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取EZ锁存模式设置(轴扩展数据 _EZ锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取IO触发减速停止电平信号(轴扩展数据 _运动异常停止, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取IO计数值(卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取IO计数模式设置(卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取PWM当前输出参数(卡扩展数据 _PWM, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取一维位置比较器设置(轴扩展数据 _位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取二维位置比较器设置(轴扩展数据 _位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取函数调用打印输出设置(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 读取剩余未比较的二位比较点数量(轴扩展数据 _位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取剩余未比较的点数量(轴扩展数据 _位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取单轴运动速度曲线(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取原点锁存值(轴扩展数据 _原点锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取原点锁存标志(轴扩展数据 _原点锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取原点锁存模式设置(轴扩展数据 _原点锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取反向间隙值设置(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }



        public override int 读取回原点完成后偏移位置值(轴扩展数据 _运动, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取回原点模式(轴扩展数据 _运动, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取回原点运动状态(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取回原点速度参数(轴扩展数据 _运动, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取圆弧插补限速功能(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取定长运动减速停止时间设置(轴扩展数据 _运动异常停止, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取已经比较过的二维比较点个数(轴扩展数据 _位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取已经比较过的点数量(轴扩展数据 _位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取序列号(卡扩展数据 _密码管理, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取当前二位比较点位置(轴扩展数据 _位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取当前工件原点(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取当前指令位置计数器值(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取当前比较点位置(轴扩展数据 _位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取当前目标位置(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定CMP端口的电平(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定IO组号的全部输入口的电平(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定IO组号的全部输出口的电平(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定控制器或扩展模块的某个输入端口的电平(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定控制器或扩展模块的某个输出端口的电平(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定控制器的全部输入端口的电平(卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定控制器的全部输出口的电平(卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定控制器的某个输入端口的电平(卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定控制器的某个输出端口的电平(卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴有关运动信号的状态(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴特殊信号的使能状态(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的ALARM端口电平(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的ALM信号设置(轴数据 _轴, 卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的ERC端口电平(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的EZ信号电平(轴扩展数据 _编码器, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的INP信号设置(轴数据 _轴, 卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的INP端口电平(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的LTC信号设置(轴扩展数据 _高速位置锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的ORG端口电平(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的伺服使能端口的电平(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的急停端口电平(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的正硬限位端口电平(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的脉冲输出模式设置(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴的负硬限位端口电平(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取指定轴编码器脉冲计数值(轴扩展数据 _编码器, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取控制器COM口参数(控制卡数据 _卡, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }



        public override int 读取插补异常减速停止时间参数(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取插补模式及小线段前瞻参数(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取插补运动速度参数(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取模拟量电压值(卡扩展数据 _模拟量操作, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取模拟量输入触发状态(卡扩展数据 _模拟量操作, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取编码器的计数方式(轴扩展数据 _编码器, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取脉冲当量值设置(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取虚拟IO映射关系参数(轴扩展数据 _轴IO映射, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取设置的插补运动速度曲线平滑时间(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取软限位设置(轴扩展数据 _软硬件限位, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取轴IO映射关系参数(轴扩展数据 _轴IO映射, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取轴停止原因(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取轴当前速度(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取轴类型(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取轴运动模式(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取连续插补Blend拐角过度模式使能状态设置(轴数据 _轴, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取连续插补暂停及异常停止时IO输出状态设置(卡扩展数据 _IO, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取连续插补缓冲区当前插补段号(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 读取连续插补运动状态(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 读取锁存方式(轴扩展数据 _高速位置锁存, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取高速比较器配置(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取高速比较模式设置(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取高速比较状态(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读取高速比较线性模式参数设置(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读字寄存器(卡扩展数据 _寄存器操作, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读扩展rxpdo(轴扩展数据 _总线配置, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读扩展txpdo(轴扩展数据 _总线配置, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读掉电保存寄存器数值(卡扩展数据 _寄存器操作, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 读模拟量设定参数值(卡扩展数据 _模拟量操作, ref 返回值数据 _返回值)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中基于三点圆弧扩展的圆柱螺旋线插补指令(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中基于半径终点圆弧扩展的圆柱螺旋线插补指令(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中基于圆心终点圆弧扩展的螺旋线插补指令(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中控制指定其它轴运动指令(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中暂停延时指令(控制卡数据 _卡)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中直线插补指令(轴数据 _轴)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中相对于轨迹段终点IO提前输出_段内执行(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中相对于轨迹段终点IO滞后输出(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中相对于轨迹段起点IO滞后输出_段内执行(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补中缓冲区立即IO输出(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 连续插补等待IO输入(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 配置高速比较器(轴扩展数据 _高速位置比较)
        {
            throw new NotImplementedException();
        }

        public override int 重置IO计数值(卡扩展数据 _IO)
        {
            throw new NotImplementedException();
        }

        public override int 限位当原点切换(轴扩展数据 _运动)
        {
            throw new NotImplementedException();
        }
    }
}
