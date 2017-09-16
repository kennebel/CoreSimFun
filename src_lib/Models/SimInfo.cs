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

        #region Static Fields / Properties
        private static SimInfo _instance;
        public static SimInfo instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = DbMgr.GetSimInfo();
                    if (_instance == null) { _instance = new SimInfo(); }
                }
                return _instance;
            }
            set { _instance = value; }
        }
        #endregion

        #region Static Methods
        public static bool Save()
        {
            DbMgr.SaveSimInfo(instance);
            return true;
        }
        #endregion
    }
}