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
using Radar.Droid;
using Xamarin.Forms;
using Radar.Utils;
using Android.Support.V7.App;

[assembly: Dependency(typeof(MensagemAndroid))]

namespace Radar.Droid {
    public class MensagemAndroid : IMensagem {
        public void exibirAviso(string Titulo, string Mensagem)
        {
            Context context = Android.App.Application.Context;
            Toast.MakeText(context, Mensagem, ToastLength.Short).Show();
        }

        public bool notificar(int id, string titulo, string mensagem)
        {
            Context context = Android.App.Application.Context;
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context);
            builder.SetAutoCancel(true);
            //builder.SetContentIntent();
            builder.SetNumber(id);
            builder.SetSmallIcon(Resource.Drawable.icon);
            builder.SetContentTitle(titulo);
            builder.SetContentText(mensagem);
            
            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(id, builder.Build());

            return true;
        }
    }
}