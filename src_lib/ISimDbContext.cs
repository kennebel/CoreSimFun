using System;
using Microsoft.EntityFrameworkCore;

namespace src_lib
{
    public interface ISimDbContext
    {
         void EnsureCreated(IServiceProvider serviceProvider);
         void DbInitialize(IServiceProvider serviceProvider);
    }
}