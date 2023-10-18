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
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
        public async Task IsDeletedAsync(Guid id)
        {
            var e = await _appDbContext.Events.FindAsync(id);

            if (e == null)
            {
                throw new Exception("Event not found.");
            }

            e.IsDeleted = true;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
