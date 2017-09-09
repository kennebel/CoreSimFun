using System;
using System.Collections.Generic;
using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public static class SimStateMgr
    {
        /// <summary>
        /// Inserts a new SimState to the database
        /// </summary>
        /// <param name="eventType">The event being logged</param>
        /// <param name="message">Optional message</param>
        /// <returns>True if the new sim state was logged to the database</returns>
        public static bool LogSimState(SimState.Event eventType, string message = null)
        {
            using (var context = new SimDbContext())
            {
                context.SimState.Add(new SimState() {
                   EventTime = DateTime.Now,
                   EventType = eventType,
                   Message = message
                });

                return (context.SaveChanges() == 1);
            }
        }

        /// <summary>
        /// Pulls out the most recent SimStates
        /// </summary>
        /// <param name="recentCount"></param>
        /// <returns></returns>
        public static IEnumerable<SimState> RecentStates(int recentCount=5)
        {
            if (recentCount > 0)
            {
                using (var context = new SimDbContext())
                {
                    return context.SimState.OrderByDescending(s => s.EventTime).Take(recentCount).ToList();
                }
            }

            return new List<SimState>();
        }
    }
}