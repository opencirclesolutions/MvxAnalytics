namespace OCS.MvvmCross.Plugins.MvxAnalytics
{
	public enum LogLevel {
		Verbose = 0,
		Info = 1,
		Warning = 2,
		Error = 3
	}

	public class AnalyticsConfiguration
	{
		public string TrackingId { get; set;}
		public string AppName { get;set; }
		public string AppVersion { get; set;}
		public LogLevel LogLevel {get;set;}
		public int DispatchPeriod { get; set;}
		public double SampleFrequency { get; set; }
		public bool AnonymizeIp { get; set;}
		public bool ReportUncaughtExceptions { get; set; }
		public bool DryRun{ get; set;}
	}
}