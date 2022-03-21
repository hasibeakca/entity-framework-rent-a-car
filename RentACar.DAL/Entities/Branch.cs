using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Entities
{
    public class Branch : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<BranchCustomer> BranchCustomers { get; set; }
        public int CompanyId { get; set; }
        public Company CompanyFK { get; set; } // Daha sonra kullanılacak foreıgnkey için yazdık 
        public bool IsDeleted { get; set; }
    }
}
