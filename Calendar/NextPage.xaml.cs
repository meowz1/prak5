using Glimpse.Core.ClientScript;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// Логика взаимодействия для NextPage.xaml
    /// </summary>
    public partial class NextPage : Page
    {
        Frame nextFrame = new Frame();
        public NextPage(Frame frame)
        {
            InitializeComponent();
            nextFrame = frame;

            DateTime now = DateTime.Now.Date;
            DateDpk.Text = now.ToString();
        }

        private void NextMouth_Click(object sender, RoutedEventArgs e)
        {
            string vr = DateDpk.SelectedDate.ToString().Substring(0, 10);
            (int, int) date = Helps.ParseDate(vr);

            if (date.Item1 == 12)
            {
                DateDpk.Text = $"01.01.{date.Item2 + 1}";
            }
            else
            {
                DateDpk.Text = $"01.{date.Item1 + 1}.{date.Item2}";
            }
            
        }

        private void BackMouth_Click(object sender, RoutedEventArgs e)
        {
            string vr = DateDpk.SelectedDate.ToString().Substring(0, 10);
            (int, int) date = Helps.ParseDate(vr);
            if (date.Item1 == 1)
            {
                DateDpk.Text = $"01.01.{date.Item2 - 1}";
            }
            else
            {
                DateDpk.Text = $"01.{date.Item1 - 1}.{date.Item2}";
            }
        }

        private void DateDpk_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatesPanel.Children.Clear();
            string vr = DateDpk.SelectedDate.ToString().Substring(0, 10);
            (int, int) date = Helps.ParseDate(vr);
            int days = DateTime.DaysInMonth(date.Item2, date.Item1);

            string ifDate = $"{date.Item1}.{date.Item2}";
            List<DayClass> serDays = Serializer.Des<List<DayClass>>()?? new List<DayClass>();


            for (int i = 1; i <= days; i++)
            {
                Plitka p = new Plitka();
                p.datelbl.Content = i.ToString();
                DatesPanel.Children.Add(p);
                p.MouseDown += Element;
                if (serDays.Count != 0)
                {
                    foreach (DayClass j in serDays)
                    {
                        var datetme = new DateTime(date.Item2, date.Item1, i).ToString().Substring(0, 10);
/*                        string vrDate = $"{i}.{ifDate}";*/
                        if (datetme == j.date)
                        {
                            var uri = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory() + $"\\..\\..\\{j.animes.imgPath}"));
                            p.ImgSt.Source = new BitmapImage(uri);
                        }
                    }
                }
            }
        }

        private void Element(object sender, RoutedEventArgs e)
        {
            nextFrame.Content = new ListAnime(nextFrame, DateDpk.SelectedDate.ToString());
        }
    }
}
