using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class BookModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
