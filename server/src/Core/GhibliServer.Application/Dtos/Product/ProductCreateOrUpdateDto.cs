
using Microsoft.AspNetCore.Http;

namespace GhibliServer.Application.Dtos.Product
{
    public class ProductCreateOrUpdateDto
    {
        public string Name { get; set; }
        public double? OldPrice { get; set; }
        public double RegularPrice { get; set; }
        public int Count { get; set; }
        public int? Discount { get; set; }
        public Guid CategoryId { get; set; }
        public List<IFormFile>? ExistingPictures { get; set; }
        public List<IFormFile>? NewPictures { get; set; }
        public string Desc { get; set; }
        public double Tax { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
        public string Availability { get; set; }
        public List<Guid>? ColorIds { get; set; }
        public List<Guid>? SizeIds { get; set; }
    }
}
