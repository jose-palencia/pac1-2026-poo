using Microsoft.AspNetCore.Mvc;
using PersonsApp.Entities;

namespace PersonsApp.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly List<PersonEntity> _persons;

        public PersonController()
        {
            //_persons = new List<PersonEntity>();
            // _persons.Add(new PersonEntity
            // {
            //     DNI = "0401200012345",
            //     FirstName = "Juan Carlos",
            //     LastName = "Perez Hernandez",
            //     Gender = "M",
            //     BirthDate = DateTime.Parse("01/06/2000")
            // });
            
            _persons = new List<PersonEntity>
            {
                new PersonEntity
                {
                    DNI = "0401200012345",
                    FirstName = "Juan Carlos",
                    LastName = "Perez Hernandez",
                    Gender = "M",
                    BirthDate = DateTime.Parse("01/06/2000")
                },
                new PersonEntity
                {
                    DNI = "0401200012346",
                    FirstName = "Maria Michelle",
                    LastName = "Lopez Pineda",
                    Gender = "F",
                    BirthDate = DateTime.Parse("15/03/2000")
                },
                new PersonEntity
                {
                    DNI = "0401200012347",
                    FirstName = "Carlos Ismael",
                    LastName = "Rodriguez Mejia",
                    Gender = "M",
                    BirthDate = DateTime.Parse("07/08/1998")
                }
            };
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_persons);
        }

        [HttpGet("{dni}")]
        public IActionResult GetOne(string dni)
        {
            var person = _persons.FirstOrDefault(p => p.DNI == dni);
            return person != null ? Ok(person) : NotFound(new {Message = "Persona no encontrada."});
        }

        [HttpPost]
        public IActionResult Create(PersonEntity person)
        {
            // Console.WriteLine(person.DNI);
            // if(string.IsNullOrWhiteSpace(person.DNI))
            // {
            //     return BadRequest(new {Message = "El DNI es requerido."});
            // }

            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                return BadRequest(new {Message = "Los nombres son requeridos."});
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                return BadRequest(new {Message = "Los apellidos son requeridos."});
            }

            var personExist = _persons.Any(p => p.DNI == person.DNI);

            if(!personExist)
            {
                _persons.Add(person);
                return Created();
            }

            return BadRequest(new {Message = "El DNI ya esta registrado."});

        }
    }
}