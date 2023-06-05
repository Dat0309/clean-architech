using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class SliderTypeRepository : GenericRepository<SliderType>, ISliderTypeRepository
    {

        public SliderTypeRepository(TtwebContext context) : base(context)
        {
        }

        /// <summary>
        /// Get all slider type attach data sliders of them
        /// </summary>
        /// <returns> List all slider type </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IEnumerable<SliderType>> GetAllWithDataSlides()
        {
            IEnumerable<SliderType> sliderTypes = from obj in await Context.SliderTypes.ToListAsync()
                                                  select new SliderType
                                                  {
                                                      Id = obj.Id,
                                                      Description = obj.Description,
                                                      Title = obj.Title,
                                                      Sliders = getSliderByType(obj.Id)
                                                  };
                
            return sliderTypes;
        }

        /// <summary>
        /// Get sliders by type
        /// </summary>
        /// <param name="type"> tyoeID of sliders want to get</param>
        /// <returns> List of sliders by typeID </returns>
        /// <exception cref="ArgumentNullException"></exception>
        private ICollection<Slider> getSliderByType(int typeID)
        {
            ICollection<Slider> sliders = (from obj in Context.Sliders.ToList()
                                           where obj.Type == typeID
                                           select new Slider
                                           {
                                               Id = obj.Id,
                                               Title = obj.Title,
                                               Image = obj.Image,
                                               Description = obj.Description,
                                               Ordering = obj.Ordering,
                                               Subtitle = obj.Subtitle,
                                               Type = obj.Type,
                                               CreatedTime = obj.CreatedTime,
                                               Url = obj.Url,
                                               TypeNavigation = null
                                           }).ToList();
            sliders = sliders.OrderBy(o => o.Ordering).ToList();
            
            return sliders;
        }

        /// <summary>
        /// Get slider type id attach data sliders of them
        /// </summary>
        /// <param name="id"> ID of slider type want to get </param>
        /// <returns> Single slider type </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<SliderType> GetByIdWithDataSlides(int id)
        {
            var sliderTypes = await Context.SliderTypes.FindAsync(id);
                
            return new SliderType
            {
                Id = sliderTypes!.Id,
                Description = sliderTypes.Description,
                Title = sliderTypes.Title,
                Sliders = getSliderByType(sliderTypes.Id)
            };
        }
    }
}
