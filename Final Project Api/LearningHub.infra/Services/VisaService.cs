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
    public class VisaService : IVisaService
    {
        private readonly IVisaRepository VisaRepository;
        public VisaService(IVisaRepository VisaRepository)
        {
            this.VisaRepository = VisaRepository;
        }

        public List<Visa> GetAllVisa()
        {
            return VisaRepository.GetAllVisa();
        }

        public Visa GetByVisaId(int id)
        {
            return VisaRepository.GetByVisaId(id);


        }

        public bool updateVisa(Visa visa)
        {
            return VisaRepository.updateVisa(visa);
        }

    }
}
