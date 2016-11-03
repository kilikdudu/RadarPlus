using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Radar
{
	public partial class ModoReproducaoVozPage : ContentPage
	{
		public ModoReproducaoVozPage()
		{
			InitializeComponent();
            Title = "Reprodução Voz";
            Content = new ScrollView() { Content = teststack };
        }
	}
}
