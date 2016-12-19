using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android;
using Android.Locations;
using Radar.BLL;
using Radar.Model;
using Radar.Droid;
using Xamarin.Forms;
using Radar.IBLL;
using Radar.Utils;
using Android.Support.V7.App;
using Android.Views;
using Android.Content.Res;
using Android.Widget;
using Java.Util;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using ClubManagement.Utils;

[assembly: UsesPermission(Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Manifest.Permission.Internet)]
[assembly: UsesPermission(Manifest.Permission.InternalSystemWindow)]
[assembly: UsesPermission(Manifest.Permission.SystemAlertWindow)]

[assembly: Dependency(typeof(GPSAndroid))]

namespace Radar.Droid
{
    [Service]
    [IntentFilter(new String[] { "br.com.cmapps.radar.service" })]
    public class GPSAndroid : Service, ILocationListener, IGPS
    {
        private const int ID_RADAR_CLUB = 5;
        private const int TRAY_DIM_X_DP = 160;   // Width of the tray in dps
        private const int TRAY_DIM_Y_DP = 240; 	// Height of the tray in dps
        private const int ANIMATION_FRAME_RATE = 30;	// Animation frame rate per second.
        private const int TRAY_MOVEMENT_REGION_FRACTION = 6; // Controls fraction of y-axis on screen within which the tray stays.
        private const int TRAY_HIDDEN_FRACTION = 6;

        private bool _inicializado = false;
        private bool desativando = false;
        public GPSSituacaoEnum Situacao { get; set; }
        public GPSDisponibilidadeEnum Disponibilidade { get; set; }

        private float _sentidoAnterior = 0;

        LocationManager _locationManager;
        string _locationProvider;
        IWindowManager mWindowManager;
        Android.Views.View mRootLayout;
        WindowManagerLayoutParams mRootLayoutParams;

        private Timer mTrayAnimationTimer;
        private TrayAnimationTimerTask mTrayTimerTask;
        private Handler mAnimationHandler = new Handler();

        private int mStartDragX;
        private int mPrevDragX;
        private int mPrevDragY;

        //private bool mIsTrayOpen = true;
        private bool widgetInicializado = false;

        public GPSAndroid() {
        }

        DemoServiceBinder binder;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if (intent.GetBooleanExtra("ativo", false))
                Situacao = GPSSituacaoEnum.Ativo;
            else
                Situacao = GPSSituacaoEnum.Espera;
            if (!_inicializado)
            {
                notificar(intent);
                if (!widgetInicializado)
                {
                    criarWidget();
                    widgetInicializado = true;
                }
                ativarGPS();
                _inicializado = true;
            }
            return StartCommandResult.NotSticky;
        }

        public void notificar(Intent intent)
        {
            /*
            var ongoing = new Notification(Resource.Drawable.navicon, "Radar+");
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(MainActivity)), 0);
            ongoing.SetLatestEventInfo(this, "Radar+", "Está em funcionamento", pendingIntent);
            StartForeground((int)NotificationFlags.ForegroundService, ongoing);
            */
            if (intent.GetBooleanExtra("stop_service", false))
            {
                StopSelf();
            }
            else {
				Context context = Android.App.Application.Context;
                Intent notificationIntent = new Intent(this, typeof(GPSAndroid));
			    notificationIntent.PutExtra("stop_service", true);
			    //PendingIntent pendingIntent = PendingIntent.GetService(this, 0, notificationIntent, 0);
				//PendingIntent pendingIntent = PendingIntent.getActivity(this, 1, intent, PendingIntent.FLAG_ONE_SHOT);
				var acao = new Intent(context, typeof(BroadcastAndroid));
				acao.SetAction("Fechar");

				var pendingIntent = PendingIntent.GetBroadcast(context, 0, acao, PendingIntentFlags.UpdateCurrent);

				//Button
				NotificationCompat.Action action = new NotificationCompat.Action.Builder(Resource.Drawable.mystop, "Fechar", pendingIntent).Build();

				Notification notificacao = new NotificationCompat.Builder(context)
					.SetSmallIcon(Resource.Drawable.radarplus_logo)
					.SetContentTitle("Radar+")
					.SetContentText("Seu Radar+ está em funcionamento.")
				    .SetAutoCancel(true)
				    .SetPriority((int)NotificationPriority.Max)
					.AddAction(action) //add buton
					.Build();

                //notification.SetLatestEventInfo( this, "Radar+", "Pressione aqui para fechar.", pendingIntent);
                //StartForeground((int)NotificationFlags.ForegroundService, notification);

                NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                //Notification notificacao = notification;
                //notificacao.Flags = NotificationFlags.AutoCancel;
                notificacao.Flags = NotificationFlags.NoClear;
                notificationManager.Notify(1, notificacao);
            }
        }

        public override IBinder OnBind(Intent intent)
        {
            binder = new DemoServiceBinder(this);
            return binder;
        }

        private LocalizacaoInfo converterLocalizacao(Location location)
        {
            LocalizacaoInfo local = new LocalizacaoInfo();
            local.Latitude = location.Latitude;
            local.Longitude = location.Longitude;
            local.Precisao = location.Accuracy;
            if (location.HasBearing)
            {
                local.Sentido = location.Bearing;
                _sentidoAnterior = local.Sentido;
            }
            else
                local.Sentido = _sentidoAnterior;
            local.Tempo = (new DateTime(1970, 1, 1)).AddMilliseconds(location.Time);
            local.Velocidade = location.Speed * 3.6;
            return local;
        }

        private void atualizarVelocidadeRadar(float velocidade)
        {
            var velocidadeImagem = mRootLayout.FindViewById<ImageView>(Resource.Id.velocidadeImagem);
            if (velocidade <= 20)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_20);
            else if (velocidade > 20 && velocidade <= 30)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_30);
            else if (velocidade > 30 && velocidade <= 40)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_40);
            else if (velocidade > 40 && velocidade <= 50)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_50);
            else if (velocidade > 50 && velocidade <= 60)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_60);
            else if (velocidade > 60 && velocidade <= 70)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_70);
            else if (velocidade > 70 && velocidade <= 80)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_80);
            else if (velocidade > 80 && velocidade <= 90)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_90);
            else if (velocidade > 90 && velocidade <= 100)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_100);
            else if (velocidade > 90 && velocidade <= 100)
                velocidadeImagem.SetImageResource(Resource.Drawable.radar_110);
        }

        public void OnLocationChanged(Location location)
        {
            if (desativando)
                return;
            LocalizacaoInfo local = converterLocalizacao(location);
            local.Velocidade = 20;
            local.Latitude = -16.620743;
            local.Longitude = -49.356621;
            local.Sentido = 324;
            if (Situacao == GPSSituacaoEnum.Ativo)
            {
                if (Xamarin.Forms.Forms.IsInitialized)
                {
                    local = GPSUtils.atualizarPosicao(local);
                    RadarInfo radar = RadarBLL.RadarAtual;
                    if (radar != null)
                    {
                        //var velocidadeImagem = mRootLayout.FindViewById<ImageView>(Resource.Id.velocidadeImagem);
                        atualizarVelocidadeRadar(radar.Velocidade);
                        var distanciaRadar = mRootLayout.FindViewById<TextView>(Resource.Id.distanciaRadar);
                        int distancia = Convert.ToInt32(Math.Floor(local.Distancia));
                        //velocidadeImagem.SetImageResource(Resource.Drawable.radar_20);
                        //velocidadeRadar.Text = radar.VelocidadeStr;
                        distanciaRadar.Text = distancia.ToString() + " m";
                        if (mRootLayout.Visibility != ViewStates.Visible)
                            mRootLayout.Visibility = ViewStates.Visible;
                    }
                    else {
                        if (mRootLayout.Visibility == ViewStates.Visible)
                            mRootLayout.Visibility = ViewStates.Invisible;
                    }
                }
            }
            else if (Situacao == GPSSituacaoEnum.Espera) {
				var regraPreferencia = new PreferenciaBLL();
				if (regraPreferencia.pegar("ligarDesligar", "") == "1" && local.Precisao <= 30)
                {
                    if (local.Velocidade >= 15)
                    {
                        Situacao = GPSSituacaoEnum.Ativo;
                        if (!Xamarin.Forms.Forms.IsInitialized) {
                            Intent intent = new Intent(this, typeof(MainActivity));
                            intent.AddFlags(ActivityFlags.NewTask);
                            StartActivity(intent);
                        }
                        else if (MainActivity.Situacao != JanelaSituacaoEnum.Aberta)
                        {
                            Intent intent = new Intent(this, typeof(MainActivity));
                            intent.AddFlags(ActivityFlags.NewTask);
                            StartActivity(intent);
                        }
                    }
                    else {
                        desativarGPS();
                        new Handler().PostDelayed(() => { ativarGPS(); }, 30000);
                    }
                }
            }
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            double velocidade = 0;
            double precisao = 21;
            if (GPSUtils.UltimaLocalizacao != null) {
                precisao = GPSUtils.UltimaLocalizacao.Precisao;
                velocidade = GPSUtils.UltimaLocalizacao.Velocidade;
            }
            if (precisao <= 20 && velocidade > 15)
            {
                if (status.Equals(Availability.Available))
                {
                    if (Disponibilidade != GPSDisponibilidadeEnum.Disponivel)
                    {
                        MensagemUtils.notificar(5, "Radar+", "Sinal de GPS encontrado!", audio: "sinal_gps_encontrado");
                        Disponibilidade = GPSDisponibilidadeEnum.Disponivel;
                    }
                }
                else if (status.Equals(Availability.OutOfService))
                {
                    if (Disponibilidade != GPSDisponibilidadeEnum.ForaDoAr)
                    {
                        MensagemUtils.notificar(5, "Radar+", "Sinal de GPS fora do ar!", audio: "sinal_gps_fora_do_ar");
                        Disponibilidade = GPSDisponibilidadeEnum.ForaDoAr;
                    }
                }
                else if (status.Equals(Availability.TemporarilyUnavailable))
                {
                    if (Disponibilidade != GPSDisponibilidadeEnum.IndisponivelTemporariamente)
                    {
                        MensagemUtils.notificar(5, "Radar+", "Sinal de GPS fora do ar!", audio: "sinal_gps_perdido");
                        Disponibilidade = GPSDisponibilidadeEnum.IndisponivelTemporariamente;
                    }
                }
            }
        }

        public bool inicializar()
        {
            ativarGPS();
            return true;
        }

        public void ativarGPS()
        {
            desativando = false;
            Context context = Android.App.Application.Context;
            if (_locationManager == null)
                _locationManager = (LocationManager)context.GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine,
                
            };
            _locationProvider = _locationManager.GetBestProvider(criteriaForLocationService, true);
            _locationManager.RequestLocationUpdates(_locationProvider, PreferenciaUtils.GPSTempoAtualiazacao, PreferenciaUtils.GPSDistanciaAtualizacao, this);
        }

        public void desativarGPS() {
            desativando = true;
            Context context = Android.App.Application.Context;
            if (_locationManager == null)
                _locationManager = (LocationManager)context.GetSystemService(LocationService);
            _locationManager.RemoveUpdates(this);
            _locationManager = null;
        }

        public static int dpToPixels(int dp, Resources res)
        {
            return (int)(res.DisplayMetrics.Density * dp + 0.5f);
        }

        public void criarWidget() {
            Context context = Android.App.Application.Context;
            mWindowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            mRootLayout = LayoutInflater.From(context).Inflate(Resource.Layout.service_player, null);
            var mContentContainerLayout = mRootLayout.FindViewById(Resource.Id.root_layout);
            //mContentContainerLayout.SetBackgroundColor(Android.Graphics.Color.Argb(200, 255, 255, 255));
            // Erro de Invalid Cast - Depois a gente vé essa merda!
            //mContentContainerLayout.SetOnTouchListener(new TrayTouchListener(this));
            mContentContainerLayout.Touch += (sender, e) =>
            {
                var me = ((Android.Views.View.TouchEventArgs)e).Event;
                MotionEventActions action = me.ActionMasked;
                switch (action)
                {
                    case MotionEventActions.Down:
                    case MotionEventActions.Move:
                    case MotionEventActions.Up:
                    case MotionEventActions.Cancel:
                        this.dragTray(action, (int)me.RawX, (int)me.RawY);
                        break;
                    //default:
                    //    return false;
                }
                //return true;
            };
            mRootLayoutParams = new WindowManagerLayoutParams(
                dpToPixels(TRAY_DIM_X_DP, context.Resources),
                dpToPixels(TRAY_DIM_Y_DP, context.Resources),
                WindowManagerTypes.Phone,
                WindowManagerFlags.NotFocusable | WindowManagerFlags.LayoutNoLimits,
                Android.Graphics.Format.Translucent
            );
            mRootLayoutParams.Gravity = GravityFlags.Top | GravityFlags.Left;
            //mRootLayout.SetBackgroundColor(Android.Graphics.Color.White);
            mWindowManager.AddView(mRootLayout, mRootLayoutParams);
            //var velocidadeRadar = mRootLayout.FindViewById<TextView>(Resource.Id.velocidadeRadar);
            var distanciaRadar = mRootLayout.FindViewById<TextView>(Resource.Id.distanciaRadar);
            //velocidadeRadar.Text = "0 KM/H";
            distanciaRadar.Text = "0 m";
            //mRootLayout.Visibility = ViewStates.Visible;
        }

        public bool estaAtivo()
        {
            Context context = Android.App.Application.Context;
            if (_locationManager == null)
                _locationManager = (LocationManager)context.GetSystemService(LocationService);
            if (_locationManager != null)
                return _locationManager.IsProviderEnabled(LocationManager.GpsProvider);
            return false;
        }

        public void abrirPreferencia()
        {
            Context context = Android.App.Application.Context;
            Intent myIntent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
            myIntent.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(myIntent);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            if (mRootLayout != null)
                mWindowManager.RemoveView(mRootLayout);
        }

        public void dragTray(MotionEventActions action, int x, int y)
        {
            switch (action)
            {
                case MotionEventActions.Down:
                    if (mTrayTimerTask != null)
                    {
                        mTrayTimerTask.Cancel();
                        mTrayAnimationTimer.Cancel();
                    }

                    // Store the start points
                    mStartDragX = x;
                    //mStartDragY = y;
                    mPrevDragX = x;
                    mPrevDragY = y;
                    break;

                case MotionEventActions.Move:
                    float deltaX = x - mPrevDragX;
                    float deltaY = y - mPrevDragY;
                    mRootLayoutParams.X += (int)deltaX;
                    mRootLayoutParams.Y += (int)deltaY;
                    mPrevDragX = x;
                    mPrevDragY = y;
                    mWindowManager.UpdateViewLayout(mRootLayout, mRootLayoutParams);
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Cancel:
                    mTrayTimerTask = new TrayAnimationTimerTask(this);
                    mTrayAnimationTimer = new Timer();
                    mTrayAnimationTimer.Schedule(mTrayTimerTask, 0, ANIMATION_FRAME_RATE);
                    break;
            }
        }

        public class TrayAnimationTimerTask : TimerTask
        {
            GPSAndroid _service;
            int mDestX;
            int mDestY;

            public TrayAnimationTimerTask(GPSAndroid service) : base()
            {
                _service = service;
                /*
                if (!_service.mIsTrayOpen)
                {
                    //mDestX = -_service.mLogoLayout.getWidth();
                */
                //mDestX = -_service.mRootLayout.Width / TRAY_HIDDEN_FRACTION;
                /*
                }
                else {
                    mDestX = -mRootLayout.getWidth() / TRAY_HIDDEN_FRACTION;
                }
                */

                // Keep upper edge of the widget within the upper limit of screen
                int screenWidth = _service.Resources.DisplayMetrics.WidthPixels;
                int screenHeight = _service.Resources.DisplayMetrics.HeightPixels;

                int x = _service.mRootLayoutParams.X;
                int metade = (int)Math.Floor((double)(screenWidth - _service.mRootLayoutParams.Width)  / 2);
                if (x <= metade)
                {
                    mDestX = 0;
                }
                else {
                    mDestX = screenWidth - _service.mRootLayoutParams.Width;
                }

                mDestY = Math.Max(
                    screenHeight / TRAY_MOVEMENT_REGION_FRACTION,
                    _service.mRootLayoutParams.Y
                );

                mDestY = Math.Min(
                    ((TRAY_MOVEMENT_REGION_FRACTION - 1) * screenHeight) / TRAY_MOVEMENT_REGION_FRACTION - _service.mRootLayout.Width,
                    mDestY
                );
            }

            public override void Run()
            {
                _service.mAnimationHandler.Post(() => {
                    _service.mRootLayoutParams.X = (2 * (_service.mRootLayoutParams.X - mDestX)) / 3 + mDestX;
                    _service.mRootLayoutParams.Y = (2 * (_service.mRootLayoutParams.Y - mDestY)) / 3 + mDestY;
                    _service.mWindowManager.UpdateViewLayout(_service.mRootLayout, _service.mRootLayoutParams);

                    if (Math.Abs(_service.mRootLayoutParams.X - mDestX) < 2 && Math.Abs(_service.mRootLayoutParams.Y - mDestY) < 2)
                    {
                        _service.mTrayAnimationTimer.Cancel();
                    }
                });
            }
        }

        public class DemoServiceBinder : Binder
        {
            GPSAndroid service;

            public DemoServiceBinder(GPSAndroid service)
            {
                this.service = service;
            }

            public GPSAndroid GetDemoService()
            {
                return service;
            }
        }

        public class PreferenciaAndroid
        {
            SQLiteConnection _database;
            static object locker = new object();

            private void inicializar()
            {
                var sqlite = new SQLiteAndroid();
                var _database = sqlite.GetConnection();
                _database.CreateTable<PreferenciaInfo>();
            }

            private string pegarValor(string campo)
            {
				inicializar();
				var preferencias = listarPreferencia();
                lock (locker)
                {
                    var preferencia = _database.Table<PreferenciaInfo>().FirstOrDefault(x => x.Preferencia == campo);
                    if (preferencia != null)
                        return preferencia.Valor;
                }
                return string.Empty;
            }

			public IList<PreferenciaInfo> listarPreferencia()
			{
				lock (locker)
				{
					return (from i in _database.Table<PreferenciaInfo>() select i).ToList();
				}
			}

            public bool LigarDesligar
            {
                get
                {
                    var valor = pegarValor(PreferenciaUtils.LIGAR_DESLIGAR);
                    return bool.Parse(valor);
                }
            }
        }
    }
}