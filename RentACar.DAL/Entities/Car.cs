using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Entities
{
    public class Car : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int BranchId { get; set; }
        public Branch BranchFK { get; set; }
        public ICollection<CarCustomer> CarCustomers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
