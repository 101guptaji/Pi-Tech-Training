using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstDemo
{
    [Table ("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        [Column("CategoryName", TypeName="varchar" )]
        [MaxLength(20)]
        public string CategoryName { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
