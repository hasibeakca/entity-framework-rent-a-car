using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Business.Validation.Branch;
using RentACar.DAL.Dto.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [HttpGet]
        [Route("GetBranchList")]

        public async Task<ActionResult<List<GetListBranchDto>>> GetBranchList()
        {
            try
            {
                return Ok(await _branchService.GetAllBranches());
            }

            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetBranchById/{id:int}")]
        public async Task<ActionResult<GetBranchDto>> GetBranch(int id)
        {
            var list = new List<string>();

            if (id <= 0)
            {
                list.Add("Branch id geçersiz");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var currentBranch = await _branchService.GetBranchById(id);
                if (currentBranch == null)
                {
                    list.Add("Branch bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return currentBranch;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddBranch")]
        public async Task<ActionResult<string>> AddBranch(AddBranchDto addBranchDto)
        {
            var list = new List<string>(); // Geri dönüş mesajımızın string tipinde olacağını belirttik
            var validator = new AddBranchValidator(); //Bir değişken oluşturuyoruz. Bu değişkenle add kurallarını
                                                      //verdiğimiz AddBranchValidator classına ulaşıyoruz
            var validationResults = validator.Validate(addBranchDto); //ValidatorSonucu diye bir değişken oluşturuyoruz
                                                                      //ulaştığımız verilerin doğruluğunu Validate methodu sayesinde kontrol ediyoruz
           
            if (!validationResults.IsValid) // Sonucumuz yanlışsa
            {
                foreach (var error in validationResults.Errors) // foreach döngüsü oluşturuyoruz eğer sonuçlarda
                                                                // bir hata varsa bunu Errors adı altında topla
                {
                    list.Add(error.ErrorMessage); // ve bana bu hatayla birlikte bir mesaj döndür
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" }); // kodu 1002 olan
                // anonim bir kod oluşturduk (istediğiniz değeri verebilirsiniz) mesajın dönüş şeklini ve tipini belirttik
            }

            try // DENE
            {
                var result = await _branchService.AddBranch(addBranchDto); // Oluşturduğum sonuç adlı değişkeni veritabanında ekleme metotuyla
                if (result > 0) // sonuç sıfırdan büyükse
                {
                    list.Add("EKLEME ISLEMI BASARILI."); // ekrana bunu yazdır
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" }); // Kodun hatasını tipini ve mesajın dönüşünü yazdık
                }
                else // değilse
                {
                    list.Add("EKLEME ISLEMI BASARISIZ."); // ekrana bunu yazdır dedik
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" }); // başarısız kodunu döndür. mesajın dönüş şeklini ve tipini belirt.
                }
            }
            catch (Exception hata) // YAKALA
            {

                return BadRequest(hata.Message); // hata yakaladıysan mesaj döndür.
            }
        }
        [HttpPut]
        [Route("UpdateBranch")]
        public async Task<ActionResult<string>> UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            var list = new List<string>();
            var validator = new UpdateBranchValidator();
            var validationResults = validator.Validate(updateBranchDto);
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
                var result = await _branchService.UpdateBranch(updateBranchDto);
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
        [Route("DeleteBranch/{id:int}")]
        public async Task<ActionResult<string>> DeleteBranch(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _branchService.DeleteBranch(id);
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
