using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Persistence;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Enums;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly APIDbContext _db;
        public ClientsController(APIDbContext db)
        {
            _db = db;
        }

        // GET api/clients/
        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = _db.Client;
            return Ok(clients);
        }

        // GET api/clients/email&password
        [HttpGet("{email}&{password}")]
        public IActionResult GetToId(string email, string password)
        {
            try
            {
                var client = _db
                .Client?
                .SingleOrDefault(o => o.Email == email && o.Password == password);

                if (client == null)
                {
                    return NotFound();
                }

                return Ok(client);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/clients/
        [HttpPost]
        public IActionResult PostCreateClient(CadastroClientInputModel model)
        {
            var clientResult = new Client
            (
                model.Name,
                model.Email,
                model.Password
            );

            try
            {
                _db.Client?.Add(clientResult);
                _db.SaveChanges();
                var id = clientResult.IdClient;
            }
            catch
            {

            }

            return Ok();
        }

        // DELETE api/clients/id
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(string id)
        {
            var ClientToDelete = _db
                .Client?
                .SingleOrDefault(o => o.IdClient == id);

            if (ClientToDelete == null) 
            {
                return NotFound();
            }

            _db.Client?.Remove(ClientToDelete);
            _db.SaveChanges();

            return NoContent();
        } 

        // PUT api/clients/
        [HttpPut("{id}")]
        public IActionResult UpdateClient(string id, CadastroClientInputModel model)
        {
            var clientToUpdate = _db
                .Client?
                .SingleOrDefault(o => o.IdClient == id);

            if (clientToUpdate == null)
            {
                return NotFound();
            }

            clientToUpdate.changeInfo(model.Name, EClient.Name);
            clientToUpdate.changeInfo(model.Email, EClient.Email);
            clientToUpdate.changeInfo(model.Password, EClient.Password);

            _db.SaveChanges();

            return Ok();
        }
    }
}