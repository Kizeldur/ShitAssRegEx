using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AnotherShitAssWPFPj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShitAssBtn_GetShitAssFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Текст|*.txt;*.doc|Все файлы|*.*";
            dialog.ShowDialog();
            var path = dialog.FileName;
            if (string.IsNullOrEmpty(path)) return;
            //var file = new StreamReader(path);
             
            using (FileStream file = File.OpenRead(path))
            {
                var arr = new byte[file.Length];
                file.Read(arr, 0, Convert.ToInt32(file.Length));
                var text = System.Text.Encoding.Default.GetString(arr);
                ShitAssLabel.Content = text;
                //var regex = new Regex(@"ил\b|ел\b|ал\b|ила\b|ала\b|ела\b|ет\b|ит\b|ить\b|ить\b");
                //var regex = new Regex(@"\b.+[иеа]ла?\b|\b.+[иеа]ть?\b");
                var regex = new Regex(@"[А-Яа-я]+[иеа](ла?|ть?)\b");
                var verbCol = regex.Matches(text);
                //regex = new Regex(@"[ие]л\b|ел\b|ал\b|ила\b|ала\b|ела\b|ет\b|ит\b|ить\b|ить\b|ий\b|ый\b|ого\b|ая\b|ую\b|их\b|ые\b|ие\b|ийся\b|егося\b|уюся\b|аяся\b|иеся\b|ихся\b");
                //regex = new Regex(@"[^]");
                var noun = regex.Matches(text);
                ShitAssLabel.Content = verbCol.Count;
            }


            double[] dataX = new double[] { 20, 5, 10, 50, 70 };
            double[] dataY = new double[] { 1, 10, 35, 78, 50 };
            string[] labels = new string[] { "JS", "PHP", "C++", "Pascal", "C#" };
            //Chart.Plot.AddScatter(dataX, dataY);
            Chart.Plot.AddBar(dataX, dataY);
            Chart.Plot.XTicks(dataY, labels);
            
            Chart.Plot.SetAxisLimits(yMin: 0);
            
        }
    }
}
