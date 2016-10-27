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

namespace Radar.Droid
{
    [BroadcastReceiver(Enabled = true)]
    public class BroadcastAndroid : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            PercursoBLL regraPercurso = PercursoFactory.create();
            regraPercurso.pararGravacao();
        }
    }
}