using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radar.Pages;
using Xamarin.Forms;
using System;
using Radar.Model;

namespace Radar.Controls
{
	/// <summary> The ExtendedMasterDetailPage can be used wtih the ExtendedMasterDetailRenderer to (for now) change the drawer width of the Master page. </summary>
	public class RadarMasterDetailPage : MasterDetailPage
	{
		MenuPage masterPage;

		private Page _paginaAtual;

		bool carregandoPagina = false;

		/// <summary> The DrawerWidthProperty is the static BindableProperty declaration For DrawerWidth </summary>
		public static readonly BindableProperty DrawerWidthProperty = BindableProperty.Create<RadarMasterDetailPage, int>(p => p.DrawerWidth, default(int));

		//RadarMasterDetailPage masterPage;

		public RadarMasterDetailPage()
		{
			//masterPage = new MenuPage();
			Master = new ContentPage
			{
				Title = "Master",
				BackgroundColor = Color.Yellow,
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
									new Label {
										XAlign = TextAlignment.Center,
										Text = "Welcome to Xamarin Forms!"
									},
									new Button{Text="Test 1 button"}
								}
				}
			};

			//_paginaAtual = new SobrePage();
			//var nav = new NavigationPage(_paginaAtual);
			//nav.BarBackgroundColor = Color.FromHex(TemaInfo.DarkPrimaryColor);
			//nav.BarTextColor = Color.FromHex(TemaInfo.TextIcons);
			DrawerWidth = 100;
			Detail = new NavigationPage(new ContentPage
			{
				BackgroundColor = Color.Red,
				Content = new StackLayout() { BackgroundColor = Color.Aqua }
			});
			//masterPage.ListView.ItemSelected += OnItemSelected;

			if (Device.OS == TargetPlatform.Windows)
			{
				Master.Icon = "swap.png";
			}
		}
		/// <summary> The DrawerWidth property can be used to change the width of the DrawerLayout on the Android System (iOS to come soon) </summary>
		public int DrawerWidth
		{
			get { return (int)GetValue(DrawerWidthProperty); }
			set { SetValue(DrawerWidthProperty, value); }
		}


		protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			/*
			var item = e.SelectedItem as MenuItemInfo;
			if (item != null)
			{
				if (item.aoClicar != null)
				{
					item.aoClicar(sender, e);
				}
				else {
					if (!carregandoPagina)
					{
						if (_paginaAtual.GetType() != item.TargetType)
						{
							carregandoPagina = true;
							_paginaAtual = (Page)Activator.CreateInstance(item.TargetType);
							_paginaAtual.Appearing += (sender2, e2) =>
							{
								carregandoPagina = false;
							};
							Detail = new NavigationPage(_paginaAtual);
						}
						masterPage.ListView.SelectedItem = null;
						IsPresented = false;
					}
				}
			}
			*/
		}
	}
}