using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNLog
{
    //暂时用的这个枚举来做时间筛选的选项，比较笨，因为不好扩展；相比而言人物选项的内容就是动态扩展的。
    public enum DateTypeenum
    {
        选择时间段 = 0,
        Day = 1,
        ThreeDay = 3,
        Week = 7,
        HalfMonth = 15,
        Month = 30,
        All
    }

    //这个没用到
    public enum Authorenum
    {
        hjy,
        lsx
    }
    
}
