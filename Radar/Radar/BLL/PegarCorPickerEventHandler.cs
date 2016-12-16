using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radar.BLL
{
    public delegate void PegarCorPickerEventHandle(object sender, PegarCorPickerEventArgs e);

    public class PegarCorPickerEventArgs : EventArgs
    {
 		
		public PegarCorPickerEventArgs(Color cor, string color)
		{
			corPicker = cor;
		}
        public Color corPicker { get; set; }
        public string corTexto { get; set; }
    }
}
