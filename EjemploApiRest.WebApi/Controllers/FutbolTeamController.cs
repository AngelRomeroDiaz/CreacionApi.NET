using EjemploApiRest.Application;
using EjemploApiRest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjemploApiRest.WebApi.Controllers
{
    [Route("api/FutbolTeamController")]
    [ApiController]
    public class FutbolTeamController : ControllerBase
    {
        IApplication<FutbolTeam> _football;

        public FutbolTeamController(IApplication<FutbolTeam> footbal)
        {
            _football = footbal;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_football.GetAll());
           
        }

        [HttpPost]
        public IActionResult Save(DTOs.FutbolTeamDTO dto)
        {
            var f = new FutbolTeam()
            {
                Name=dto.Name,
                Scocre=dto.Scocre
            };
            return Ok(_football.Save(f));

        }


    }
}
