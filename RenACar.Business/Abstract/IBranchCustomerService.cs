using RentACar.DAL.Dto.BranchCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IBranchCustomerService
    {
        Task<List<GetListBranchCustomerDto>> GetAllBranchCustomers();
        // Görev belirttik , buradan(DTO) bilgileri alacağımızı söyledik , Tüm branchcustomersleri getirme metotunu yazdık.
        // Birden çok veri getireceği için liste şeklinde tanımlama yapıyoruz.
        Task<GetBranchCustomerDto> GetBranchCustomerById(int BranchCustomerId);
        //Görev belirttik , DTO dan bilgileri alacağımızı söyledik, getireceğimiz şeyi idye göre getireceğimizi,
        // bu id nin de int tipinde olduğunu söyledik.
        Task<int> AddBranchCustomer(AddBranchCustomerDto addBranchCustomerDto);
        //Görev belirttik , int tipinde bir değer döndüreceğini söyledik. Dto dan bilgileri aldık
        Task<int> UpdateBranchCustomer(UpdateBranchCustomerDto updateBranchCustomerDto);
        //Görev belirttik , int tipinde bir değer döndüreceğini söyledik. Dto dan bilgileri aldık
        Task<int> DeleteBranchCustomer(int BranchCustomerId);
        //Görev belirttik , int tipinde bir değer döndüreceğini söyledik. Idye göre işlem olacak ve id int tipinde bir değişkenimiz.
    }
}
