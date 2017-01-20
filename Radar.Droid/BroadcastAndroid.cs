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
using ClubManagement.Model;

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
            else if (intent.Action == Intent.ActionProviderChanged) {
                Intent pushIntent = new Intent(context, typeof(GPSAndroid));
                context.StartService(pushIntent);
                InvokeAbortBroadcast();
            }
            else if (intent.Action == PercursoBLL.ACAO_PARAR_SIMULACAO)
            {
                GPSUtils.pararSimulacao();
                MensagemUtils.pararNotificaoPermanente(PercursoBLL.NOTIFICACAO_SIMULACAO_PERCURSO_ID);
                InvokeAbortBroadcast();
            }
            else if (intent.Action == PercursoBLL.ACAO_PARAR_GRAVACAO)
            {
                PercursoBLL regraPercurso = PercursoFactory.create();
                regraPercurso.pararGravacao();
                //MensagemUtils.pararNotificaoPermanente(PercursoBLL.NOTIFICACAO_GRAVAR_PERCURSO_ID);
                InvokeAbortBroadcast();
            }
            else if (intent.Action == "Fechar")
            {
                if (PreferenciaUtils.LigarDesligar)
                {
                    if (PreferenciaUtils.CanalAudio == AudioCanalEnum.Notificacao)
                    {
                        MensagemUtils.notificar(101, "Radar+", "O Radar+ está sendo encerrado!", audio: "radar_fechado");
                    }
                    else {
                        AudioUtils.Volume = PreferenciaUtils.AlturaVolume;
                        AudioUtils.Canal = PreferenciaUtils.CanalAudio;
                        AudioUtils.CaixaSom = PreferenciaUtils.CaixaSom;
                        AudioUtils.play("audios/radar_fechado.mp3");
                    }
                }
                NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                notificationManager.Cancel(1);
                System.Environment.Exit(0);
                Process.KillProcess(Process.MyPid());
            }
        }
    }
}