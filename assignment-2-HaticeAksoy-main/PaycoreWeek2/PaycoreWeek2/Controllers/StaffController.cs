using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaycoreWeek2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaycoreWeek2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        public static List<Staff> staff = new List<Staff>();


        public StaffController()
        {
            //staff = new List<Staff>();

            if (staff.Count <= 0)
            {
                staff = new List<Staff>();
                staff.Add(new Staff { Id = 1, Name = "Hatice", Lastname = "Aksoy", PhoneNumber = "05073586209", Email = "hatice.aksoy@gmail.com", DateofBirth = new DateTime(1999, 01, 01), Salary = 15000 });
                staff.Add(new Staff { Id = 2, Name = "Ayşegül", Lastname = "Aksoy", PhoneNumber = "0557646248", Email = "aysegul.aksoy@gmail.com", DateofBirth = new DateTime(1996, 04, 28), Salary = 14000 });
                staff.Add(new Staff { Id = 3, Name = "Uğur Mücahit", Lastname = "Kılıç", PhoneNumber = "05463452204", Email = "ugur.kilic@gmail.com", DateofBirth = new DateTime(1996, 04, 08), Salary = 10000 });
            }
        }

        [HttpGet]
        public List<Staff> Get()
        {
            return staff.ToList();
        }

        [HttpGet("GetStaffById")]
        public ActionResult GetStaffById([FromQuery] int id)
        {
            var response = staff.Where(x => x.Id == id).FirstOrDefault();
            if (response == null)
            {
                return BadRequest(error:"Verilen id Bilgisine Ait Veri bulunamamaktadır.");
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public ActionResult CreateStaff([FromBody] Staff request)
        {

            //Fluent validation ile girilen değerlerin bizim kurallarımıza uygun olmadığını kontrol ediyoruz.
            StaffValidator validator = new StaffValidator();
            var result = validator.Validate(request);

            //gelen sonuçta isvalid false gelirse kurallarımıza uymayan veri var demektir.Bu sonuca göre return işlemimizi yapıyoruz.
            if (result.IsValid)
            {
                staff.Add(request); //gelen verilerinn listeye eklenmesi işlemi yapılıyor.
                return Ok(staff.ToList());
            }
            else
            {
                return Ok(result.Errors);//validasyon işlemi sonrası gelen hatalar ger döndürülüyor.
            }

            
        }

        [HttpPut]
        public ActionResult UpdateStaff([FromBody] Staff request, int id)
        {
            var response = staff.Where(x => x.Id == id).FirstOrDefault();

            if (response != null)
            {

                //Fluent validation ile girilen değerlerin bizim kurallarımıza uygun olmadığını kontrol ediyoruz.
                StaffValidator validator = new StaffValidator();
                var result = validator.Validate(request);

                //gelen sonuçta isvalid false gelirse kurallarımıza uymayan veri var demektir.Bu sonuca göre return işlemimizi yapıyoruz.
                if (result.IsValid)
                {
                    staff.Remove(response);
                    response = request;
                    staff.Add(response);
                    return Ok(staff.ToList());
                }
                else
                {
                    return Ok(result.Errors);//validasyon işlemi sonrası gelen hatalar ger döndürülüyor.
                }

               
            }
            else
            {
                return BadRequest("Girilen değerlere ait veri bulunamadı.");
            }
            
        }

        [HttpDelete]
        public ActionResult DeleteStaff(int id)
        {
            var response = staff.Where(x => x.Id == id).FirstOrDefault();
            if (response != null)
            {
                staff.Remove(response);
                return Ok(staff.ToList());
            }
            else
            {
                return BadRequest(error: "Girilen değere ait veri bulunamamaktadır.");
            }
            
        }





    }
}
