using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.About
{
    public class AboutViewDto
    {
        public Guid Id { get; set; }
        public string OriginImageUrl { get; set; }
        public string OriginTitle { get; set; }
        public string OriginDesc { get; set; }
        public string GhibliImageUrl { get; set; }
        public string GhibliTitle { get; set; }
        public string GhibliDesc { get; set; }
        public string GlobalImageUrl { get; set; }
        public string GlobalTitle { get; set; }
        public string GlobalDesc { get; set; }
        public string MessageImageUrl { get; set; }
        public string MessageTitle { get; set; }
        public string MessageDesc { get; set; }
        public string HeightImageUrl { get; set; }
        public string HeightTitle { get; set; }
        public string HeightDesc { get; set; }
        public string FutureImageUrl { get; set; }
        public string FutureTitle { get; set; }
        public string FutureDesc { get; set; }
    }
}
