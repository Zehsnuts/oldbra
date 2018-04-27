using System.Timers;

namespace Bradesco {
	internal static class Extensions {
		public static void Reset(this Timer timer)
		{
			timer.Stop();
			timer.Start();
		}
	}
}
