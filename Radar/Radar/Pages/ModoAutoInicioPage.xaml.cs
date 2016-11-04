using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Radar
{
	public partial class ModoAutoInicioPage : ContentPage
	{
		public ModoAutoInicioPage()
		{
			InitializeComponent();
            Title = "Auto Inicio/ Desligamento";
            Content = new ScrollView() { Content = teststack };
        }
	}
}
