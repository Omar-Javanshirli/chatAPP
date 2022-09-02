using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public ObservableCollection<Human> Humans { get; set; }
        private Human selectedItem;

        public Human SelectedHuman
        {
            get { return selectedItem; }
            set { selectedItem = value;  OnPropertyChanged(); }
        }

        public dynamic GrandientColor { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            GrandientColor = messageBorder.Background;
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
                                messageBorder.Background = GrandientColor;
                            }
                        }
                    }
                }
                else if (item is Ellipse el)
                {
                    
                }
            }

            //foreach (var item in chatingCanvas.Children)
            //{
            //    if (item is Border b)
            //    {
            //        var childCanvas = b.Child as Canvas;
            //        foreach (var item2 in childCanvas.Children)
            //        {
            //            if (item2 is TextBlock tb)
            //            {
            //                tb.Width = tb.Text.Length * 9;
            //            }
            //        }
            //    }
            //}
        }


        private void rightMessageTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (rightMessageTextBox.Text.ToString() == "Type Something")
                rightMessageTextBox.Text = String.Empty;
        }

        private void rightMessageTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (rightMessageTextBox.Text.ToString() == String.Empty)
                rightMessageTextBox.Text = "Type Something";
        }

        int count = 20;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border newBorder=new Border();
            Canvas newCanvas = new Canvas();
            TextBlock newTextBlock=new TextBlock();

            newTextBlock.FontSize = 15;
            newTextBlock.FontFamily = messageTextBox.FontFamily;
            newTextBlock.FontStyle=messageTextBox.FontStyle;
            newTextBlock.Foreground=messageTextBox.Foreground;
            newTextBlock.Text = rightMessageTextBox.Text;

            newBorder.Name = "newBorder";
            newBorder.Background= GrandientColor;
            newBorder.Width = rightMessageTextBox.Text.Length * 9;
            newBorder.Height = 30;
            newBorder.CornerRadius = messageBorder.CornerRadius;

            newBorder.Child = newCanvas;
            newBorder.HorizontalAlignment = HorizontalAlignment.Right;
            
            newCanvas.Children.Add(newTextBlock);
            chatingCanvas.Children.Add(newBorder);
            
        }
        private int myHeight;

        public int MyHeight
        {
            get { return myHeight; }
            set { myHeight = value;OnPropertyChanged(); }
        }
        private string myText;

        public string MyText
        {
            get { return myText; }
            set { myText = value; OnPropertyChanged(); MyHeight = MyText.Length +20; }
        }
       
    }
}
