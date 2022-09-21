using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaycoreOdev1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaycoreOdev1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {

        public InterestController()  // constructor (yapıcı metot)  
        {

        }

        [HttpGet]
        public ActionResult CalculateInterest(double total, double interestRate, int time)
        {
            if (total < 0 || interestRate < 0 || time <0) // eğer gelen değerlerden herhangi biri negatif bir değer gelecek olursa bad request dönderecek.
            {
                return BadRequest();
            }


            InterestResponseModel response = new InterestResponseModel(); // response edilecek modelden bir nesne oluşturuldu.

            response.TotalBalance  = Math.Round(total * Math.Pow((1 + (interestRate/100)),time),3);  //  bileşik faiz hesaplaması yapılarak virgülden sonra 3 hane olacak şekilde yuvarlama işlemi                                                                                        yapıldı.

            response.InterestAmount = response.TotalBalance - total;  // faiz getirisi hesaplanarak  requestte döndürülecek olan değişkene atandı.

            return Ok(response);


        }



    }
}
