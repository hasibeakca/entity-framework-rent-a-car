using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Entities
{
    public class Company : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public bool IsDeleted { get ; set; }

    }
}
