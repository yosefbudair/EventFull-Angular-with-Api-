using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IServicesService
    {
        public List<Service> GetAllServices();
        public bool CreateServices(Service service);

        public bool UpdateServices(Service service);

        public Service GETServicesBYID(int id);
        public bool DeleteServices(int id);
    }
}
