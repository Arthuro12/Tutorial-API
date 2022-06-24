using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutoController : ControllerBase
    {
        Tuto[] tutos = new Tuto[]
        {
            new Tuto { title = "wpf", price = 49, image = "wpf.png", description = "Blalabla....." },
            new Tuto { title = "Unity", price = 27, image = "unity.png", description = "Lalala....." },
            new Tuto { title = "JavaScript", price = 49, image = "js.png", description = "Blobloblo....." },
            new Tuto { title = "Java", price = 40, image = "java.png", description = "Lololo....." },
            new Tuto { title = "DevOps", price = 23, image = "devo.png", description = "Buuuuzzzzz....." },
            new Tuto { title = "web development", price = 50, image = "web.png", description = "Okkkkkkkkkk....." }
        };

        private readonly ILogger<TutoController> _logger;

        public TutoController(ILogger<TutoController> logger)
        {
            _logger = logger;
        }
       
        // Possible api calls

        [HttpGet]
        public IEnumerable<Tuto> Get()
        {
            return tutos;
        }

        [HttpGet]
        [Route("index")]
        public Tuto GetByIndex(int i = 0)
        {
            return tutos[i];
        }
    }
}
