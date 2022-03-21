using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dto.Branch;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class BranchService : IBranchService
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public BranchService(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<int> AddBranch(AddBranchDto addBranchDto)
        {
            var addingBranch = new Branch
            {
                BranchName = addBranchDto.BranchName,
                PhoneNumber = addBranchDto.PhoneNumber,
                CompanyId = addBranchDto.CompanyId
            };
            await _rentACarDbContext.Branches.AddAsync(addingBranch);
            return await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteBranch(int BranchId)
        {
            var currentBranch = await _rentACarDbContext.Branches.
                Where(p => !p.IsDeleted && p.Id == BranchId).FirstOrDefaultAsync();
            if (currentBranch == null)
            {
                return -1;
            }
            currentBranch.IsDeleted = true;
            _rentACarDbContext.Branches.Update(currentBranch);
            return await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListBranchDto>> GetAllBranches()
        {
            return await _rentACarDbContext.Branches.Where(p => !p.IsDeleted).Include(p => p.CompanyFK).Select(p => new GetListBranchDto
            {
                Id = p.Id,
                BranchName = p.BranchName,
                CompanyId = p.CompanyId,
                CompanyName = p.CompanyFK.CompanyName,
                BranchPhoneNumber = p.PhoneNumber

            }).ToListAsync();
        }

        public async Task<GetBranchDto> GetBranchById(int BranchId)
        {
            return await _rentACarDbContext.Branches.Where(p => !p.IsDeleted && p.Id == BranchId)
                .Include(p => p.CompanyFK).Select(p => new GetBranchDto
                {
                    Id = p.Id,
                    BranchName = p.BranchName,
                    CompanyId = p.CompanyId,
                    CompanyName = p.CompanyFK.CompanyName,
                    BranchPhoneNumber = p.PhoneNumber


                }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            var currentBranch = await _rentACarDbContext.Branches.Where(p => !p.IsDeleted && p.Id == updateBranchDto.Id).FirstOrDefaultAsync();
            if (currentBranch == null)
            {
                return -1;
            }
            currentBranch.PhoneNumber = updateBranchDto.PhoneNumber;
            currentBranch.BranchName = updateBranchDto.PhoneNumber;
            currentBranch.CompanyId = updateBranchDto.CompanyId;
            _rentACarDbContext.Branches.Update(currentBranch);
            return await _rentACarDbContext.SaveChangesAsync();

        }
    }
}