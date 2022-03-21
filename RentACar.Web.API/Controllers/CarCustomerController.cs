using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Business.Validation.CarCustomer;
using RentACar.DAL.Dto.CarCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCustomerController : ControllerBase
    {
        private readonly ICarCustomerService _carCustomerService;
        public CarCustomerController(ICarCustomerService carCustomerService)
        {
            _carCustomerService = carCustomerService;
        }
        [HttpGet]
        [Route("GetCarCustomerList")]

        public async Task<ActionResult<List<GetListCarCustomerDto>>> GetCarCustomerList()
        {
            try
            {
                return Ok(await _carCustomerService.GetAllCarCustomers());
            }

            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetCarCustomerById/{id:int}")]
        public async Task<ActionResult<GetCarCustomerDto>> GetCarCustomer(int id)
        {
            var list = new List<string>();

            if (id <= 0)
            {
                list.Add("CarCustomer id geçersiz");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var currentCarCustomer = await _carCustomerService.GetCarCustomerById(id);
                if (currentCarCustomer == null)
                {
                    list.Add("CarCustomer bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentCarCustomer;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddCarCustomer")]
        public async Task<ActionResult<string>> AddCarCustomer(AddCarCustomerDto addCarCustomerDto)
        {
            var list = new List<string>();
            var validator = new AddCarCustomerValidator();
            var validationResults = validator.Validate(addCarCustomerDto);
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
                var result = await _carCustomerService.AddCarCustomer(addCarCustomerDto);
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
        [Route("UpdateCarCustomer")]
        public async Task<ActionResult<string>> UpdateCarCustomer(UpdateCarCustomerDto updateCarCustomerDto)
        {
            var list = new List<string>();
            var validator = new UpdateCarCustomerValidator();
            var validationResults = validator.Validate(updateCarCustomerDto);
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
                var result = await _carCustomerService.UpdateCarCustomer(updateCarCustomerDto);
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
        [Route("DeleteCarCustomer/{id:int}")]
        public async Task<ActionResult<string>> DeleteCarCustomer(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _carCustomerService.DeleteCarCustomer(id);
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
