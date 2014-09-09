using System.Collections.Generic;

using Android.App;
using Android.Gms.Analytics;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Droid
{
	public class TrackerService {

		private static TrackerService _trackerService;
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

		public enum TrackerName {
			APP_TRACKER, // Tracker used only in this app.
			GLOBAL_TRACKER, // Tracker used by all the apps from a company. eg: roll-up tracking.
			ECOMMERCE_TRACKER, // Tracker used by all ecommerce transactions from a company.
		}

		Dictionary<TrackerName, Tracker> Trackers = new Dictionary<TrackerName, Tracker>();

		public Tracker GetTracker(TrackerName trackerId) {
			Tracker tracker = null;
			Trackers.TryGetValue(trackerId, out tracker);

			if (tracker == null) {
				GoogleAnalytics analytics = GoogleAnalytics.GetInstance (Application.Context);
//				GoogleAnalytics.GetInstance(Application.Context).Logger.LogLevel = LoggerLogLevel.Verbose;
				tracker = analytics.NewTracker ("");
				Trackers.Add (trackerId, tracker);

			}

			return tracker;
		}
	}
}