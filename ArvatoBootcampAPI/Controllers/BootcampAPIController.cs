using ArvatoBootcampAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArvatoBootcampAPI.Controllers
{
    [Route("bootcamp")]
    [ApiController]
    public class BootcampAPIController : ControllerBase
    {
        IApiData apiData;

        public BootcampAPIController(IApiData apiData)
        {
            this.apiData = apiData;
        }

        [HttpGet]
        [Route("list")]
        public List<BootcampDto> GetList()
        {
            return apiData.GetBootcampList();
        }

        [HttpGet]
        public BootcampDto Get(int id)
        {
            return apiData.GetBootcampList().Where(x => x.Id == id).FirstOrDefault();
        }


        [HttpDelete]
        public bool Delete(int id)
        {
            return false;
        }

        [HttpPost]
        public bool Post(BootcampDto dto)
        {
            apiData.Add<BootcampDto>(new List<BootcampDto>());

            apiData.BootcampList.Add(dto);

            return true;
        }

        public bool Update(BootcampDto dto)
        {
            var bootcamp = apiData.BootcampList.FirstOrDefault(x => x.Id == dto.Id);

            if (bootcamp == null) return false;

            bootcamp.Title = dto.Title;
            bootcamp.Description = dto.Description;  
                      
            return true;
        }



    }
}
