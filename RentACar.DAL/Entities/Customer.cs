using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Entities
{
    public class Customer : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public ICollection<CarCustomer> CarCustomers { get; set; }
        public ICollection<BranchCustomer> BranchCustomers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
