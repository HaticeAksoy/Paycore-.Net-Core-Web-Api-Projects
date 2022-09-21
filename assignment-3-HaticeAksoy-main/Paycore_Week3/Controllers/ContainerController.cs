using Microsoft.AspNetCore.Mvc;
using Paycore_Week3.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paycore_Week3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {

        private readonly IMapperSession<Vehicle> sessinonvehicle;
        private readonly IMapperSession<Container> sessionContainer;

        public ContainerController(IMapperSession<Container> session)
        {
            this.sessionContainer = session;
        }


        [HttpGet]
        public List<Container> GetAll()
        {
            List<Container> result = sessionContainer.query.ToList();
            return result;
        }



        [HttpGet("GetVehicleContainer/id")]
        public List<Container> GetVehicleContainer(long id)
        {
            List<Container> result = sessionContainer.query.Where(x=>x.VehicleId == id).ToList();
            return result;
        }



        [HttpPost]
        public void Post([FromBody] Container container)
        {
            try
            {
                sessionContainer.BeginTransaction();
                sessionContainer.Save(container);
                sessionContainer.Commit();
            }
            catch (Exception ex) 
            {
                sessionContainer.Rollback();
            }
            finally
            {
                sessionContainer.CloseTransaction();
            }
        }



        [HttpPut]
        public ActionResult<Container> Put([FromBody] Container request)
        {
            Container _container = sessionContainer.query.Where(x => x.Id == request.Id).FirstOrDefault();
            if (_container == null)
            {
                return NotFound();
            }

            try
            {
                sessionContainer.BeginTransaction();

                _container.Latitude = request.Latitude;
                _container.Longitude = request.Longitude;
                _container.VehicleId = _container.VehicleId;
                _container.ContainerName = request.ContainerName;

                sessionContainer.Update(_container);

                sessionContainer.Commit();
            }
            catch (Exception ex)
            {
                sessionContainer.Rollback();
            }
            finally
            {
                sessionContainer.CloseTransaction();
            }


            return Ok();
        }


        [HttpDelete("id")]
        public ActionResult<Container> Delete(int id)
        {
            Container _container = sessionContainer.query.Where(x => x.Id == id).FirstOrDefault();
            if (_container == null)
            {
                return NotFound();
            }

            try
            {
                sessionContainer.BeginTransaction();
                sessionContainer.Delete(_container);
                sessionContainer.Commit();
            }
            catch (Exception ex)
            {
                sessionContainer.Rollback();               
            }
            finally
            {
                sessionContainer.CloseTransaction();
            }

            return Ok();
        }






    }
}
