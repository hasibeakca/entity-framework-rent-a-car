using RentACar.DAL.Dto.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
   public interface IBranchService
    {
        Task<List<GetListBranchDto>> GetAllBranches();

        Task<GetBranchDto> GetBranchById(int BranchId);

        Task<int> AddBranch(AddBranchDto addBranchDto);
        Task<int> UpdateBranch(UpdateBranchDto updateBranchDto);

        Task<int> DeleteBranch(int BranchId);
    }
}
