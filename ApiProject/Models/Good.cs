using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        public GoodCategory Category { get; set; }

    }
}
