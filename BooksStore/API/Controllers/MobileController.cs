using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Interface;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Mobile")]

    public class MobileController : ControllerBase
    {
        private readonly IGenericDetail<BrandDetail> branddetail;
        private readonly IGenericDetail<MobileDetail> mobiledetail;
        public MobileController(IGenericDetail<BrandDetail> branddetail, IGenericDetail<MobileDetail> mobiledetail)
        {
            this.mobiledetail = mobiledetail;
            this.branddetail = branddetail;
        }
        [HttpGet]
        [Route("MobileDetail")]
        public List<MobileDetail> GetMobileDetail()
        {
            return mobiledetail.GetDetail();
        }
        [HttpGet]
        [Route("MobileDetailBYID")]
        public Task<MobileDetail> GetMobilebyID(int id)
        {
            return mobiledetail.GetById(id);
        }
    }
}