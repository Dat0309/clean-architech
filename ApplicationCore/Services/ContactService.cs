using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add contact
        /// </summary>
        /// <param name="entity">Contact model</param>
        /// <returns></returns>
        public async Task<bool> Add(Contact entity)
        {
            await _contactRepository.Add(entity);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get all caontacts
        /// </summary>
        /// <returns>List of all contacts</returns>
        /// <exception cref="NullTableException"></exception>
        public async Task<IEnumerable<Contact>> GetAll()
        {
            var contacts = await _contactRepository.GetAll();
            return contacts;
        }

        /// <summary>
        /// Get contact by id
        /// </summary>
        /// <param name="id"> ID of contact want to get </param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        /// <exception cref="RecordNotFoundException"></exception>
        public async Task<Contact> GetById(int id)
        {
            var contact = await _contactRepository.GetById(id);
            return contact;
        }
    }
}
