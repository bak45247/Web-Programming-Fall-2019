using System.Diagnostics;
using System.Text;

namespace DependencyInjection.Services
{
	/*
	* This class times how long passes between events.
	*/
	public class StopwatchService
    {
        private readonly ILogger logger;
        private Stopwatch stopwatch = new Stopwatch();
		private StringBuilder builder = new StringBuilder();

        public StopwatchService()
        {

        }
        public StopwatchService(ILogger logger)
        {
            this.logger = logger;
        }

		public void Start(string name)
		{
			logger.Log("Starting a new stopwatch");
			Lap(name);
			stopwatch.Start();
		}

		public void Lap(string name)
		{
			builder.Append("{").Append(name).Append(" ").Append(stopwatch.ElapsedTicks).Append("}");
		}

		public override string ToString()
		{
			return builder.ToString();
		}
	}
}
