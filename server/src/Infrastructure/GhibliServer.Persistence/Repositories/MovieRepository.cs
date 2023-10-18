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
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
        public async Task IsDeletedAsync(Guid id)
        {
            var movie = await _appDbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new Exception("Movie not found.");
            }

            movie.IsDeleted = true;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
