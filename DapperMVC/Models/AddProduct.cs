using System.ComponentModel.DataAnnotations;

namespace DapperMVC.Models
{
    public class AddProduct
    {
        [Key]
        public int SN { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime  Created { get; set; }
    }
}
