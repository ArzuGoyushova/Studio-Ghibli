using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using GhibliServer.Domain.Common;

namespace GhibliServer.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; } = new List<Category>();
        public bool IsDeleted { get; set; }
        public List<Product>? Products { get; set; }
        public List<Blog>? Blogs { get; set; }
        public List<Movie>? Movies { get; set; }
        public string Desc { get; set; }
    }
}
