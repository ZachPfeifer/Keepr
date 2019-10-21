using Keepr.Interfaces;

namespace Keepr.Models
{
  public class VaultKeep : IVaultKeeps
  {
    public int Id { get; set; } //FIXME ??
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public string UserId { get; set; }
  }
}

// public int Id { get; set; }
// public int OrderId { get; set; }
// public string ShoeId { get; set; }
// public string UserId { get; set; }
