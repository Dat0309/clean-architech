using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(TtwebContext context) : base(context)
        {
        }

    }
}
