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
        public string listar(string nombre)
        {
            string palabra = "";
            Humano humano = new Humano
            {
                nombre = "daniel",
                edad = 18,
                nacion = "bolivia"
            };
            if (nombre == humano.nombre) { palabra = nombre + " es igual a " + humano.nombre; }
            else
            {
                palabra = nombre + " no es igual a " + humano.nombre;
            }
            return palabra;
        }

    }
}
