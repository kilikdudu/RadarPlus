using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Radar.Pages {
    public partial class ModoAudioPage : ContentPage {
        public ModoAudioPage() {
            InitializeComponent();
            Title = "Áudio";
            Content = new ScrollView() { Content = teststack };
        }
    }
}
