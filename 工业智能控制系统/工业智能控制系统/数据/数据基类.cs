using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工业智能控制系统.数据
{
    public class 数据基类
    {
        private string _名称 = string.Empty;
        private  string _GUID=string.Empty;

        public string 名称
        {
            get
            {
                return _名称;
            }

            set
            {
                _名称 = value;
            }
        }

        public string GUID
        {
            get
            {
                return _GUID;
            }

            set
            {
                _GUID = value;
            }
        }
    }
}
