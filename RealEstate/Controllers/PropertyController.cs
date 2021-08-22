using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealEstate.DataAccess;
using RealEstate.Helpers;
using RealEstate.Models.ViewModels;

namespace RealEstate.Controllers
{
    public class PropertyController : ApiController
    {
        [MyAuthorize]
        [HttpPost]
        public IHttpActionResult List([FromBody] Property_VM_List viewModel)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                int returnValue = PropertyService.Properties_Insert(viewModel.ConvertToModel(MyToken.GetUserID(token)));

                if (returnValue != 0)
                {
                    return BadRequest("Unknown error.");
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }

        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult Get1()
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                List<Property_VM_Get> properties = PropertyService.Properties_Select(userID: MyToken.GetUserID(token));
                if (properties == null || properties.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                return Ok(properties);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [HttpGet]
        public IHttpActionResult Get2()
        {
            try
            {
                List<Property_VM_Get> properties = PropertyService.Properties_Select();
                if (properties == null || properties.Count == 0)
                {
                    return BadRequest("The list is empty.");
                }

                return Ok(properties);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [MyAuthorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            int returnValue = PropertyService.Properties_Delete(id);

            if (returnValue != 0)
            {
                return BadRequest("Unknown error.");
            }

            return Ok();
        }
    }
}
