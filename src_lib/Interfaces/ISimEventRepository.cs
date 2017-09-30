using System.Collections.Generic;
using System.Linq;
using src_lib.Models;

namespace src_lib
{
    public interface ISimEventRepository
    {
        IQueryable<SimEvent> GetSimEvents();

        SimEvent GetSimEvent(int id);

        SimEvent UpsertSimEvent(SimEvent se);

        bool ClearAllEvents();
    }
}