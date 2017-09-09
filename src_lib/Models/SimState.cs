using System;

namespace src_lib.Models
{
    public class SimState
    {
        #region Properties
        public int Id { get; set; }

        public DateTime EventTime { get; set; }

        public Event EventType { get; set; }

        public string Message { get; set; }
        #endregion

        #region Enums
        public enum Event {
            Other=0,
            StartUp,
            ShutDown,
            Error,
            Special
        }
        #endregion
    }
}
