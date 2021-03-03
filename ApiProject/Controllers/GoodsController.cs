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

        [HttpPut("{id}")]
        public void Update(int id, [FromBody]UpdateGoodDto dto)
        {
            Good theGood = _context.Goods.Find(id);
            theGood.Title = dto.Title;
            theGood.Code = dto.Code;

            _context.Update(theGood);
            _context.SaveChanges();
        }

        [HttpGet]
        public IList<GetGoodDto> GetAll()
        {
            return _context.Goods.Select(x => new GetGoodDto()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Count = x.Count,
                Title = x.Title
            }).ToList();
        }

        #region [join example]
        // join example in c#
        // here i want to create unanymous objects
        // containing matched goodEntries & goods with same code
        [HttpGet]
        public void GetAll02()
        {
            //var allGoodEntries = GetAll();
            //GoodsController c = new GoodsController();
            //var allGoods = c.GetAll();

            var innerJoinQuery =
            from goodentry in _context.GoodEntries
            join good in _context.Goods on goodentry.GoodCode equals good.Code
            select new { aa = goodentry.Id, bb = good.Id };

            foreach (var result in innerJoinQuery)
            {
                Console.WriteLine($"\"{result.aa}\"  {result.bb}");
            }

        } 
        #endregion

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Goods.Remove(_context.Goods.Find(id));
            _context.SaveChanges();
        }

    }
}