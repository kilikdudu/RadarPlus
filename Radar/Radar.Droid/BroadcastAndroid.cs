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
using Radar.BLL;
using Radar.Factory;
using ClubManagement.Utils;
using Radar.Utils;

namespace Radar.Droid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class BroadcastAndroid : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == Intent.ActionBootCompleted)
            {
                Intent pushIntent = new Intent(context, typeof(GPSAndroid));
                context.StartService(pushIntent);
                InvokeAbortBroadcast();
            }
            else if (intent.Action == PercursoBLL.ACAO_PARAR_SIMULACAO)
            {
                GPSUtils.pararSimulacao();
                ClubManagement.Utils.MensagemUtils.pararNotificaoPermanente(PercursoBLL.NOTIFICACAO_SIMULACAO_PERCURSO_ID);
                InvokeAbortBroadcast();
            }
            else if (intent.Action == PercursoBLL.ACAO_PARAR_SIMULACAO) {
                PercursoBLL regraPercurso = PercursoFactory.create();
				regraPercurso.pararGravacao();
                ClubManagement.Utils.MensagemUtils.pararNotificaoPermanente(PercursoBLL.NOTIFICACAO_GRAVAR_PERCURSO_ID);
                InvokeAbortBroadcast();
            }
			else if (intent.Action == "Fechar")
			{
				NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
				notificationManager.Cancel(1);
				System.Environment.Exit(0);
				Android.OS.Process.KillProcess(Android.OS.Process.MyPid());


			}
        }
    }
}