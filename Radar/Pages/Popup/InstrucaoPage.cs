

using Radar.Model;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Radar.Pages.Popup
{
	public class InstrucaoPage : PopupPage
	{

		public InstrucaoPage()
		{

           
			ScrollView scrollView = new ScrollView()
			{
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = ScrollOrientation.Horizontal,
				//BackgroundColor = Color.Red			
			};

			StackLayout fundo = new StackLayout()
			{
				HeightRequest = 350,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				//BackgroundColor = Color.Red
				
			};
			
			StackLayout main = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				//BackgroundColor = Color.Blue,
				HeightRequest = 350
			};
			
			Frame instrucao1 = new Frame()
			{
				 WidthRequest = 200,
				Content = new StackLayout
				{			
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Children = {
					new Label{
					Text = "Internet",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
					},
					new BoxView {
						HeightRequest = 1,
						BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor)
					},
					new Label{
					Text = "A conexão com a Internet é necessária somente para atualizar os locais dos novos radares o remoção de algum radar. " +
							" Utilizando o modo Velocímetro náo consome seus dados de internet, caso utilize o Modo Mapa poderá utilizar a sua conexão com a internet.",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center
					}
				}
				}
			};

			Frame instrucao2 = new Frame()
			{
			 WidthRequest = 200,
			 Content = new StackLayout{
				Children = {
					new Label{
					Text = "Bateria",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
					},
					new BoxView {
						HeightRequest = 1,
						BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor)
					},
					new Label{
					Text = "Se não desejar receber mais alertas, desligue o aplicativo." +
							" Esquecê-lo ligado poderá consumir toda a bateria do seu aparelho." +
							" Fechar o aplicativo pelo menu sair, a barra de notificações irá desaparecer " +
							" indicando que foi encerrado o processamento.",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center
					}
				}
			}
			};

			Frame instrucao3 = new Frame()
			{
				WidthRequest = 200,
				Content = new StackLayout
				{
					Children = {
					new Label{
					Text = "Legenda",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
					},
					new BoxView {
						HeightRequest = 1,
						BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor)
					},
					new StackLayout{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new Image{
							Source = "radar_40.png",
							WidthRequest = 30,
							HeightRequest = 30
						},
						new Label{
							Text = "Radar Fixo"
						}
					}
					},
					new StackLayout{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new Image{
							Source = "radar_movel.png",
							WidthRequest = 30,
							HeightRequest = 30
						},
						new Label{
							Text = "Área de radar Móvel"
						}
					}
					},
					new StackLayout{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new Image{
							Source = "radar_40_semaforo.png",
							WidthRequest = 30,
							HeightRequest = 30
						},
						new Label{
							Text = "Semáforo com Radar"
						}
					}
					},
					new StackLayout{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new Image{
							Source = "semaforo.png",
							WidthRequest = 30,
							HeightRequest = 30
						},
						new Label{
							Text = "Semáforo com Câmera"
						}
					}
					},
					new StackLayout{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new Image{
							Source = "lombada.png",
							WidthRequest = 30,
							HeightRequest = 30
						},
						new Label{
							Text = "Lombada Eletrônica"
						}
					}
					},
					new StackLayout{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new Image{
							Source = "policiarodoviaria.png",
							WidthRequest = 30,
							HeightRequest = 30
						},
						new Label{
							Text = "Polícia Rodoviária"
						}
					}
					},
					new StackLayout{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					Orientation = StackOrientation.Horizontal,
					Children = {
						new Image{
							Source = "pedagio.png",
							WidthRequest = 30,
							HeightRequest = 30
						},
						new Label{
							Text = "Pedágio"
						}
					}
					}
				}
				}
			};
			Frame instrucao4 = new Frame()
			{
				WidthRequest = 200,
				Content = new StackLayout
				{
					Children = {
					new Label{
					Text = "Mapa",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
					},
					new BoxView {
						HeightRequest = 1,
						BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor)
					},
					new Label{
					Text = "No Modo Mapa visualize a distância que os radares estão do seu local atual." +
							" Onde exibidos apenas os radares que estão próximo de sua localização atual.",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center
					}
				}
				}
			};

			Frame instrucao5 = new Frame()
			{
				WidthRequest = 200,
				Content = new StackLayout
				{
					Children = {
					new Label{
					Text = "Finalidade",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
					},
					new BoxView {
						HeightRequest = 1,
						BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor)
					},
					new Label{
					Text = "O Radar+ tem a finalidade de alerta-ló sobre a proximidade de radares." +
							" O Radar+ não funciona como  navegador GPS. No entando é possível utilizar um Navegador GPS de sua preferência e o Radar+ ao mesmo tempo",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center
					}
				}
				}
			};

			Frame instrucao6 = new Frame()
			{
				WidthRequest = 200,
				Content = new StackLayout
				{
					Children = {
					new Label{
					Text = "Funcionamento",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
					},
					new BoxView {
						HeightRequest = 1,
						BackgroundColor = Color.FromHex(TemaInfo.PrimaryColor)
					},
					new Label{
					Text = "O sistema pode ser utilizado ao mesmo tempo com navegadores GPS ou mesmo qualquer outro aplicativo." +
							" Para tanto, após iniciar o Radar+, pressione HOME. Um ícone do MapaRadar permanecerá fixo na barra de notificações" +
							" indicando que o aplicativo está em funcionamento.",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center
					}
				}
				}
			};

			
			main.Children.Add(instrucao1);
			main.Children.Add(instrucao2);
			main.Children.Add(instrucao3);
			main.Children.Add(instrucao4);
			main.Children.Add(instrucao5);
			main.Children.Add(instrucao6);
		   
			scrollView.Content = main;
			fundo.Children.Add(scrollView);
			Content = fundo;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

	}
}