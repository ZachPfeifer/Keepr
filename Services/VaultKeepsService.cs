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



    // public VaultKeep Delete(VaultKeep newVaultKeepEdit)
    // {
    //   VaultKeep vaultKeep = _repo.Delete(newVaultKeepEdit.Id);
    //   if (vaultKeep == null) { throw new Exception("Invalid Id Homie"); }
    //   vaultKeep.Id = newVaultKeepEdit.Id;
    //   //   vault.UserId = newVaultEdit.UserId; //FIXME ??

    //   _repo.Delete(vaultKeep);
    //   return vaultKeep;
    // }

    // public string Delete(int id)
    // {
    //   VaultKeep vaultKeep = _repo.Delete(id);
    //   if (vaultKeep == null) { throw new Exception("Invalid Id Homie"); }
    //   _repo.Delete(id);
    //   return "Successfully Deleted";
    // }
    public string RemoveKeep(VaultKeep vk)
    {
      VaultKeep vault = _repo.GetIds(vk.VaultId, vk.KeepId);
      if (vault == null || vault.UserId != vk.UserId) { throw new Exception("Invalid Info Homie"); } //FIXME ????
      _repo.RemoveKeepFromKeeps(vault.Id);
      return "Successfully Booted";
    }

  }
}