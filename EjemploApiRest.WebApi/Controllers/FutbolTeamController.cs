//using EjemploApiRest.Application;
//using EjemploApiRest.Entities;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace EjemploApiRest.WebApi.Controllers
//{
//    [Route("api/FutbolTeamController")]
//    [ApiController]
//    public class FutbolTeamController : ControllerBase
//    {
//        IApplication<FutbolTeam> _football;

//        public FutbolTeamController(IApplication<FutbolTeam> footbal)
//        {
//            _football = footbal;
//        }

//        [HttpGet]
//        public ActionResult Get()
//        {
//            return Ok(_football.GetAll());

//        }

//        [HttpPost]
//        public IActionResult Save(DTOs.FutbolTeamDTO dto)
//        {
//            var f = new FutbolTeam()
//            {
//                Name=dto.Name,
//                Scocre=dto.Scocre
//            };
//            return Ok(_football.Save(f));

//        }


//    }
//}

using EjemploApiRest.Application;
using EjemploApiRest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EjemploApiRest.WebApi.Controllers
{
    [Route("api/FutbolTeamController")]
    [ApiController]
    public class FutbolTeamController : ControllerBase
    {
        IApplication<FutbolTeam> _football;

        // Cadena de conexión de ejemplo (solo para pruebas locales)
        // NO usar credenciales reales en repositorios públicos
        private readonly string _conn = "Server=(local);Database=TestDb;Trusted_Connection=True;";

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
            // VULNERABLE: concatenación directa de valores en la consulta SQL
            // (intencional para pruebas SAST)
            var sql = "INSERT INTO FutbolTeams (Name, Scocre) VALUES ('" + dto.Name + "', '" + dto.Scocre + "');";

            using (var conn = new SqlConnection(_conn))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            var f = new FutbolTeam()
            {
                Name = dto.Name,
                Scocre = dto.Scocre
            };
            return Ok(_football.Save(f));
        }

        // Endpoint adicional vulnerable a inyección SQL por búsqueda
        [HttpGet("search")]
        public IActionResult Search(string q)
        {
            // VULNERABLE: concatenación directa de entrada del usuario en la consulta
            var sql = "SELECT Id, Name, Scocre FROM FutbolTeams WHERE Name LIKE '%" + q + "%'";

            var results = new List<object>();
            using (var conn = new SqlConnection(_conn))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new { Id = reader["Id"], Name = reader["Name"], Scocre = reader["Scocre"] });
                    }
                }
            }

            return Ok(results);
        }
    }
}

