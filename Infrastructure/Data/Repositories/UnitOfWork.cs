using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Entity.Validation;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TtwebContext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;

        public UnitOfWork(TtwebContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Func commit of database
        /// </summary>
        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Func dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
