using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaminagrobisBTS.DAL.Depot
{
    public interface IDepot<Type_DAL>
    {
        public string ChaineDeConnexion { get; set; }
        public IEnumerable<Type_DAL> GetAll();
        public Type_DAL Insert(Type_DAL item);
        public Type_DAL Update(Type_DAL item);
        public void Delete(Type_DAL item);
    }
}
