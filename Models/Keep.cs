using System.ComponentModel.DataAnnotations;
using Keepr.Interfaces;

namespace Keepr.Models
{
  public class Keep : IKeep
  {
    // [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string Img { get; set; }
    public bool isPrivate { get; set; }

    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }

    // [Required]
    public string UserId { get; set; }
  }
}