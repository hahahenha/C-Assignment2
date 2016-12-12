using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using 作业2;

namespace 作业2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //创建数组
        stuInfo[] student = {
                                new stuInfo("王一", "男", "20130101", "Image/1.jpg", 20, 20, 60),
                                new stuInfo("张二", "男", "20130102", "Image/2.jpg", 21, 15, 50),
                                new stuInfo("张二", "男", "20130201", "Image/3.jpg", 19, 25, 70),
                                new stuInfo("李三", "男", "20130202", "Image/4.jpg", 20, 25, 65)
                            };
        stuInfo currentStudent = new stuInfo();




        //这里我treeview控件添加的节点是用函数添加的 让每个节点有header属性，便于后面利用这个属性判段学生
        public void InitTree()
        {
            //父节点
            TreeViewItem tvitemp1 = new TreeViewItem();
            tvitemp1.Header = "计算机1101班";
            //两个子节点
            TreeViewItem tvitemp11 = new TreeViewItem();
            tvitemp11.Header = "王一";
            TreeViewItem tvitemp12 = new TreeViewItem();
            tvitemp12.Header = "张二";
            tvitemp1.Items.Add(tvitemp11);
            tvitemp1.Items.Add(tvitemp12);

            TreeViewItem tvitemp2 = new TreeViewItem();
            tvitemp2.Header = "计算机1102班";
            TreeViewItem tvitemp21 = new TreeViewItem();
            tvitemp21.Header = "张二";
            TreeViewItem tvitemp22 = new TreeViewItem();
            tvitemp22.Header = "李三";
            tvitemp2.Items.Add(tvitemp21);
            tvitemp2.Items.Add(tvitemp22);

            treeView1.Items.Add(tvitemp1);
            treeView1.Items.Add(tvitemp2);
        }

        //主函数
        public MainWindow()
        {
            //这个设置xaml的datacontext为 stuInfo类的对象
            this.DataContext = new stuInfo();

            //两个初始化
            InitializeComponent();
            InitTree();

        }

        //节点选择发生变化时 响应函数
        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //获取当前节点
            TreeViewItem a = this.treeView1.SelectedItem as TreeViewItem;

            //获取节点的header属性
            string xa = a.Header.ToString();

            //判断姓名
            switch (xa)
            {
                case "王一":
                    myPanel.DataContext = student[0]; //myPanel是xaml里的属性 代表整个界面 datacontext之前申明过为stuInfo对象

                    //图片控件没绑定 设置显示图片 方法为调用相对路径 image文件夹下的图片 路径是stuInfo的imagePath属性
                    image1.Source = new BitmapImage(new Uri(@student[0].imagePath, UriKind.Relative));
                    break;
                case "张二":
                    TreeViewItem b = a.Parent as TreeViewItem;
                    string xb = b.Header.ToString();
                    if (xb == "计算机1101班")
                    {
                        myPanel.DataContext = student[1];
                        image1.Source = new BitmapImage(new Uri(@student[1].imagePath, UriKind.Relative));
                        break;
                    }
                    else
                    {
                        myPanel.DataContext = student[2];
                        image1.Source = new BitmapImage(new Uri(@student[2].imagePath, UriKind.Relative));
                        break;
                    }
                case "李三":
                    myPanel.DataContext = student[3];
                    image1.Source = new BitmapImage(new Uri(@student[3].imagePath, UriKind.Relative));
                    break;
                default: break;

            }

        }

        //textchange响应函数 目的是让总成绩随着两个成绩的变化实时变化
        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            int.TryParse(textBox5.Text, out i);
            int j;
            int.TryParse(textBox6.Text, out j);
            lbl.Content = i + j;
        }

        private void textBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            int.TryParse(textBox5.Text, out i);
            int j;
            int.TryParse(textBox6.Text, out j);
            lbl.Content = i + j;

        }



    }
}