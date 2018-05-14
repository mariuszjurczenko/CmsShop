using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CmsShop.Models.Data
{
    [Table("tblCategories")]
    public class CategoryDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Sorting { get; set; } 
    }
}