using GoogleAnalytics.iOS;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Touch
{
	public class TrackerService
	{
		public IGAITracker Tracker;

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

					GAI.SharedInstance.DispatchInterval = 20;
					GAI.SharedInstance.TrackUncaughtExceptions = true;
					_trackerService.Tracker = GAI.SharedInstance.GetTracker ("");
				}
				return _trackerService;
			}
		}
	}
}