using LearningHub.Core.Data;
using LearningHub.Core.repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class ServicesService: IServicesService
    {
        private readonly IServicesRepository _servicesRepository;
        public ServicesService(IServicesRepository servicesRepository)
        {
            this._servicesRepository = servicesRepository;
        }

        public bool CreateServices(Service service)
        {
           return _servicesRepository.CreateServices(service);
        }

        public bool DeleteServices(int id)
        {
            return _servicesRepository.DeleteServices(id);
        }

        public List<Service> GetAllServices()
        {
            return _servicesRepository.GetAllServices();
        }

        public Service GETServicesBYID(int id)
        {
            return _servicesRepository.GETServicesBYID(id);
        }

        public bool UpdateServices(Service service)
        {
            return _servicesRepository.UpdateServices(service);
        }
    }
}
