using Android.App;
using Android.Gms.Analytics;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Droid
{
	public class TrackerService {

		private static TrackerService _trackerService;

		private Tracker Tracker { get; set;}

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

		public Tracker GetTracker(AnalyticsConfiguration configuration) {
			if (Tracker == null) {
				var analytics = GoogleAnalytics.GetInstance (Application.Context);
				analytics.Logger.LogLevel = (int)configuration.LogLevel;
				analytics.SetLocalDispatchPeriod (configuration.DispatchPeriod);
				analytics.SetDryRun (configuration.DryRun);

				Tracker = analytics.NewTracker (configuration.TrackingId);
				Tracker.SetSampleRate (configuration.SampleFrequency);
				Tracker.SetAnonymizeIp (configuration.AnonymizeIp);
				Tracker.EnableExceptionReporting (configuration.ReportUncaughtExceptions);

				if (!string.IsNullOrEmpty (configuration.AppName)) {
					Tracker.SetAppName (configuration.AppName);
				}

				if (!string.IsNullOrEmpty (configuration.AppVersion)) {
					Tracker.SetAppVersion (configuration.AppVersion);
				}
			}

			return Tracker;
		}
	}
}