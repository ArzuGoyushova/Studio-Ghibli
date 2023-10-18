using GhibliServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Interfaces.Repository
{
    public interface IEventRepository : IGenericRepositoryAsync<Event>
    {
        Task IsDeletedAsync(Guid id);
    }
}
