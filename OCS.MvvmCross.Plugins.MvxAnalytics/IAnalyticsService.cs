namespace OCS.MvvmCross.Plugins.MvxAnalytics
{
	public interface IAnalyticsService
	{
		void TrackView(string viewName);
		void TrackEvent (string action, string label);
		void TrackEvent (string category, string action, string label);
	}
}