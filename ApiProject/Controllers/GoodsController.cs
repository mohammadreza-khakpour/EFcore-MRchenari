using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.Models;
using ApiProject.Models.DTOs;
using ApiProject.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [ApiController,Route("api/goods")]
    public class GoodsController : Controller
    {
        private readonly ApiDbContext _context;
        public GoodsController()
        {
            _context = new ApiDbContext();
        }

        [HttpPost]
        public void Add([FromBody]AddGoodDto dto)
        {
            if (_context.Goods.Any(_ => _.Code == dto.Code))
            {
                throw new GoodCodeCantBeDuplicateException();
            }

            var good = new Good
            {
                Title = dto.Title,
                Code = dto.Code,
                Count = 0,
                CategoryId = dto.CategoryId
            };

            _context.Goods.Add(good);

            _context.SaveChanges();
        }
    }
}