namespace OCS.MvvmCross.Plugins.MvxAnalytics
{
	public interface IAnalyticsService
	{
	    AnalyticsConfiguration Configuration { get; }
	    void TrackView(string viewName);
		void TrackEvent (string action, string label);
		void TrackEvent (string category, string action, string label);
	}
}