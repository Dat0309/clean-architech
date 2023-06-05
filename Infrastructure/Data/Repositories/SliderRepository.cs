using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Filer;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(TtwebContext context) : base(context)
        {
        }

        /// <summary>
        /// Get sliders by type id
        /// </summary>
        /// <param name="typeId"> type id of slides want to get </param>
        /// <returns> List of sliders by type id </returns>
        /// <exception cref="ArgumentNullException"> Exception when typeID not valid </exception>
        public async Task<IEnumerable<Slider>> GetSliderByType(int typeId)
        {
            IEnumerable<Slider> sliders = from obj in await Context.Sliders.ToListAsync()
                                          where obj.Type == typeId
                                          select obj;
                
            sliders = sliders.OrderByDescending(o => o.Ordering).ToList();
            
            return sliders;
        }

        /// <summary>
        /// Get sliders by type support pagination
        /// </summary>
        /// <param name="typeId"> typeId of sliders want to get </param>
        /// <param name="filter"> Pagination filter from request body </param>
        /// <returns> List sliders by typeId, support pagination </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IEnumerable<Slider>> GetSliderByTypeWithPagination(int typeId, PaginationFilter filter)
        {
            IEnumerable<Slider> sliders = from obj in await Context.Sliders.ToListAsync()
                                          where obj.Type == typeId
                                          select obj;
                
            sliders = sliders.OrderByDescending(o => o.Ordering).Skip(filter.PageSize * (filter.PageNumber - 1)).Take(filter.PageSize).ToList();
            return sliders;
        }

        /// <summary>
        /// Get all sliders support pagination
        /// </summary>
        /// <param name="filter"> Pagination filter from request body </param>
        /// <returns> List All sliders support pagination </returns>
        public async Task<IEnumerable<Slider>> GetSliderWithPagination(PaginationFilter filter)
        {
            IEnumerable<Slider> sliders = await Context.Sliders.ToListAsync();
            sliders = sliders.OrderByDescending(o => o.Ordering).Skip(filter.PageSize * (filter.PageNumber - 1)).Take(filter.PageSize).ToList();
            return sliders;
        }
    }
}
