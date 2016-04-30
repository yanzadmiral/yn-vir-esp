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
using System.Collections.Specialized;
using System.Net;
using System.IO.Ports;
using System.IO;
using System.Windows.Threading;

namespace yn_virtual_esp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

        }
        public string key;
        public string url;
        int p;
            
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string c1 = Convert.ToString(rnd.Next(52));
            string c2 = Convert.ToString(rnd.Next(52));
            string[] datta = new string[5];
            datta[0] = c1;
            datta[1] =c2;
            atur2(datta);
            p = p + 1;
            timr.Content = Convert.ToString(p);
            string a = " ["+datta[0] +"/"+ datta[1]+"] ";
            t1.Content = a + t1.Content;
        }
        
        public void atur2(string[] data)
        {
            WebClient objWebClient = new WebClient();

            NameValueCollection objNameValueCollection = new NameValueCollection();
            objNameValueCollection.Add("api_key", key);
            objNameValueCollection.Add("field1", data[0]);
            objNameValueCollection.Add("field2", data[1]);
    
            byte[] bytes = objWebClient.UploadValues(url, "POST", objNameValueCollection);
            //MessageBox.Show(Encoding.ASCII.GetString(bytes));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            url = bok1.Text;
            key = box2.Text;
            l1.Content = url;
            l2.Content = key;

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();

            p = 0;

            btst.IsEnabled = true;
            btml.IsEnabled = false;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            timr.Content = "0";
            btst.IsEnabled = false;
            btml.IsEnabled = true;
        }

        private void box2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}
