using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Business.Validation.BranchCustomer;
using RentACar.DAL.Dto.BranchCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchCustomerController : ControllerBase
    {
        private readonly IBranchCustomerService _branchCustomerService;
        public BranchCustomerController(IBranchCustomerService branchCustomerService)
        {
            _branchCustomerService = branchCustomerService;
        }
        [HttpGet]
        [Route("GetBranchCustomerList")]

        public async Task<ActionResult<List<GetListBranchCustomerDto>>> GetBranchCustomerList()
        {
            try
            {
                return Ok(await _branchCustomerService.GetAllBranchCustomers());
            }

            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetBranchCustomerById/{id:int}")]
        public async Task<ActionResult<GetBranchCustomerDto>> GetBranchCustomer(int id)
        {
            var list = new List<string>();

            if (id <= 0)
            {
                list.Add("BranchCustomer id geçersiz");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var currentBranchCustomer = await _branchCustomerService.GetBranchCustomerById(id);
                if (currentBranchCustomer == null)
                {
                    list.Add("BranchCustomer bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentBranchCustomer;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddBranchCustomer")]
        public async Task<ActionResult<string>> AddBranchCustomer(AddBranchCustomerDto addBranchCustomerDto)
        {
            var list = new List<string>();
            var validator = new AddBranchCustomerValidator();
            var validationResults = validator.Validate(addBranchCustomerDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }

            try
            {
                var result = await _branchCustomerService.AddBranchCustomer(addBranchCustomerDto);
                if (result > 0)
                {
                    list.Add("EKLEME ISLEMI BASARILI.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
                {
                    list.Add("EKLEME ISLEMI BASARISIZ.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPut]
        [Route("UpdateBranchCustomer")]
        public async Task<ActionResult<string>> UpdateBranchCustomer(UpdateBranchCustomerDto updateBranchCustomerDto)
        {
            var list = new List<string>();
            var validator = new UpdateBranchCustomerValidator();
            var validationResults = validator.Validate(updateBranchCustomerDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = await _branchCustomerService.UpdateBranchCustomer(updateBranchCustomerDto);
                if (result < 0)
                {
                    list.Add("GUNCELLEME BASARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                if (result == -1)
                {
                    list.Add("GUNCELLENECEK ID BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, Type = "error" });
                }
                else
                {
                    list.Add("GUNCELLEME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }

        [HttpDelete]
        [Route("DeleteBranchCustomer/{id:int}")]
        public async Task<ActionResult<string>> DeleteBranchCustomer(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _branchCustomerService.DeleteBranchCustomer(id);
                if (result <= 0)
                {
                    list.Add("SİLME İŞLEMİ BAŞARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else if (result == -1)
                {
                    list.Add("SİLİNECEK BIR ID BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("SİLME İŞLEMİ BAŞARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }

            }
            catch (Exception hata)
            {

                return Ok(hata.Message);
            }
        }
    }
}
