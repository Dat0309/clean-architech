using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private string _errorMessage = string.Empty;

        public GenericRepository(TtwebContext context)
        {
            Context = context;
        }

        public TtwebContext Context { get; set; }

        /// <summary>
        /// Add entity to DB Table
        /// </summary>
        /// <param name="entity"> Some table entity in table </param>
        /// <returns> Entity added </returns>
        /// <exception cref="Exception"></exception>
        public async Task Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        /// <summary>
        /// Get all entities 
        /// </summary>
        /// <returns> List all entities </returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"> Id of entity </param>
        /// <returns> Single entity </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> GetById(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            return entity!;
        }

        /// <summary>
        /// Get count off list entities
        /// </summary>
        /// <returns></returns>
        public int GetCountDocument()
        {
            return Context.Set<T>().Count();
        }
    }
}
