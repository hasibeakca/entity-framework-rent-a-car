using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Entities
{
    public class BranchCustomer : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public Branch BranchFK { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
