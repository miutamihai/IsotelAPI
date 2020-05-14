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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RentId { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public int LandlordId { get; set; }
        [ForeignKey("LandlordId")]
        public virtual Landlord Landlord { get; set; }
        public int PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
