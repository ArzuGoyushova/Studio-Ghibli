using GhibliServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Category
{
    public class CategoryViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public string Desc { get; set; }
        public List<string> SubCategoryNames { get; set; } = new List<string>();
        public List<string> ProductNames { get; set; } = new List<string>();
        public List<string> BlogTitles { get; set; } = new List<string>();
        public List<string> MovieTitles { get; set; } = new List<string>();

    }
}
