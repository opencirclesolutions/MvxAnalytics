﻿using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;
using OCS.MvvmCross.Plugins.MvxAnalytics.Core;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Droid
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IAnalyticsService>(() => new DroidAnalyticsService());
		}
	}
}