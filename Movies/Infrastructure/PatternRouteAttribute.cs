using System;

namespace Movies.Infrastructure
{
	public class PatternRouteAttribute : Attribute
	{
		public string Url { get; set; }

		public PatternRouteAttribute(string url)
		{
			Url = url;
		}
	}
}