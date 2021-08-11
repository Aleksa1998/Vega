using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheetWebApp.Dtos;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IClientService _clientService;

        public ClientController(IUnitOfWork unitOfWork, IClientService clientService)
        {
            _unitOfWork = unitOfWork;
            _clientService = clientService;
        }

        [HttpGet]    
        public IActionResult GetAll()
        {
            return Ok(_clientService.GetAllClients());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            Client client = _unitOfWork.Clients.GetOneById(id);
            return (client == null) ? NotFound() : Ok(client);
        }

        [HttpPost]
        public IActionResult Save(Client client)
        {
            return Ok(_unitOfWork.Clients.Save(client));
        }


        [HttpPost("update")]
        public IActionResult Update(Client client)
        {
            return Ok(_unitOfWork.Clients.Update(client));
        }

        [HttpPost("delete")]
        public IActionResult Delete(Client client)
        {
            return Ok(_unitOfWork.Clients.Delete(client));
        }

    }
}
