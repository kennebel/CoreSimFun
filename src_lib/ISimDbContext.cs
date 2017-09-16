using System;
using Microsoft.EntityFrameworkCore;

namespace src_lib
{
    public interface ISimDbContext
    {
         string FindDbFolder(string name = null);
         void EnsureCreated(IServiceProvider serviceProvider);
         void DbInitialize(IServiceProvider serviceProvider);
    }
}