using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Pages.Models
{
    [Table("Property88")]
    public partial class Property
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool Active { get; set; }
    }
}
