using GoogleAnalytics.iOS;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Touch
{
	public class TrackerService
	{
		private static TrackerService _trackerService;

		private IGAITracker Tracker;

		private TrackerService() {
		}

		public static TrackerService Instance
		{
			get
			{
				if (_trackerService == null)
				{
					_trackerService = new TrackerService();
				}
				return _trackerService;
			}
		}

		public IGAITracker GetTracker(AnalyticsConfiguration configuration) {
			if (Tracker == null) {
				GAI.SharedInstance.Logger.LogLevel = GetLogLevel (configuration.LogLevel);
				GAI.SharedInstance.DispatchInterval = configuration.DispatchPeriod;
				GAI.SharedInstance.DryRun = configuration.DryRun;
				GAI.SharedInstance.TrackUncaughtExceptions = configuration.ReportUncaughtExceptions;

				Tracker = GAI.SharedInstance.GetTracker (configuration.TrackingId);

				Tracker.Set (GAIConstants.SampleRate, configuration.SampleFrequency.ToString ());
				Tracker.Set (GAIConstants.AnonymizeIp, configuration.AnonymizeIp.ToString ());

				if (!string.IsNullOrEmpty (configuration.AppName)) {
					Tracker.Set (GAIConstants.AppName, configuration.AppName);
				}

				if (!string.IsNullOrEmpty (configuration.AppVersion)) {
					Tracker.Set (GAIConstants.AppVersion, configuration.AppVersion);
				}
			}

			return Tracker;
		}

		private GAILogLevel GetLogLevel(LogLevel logLevel) {
			switch (logLevel) {
			case LogLevel.Error:
				return GAILogLevel.Error;
			case LogLevel.Info:
				return GAILogLevel.Info;
			case LogLevel.Verbose:
				return GAILogLevel.Verbose;
			case LogLevel.Warning:
				return GAILogLevel.Warning;
			}

			return GAILogLevel.Warning;
		}
	}
}