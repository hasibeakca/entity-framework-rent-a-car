using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Entities
{
    public class CarCustomer : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car CarFK { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerFK { get; set; }
        public bool ForRent { get; set; }
        public bool IsDeleted { get; set; }
    }
}
