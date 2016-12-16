using System;
using System.Collections.Generic;
using Radar.BLL;
using Radar.Model;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Radar.Controls
{
    class ColorPicker : ContentPage
    {
    public PegarCorPickerEventHandle AoProcessar { get; set; }
        // Dictionary to get Color from color name.
        Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua }, { "Preto", Color.Black },
            { "Azul", Color.Blue }, { "Rosa", Color.Fuschia },
            { "Cinza", Color.Gray }, { "Verde", Color.Green },
            { "Limão", Color.Lime }, { "Marron", Color.Maroon },
            { "Oceano", Color.Navy }, { "Oliva", Color.Olive },
            { "Roxo", Color.Purple }, { "Vermelho", Color.Red },
            { "Prata", Color.Silver }, { "Chá", Color.Teal },
            { "Branco", Color.White }, { "Amarelo", Color.Yellow }
        };

        public ColorPicker(PegarCorPickerEventHandle aoProcessar)
        {
			AoProcessar += AoProcessar;
            Label header = new Label
            {
                Text = "Picker",
                FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Picker picker = new Picker
            {
                Title = "Cor",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string colorName in nameToColor.Keys)
            {
                picker.Items.Add(colorName);
            }

            // Create BoxView for displaying picked Color
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            picker.SelectedIndexChanged += (sender, args) =>
                {
                    if (picker.SelectedIndex == -1)
                    {
                        boxView.Color = Color.Default;
                        string colorName = picker.Items[picker.SelectedIndex];
						if (AoProcessar != null)
                		AoProcessar(this, new PegarCorPickerEventArgs(nameToColor[colorName], colorName));
                    }
                    else
                    {
                        string colorName = picker.Items[picker.SelectedIndex];
                        boxView.Color = nameToColor[colorName];
						if (AoProcessar != null)							
                		AoProcessar(this, new PegarCorPickerEventArgs(nameToColor[colorName], colorName));
                    }
                };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    picker,
                    boxView
                }
            };

        }
    }
}