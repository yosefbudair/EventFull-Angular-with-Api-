using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IVisaService
    {
        List<Visa> GetAllVisa();
        Visa GetByVisaId(int id);
        bool updateVisa(Visa visa);
    }
}
