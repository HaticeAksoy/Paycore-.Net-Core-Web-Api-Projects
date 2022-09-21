using Microsoft.AspNetCore.Mvc;
using Paycore_Week3.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paycore_Week3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IMapperSession<Vehicle> sessionvehicle;
        private readonly IMapperSession<Container> sessionContainer;
        public VehicleController(IMapperSession<Vehicle> session)
        {
            this.sessionvehicle = session;
        }


        [HttpGet]
        public List<Vehicle> GetAll()
        {
            List<Vehicle> result = sessionvehicle.query.ToList();
            return result;
        }


        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            try
            {
                sessionvehicle.BeginTransaction();
                sessionvehicle.Save(vehicle);
                sessionvehicle.Commit();
            }
            catch (Exception ex) 
            {
                sessionvehicle.Rollback();
            }
            finally
            {
                sessionvehicle.CloseTransaction();
            }
        }



        [HttpPut]
        public ActionResult<Vehicle> Put([FromBody] Vehicle request)
        {
            Vehicle _vehicle = sessionvehicle.query.Where(x => x.Id == request.Id).FirstOrDefault();
            if (_vehicle == null)
            {
                return NotFound();
            }

            try
            {
                sessionvehicle.BeginTransaction();

                _vehicle.VehicleName = request.VehicleName;
                _vehicle.VehiclePlate = request.VehiclePlate;

                sessionvehicle.Update(_vehicle);

                sessionvehicle.Commit();
            }
            catch (Exception ex)
            {
                sessionvehicle.Rollback();
            }
            finally
            {
                sessionvehicle.CloseTransaction();
            }


            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<Vehicle> Delete(int id)
        {
            Vehicle _vehicle = sessionvehicle.query.Where(x => x.Id == id).FirstOrDefault();
            if (_vehicle == null)
            {
                return NotFound();
            }

            try
            {

                long vehicleid = _vehicle.Id;
                Container _container = sessionContainer.query.Where(x => x.VehicleId == vehicleid).FirstOrDefault();

                try
                {
                    if (_container != null)
                    {
                        sessionContainer.BeginTransaction();
                        sessionContainer.Delete(_container);
                        sessionContainer.Commit();
                    }
                }
                catch (Exception ex)
                {
                    sessionvehicle.Rollback();
                }
                

                sessionvehicle.BeginTransaction();
                sessionvehicle.Delete(_vehicle);
                sessionvehicle.Commit();
            }
            catch (Exception ex)
            {
                sessionvehicle.Rollback();               
            }
            finally
            {
                sessionvehicle.CloseTransaction();
            }

            return Ok();
        }






    }
}
