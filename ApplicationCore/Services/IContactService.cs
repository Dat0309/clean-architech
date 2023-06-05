using ApplicationCore.Entities;

namespace ApplicationCore.Services
{
    public interface IContactService
    {
        public Task<Contact> GetById(int id);
        public Task<IEnumerable<Contact>> GetAll();
        public Task<bool> Add(Contact entity);
    }
}
