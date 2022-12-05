using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI2.Controllers
{
    //[Route("api
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       
        //[Route("books")]
        public string Get()
        {
            return "this is book";
        }

        [Route("{id}")]
        public string GetbyID(int id)
        {
            return "this is book " + id;
        }

        [Route("books/{id}/Author/{auid}")]
        public string GetbyID(int id,int auid)
        {
            return "this is book " + id + " and Author "+auid;
        }

        
        public string GetAll()
        {
            return "this is from GetAll";
        }
    }
}
