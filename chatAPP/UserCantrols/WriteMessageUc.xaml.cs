using System;
using System.Collections.Generic;
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

namespace chatAPP.UserCantrols
{
    /// <summary>
    /// Interaction logic for WriteMessageUc.xaml
    /// </summary>
    public partial class WriteMessageUc : UserControl,INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private int myHeight;
        public int MyHeight
        {
            get { return myHeight; }
            set { myHeight = value; OnPropertyChanged(); }
        }
        private string myText;


        public string MyText
        {
            get { return myText; }
            set { myText = value; OnPropertyChanged(); MyHeight = MyText.Length + 20; }
        }

        private string myText2;

        public string Mytext2
        {
            get { return myText2; }
            set { myText2 = value; OnPropertyChanged(); }
        }



        public WriteMessageUc()
        {
            InitializeComponent();

            this.DataContext = this;
        }
    }
}
