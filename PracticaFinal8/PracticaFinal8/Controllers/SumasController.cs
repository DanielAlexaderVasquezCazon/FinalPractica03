using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticaFinal8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumasController : ControllerBase
    {   
        
        
        [HttpGet]
        [Route("Add")]
        public int Add(int a,int b)
        {
            return (a + b);
        }
        [HttpPost]
        [Route("Add")]
        public int Add1([FromHeader]int a, [FromHeader] int b)
        {
            return (a + b);
        }
       
        
        [HttpGet]
        [Route("Mul")]
        public int Mul(int a, int b)
        {
            return (a * b);
        }
        [HttpPost]
        [Route("Mul")]
        public int Mul1([FromHeader] int a, [FromHeader] int b)
        {
            return (a * b);
        }
    }
}
