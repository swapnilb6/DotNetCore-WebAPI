using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI2
{
    public class CountryModel
    {

        //[BindProperty]
        public String Name { get; set; }

        //[BindProperty]
        public int Population { get; set; }

    }
}
