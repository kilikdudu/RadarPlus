﻿using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Radar.BLL;
using Radar.Factory;
using System.Diagnostics;

namespace Radar.Pages.Popup {
    public partial class NivelZoomPopUp : PopupPage {
        private String valorSlider;
        private double sliderValor;
        PreferenciaBLL regraPreferencia = PreferenciaFactory.create();

        public NivelZoomPopUp() {
            InitializeComponent();
            valorSlider = Configuracao.NivelZoom;
            Slider.Value = int.Parse(valorSlider);
            textValor.Text = valorSlider;
            Slider.ValueChanged += OnSliderValueChanged;
        }

        private void OnCancelar(object sender, EventArgs e) {
            PopupNavigation.PopAsync();
        }

        private void OnOk(object sender, EventArgs e) {
            //PopupNavigation.PopAsync();
            regraPreferencia.gravar("nivelZoom", (int)Math.Floor(sliderValor));
            Debug.WriteLine("sliderValor: " + sliderValor);
            PopupNavigation.PopAsync();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e) {
            var newStep = Math.Round(e.NewValue);
            Slider.Value = newStep;
            sliderValor = newStep;
            textValor.Text = sliderValor.ToString();
            Debug.WriteLine("sliderValor: " + sliderValor);
        }

        protected override Task OnAppearingAnimationEnd() {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBegin() {
            return Content.FadeTo(1);
        }
    }
}