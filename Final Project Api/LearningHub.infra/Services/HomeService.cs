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
    public class HomeService:IHomeService
    {
        private readonly IHomeRepository _homeRepository;
        public HomeService(IHomeRepository homeRepository)
        {
            this._homeRepository = homeRepository;
        }

        public bool CreateHome(Home home)
        {
            return _homeRepository.CreateHome(home);
        }

        public bool DeleteHome(int id)
        {
            return _homeRepository.DeleteHome(id);
        }
        public bool UpdateHome(Home home)
        {
            return _homeRepository.UpdateHome(home);
        }

        public List<Home> GetAllHome()
        {
            return _homeRepository.GetAllHome();
        }

        public Home GETHomeBYID(int id)
        {
            return _homeRepository.GETHomeBYID(id);
        }

    }
}
