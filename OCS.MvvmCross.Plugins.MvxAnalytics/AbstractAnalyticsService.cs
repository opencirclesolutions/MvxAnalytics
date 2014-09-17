namespace OCS.MvvmCross.Plugins.MvxAnalytics
{
	public abstract class AbstractAnalyticsService : IAnalyticsService
	{
		protected AbstractAnalyticsService ()
		{
			this.Configuration = new AnalyticsConfiguration {
				LogLevel = LogLevel.Warning,
				DispatchPeriod = 30,
				SampleFrequency = 100.0,
				AnonymizeIp = false,
				ReportUncaughtExceptions = false,
				DryRun = false
			};
		}
			
		public abstract void TrackView (string viewName);
		public abstract void TrackEvent (string action, string label);
		public abstract void TrackEvent (string category, string action, string label);

		public AnalyticsConfiguration Configuration { get; private set; }
	}
}