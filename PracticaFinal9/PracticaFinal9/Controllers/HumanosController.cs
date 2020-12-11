using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal9.Models;

namespace PracticaFinal9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanosController : ControllerBase
    {   
        [HttpGet]
        public Humano listar()
        {
            Humano humano = new Humano
            {
                nombre = "daniel",
                edad = 18,
                nacion = "bolivia"
            };
            return humano;
        }

    }
}
