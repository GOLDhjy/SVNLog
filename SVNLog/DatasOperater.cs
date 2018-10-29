using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SVNLog
{
    /// <summary>
    /// 数据操作类,对XML的读入解析反序列化等等操作
    /// </summary>
    public static class DatasOperateSystem
    {
        //xml序列化
        public static void WriteXmlAsync(string Path, log ObjectXml)
        {
            try
            {
                using (FileStream FS = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    XmlSerializer MyXmlSerializer = new XmlSerializer(typeof(log));
                    MyXmlSerializer.Serialize(FS, ObjectXml);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //xml反序列化
        public static void ReadXmlAsync(string Path, out log Result)//值类型，利用out关键字
        {
            using (FileStream FS = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                XmlSerializer MyXmlSerializer = new XmlSerializer(typeof(log));
                Result = (log)MyXmlSerializer.Deserialize(FS);
            }
        }

        public static void ClassifyByPerson(ref log MyLog , Dictionary<string,List<logentry>> Person)
        {
            foreach(logentry element in MyLog.Logentrie)
            {
                Person[element.Author].Add(element);
            }
        }
        //对数据进行人物筛选
        public static void ClassifyByPerson(List<logentry> LogList , List<logentry> LogListTmp,string Name)
        {
            foreach(logentry item in LogList)
            {
                if(item.Author==Name)
                {
                    LogListTmp.Add(item);
                }
            }
        }

        public static void ClassifyByTime(ref log MyLog , Dictionary<DateTypeenum, List<logentry>> Time)
        {
            Regex regex = new Regex(@"^(\d*)-(\d*)-(\d*)T(\d*):(\d*):([\d\.]{5})\w*$");
            foreach (logentry item in MainWindow.LogList)
            {
                Match match = regex.Match(item.Date);
                Console.WriteLine(match.Groups[0].Value + " " + match.Groups[1].Value);
            }
        }

        //根据所选时间筛选，本来想直接做成一个时间段筛选，但是先做成选项筛选，还有就是，时间筛选部分的算法我没完成，只是胡乱做了一个样例。
        public static void ClassifyByTime(List<logentry> LogList , List<logentry> LogListTmp , DateTypeenum Date)
        {
            if (Date == DateTypeenum.All)
            {
                LogListTmp.AddRange(LogList);
                LogListTmp = LogList;
                return;
            }
            Regex regex = new Regex(@"^(\d*)-(\d*)-(\d*)T(\d*):(\d*):([\d\.]{5})\w*$");
            foreach (logentry item in LogList)
            {
                Match match = regex.Match(item.Date);
                //Console.WriteLine(match.Groups[0].Value + " " + match.Groups[1].Value);
                
                switch (Date)
                {
                    case DateTypeenum.Day:
                        if (DateTime.Today.Day - 1 <= Convert.ToInt32(match.Groups[3].Value))
                        {
                            LogListTmp.Add(item);
                        }
                        break;
                    case DateTypeenum.ThreeDay:
                        if (DateTime.Today.Day - 3 <= Convert.ToInt32(match.Groups[3].Value))
                        {
                            LogListTmp.Add(item);
                        }
                        break;
                    case DateTypeenum.Week:
                        if (DateTime.Today.Day - 7 <= Convert.ToInt32(match.Groups[3].Value))
                        {
                            LogListTmp.Add(item);
                        }
                        break;
                    case DateTypeenum.HalfMonth:
                        if (DateTime.Today.Day - 15 <= Convert.ToInt32(match.Groups[3].Value))
                        {
                            LogListTmp.Add(item);
                        }
                        break;
                    case DateTypeenum.Month:
                        if (DateTime.Today.Month - 1 <= Convert.ToInt32(match.Groups[2].Value))
                        {
                            LogListTmp.Add(item);
                        }
                        break;
                }
                
            }

        }
        //暂时没用到这个接口
        public static void CoverToDateDrid(ref log MyLog,List<DataGridLog> DataList)
        {
            DataGridLog Tmp = new DataGridLog();
            foreach (logentry item in MyLog.Logentrie)
            {
                Tmp.Author = item.Author;
                Tmp.Date = item.Date;
                Tmp.Msg = item.Msg;
                Tmp.Revision = item.Revision;
                foreach(path MyPath in item.Paths.Path)
                {
                    Tmp.Paths += MyPath.Value;
                }
            }
        }
        
    }
    

}
