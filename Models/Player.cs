using System.ComponentModel.DataAnnotations;

namespace CSharp_Blogs.Models
{
  public class Player
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public string Name { get; set; }
    [Range(1, 99)]
    public int Number { get; set; }
    public string Position { get; set; }

  }
}