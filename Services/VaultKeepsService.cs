using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    // public IEnumerable<VaultKeep> Get()
    // {
    // return _repo.GetVaultKeep();
    // }

    // public VaultKeep GetVaultKeep(int id, string userId)
    // {
    //   VaultKeep exists = _repo.GetVaultKeep(id, userId);
    //   if (exists == null) { throw new Exception("Invalid ID"); }
    //   return exists;
    // }
    public IEnumerable<Keep> GetVaultKeep(int vaultId, string userId)
    {
      return _repo.GetVaultKeep(vaultId, userId);
    }

    public Vault Create(Vault newVaultKeep, string userId)
    {
      newVaultKeep.UserId = userId;
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    // public Vault Edit(Vault newVaultEdit)
    // {
    //   Vault vault = _repo.Get(newVaultEdit.Id);
    //   if (vault == null) { throw new Exception("Invalid Id Homie"); }
    //   vault.Name = newVaultEdit.Name;
    //   vault.Description = newVaultEdit.Description;
    //   //   vault.UserId = newVaultEdit.UserId; //FIXME ??

    //   _repo.Edit(vault);
    //   return vault;
    // }

    public string RemoveKeepFromVault(int id)
    {
      VaultKeep vaultKeep = _repo.GetVaultKeep(id);
      if (vaultKeep == null) { throw new Exception("Invalid Id Homie"); }
      _repo.RemoveKeepFromVault(id);
      return "Successfully Deleted";
    }
  }
}