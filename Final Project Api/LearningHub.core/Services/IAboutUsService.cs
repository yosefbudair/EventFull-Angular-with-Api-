using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IAboutUsService
    {
        public List<Aboutu> GetAllAboutUs();
        public bool CreateAboutUs(Aboutu aboutu);
        public bool UpdateAboutUs(Aboutu aboutu);
        public bool DeleteAboutUs(int id);
        public Aboutu GETAboutUsBYID(int id);

    }
}
