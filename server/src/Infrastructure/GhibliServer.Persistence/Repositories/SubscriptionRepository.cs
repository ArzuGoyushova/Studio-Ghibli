using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Domain.Entities;
using GhibliServer.Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Persistence.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
