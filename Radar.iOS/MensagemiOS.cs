using Radar.iOS;
using Radar.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(MensagemiOS))]

namespace Radar.iOS
{
    public class MensagemiOS: IMensagem
    {
        public void exibirAviso(string Titulo, string Mensagem)
        {
            /*
            Context context = Android.App.Application.Context;
            Toast.MakeText(context, Mensagem, ToastLength.Short).Show();
            */
        }

        public bool notificar(int id, string titulo, string mensagem)
        {
            /*
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
            */
            return true;
        }
    }
}
