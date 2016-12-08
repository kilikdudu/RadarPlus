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

        private bool _inicializado = false;
        private bool desativando = false;
        public GPSSituacaoEnum Situacao { get; set; }

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

        private bool mIsTrayOpen = true;
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
                Intent notificationIntent = new Intent(this, typeof(GPSAndroid));
			    notificationIntent.PutExtra("stop_service", true);
			    PendingIntent pendingIntent = PendingIntent.GetService(this, 0, notificationIntent, 0);
                Notification notification = new Notification(
                    Resource.Drawable.navicon,
                    "Radar+",
                    Java.Lang.JavaSystem.CurrentTimeMillis()
                );
                notification.SetLatestEventInfo( this, "Radar+", "Pressione aqui para fechar.", pendingIntent);
                StartForeground((int)NotificationFlags.ForegroundService, notification);
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
            local.Sentido = location.Bearing;
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
            /*
            local.Velocidade = 20;
            local.Latitude = -16.620743;
            local.Longitude = -49.356621;
            local.Sentido = 324;
            */
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
                var regraPreferencia = new PreferenciaAndroid();
                if (regraPreferencia.LigarDesligar && local.Precisao <= 30)
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

                    // Cancel any currently running animations/automatic tray movements.
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

                    // Calculate position of the whole tray according to the drag, and update layout.
                    float deltaX = x - mPrevDragX;
                    float deltaY = y - mPrevDragY;
                    mRootLayoutParams.X += (int)deltaX;
                    mRootLayoutParams.Y += (int)deltaY;
                    mPrevDragX = x;
                    mPrevDragY = y;
                    //animateButtons();
                    mWindowManager.UpdateViewLayout(mRootLayout, mRootLayoutParams);
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Cancel:

                    // When the tray is released, bring it back to "open" or "closed" state.
                    if ((mIsTrayOpen && (x - mStartDragX) <= 0) ||
                        (!mIsTrayOpen && (x - mStartDragX) >= 0))
                        mIsTrayOpen = !mIsTrayOpen;

                    mTrayTimerTask = new TrayAnimationTimerTask(this);
                    mTrayAnimationTimer = new Timer();
                    mTrayAnimationTimer.Schedule(mTrayTimerTask, 0, ANIMATION_FRAME_RATE);
                    break;
            }
        }

        public class TrayTouchListener : Android.Views.View.IOnTouchListener
        {
            GPSAndroid _service;

            public TrayTouchListener(GPSAndroid service) {
                _service = service;
            }

            public IntPtr Handle {
                get {
                    return this.Handle;
                    //return _service.Handle;
                }
            }

            public void Dispose() {
                //nada
            }

            public bool OnTouch(Android.Views.View v, MotionEvent e)
            {
                MotionEventActions action = e.ActionMasked;
                switch (action)
                {
                    case MotionEventActions.Down:
                    case MotionEventActions.Move:
                    case MotionEventActions.Up:
                    case MotionEventActions.Cancel:
                        _service.dragTray(action, (int)e.RawX, (int)e.RawY);
                        break;
                    default:
                        return false;
                }
                return true;
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
                if (!mIsTrayOpen)
                {
                    mDestX = -mLogoLayout.getWidth();
                }
                else {
                    mDestX = -mRootLayout.getWidth() / TRAY_HIDDEN_FRACTION;
                }
                */

                // Keep upper edge of the widget within the upper limit of screen
                int screenHeight = _service.Resources.DisplayMetrics.HeightPixels;
                mDestY = Math.Max(
                    screenHeight / TRAY_MOVEMENT_REGION_FRACTION,
                    _service.mRootLayoutParams.Y
                );

                // Keep lower edge of the widget within the lower limit of screen
                mDestY = Math.Min(
                    ((TRAY_MOVEMENT_REGION_FRACTION - 1) * screenHeight) / TRAY_MOVEMENT_REGION_FRACTION - _service.mRootLayout.Width,
                    mDestY
                );
            }

            public override void Run()
            {
                _service.mAnimationHandler.Post(() => {
                    // Update coordinates of the tray
                    _service.mRootLayoutParams.X = (2 * (_service.mRootLayoutParams.X - mDestX)) / 3 + mDestX;
                    _service.mRootLayoutParams.Y = (2 * (_service.mRootLayoutParams.Y - mDestY)) / 3 + mDestY;
                    _service.mWindowManager.UpdateViewLayout(_service.mRootLayout, _service.mRootLayoutParams);
                    //animateButtons();

                    // Cancel animation when the destination is reached
                    if (Math.Abs(_service.mRootLayoutParams.X - mDestX) < 2 && Math.Abs(_service.mRootLayoutParams.Y - mDestY) < 2)
                    {
                        //TrayAnimationTimerTask.this.Cancel();
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
                lock (locker)
                {
                    var preferencia = _database.Table<PreferenciaInfo>().FirstOrDefault(x => x.Preferencia == campo);
                    if (preferencia != null)
                        return preferencia.Valor;
                }
                return string.Empty;
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