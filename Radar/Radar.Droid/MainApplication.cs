using System;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using Radar.Pages;

namespace Radar.Droid
{
	//You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
            
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
        /*
        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			
			if (newConfig.Orientation == Orientation.Portrait) {
				var index = ClubManagement.Utils.NavigationX._current.NavigationStack.Count - 1;				
				var currPage = ClubManagement.Utils.NavigationX._current.NavigationStack[index];
				//CrossCurrentActivity.Current.Activity.Recreate();
				App.Current.MainPage = (currPage);
				
		    } else if (newConfig.Orientation == Orientation.Landscape) {
		       var index = ClubManagement.Utils.NavigationX._current.NavigationStack.Count - 1;				
				var currPage = ClubManagement.Utils.NavigationX._current.NavigationStack[index];
				//CrossCurrentActivity.Current.Activity.Recreate();
				App.Current.MainPage = (currPage);
		    }
		
		}
		*/
    }
}