using System;
using System.Collections.Generic;
using TimeSheetWebApp.Dtos;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Services
{
    public class ClientService : IClientService
    {
        private IUnitOfWork _unitOfWork;
        private ICountryService _countryService;

        public ClientService(IUnitOfWork unitOfWork, ICountryService countryService)
        {
            _unitOfWork = unitOfWork;
            _countryService = countryService;
        }
        public Client Delete(Client obj)
        {
            return _unitOfWork.Clients.Delete(obj);
        }

        public List<ClientDTO> GetAllClients()
        {
            List<ClientDTO> clients = new List<ClientDTO>();
            foreach(Client client in _unitOfWork.Clients.GetAll())
            {
                ClientDTO newClient = new ClientDTO(client);
                newClient.Country = new CountryDTO(_unitOfWork.Country.GetOneById(client.CountryId));
                clients.Add(newClient);
            } 
            return clients;
        }

        public Client GetOneById(int id)
        {
            return _unitOfWork.Clients.GetOneById(id);
        }

        public Client SaveClient(SaveClientDTO client)
        {
            Client newClient = new Client(){ Name = client.Name, Address = client.Address, City = client.City, PostalCode = client.PostalCode };
            newClient.CountryId = _countryService.GetOneByName(client.Country);
            return _unitOfWork.Clients.Save(newClient);
        }

        public Client Save(Client obj)
        {
            return _unitOfWork.Clients.Save(obj);
        }
        public Client UpdateClient(ClientDTO client)
        {
            Client updateClient = _unitOfWork.Clients.GetOneById(client.Id);
            if (updateClient == null) return null;
            updateClient.Id = client.Id; updateClient.Name = client.Name; updateClient.Address = client.Address; updateClient.City = client.City; updateClient.PostalCode = client.PostalCode;
            updateClient.CountryId = _countryService.GetOneByName(client.Country.Name);
            return _unitOfWork.Clients.Update(updateClient);
        }

        public Client Update(Client obj)
        {
            return _unitOfWork.Clients.Update(obj);
        }

        IEnumerable<Client> IService<Client>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
