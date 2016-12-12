using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace 作业2
{
    //添加两个接口 数据改变 数据错误
    public class stuInfo : INotifyPropertyChanged, IDataErrorInfo
    {

        public event PropertyChangedEventHandler PropertyChanged; //创建数据改变事件
        //创建变量保存 xaml的各个数据  学号 名字 图片路径 性别 年龄 三个成绩
        public string studentId;
        public string studentName;
        public string imagePath;
        public string sex = "男";
        public int age;
        public int grade1;
        public int grade2;
        public int totalGrade;

        //两个构造函数
        public stuInfo(string a, string b, string c, string d, int a1, int b1, int c1)
        {
            this.studentName = a;
            this.sex = b;
            this.studentId = c;
            this.imagePath = d;
            this.age = a1;
            this.grade1 = b1;
            this.grade2 = c1;
            this.totalGrade = b1 + c1;
        }
        public stuInfo()
        { }

        //赋值函数 暂时没用到
        public void FuZhi(stuInfo a)
        {
            StudentName = a.studentName;
            StudentId = a.studentId;
            Sex = a.sex;
            Grade1 = a.grade1;
            Grade2 = a.grade2;
            this.totalGrade = a.totalGrade;
            this.imagePath = a.imagePath;
        }

        //接下来的函数都是这种形式  函数与 xaml 界面textbox绑定
        public string StudentId
        {
            get
            {
                return this.studentId; //将值显示到textbox上
            }
            set
            {
                this.studentId = value;  //获取textbox值到调用它的对象的studentId
                if (PropertyChanged != null) //暂时不清楚
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("StudentId"));
                }
            }
        }

        public string StudentName
        {
            get
            {
                return this.studentName;
            }
            set
            {
                this.studentName = value;

            }
        }

        public string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {

                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Sex"));
                }
                this.sex = value;


                if (value.Equals("男") || value.Equals("女"))
                {
                    this.sex = value;
                }
                else
                {
                    MessageBox.Show("只能为男或女");
                }

            }
        }

        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }
            set
            {
                this.imagePath = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ImagePath"));
                }
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));
                }
            }
        }

        public int Grade1
        {
            get
            {
                return this.grade1;
            }
            set
            {
                this.grade1 = value;
                this.totalGrade = this.grade1 + this.grade2;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Grade1"));
                }
            }
        }

        public int Grade2
        {
            get
            {
                return this.grade2;
            }
            set
            {
                this.grade2 = value;
                this.totalGrade = this.grade1 + this.grade2;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Grade2"));
                }
            }
        }

        //实现接口的方法
        public string Error
        {
            get
            {
                return null;
            }
        }

        //数据不对时显示红框
        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case "Grade1":

                        if (Grade1 < 0 || Grade1 > 100)
                        {
                            result = "Grade1 must between 0 and 100";
                        }
                        break;
                    case "Grade2":

                        if (Grade2 < 0 || Grade2 > 100)
                        {
                            result = "Grade2 must between 0 and 100";
                        }
                        break;
                    case "Sex":

                        if (!(Sex.Equals("男") || Sex.Equals("女")))
                        {
                            //      MessageBox.Show("只能为男或女");
                            result = "必须为男或女";
                        }
                        break;
                }
                return result;
            }
        }

        public int TotalGrade
        {
            get
            {
                return this.totalGrade;
            }
            set
            {
                this.totalGrade = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("TotalGrade"));
                }
            }
        }
    }
}
