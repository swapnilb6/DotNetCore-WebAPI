using AutoMapper;
using BookStore.API.DataContext;
using BookStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Helpers
{
    public class AppMapper :Profile
    {
        public AppMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
