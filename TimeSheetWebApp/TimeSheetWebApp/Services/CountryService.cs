using System.Collections.Generic;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Services
{
    public class CountryService : ICountryService
    {
        private IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Country Delete(Country obj)
        {
            return _unitOfWork.Country.Delete(obj);
        }

        public IEnumerable<Country> GetAll()
        {
            return _unitOfWork.Country.GetAll();
        }

        public Country GetOneById(int id)
        {
            return _unitOfWork.Country.GetOneById(id);
        }

        public Country Save(Country obj)
        {
           return _unitOfWork.Country.Save(obj);
        }

        public Country Update(Country obj)
        {
            return _unitOfWork.Country.Update(obj);
        }

        public int GetOneByName(string name)
        {
            foreach (Country country in _unitOfWork.Country.GetAll()){
                if (country.Name.Equals(name)) { return country.Id; }
            }
            return 0;
        }

    }
}
