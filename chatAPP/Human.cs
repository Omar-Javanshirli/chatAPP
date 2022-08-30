using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace chatAPP
{
    public class Human:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;OnPropertyChanged(); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged(); }
        }

    }
}
