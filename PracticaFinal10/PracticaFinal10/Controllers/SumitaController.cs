using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticaFinal10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumitaController : ControllerBase
    {   
        [HttpGet]
        public string letra(int a)
        {
            string palabra="";
            if (a < 0) { palabra = "error"; }
            if (a == 0) { palabra = "Realizado por alexander"; }
            if (a > 0) { palabra = "el numero es " + a; }
            return palabra;
        }
    }
}
