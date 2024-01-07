using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.repository
{
    public interface IHomeRepository
    {
        public  List<Home> GetAllHome();
        public bool DeleteHome(int id);
        public bool CreateHome(Home home);
        public bool UpdateHome(Home home);
        public Home GETHomeBYID(int id);
    }
}
