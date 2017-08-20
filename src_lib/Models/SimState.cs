using System;

namespace src_lib.Models
{
    public class SimState
    {
        public int Id { get; set; }

        public DateTime StartRun { get; set; }

        public DateTime StopRun { get; set; }

        public string Message { get; set; }
    }
}
