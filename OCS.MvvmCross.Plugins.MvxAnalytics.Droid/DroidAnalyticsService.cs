using OCS.MvvmCross.Plugins.MvxAnalytics.Core;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Droid
{
	public class DroidAnalyticsService : IAnalyticsService
	{
		public DroidAnalyticsService ()
		{
		}

		public void TrackView(string viewName) {
			#if DEBUG
				return;
			#else
				// Get tracker.
				var tracker = TrackerService.Instance.GetTracker (TrackerService.TrackerName.APP_TRACKER);

				// Set screen name.
				// Where path is a String representing the screen name.
				tracker.SetScreenName (viewName);

				// Send a screen view.
				tracker.Send(new HitBuilders.ScreenViewBuilder().Build());
			#endif
		}
	}
}