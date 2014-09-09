using GoogleAnalytics.iOS;
using OCS.MvvmCross.Plugins.MvxAnalytics.Core;

namespace OCS.MvvmCross.Plugins.MvxAnalytics.Touch
{
	public class TouchAnalyticsService : IAnalyticsService
	{
		public void TrackView(string viewName) {
			var tracker = TrackerService.Instance.Tracker;

			tracker.Set (GAIConstants.ScreenName, viewName);
			tracker.Send(GAIDictionaryBuilder.CreateAppView().Build());
		}
	}
}