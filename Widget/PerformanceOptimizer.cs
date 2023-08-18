using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Widget
{
    public class PerformanceOptimizer
    {
        private int timeSinceLastFullScreenCheck = 0;

#if !DEBUG
        private int fullScreenCheckInterval = 5 * 60 * 1000; // 5 Min
#else
        private readonly int fullScreenCheckInterval = 1 * 60 * 1000; // 1 Min
#endif
        private readonly int extraOptimizationDelay = 5 * 60 * 1000; // 5 Min

        private bool isUserEngagedInFullScreenActivity;

        public PerformanceOptimizer(int updateInterval)
        {
            if (updateInterval <= 0)
                throw new Exception(Constants.PerformanceOptimizerError);

            extraOptimizationDelay = extraOptimizationDelay  - updateInterval;
        }

        public bool ShouldCheckFullScreenActivity(int updateInterval)
        {
            timeSinceLastFullScreenCheck += updateInterval;
            if (timeSinceLastFullScreenCheck >= fullScreenCheckInterval || isUserEngagedInFullScreenActivity)
            {
                timeSinceLastFullScreenCheck = 0; // Reset
                return true;
            }
            return false;
        }

        public async Task PerformOptimizationDelay()
        {
            isUserEngagedInFullScreenActivity = await WindowsAPI.IsUserEngagedInFullScreenActivity();

            if (isUserEngagedInFullScreenActivity)
            {
                await Task.Delay(extraOptimizationDelay);
            }
        }
    }



}
