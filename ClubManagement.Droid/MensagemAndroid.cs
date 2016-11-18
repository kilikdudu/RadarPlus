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
using Xamarin.Forms;
using Android.Support.V7.App;
using Android.Media;
using ClubManagement.Droid;
using ClubManagement.Utils;
using ClubManagement.IBLL;
using Android;

[assembly: UsesPermission(Manifest.Permission.Vibrate)]

[assembly: Dependency(typeof(MensagemAndroid))]

namespace ClubManagement.Droid {

    public class MensagemAndroid : IMensagem
    {

        private const int NOTIFICACAO_GRAVAR_PERCURSO_ID = 2301;

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
            builder.SetNumber(id);
            //builder.SetSmallIcon(Resource.Drawable.icon);
            builder.SetContentTitle(titulo);
            builder.SetContentText(mensagem);
            builder.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification));

            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(id, builder.Build());

            return true;
        }

        public bool notificarPermanente(int id, string titulo, string descricao) {
            Context context = Android.App.Application.Context;

            var intent = new Intent();

            NotificationCompat.Builder builder = new NotificationCompat.Builder(context);
            builder.SetAutoCancel(true);
            //builder.SetContentIntent();
            builder.SetNumber(id);
            //builder.SetSmallIcon(Resource.Drawable.icon);
            builder.SetContentTitle(titulo);
            if (!string.IsNullOrEmpty(descricao))
                builder.SetContentText(descricao);
            //builder.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm));

            var pendingIntent = PendingIntent.GetBroadcast(context, 0, new Intent(), PendingIntentFlags.CancelCurrent);

            //builder.AddAction(new Android.Support.V4.App.NotificationCompat.Action(Resource.Drawable.icon, "Parar Gravação!", pendingIntent));

            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            Notification notificacao = builder.Build();
            notificacao.Flags = NotificationFlags.NoClear;
            notificationManager.Notify(id, notificacao);

            //notificationManager.Cancel();
            return true;
        }

        public bool pararNotificaoPermanente(int id)
        {
            Context context = Android.App.Application.Context;
            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.Cancel(id);

            return true;
        }

        public bool notificarGravacaoPercurso()
        {
            Context context = Android.App.Application.Context;

            var intent = new Intent();

            NotificationCompat.Builder builder = new NotificationCompat.Builder(context);
            builder.SetAutoCancel(true);
            //builder.SetContentIntent();
            builder.SetNumber(NOTIFICACAO_GRAVAR_PERCURSO_ID);
            //builder.SetSmallIcon(Resource.Drawable.icon);
            builder.SetContentTitle("Gravando percurso!");
            builder.SetContentText("");
            //builder.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm));

            var pendingIntent = PendingIntent.GetBroadcast(context, 0, new Intent(), PendingIntentFlags.CancelCurrent);

            //builder.AddAction(new Android.Support.V4.App.NotificationCompat.Action(Resource.Drawable.icon, "Parar Gravação!", pendingIntent));

            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            Notification notificacao = builder.Build();
            notificacao.Flags = NotificationFlags.NoClear;
            notificationManager.Notify(NOTIFICACAO_GRAVAR_PERCURSO_ID, notificacao);

            //notificationManager.Cancel();


            return true;
        }

        public bool pararNotificaoPercurso()
        {
            Context context = Android.App.Application.Context;
            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.Cancel(NOTIFICACAO_GRAVAR_PERCURSO_ID);

            return true;
        }

        public bool enviarEmail(string para, string titulo, string mensagem) {
            var email = new Intent(Intent.ActionSend);
            email.SetFlags(ActivityFlags.NewTask);
            email.PutExtra(Intent.ExtraEmail, new string[] { para });
            //email.PutExtra(Intent.ExtraCc, new string[] { "person3@xamarin.com" });
            email.PutExtra(Intent.ExtraSubject, titulo);
            email.PutExtra(Intent.ExtraText, mensagem);
            email.SetType("message/rfc822");
            Context context = Android.App.Application.Context;
            context.StartActivity(email);
            return true;
        }

        public void vibrar(int milisegundo) {
            Context context = Android.App.Application.Context;
            Vibrator vibrator = (Vibrator)context.GetSystemService(Context.VibratorService);
            vibrator.Vibrate(milisegundo);
        }
    }
}