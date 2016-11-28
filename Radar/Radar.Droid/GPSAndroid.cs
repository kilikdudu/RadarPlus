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

[assembly: UsesPermission(Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Manifest.Permission.Internet)]
[assembly: UsesPermission(Manifest.Permission.InternalSystemWindow)]
[assembly: UsesPermission(Manifest.Permission.SystemAlertWindow)]

[assembly: Dependency(typeof(GPSAndroid))]

namespace Radar.Droid
{
    [Service]
    [IntentFilter(new String[] { "br.com.cmapps.radar" })]
    public class GPSAndroid : Service, ILocationListener, IGPS
    {
        private const int ID_RADAR_CLUB = 5;
        private const int TRAY_DIM_X_DP = 170;   // Width of the tray in dps
        private const int TRAY_DIM_Y_DP = 160; 	// Height of the tray in dps
        private const int ANIMATION_FRAME_RATE = 30;	// Animation frame rate per second.
        private const int TRAY_MOVEMENT_REGION_FRACTION = 6; // Controls fraction of y-axis on screen within which the tray stays.

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

        public GPSAndroid() {
        }

        DemoServiceBinder binder;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            inicializar();
            notificar(intent);
            criarWidget();
            return StartCommandResult.NotSticky;
        }

        public void notificar(Intent intent)
        {
            /*
            var ongoing = new Notification(Resource.Drawable.navicon, "Radar+");
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(MainActivity)), 0);
            ongoing.SetLatestEventInfo(this, "Radar+", "Est� em funcionamento", pendingIntent);
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

        public void OnLocationChanged(Location location)
        {
            LocalizacaoInfo local = converterLocalizacao(location);
            GPSUtils.atualizarPosicao(local);
            RadarInfo radar = RadarBLL.RadarAtual;
            if (radar != null)
            {
                var velocidadeRadar = mRootLayout.FindViewById<TextView>(Resource.Id.velocidadeRadar);
                var distanciaRadar = mRootLayout.FindViewById<TextView>(Resource.Id.distanciaRadar);
                velocidadeRadar.Text = radar.VelocidadeStr;
                distanciaRadar.Text = local.Distancia.ToString() + " m";
                if (mRootLayout.Visibility != ViewStates.Visible)
                    mRootLayout.Visibility = ViewStates.Visible;
            }
            else {
                if (mRootLayout.Visibility == ViewStates.Visible)
                    mRootLayout.Visibility = ViewStates.Invisible;
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
            Context context = Android.App.Application.Context;
            _locationManager = (LocationManager)context.GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            _locationProvider = _locationManager.GetBestProvider(criteriaForLocationService, true);
            _locationManager.RequestLocationUpdates(_locationProvider, PreferenciaUtils.GPSTempoAtualiazacao, PreferenciaUtils.GPSDistanciaAtualizacao, this);
            return true;
        }

        public static int dpToPixels(int dp, Resources res)
        {
            return (int)(res.DisplayMetrics.Density * dp + 0.5f);
        }

        public void criarWidget() {
            Context context = Android.App.Application.Context;
            mWindowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            mRootLayout = LayoutInflater.From(context).Inflate(Resource.Layout.service_player, null);
            var mContentContainerLayout = mRootLayout.FindViewById(Resource.Id.content_container);
            // Erro de Invelid Cast - Depois a gente v� essa merda!
            //mContentContainerLayout.SetOnTouchListener(new TrayTouchListener(this));
            mRootLayoutParams = new WindowManagerLayoutParams(
                dpToPixels(TRAY_DIM_X_DP, context.Resources),
                dpToPixels(TRAY_DIM_Y_DP, context.Resources),
                WindowManagerTypes.Phone,
                WindowManagerFlags.NotFocusable | WindowManagerFlags.LayoutNoLimits,
                Android.Graphics.Format.Translucent
            );
            mRootLayout.SetBackgroundColor(Android.Graphics.Color.White);
            mWindowManager.AddView(mRootLayout, mRootLayoutParams);
            var velocidadeRadar = mRootLayout.FindViewById<TextView>(Resource.Id.velocidadeRadar);
            var distanciaRadar = mRootLayout.FindViewById<TextView>(Resource.Id.distanciaRadar);
            velocidadeRadar.Text = "0 KM/H";
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
    }
}