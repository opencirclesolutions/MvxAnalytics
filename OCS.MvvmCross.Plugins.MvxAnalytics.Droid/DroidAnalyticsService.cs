using OCS.MvvmCross.Plugins.MvxAnalytics;
using Android.Gms.Analytics;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Droid
{
	public class DroidAnalyticsService : AbstractAnalyticsService
	{
		public DroidAnalyticsService () { }

		public override void TrackView(string viewName) {
			var tracker = TrackerService.Instance.GetTracker (Configuration);

			tracker.SetScreenName (viewName);

			tracker.Send(new HitBuilders.ScreenViewBuilder().Build());
		}

		public override void TrackEvent(string category, string action, string label) {
			var tracker = TrackerService.Instance.GetTracker (Configuration);

			var analyticsEvent = new HitBuilders.EventBuilder ()
				.SetCategory (category)
				.SetAction (action)
				.SetLabel (label)
				.SetValue (1)
				.Build ();

			tracker.Send (analyticsEvent);
		}
	}
}