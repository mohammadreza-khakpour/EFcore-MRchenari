using ApiProject.Models;
using ApiProject.Models.DTOs;
using ApiProject.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/good-categories")]
    public class GoodCategoriesController : Controller
    {
        private readonly ApiDbContext _context;

        public GoodCategoriesController()
        {
            _context = new ApiDbContext();
        }

        [HttpPost]
        public void Add([Required][FromBody] string Title)
        {
            if (_context.GoodCategories.Any(_ => _.Title == Title))
            {
                throw new GoodCategoryTitleCantBeDuplicatedExcption();
            }
            var goodCategory = new GoodCategory
            {
                Title = Title
            };

            _context.GoodCategories.Add(goodCategory);

            _context.SaveChanges();
        }

        [HttpGet]
        public IList<GetGoodCategoryDto> GetAll()
        {
            return _context.GoodCategories.Select
                  (_ => new GetGoodCategoryDto
                  {
                      Id = _.Id,
                      Title = _.Title
                  }).ToList();
        }

        [HttpPut("{id}")]
        public void Update(int id, UpdateGoodCategoryDto dto)
        {
            var category = _context.GoodCategories.Find(id);

            category.Title = dto.Title;

            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _context.GoodCategories.Find(id);
            _context.GoodCategories.Remove(category);

            /* var goodCategory = new GoodCategory { Id = id };
             _context.Entry(goodCategory).State = EntityState.Deleted;*/

            _context.SaveChanges();
        }
    }
}
