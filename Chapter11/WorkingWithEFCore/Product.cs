using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared
{
  public class Product
  {
    [Required]
    [StringLength(40)]
    public string ProductName { get; set; }

    [Column("UnitPrice")]
    public short? Stock { get; set; }

    public bool Discontinued { get; set; }

    // these two define the foreign key relationship
    // to the Categories table
    public int CategoryID { get; set; }
    public virtual Category Category { get; set; }
  }
}