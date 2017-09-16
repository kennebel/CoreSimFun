using System;

namespace src_lib.Models
{
    public class SimInfo
    {
        #region Fields
        protected int _TickCount = 0;
        #endregion

        #region Properties
        public int Id { get; set; }

        public int TickCount
        {
            get { return _TickCount; }
            set
            {
                _TickCount = value >= 0 ? value : 0;
            }
        }
        #endregion
    }
}