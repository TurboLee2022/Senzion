using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 工业智能控制系统.数据;

namespace 工业智能控制系统.运动
{
    public abstract class 运动控制卡基类
    {
        private 控制卡数据 _卡;
        private 轴数据 _轴;
        private 轴扩展数据 _轴扩展;
        private 卡扩展数据 _卡扩展;
        public  异常代码数据 _异常代码;
        public 控制卡数据 卡
        {
            get
            {
                return _卡;
            }

            set
            {
                _卡 = value;
            }
        }

        public 轴数据 轴
        {
            get
            {
                return _轴;
            }

            set
            {
                _轴 = value;
            }
        }

        public 轴扩展数据 轴扩展
        {
            get
            {
                return _轴扩展;
            }

            set
            {
                _轴扩展 = value;
            }
        }

        public 卡扩展数据 卡扩展
        {
            get
            {
                return _卡扩展;
            }

            set
            {
                _卡扩展 = value;
            }
        }

        public 异常代码数据 异常代码
        {
            get
            {
                return _异常代码;
            }

            set
            {
                _异常代码 = value;
            }
        }

        #region 数据初始化
        /// <summary>
        /// 初始化实例化各数据类,并绑定各数据间关系
        /// </summary>
        public void 初始化各数据()
        {
            _卡 = new 控制卡数据();

            _轴 = new 轴数据();
            _轴.卡数据 = _卡.卡数据;

            _卡扩展 = new 卡扩展数据();
            _卡扩展.卡数据 = _卡.卡数据;

            _轴扩展 = new 轴扩展数据();
            _轴扩展.卡数据 = _卡.卡数据;
            _轴扩展.轴列表 = _轴.轴列表;

            _异常代码 = new 异常代码数据();
        }
        public abstract int 初始化异常代码(ref 异常代码数据 _异常代码);
        #endregion

        #region 控制卡配置/通讯连接
        public abstract int 初始化连接(控制卡数据 _卡);
        public abstract int 初始化连接_高级(控制卡数据 _卡);

        public abstract int 断开连接(控制卡数据 _卡);
        public abstract int 设置连接超时(控制卡数据 _卡);
        public abstract int 读取发布版本号(控制卡数据 _卡, ref 返回值数据 _返回值);
        public abstract int 获取控制器硬件版本号(控制卡数据 _卡, ref 返回值数据 _返回值);
        public abstract int 获取控制器固件版本号(控制卡数据 _卡, ref 返回值数据 _返回值);
        public abstract int 获取控制器动态库文件版本号( ref 返回值数据 _返回值);
        public abstract int 获取当前控制器的轴数(控制卡数据 _卡,ref 返回值数据 _返回值);
        public abstract int 函数调用打印输出设置(控制卡数据 _卡);
        public abstract int 读取函数调用打印输出设置(控制卡数据 _卡, ref 返回值数据 _返回值);
        public abstract int 设置控制器新IP地址(控制卡数据 _卡);
        public abstract int 读取控制器IP地址(控制卡数据 _卡,ref 返回值数据 _返回值);
        public abstract int 设置控制器COM口参数(控制卡数据 _卡);
        public abstract int 读取控制器COM口参数(控制卡数据 _卡, ref 返回值数据 _返回值);

        #endregion
        #region 脉冲模式
        public abstract int 设置指定轴的脉冲输出模式(轴数据 _轴);
        public abstract int 读取指定轴的脉冲输出模式设置(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 设置脉冲当量值(轴数据 _轴);
        public abstract int 读取脉冲当量值设置(轴数据 _轴, ref 返回值数据 _返回值);
        #endregion
        #region 反向间隙设置
        public abstract int 设置反向间隙值(轴数据 _轴);
        public abstract int 读取反向间隙值设置(轴数据 _轴, ref 返回值数据 _返回值);

        #endregion
        #region 状态监控
        public abstract int 检测指定轴的运动状态(轴数据 _轴);
        public abstract int 检测坐标系的运动状态(控制卡数据 _卡);
        public abstract int 读取指定轴特殊信号的使能状态(轴数据 _轴);
        public abstract int 读取指定轴有关运动信号的状态(轴数据 _轴);
        public abstract int 读取轴运动模式(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 设置当前指令位置计数器值(轴数据 _轴);
        public abstract int 读取当前指令位置计数器值(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 读取轴当前速度(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 读取轴停止原因(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 清除轴停止原因(轴数据 _轴);
        public abstract int 读取当前目标位置(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 设置当前工件原点(轴数据 _轴);
        public abstract int 读取当前工件原点(轴数据 _轴, ref 返回值数据 _返回值);

        #endregion
        #region 点位运动
        public abstract int 设置单轴运动速度曲线_时间模式(轴扩展数据 _运动);
        public abstract int 读取单轴运动速度曲线(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 设置单轴速度曲线S段参数值(轴扩展数据 _运动);
        public abstract int 单轴定长运动(轴扩展数据 _运动);
        public abstract int 单轴连续运动(轴扩展数据 _运动);
        public abstract int 在线改变指定轴的当前目标位置(轴扩展数据 _运动);
        public abstract int 强制改变指定轴的当前目标位置(轴扩展数据 _运动);
        public abstract int 在线改变指定轴的当前运动速度(轴扩展数据 _运动);

        #endregion
        #region 回原点运动
        public abstract int 设置ORG原点信号(轴扩展数据 _运动);
        public abstract int 设置回原点模式(轴扩展数据 _运动);
        public abstract int 读取回原点模式(轴扩展数据 _运动,ref 返回值数据 _返回值);
        public abstract int 设置EZ个数(轴数据 _轴);
        public abstract int 读取EZ个数(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 回原点完成后设置偏移位置值(轴扩展数据 _运动);
        public abstract int 读取回原点完成后偏移位置值(轴扩展数据 _运动, ref 返回值数据 _返回值);
        public abstract int 设置回原点速度参数(轴扩展数据 _运动);
        public abstract int 读取回原点速度参数(轴扩展数据 _运动, ref 返回值数据 _返回值);
        public abstract int 限位当原点切换(轴扩展数据 _运动);
        public abstract int 回原点运动(轴数据 _轴);
        public abstract int 读取回原点运动状态(轴数据 _轴, ref 返回值数据 _返回值);

        #endregion
        #region PVT运动函数
        public abstract int PTT模式向指定数据表传送数据(轴数据 _轴);
        public abstract int PTS模式向指定数据表传送数据(轴数据 _轴);
        public abstract int PVT模式向指定数据表传送数据(轴数据 _轴);
        public abstract int PVTS模式向指定数据表传送数据(轴数据 _轴);
        public abstract int 启动PVT运动(轴数据 _轴);

        #endregion
        #region 插补运动参数函数
        public abstract int 设置插补运动速度参数_时间模式(轴数据 _轴);
        public abstract int 读取插补运动速度参数(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 设置插补运动速度曲线的平滑时间(轴数据 _轴);
        public abstract int 读取设置的插补运动速度曲线平滑时间(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 设置插补异常减速停止时间参数(轴数据 _轴);
        public abstract int 读取插补异常减速停止时间参数(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 设置圆弧插补限速功能(轴数据 _轴);
        public abstract int 读取圆弧插补限速功能(轴数据 _轴, ref 返回值数据 _返回值);

        #endregion
        #region 单段插补运动函数
        public abstract int 直线插补运动(轴数据 _轴);
        public abstract int 圆心圆弧终点模式扩展的螺旋线插补运动(轴数据 _轴);
        public abstract int 半径圆弧终点模式扩展的螺旋线插补运动(轴数据 _轴);
        public abstract int 三点圆弧模式扩展的螺旋线插补运动(轴数据 _轴);

        #endregion
        #region 连续插补运动函数
        public abstract int 设置插补模式及小线段前瞻参数(轴数据 _轴);
        public abstract int 读取插补模式及小线段前瞻参数(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 设置连续插补Blend拐角过渡模式使能状态(轴数据 _轴);
        public abstract int 读取连续插补Blend拐角过度模式使能状态设置(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 打开连续插补缓冲区(轴数据 _轴);
        public abstract int 开始连续插补(控制卡数据 _卡);
        public abstract int 关闭连续插补缓冲区(控制卡数据 _卡);
        public abstract int 暂停连续插补(控制卡数据 _卡);
        public abstract int 停止连续插补(控制卡数据 _卡);
        public abstract int 动态调整连续插补速度比例(控制卡数据 _卡);
        public abstract int 连续插补中暂停延时指令(控制卡数据 _卡);
        public abstract int 连续插补中直线插补指令(轴数据 _轴);
        public abstract int 连续插补中基于圆心终点圆弧扩展的螺旋线插补指令(轴数据 _轴);
        public abstract int 连续插补中基于半径终点圆弧扩展的圆柱螺旋线插补指令(轴数据 _轴);
        public abstract int 连续插补中基于三点圆弧扩展的圆柱螺旋线插补指令(轴数据 _轴);
        public abstract int 连续插补中控制指定其它轴运动指令(轴数据 _轴);

        #endregion
        #region 连续插补状态检测函数
        public abstract int 查询连续插补缓冲区剩余插补空间(控制卡数据 _卡);
        public abstract int 读取连续插补缓冲区当前插补段号(控制卡数据 _卡);
        public abstract int 读取连续插补运动状态(控制卡数据 _卡);
        public abstract int 检测连续插补运行是否完成(控制卡数据 _卡);

        #endregion
        #region 连续插补IO控制函数
        public abstract int 设置连续插补暂停及异常停止时IO输出状态(卡扩展数据 _IO);
        public abstract int 读取连续插补暂停及异常停止时IO输出状态设置(卡扩展数据 _IO, ref 返回值数据 _返回值);
        public abstract int 连续插补等待IO输入(卡扩展数据 _IO);
        public abstract int 连续插补中相对于轨迹段起点IO滞后输出_段内执行(卡扩展数据 _IO);
        public abstract int 连续插补中相对于轨迹段终点IO滞后输出(卡扩展数据 _IO);
        public abstract int 连续插补中相对于轨迹段终点IO提前输出_段内执行(卡扩展数据 _IO);
        public abstract int 连续插补中缓冲区立即IO输出(卡扩展数据 _IO);
        public abstract int 清除段内未执行完的IO动作(卡扩展数据 _IO);

        #endregion
        #region PWM立即输出函数
        public abstract int 设置PWM立即输出参数(卡扩展数据 _PWM);
        public abstract int 读取PWM当前输出参数(卡扩展数据 _PWM,ref 返回值数据 _返回值);

        #endregion
        #region 通用IO接口函数
        public abstract int 读取指定控制器的某个输入端口的电平(卡扩展数据 _IO, ref 返回值数据 _返回值);
        public abstract int 设置指定控制器的某个输出端口的电平(卡扩展数据 _IO);
        public abstract int 读取指定控制器的某个输出端口的电平(卡扩展数据 _IO, ref 返回值数据 _返回值);
        public abstract int 读取指定控制器的全部输入端口的电平(卡扩展数据 _IO, ref 返回值数据 _返回值);
        public abstract int 读取指定控制器的全部输出口的电平(卡扩展数据 _IO, ref 返回值数据 _返回值);
        public abstract int 设置指定控制器的全部输出口的电平(卡扩展数据 _IO);
        public abstract int IO输出延时翻转(卡扩展数据 _IO);
        public abstract int 设置IO计数模式(卡扩展数据 _IO);
        public abstract int 读取IO计数模式设置(卡扩展数据 _IO, ref 返回值数据 _返回值);
        public abstract int 重置IO计数值(卡扩展数据 _IO);
        public abstract int 读取IO计数值(卡扩展数据 _IO, ref 返回值数据 _返回值);

        #endregion
        #region 专用IO接口函数
        public abstract int 设置指定轴的INP信号(轴数据 _轴, 卡扩展数据 _IO);
        public abstract int 读取指定轴的INP信号设置(轴数据 _轴, 卡扩展数据 _IO, ref 返回值数据 _返回值);
        public abstract int 设置指定轴的ALM信号(轴数据 _轴, 卡扩展数据 _IO);
        public abstract int 读取指定轴的ALM信号设置(轴数据 _轴, 卡扩展数据 _IO, ref 返回值数据 _返回值);
        public abstract int 控制指定轴的伺服使能端口的输出(轴数据 _轴, 卡扩展数据 _IO);
        public abstract int 读取指定轴的伺服使能端口的电平(轴数据 _轴);
        public abstract int 控制指定轴的ERC信号输出(轴数据 _轴, 卡扩展数据 _IO);
        public abstract int 读取指定轴的ERC端口电平(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 读取指定轴的ALARM端口电平(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 读取指定轴的INP端口电平(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 读取指定轴的ORG端口电平(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 读取指定轴的正硬限位端口电平(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 读取指定轴的负硬限位端口电平(轴数据 _轴, ref 返回值数据 _返回值);
        public abstract int 读取指定轴的急停端口电平(轴数据 _轴, ref 返回值数据 _返回值);

        #endregion
        #region 编码器函数
        public abstract int 设置编码器的计数方式(轴扩展数据 _编码器);
        public abstract int 读取编码器的计数方式(轴扩展数据 _编码器, ref 返回值数据 _返回值);
        public abstract int 设置指定轴编码器脉冲计数值(轴扩展数据 _编码器);
        public abstract int 读取指定轴编码器脉冲计数值(轴扩展数据 _编码器, ref 返回值数据 _返回值);
        public abstract int 设置指定轴的EZ信号电平(轴扩展数据 _编码器);
        public abstract int 读取指定轴的EZ信号电平(轴扩展数据 _编码器, ref 返回值数据 _返回值);
        public abstract int 设置AB相计数反相(轴扩展数据 _编码器);
        public abstract int 读取AB相计数反相值(轴扩展数据 _编码器, ref 返回值数据 _返回值);

        #endregion
        #region 高速位置锁存函数
        public abstract int 设置指定轴的LTC信号(轴扩展数据 _高速位置锁存);
        public abstract int 读取指定轴的LTC信号设置(轴扩展数据 _高速位置锁存, ref 返回值数据 _返回值);
        public abstract int 设置锁存方式(轴扩展数据 _高速位置锁存);
        public abstract int 读取锁存方式(轴扩展数据 _高速位置锁存, ref 返回值数据 _返回值);
        public abstract int 从控制器内读取锁存器的值(轴扩展数据 _高速位置锁存, ref 返回值数据 _返回值);
        public abstract int 从控制器内读取指定轴的锁存次数(轴扩展数据 _高速位置锁存, ref 返回值数据 _返回值);
        public abstract int 复位锁存器的标志位(轴扩展数据 _高速位置锁存);

        #endregion
        #region 原点锁存函数
        public abstract int 设置原点锁存模式(轴扩展数据 _原点锁存);
        public abstract int 读取原点锁存模式设置(轴扩展数据 _原点锁存, ref 返回值数据 _返回值);
        public abstract int 清除原点锁存标志(轴扩展数据 _原点锁存);
        public abstract int 读取原点锁存标志(轴扩展数据 _原点锁存, ref 返回值数据 _返回值);
        public abstract int 读取原点锁存值(轴扩展数据 _原点锁存, ref 返回值数据 _返回值);

        #endregion
        #region EZ锁存函数
        public abstract int 设置EZ锁存模式(轴扩展数据 _EZ锁存);
        public abstract int 读取EZ锁存模式设置(轴扩展数据 _EZ锁存, ref 返回值数据 _返回值);
        public abstract int 清除EZ锁存标志(轴扩展数据 _EZ锁存);
        public abstract int 读取EZ锁存标志(轴扩展数据 _EZ锁存, ref 返回值数据 _返回值);
        public abstract int 读取EZ锁存值(轴扩展数据 _EZ锁存, ref 返回值数据 _返回值);

        #endregion
        #region 位置比较函数
        public abstract int 设置一维位置比较器(轴扩展数据 _位置比较);
        public abstract int 读取一维位置比较器设置(轴扩展数据 _位置比较, ref 返回值数据 _返回值);
        public abstract int 清除已添加的所有一维位置比较点(轴扩展数据 _位置比较);
        public abstract int 添加一维位置比较点(轴扩展数据 _位置比较);
        public abstract int 读取当前比较点位置(轴扩展数据 _位置比较, ref 返回值数据 _返回值);
        public abstract int 读取已经比较过的点数量(轴扩展数据 _位置比较, ref 返回值数据 _返回值);
        public abstract int 读取剩余未比较的点数量(轴扩展数据 _位置比较, ref 返回值数据 _返回值);
        public abstract int 设置二维位置比较器(轴扩展数据 _位置比较);
        public abstract int 读取二维位置比较器设置(轴扩展数据 _位置比较, ref 返回值数据 _返回值);
        public abstract int 清除已添加的所有二维位置比较点(轴扩展数据 _位置比较);
        public abstract int 添加二维位置比较点(轴扩展数据 _位置比较);
        public abstract int 读取当前二位比较点位置(轴扩展数据 _位置比较, ref 返回值数据 _返回值);
        public abstract int 读取已经比较过的二维比较点个数(轴扩展数据 _位置比较, ref 返回值数据 _返回值);
        public abstract int 读取剩余未比较的二位比较点数量(轴扩展数据 _位置比较, ref 返回值数据 _返回值);

        #endregion
        #region 高速位置比较函数
        public abstract int 设置高速比较模式(轴扩展数据 _高速位置比较);
        public abstract int 读取高速比较模式设置(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值);
        public abstract int 配置高速比较器(轴扩展数据 _高速位置比较);
        public abstract int 读取高速比较器配置(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值);
        public abstract int 清除已添加的所有高速位置比较点(轴扩展数据 _高速位置比较);
        public abstract int 添加_更新高速比较位置(轴扩展数据 _高速位置比较);
        public abstract int 设置高速比较线性模式参数(轴扩展数据 _高速位置比较);
        public abstract int 读取高速比较线性模式参数设置(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值);
        public abstract int 读取高速比较状态(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值);
        public abstract int 控制指定CMP端口的输出(轴扩展数据 _高速位置比较);
        public abstract int 读取指定CMP端口的电平(轴扩展数据 _高速位置比较, ref 返回值数据 _返回值);

        #endregion
        #region 软硬件限位函数
        public abstract int 设置EL限位信号(轴扩展数据 _软硬件限位);
        public abstract int 读取EL限位信号设置(轴扩展数据 _软硬件限位, ref 返回值数据 _返回值);
        public abstract int 设置软限位(轴扩展数据 _软硬件限位);
        public abstract int 读取软限位设置(轴扩展数据 _软硬件限位, ref 返回值数据 _返回值);

        #endregion
        #region 运动异常停止函数
        public abstract int 指定轴停止运动(轴扩展数据 _运动异常停止);
        public abstract int 停止坐标系内所有轴的运动(轴扩展数据 _运动异常停止);
        public abstract int 紧急停止所有轴(轴扩展数据 _运动异常停止);
        public abstract int 设置EMG急停信号(轴扩展数据 _运动异常停止);
        public abstract int 读取EMG急停信号设置(轴扩展数据 _运动异常停止, ref 返回值数据 _返回值);
        public abstract int 设置IO触发减速停止电平信号(轴扩展数据 _运动异常停止);
        public abstract int 读取IO触发减速停止电平信号(轴扩展数据 _运动异常停止, ref 返回值数据 _返回值);
        public abstract int 设置定长运动减速停止时间(轴扩展数据 _运动异常停止);
        public abstract int 读取定长运动减速停止时间设置(轴扩展数据 _运动异常停止, ref 返回值数据 _返回值);
        public abstract int 设置插补运动减速停止时间(轴扩展数据 _运动异常停止);

        #endregion
        #region 轴IO映射函数
        public abstract int 设置轴IO映射参数(轴扩展数据 _轴IO映射);
        public abstract int 读取轴IO映射关系参数(轴扩展数据 _轴IO映射, ref 返回值数据 _返回值);
        public abstract int 设置虚拟IO映射参数(轴扩展数据 _轴IO映射);
        public abstract int 读取虚拟IO映射关系参数(轴扩展数据 _轴IO映射, ref 返回值数据 _返回值);

        #endregion
        #region 密码管理函数
        public abstract int 写入序列号(卡扩展数据 _密码管理);
        public abstract int 读取序列号(卡扩展数据 _密码管理, ref 返回值数据 _返回值);
        public abstract int 写入密码(卡扩展数据 _密码管理);
        public abstract int 密码校验(卡扩展数据 _密码管理);
        public abstract int 登陆密码(卡扩展数据 _密码管理);
        public abstract int 修改登陆密码(卡扩展数据 _密码管理);

        #endregion
        #region 文件管理函数
        public abstract int 下载本地文件到FLASH(卡扩展数据 _文件管理);
        public abstract int 下载内存文件到FLASH(卡扩展数据 _文件管理);
        public abstract int 上传FLASH文件到本地文件(卡扩展数据 _文件管理);
        public abstract int 上传FLASH文件到内存文件(卡扩展数据 _文件管理);
        public abstract int 下载本地文件到RAM_掉电不保存(卡扩展数据 _文件管理);
        public abstract int 下载内存文件到RAM_掉电不保存(卡扩展数据 _文件管理);
        public abstract int 文件下载进度(卡扩展数据 _文件管理);
        public abstract int 格式化FLASH(卡扩展数据 _文件管理);

        #endregion
        #region 寄存器操作
        public abstract int 写位寄存器(卡扩展数据 _寄存器操作);
        public abstract int 读位寄存器(卡扩展数据 _寄存器操作, ref 返回值数据 _返回值);
        public abstract int 写字寄存器(卡扩展数据 _寄存器操作);
        public abstract int 读字寄存器(卡扩展数据 _寄存器操作, ref 返回值数据 _返回值);
        public abstract int 设置掉电保存寄存器值(卡扩展数据 _寄存器操作);
        public abstract int 读掉电保存寄存器数值(卡扩展数据 _寄存器操作, ref 返回值数据 _返回值);

        #endregion
        #region 模拟量操作函数
        public abstract int 读取模拟量电压值(卡扩展数据 _模拟量操作, ref 返回值数据 _返回值);
        public abstract int 设置模拟量参数(卡扩展数据 _模拟量操作);
        public abstract int 读模拟量设定参数值(卡扩展数据 _模拟量操作, ref 返回值数据 _返回值);
        public abstract int 置位模拟量输入触发状态(卡扩展数据 _模拟量操作);
        public abstract int 读取模拟量输入触发状态(卡扩展数据 _模拟量操作, ref 返回值数据 _返回值);

        #endregion
        #region 总线配置函数
        public abstract int 复位CANopen总线(轴扩展数据 _总线配置);
        public abstract int 停止EtherCAT总线运行(轴扩展数据 _总线配置);
        public abstract int 获取轴IO信息(轴扩展数据 _总线配置, ref 返回值数据 _返回值);
        public abstract int 获取心跳报文信息(轴扩展数据 _总线配置, ref 返回值数据 _返回值);
        public abstract int 获取紧急报文信息(轴扩展数据 _总线配置, ref 返回值数据 _返回值);
        public abstract int 设置从站对象字典(轴扩展数据 _总线配置);
        public abstract int 获取从站对象字典(轴扩展数据 _总线配置, ref 返回值数据 _返回值);
        public abstract int 发送NMT管理报文(轴扩展数据 _总线配置);
        public abstract int 读取EtherCAT总线循环周期(轴扩展数据 _总线配置, ref 返回值数据 _返回值);
        public abstract int 写扩展rxpdo(轴扩展数据 _总线配置);
        public abstract int 读扩展rxpdo(轴扩展数据 _总线配置, ref 返回值数据 _返回值);
        public abstract int 读扩展txpdo(轴扩展数据 _总线配置, ref 返回值数据 _返回值);

        #endregion
        #region 总线IO及轴控制函数
        public abstract int 读取轴类型(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 设置EtherCAT总线驱动器使能(轴扩展数据 _总线IO及轴控制);
        public abstract int 设置EtherCAT总线驱动器禁止使能(轴扩展数据 _总线IO及轴控制);
        public abstract int 同步运动(轴扩展数据 _总线IO及轴控制);
        public abstract int 读取EtherCAT总线轴状态机(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 读取EtherCAT总线轴控制模式(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 设置EtherCAT总线轴回零参数(轴扩展数据 _总线IO及轴控制);
        public abstract int 读取EtherCAT总线轴和虚拟轴轴数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 读取EtherCAT总线AD_DA输入输出口数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 读取EtherCAT总线IO输入输出口数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 获取EtherCAT总线模拟量IO点数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 获取EtherCAT从站总数(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 获取EtherCAT轴数字量输出IO状态(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 设置EtherCAT轴数字量输出IO状态(轴扩展数据 _总线IO及轴控制);
        public abstract int 获取EtherCAT轴数字量输入IO状态(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 设置指定控制器或扩展模块的某个输出端口的电平(轴扩展数据 _总线IO及轴控制);
        public abstract int 读取指定控制器或扩展模块的某个输出端口的电平(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 读取指定控制器或扩展模块的某个输入端口的电平(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 设置指定IO组号的全部输出口的电平(轴扩展数据 _总线IO及轴控制);
        public abstract int 读取指定IO组号的全部输出口的电平(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);
        public abstract int 读取指定IO组号的全部输入口的电平(轴扩展数据 _总线IO及轴控制, ref 返回值数据 _返回值);

        #endregion
        #region 总线错误代码函数
        public abstract int 清除报警信号(轴扩展数据 _总线错误代码);
        public abstract int 读取EtherCAT总线状态(轴扩展数据 _总线错误代码, ref 返回值数据 _返回值);
        public abstract int 清除总线错误(轴扩展数据 _总线错误代码);
        public abstract int 获取指定链接号总线错误代码(轴扩展数据 _总线错误代码, ref 返回值数据 _返回值);
        public abstract int 清除指定链接号总线错误代码(轴扩展数据 _总线错误代码);
        public abstract int 获取指定轴总线错误代码(轴扩展数据 _总线错误代码, ref 返回值数据 _返回值);
        public abstract int 清除指定轴号总线错误代码(轴扩展数据 _总线错误代码);

        #endregion
    }
}
