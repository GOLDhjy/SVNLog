using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace SVNLog
{
    
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static String Xmlpath = String.Empty;//路径，用来找到我们的XML文件
        public static List<DateTypeenum> DateType = new List<DateTypeenum>();//存储时间枚举选项的数据
        public static List<logentry> LogList = new List<logentry>();//存储初始数据，读入的数据
        public static List<logentry> Author = new List<logentry>();//这个是用来存储角色选项的数据。
        public MainWindow()
        {
            InitializeComponent();
            //InitDateType();
            //people p = new people();
            //p.age = "17";
            //p.name = "黄金溢";
            //p.sexual = "男";
            //List<people> peo =new List<people>();
            //for(int i=1; i<=100; i++)
            //{
            //    peo.Add(p);
            //}
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        

        //浏览按钮的回调函数
        private void Button_Click_findpath(object sender, RoutedEventArgs e)
        {
            var OpenFileDialog = new OpenFileDialog();
            DialogResult Result = OpenFileDialog.ShowDialog();

            //DialogResult num = DialogResult.OK;
            if (Result == System.Windows.Forms.DialogResult.OK)
            {
                Xmlpath = System.IO.Path.Combine(Xmlpath, OpenFileDialog.FileName);
                SVNPath.Text = Xmlpath;
            }

            //下面初始化DataGrid、和增加两个选项的内容
            DataInit();
            ComboBoxInit();
            InitDateType();
        }

        //双击某一条信息后，在下面一个DataGrid会显示这次操作修改文件信息和路径
        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                var SL = (logentry)DataGrid.SelectedItem;
                List<path> PathsList = new List<path>();
                foreach(path littlepath in SL.Paths.Path)
                {
                    PathsList.Add(littlepath);
                }
                DataGrid2.ItemsSource = PathsList;
                DataGrid2.AutoGenerateColumns = false;
            }
        }

        //private void MyComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    List<logentry> LogListTmpPerson = new List<logentry>();
        //    var SLVP = (logentry)MyComBox.SelectedItem;
        //    DatasOperateSystem.ClassifyByPerson(LogList, LogListTmpPerson, SLVP.Author);
        //    DataGrid.ItemsSource = LogListTmpPerson;
        //    DataGrid.AutoGenerateColumns = false;
        //}

        //进行筛选
        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {
            List<logentry> LogListTmpPerson = new List<logentry>();
            List<logentry> LogListTmpDate = new List<logentry>();
            var SLVP = (logentry)MyComBox.SelectedItem;
            if (SLVP.Author != "选择提交者")
                DatasOperateSystem.ClassifyByPerson(LogList, LogListTmpPerson, SLVP.Author);
            else
                LogListTmpPerson = LogList;

            var Date = (DateTypeenum)MyComBoxDate.SelectedItem;
            if (Date != DateTypeenum.选择时间段)
                DatasOperateSystem.ClassifyByTime(LogListTmpPerson, LogListTmpDate, Date);
            else
                LogListTmpDate = LogListTmpPerson;

            DataGrid.ItemsSource = LogListTmpDate;
            DataGrid.AutoGenerateColumns = false;
        }


        //时间枚举选项（DateType）的数据的初始化
        private void InitDateType()
        {
            DateTypeenum WU = DateTypeenum.选择时间段;
            DateTypeenum Day = DateTypeenum.Day;
            DateTypeenum ThreeDay = DateTypeenum.ThreeDay;
            DateTypeenum Week = DateTypeenum.Week;
            DateTypeenum HalfMonth = DateTypeenum.HalfMonth;
            DateTypeenum Month = DateTypeenum.Month;
            DateTypeenum All = DateTypeenum.All;
            DateType.Add(WU);
            DateType.Add(Day);
            DateType.Add(ThreeDay);
            DateType.Add(Week);
            DateType.Add(HalfMonth);
            DateType.Add(Month);
            DateType.Add(All);
            MyComBoxDate.SelectedIndex = 0;
            MyComBoxDate.ItemsSource = DateType;
        }
        //存储角色选项（Author）的数据的初始化
        private void ComboBoxInit()
        {

            List<string> Name = new List<string>();
            logentry WU = new logentry();
            WU.Author = "选择提交者";
            Author.Add(WU);
            foreach (logentry loglist in LogList)
            {
                if (!Name.Contains(loglist.Author))
                {
                    Name.Add(loglist.Author);
                    Author.Add(loglist);
                }
            }
            this.MyComBox.ItemsSource = Author;
            this.MyComBox.SelectedIndex = 0;
            //this.MyComBox.SelectedIndex = 0;
        }
        //LogList的初始化
        private void DataInit()
        {
            log MyLog = new log();
            Task Tasks = new Task(() => DatasOperateSystem.ReadXmlAsync(Xmlpath, out MyLog));
            Tasks.Start();
            Tasks.Wait();
            foreach (logentry item in MyLog.Logentrie)
                LogList.Add(item);

            DataGrid.ItemsSource = LogList;
            DataGrid.AutoGenerateColumns = false;
        }
    }
}
