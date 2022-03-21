using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore
{
  public abstract class Audit
    {
        public DateTime CDate { get; set; } = DateTime.Now; // OLUŞTURULMA TARİHİ Şuanki tarihi atasın diye DateTime.Now yazdık.
        public DateTime? MDate { get; set; } //GÜNCELLENME TARİHİ
        public int CUserId { get; set; }  // OLUŞTURAN KİŞİ ID
        public int? MUserId { get; set; } //GÜNCELLEYEN KİŞİ ID

    }
}
