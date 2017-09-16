using System;
using System.Collections.Generic;
using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public partial class DbMgr
    {
        /// <summary>
        /// Inserts a new SimEvent to the database
        /// </summary>
        /// <param name="eventType">The event being logged</param>
        /// <param name="message">Optional message</param>
        /// <returns>True if the new sim state was logged to the database</returns>
        public bool LogSimEvent(SimEvent.Event eventType, string message = null)
        {
            using (var context = new SimDbContext())
            {
                context.SimEvents.Add(new SimEvent() {
                   EventTime = DateTime.Now,
                   EventType = eventType,
                   Message = message
                });

                return (context.SaveChanges() == 1);
            }
        }

        /// <summary>
        /// Pulls out the most recent SimEvents
        /// </summary>
        /// <param name="recentCount"></param>
        /// <returns></returns>
        public IEnumerable<SimEvent> RecentSimEvents(int recentCount=5)
        {
            if (recentCount > 0)
            {
                using (var context = new SimDbContext())
                {
                    return context.SimEvents.OrderByDescending(s => s.EventTime).Take(recentCount).ToList();
                }
            }

            return new List<SimEvent>();
        }
    }
}