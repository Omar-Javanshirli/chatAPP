using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace chatAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Human> Humans { get; set; }
        public dynamic GrandientColor { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            GrandientColor=messageBorder.Background;
            Humans = new ObservableCollection<Human>
            {
               new Human
               {
                   Name="Anjelina",
                   Message="I miss you",
                   Image="/Image/anjelina.jpg"
               },
               new Human
               {
                   Name="Rihanna",
                   Message ="don't leave me, please",
                   Image="Image/rihanna.jpg"
               },
               new Human
               {
                   Name="Ester",
                   Message="do you have free time tomorrow?",
                   Image="Image/ester.jpg"
               },
               new Human
               {
                   Name="Lena del",
                   Message="yeterday was a very good day for me. Thank you everythink",
                   Image="Image/lena.jpg"
               }
            };
            if (messageTextBox.Text.ToString() == String.Empty)
            {
                messageBorder.Background = null;
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {

            if (searchLbl.Content.ToString() == "Search")
            {
                searchLbl.Content = string.Empty;
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (searchLbl.Content.ToString() == string.Empty)
            {
                searchLbl.Content = "Search";
            }
        }
        
        
        private void chatBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var resultBorder = sender as Border;
            var grid = resultBorder.Child as Grid;

            if (messageTextBox.Text.ToString() != String.Empty)
                messageBorder.Background = GrandientColor;

            foreach (var item in grid.Children)
            {
                if (item is Grid grid2)
                {
                    foreach (var item2 in grid2.Children)
                    {
                        if (item2 is Label l)
                        {
                            if (l.Name.ToString() == "nameLbl")
                                nameLbl2.Content = l.Content;
                            else if (l.Name.ToString() == "messageLbl")
                            {
                                messageLbl2.Content = l.Content;
                                messageTextBox.Text = l.Content.ToString();
                            }
                        }
                    }
                }
                else if (item is Ellipse el)
                {

                }
            }

            foreach (var item in chatingCanvas.Children)
            {
                if (item is Border b)
                {
                    var childCanvas = b.Child as Canvas;
                    foreach (var item2 in childCanvas.Children)
                    {
                        if (item2 is TextBlock tb)
                        {
                            tb.Width = tb.Text.Length * 9;
                        }
                    }
                }
            }
        }
    }
}
