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

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

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
                   Message ="don't leave me, please"
               },
               new Human
               {
                   Name="Ester",
                   Message="do you have free time tomorrow?"
               },
               new Human
               {
                   Name="Lena del",
                   Message="yeterday was a very good day for me. Thank you everythink"
               }
            };
        }

    }
}
