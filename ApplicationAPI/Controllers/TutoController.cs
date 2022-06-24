using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutoController : ControllerBase
    {
        Tuto[] tutosArr1 = new Tuto[]
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
            // Connection to database
            string connectionString = @"server=localhost;userid=root;password=root;database=tutos";
            MySqlConnection connectionObject = new MySqlConnection(connectionString); 
            try
            {               
                connectionObject.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string requestString = "SELECT title, price, image, description FROM listeTutos";
            using var cmd = new MySqlCommand(requestString, connectionObject);
            using MySqlDataReader reader = cmd.ExecuteReader(); // Get the result of the request

            //Get the data in a loop
            int numberOfTutoToShow = 5;
            Tuto[] tutoArr2 = new Tuto[numberOfTutoToShow];
            int count = 0;

            while (reader.Read())
            {
                Tuto tutoObject = new Tuto { title = reader[0].ToString(), price = (int)reader[1], image = reader[2].ToString(), description = reader[3].ToString() };
                if(count < 5)
                {
                    tutoArr2[count] = tutoObject;
                    count++;
                }              
            }
            tutosArr1 = tutosArr1.Concat(tutoArr2).ToArray();

            return tutosArr1;
            //return tutosArr1;
        }

        [HttpGet]
        [Route("index")]
        public Tuto GetByIndex(int i = 0)
        {
            return tutosArr1[i];
        }
    }
}
