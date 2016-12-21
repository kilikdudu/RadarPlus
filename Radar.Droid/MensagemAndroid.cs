using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClubManagement.Droid;
using Xamarin.Forms;
using Radar.Droid;

[assembly: Dependency(typeof(MensagemAndroid))]

namespace Radar.Droid
{
    public class MensagemAndroid : MensagemBaseAndroid
    {
        protected override Type pegarBroadcast()
        {
            return typeof(BroadcastAndroid);
        }

        protected override int pegarIconeParar()
        {
            return Resource.Drawable.mystop;
        }

        protected override int pegarIconePequeno()
        {
            return Resource.Drawable.mypercursos;
        }

        protected override int pegarIconeVelocidade(double velocidade)
        {
            if (velocidade <= 20)
                return Resource.Drawable.my20;
            else if (velocidade <= 30)
                return Resource.Drawable.my30;
            else if (velocidade <= 40)
                return Resource.Drawable.my40;
            else if (velocidade <= 50)
                return Resource.Drawable.my50;
            else if (velocidade <= 60)
                return Resource.Drawable.my60;
            else if (velocidade <= 70)
                return Resource.Drawable.my70;
            else if (velocidade <= 80)
                return Resource.Drawable.my80;
            else if (velocidade <= 90)
                return Resource.Drawable.my90;
            else if (velocidade <= 100)
                return Resource.Drawable.my100;
            else 
                return Resource.Drawable.my110;
        }

        protected override Type pegarJanelaTipo()
        {
            return typeof(MainActivity);
        }
    }
}