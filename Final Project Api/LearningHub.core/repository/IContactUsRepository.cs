using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.repository
{
    public interface IContactUsRepository
    {

        public List<Contactu> GetAllContact();
        public bool CreateContact(Contactu Contactu);
        public bool UpdateContact(Contactu Contactu);
        public bool DeleteContact(int id);
        public Contactu GETContactBYID(int id);
    }
}
