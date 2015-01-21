using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;
using OCS.MvvmCross.Plugins.MvxAnalytics;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Touch
{
	public class Plugin: IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IAnalyticsService>(() => new TouchAnalyticsService());
		}
	}
}