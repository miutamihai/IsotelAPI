using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelDataLayer.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        [ForeignKey("Id")]
        public virtual City City { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("Id")]
        public virtual Landlord Landlord { get; set; }
        public int PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
