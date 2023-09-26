using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для ListAnime.xaml
    /// </summary>
    public partial class ListAnime : Page
    {
        Frame listFrame = new Frame();
        string date;
        public ListAnime(Frame frame, string date)
        {
            InitializeComponent();
            listFrame = frame;
            this.date = date;
            GetDate.Text = date;
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            listFrame.Content = new NextPage(listFrame);
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (first.IsChecked == true)
            {
                Helps.MakeSerClass(GetDate.Text, "//imgs//js.png", "js");
            }
            else if (second.IsChecked == true)
            {
                Helps.MakeSerClass(GetDate.Text, "//imgs//pt.png", "py");
            }
            else if (fird.IsChecked == true)
            {
                Helps.MakeSerClass(GetDate.Text, "//imgs//cs.png", "cs");
            }
            else if (fourth.IsChecked == true)
            {
                Helps.MakeSerClass(GetDate.Text, "//imgs//cpp.png", "cpp");
            }
            listFrame.Content = new NextPage(listFrame);
        }
    }
}
