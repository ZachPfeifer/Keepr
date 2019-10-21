namespace Keepr.Interfaces
{
  //Helper Class.Model
  public interface IVaultKeeps
  {
    int VaultId { get; set; }
    int KeepId { get; set; }

  }
}


//
// PATH: /vaultkeeps

// DATA: vaultkeep {vaultId, keepId} //FIXME lower case?

// DESCRIPTION: This will map a vaultkeep relationship.It needs a vaultId, a keepId, and a userId.You should add your userId from the backend.