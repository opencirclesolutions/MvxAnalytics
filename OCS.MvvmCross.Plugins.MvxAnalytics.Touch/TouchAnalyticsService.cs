using GoogleAnalytics.iOS;
using OCS.MvvmCross.Plugins.MvxAnalytics;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Touch
{
	public class TouchAnalyticsService : AbstractAnalyticsService
	{
		public TouchAnalyticsService() {}

		public override void TrackView(string viewName) {
			var tracker = TrackerService.Instance.GetTracker(Configuration);

			tracker.Set (GAIConstants.ScreenName, viewName);
			tracker.Send(GAIDictionaryBuilder.CreateAppView().Build());
		}

		public override void TrackEvent(string category, string action, string label) {
			var tracker = TrackerService.Instance.GetTracker(Configuration);

			tracker.Send (GAIDictionaryBuilder.CreateEvent(category, action, label, 1).Build());
		}

		public override void TrackEvent(string action, string label) {
			var tracker = TrackerService.Instance.GetTracker(Configuration);

			tracker.Send (GAIDictionaryBuilder.CreateEvent("", action, label, 1).Build ());
		}
	}
}