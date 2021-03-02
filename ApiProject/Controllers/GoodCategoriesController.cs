using ApiProject.Models;
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
    }
}
