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

    //Create VaultKeep
    public VaultKeep Create(VaultKeep newVaultKeep, string userId)
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

    // public string RemoveKeepFromVault(int vaultId, string userId)
    // {
    // VaultKeep vaultKeep = _repo.GetVaultKeep(vaultId, userId);
    // if (vaultKeep == null) { throw new Exception("Invalid Id Homie"); }
    // _repo.RemoveKeepFromVault(vaultId);
    // return "Successfully Deleted";
    // }

    // public string RemoveKeepFromVault(Vault vk, string userId)
    // {
    //   Vault order = _repo.GetVaultKeep(vk);
    //   if (vault == null || vault.UserId != userId) { throw new Exception("Invalid Info Homie"); }
    //   _repo.RemoveKeepFromVault(vault.Id);
    //   return "Successfully Booted";
    // }
  }
}