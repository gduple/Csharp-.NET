using System.ComponentModel.DataAnnotations;

namespace Packt.Shared
{
  public class Category
  {
    public int CategoryID { get; set; }
    [Required]
    [StringLength(40)]
    public string CategoryName { get; set; }
    public string Description { get; set; }
  }
}