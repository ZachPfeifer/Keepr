namespace Keepr.Interfaces
{
  public interface IVault
  {
    // int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    // string userId { get; set; }
  }
}

// PATH: /vaults

// DATA: Vault Object { name, description }

// RESPONSE: Vault

// DESCRIPTION: Post request.This will create a vault. You should add userId from backend.