using LESSION_WEB_API_DEMO.Models;
using LESSION_WEB_API_DEMO.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace LESSION_WEB_API_DEMO.Controllers
{
    public class SlidesController : ApiController
    {
        private readonly ISlideRepository _slideRepository;

        public SlidesController(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        [ResponseType(typeof(List<SlideInfo>))]
        public List<SlideInfo> GetSlides()
        {
            return _slideRepository.GetAll();
        }

        [ResponseType(typeof(SlideInfo))]
        public SlideInfo GetSlide(string id)
        {
            return _slideRepository.Get(id);
        }

        public SlideInfo PostSlide(SlideInfo slide)
        {
            return null;
        }
    }
}
