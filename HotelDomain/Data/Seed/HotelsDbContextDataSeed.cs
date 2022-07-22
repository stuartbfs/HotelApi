using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDomain.Data.Seed
{
    public static class HotelsDbContextDataSeed
    {
        public static void Initialize(HotelsDbContext context)
        {
            context.Database.EnsureCreated();


        }
    }
}
