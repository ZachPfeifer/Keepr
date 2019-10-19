

using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Dapper;

namespace Keepr.Services
{

  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }

    public Vault Get(int id)
    {
      Vault exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    public IEnumerable<Vault> GetUsersVaults(string userId)
    {
      return _repo.GetUsersVaults(userId);
    }
    public Vault Create(Vault newVault, string userId)
    {
      newVault.UserId = userId;
      int id = _repo.Create(newVault);
      newVault.Id = id;
      return newVault;
    }

    public Vault Edit(Vault newVaultEdit)
    {
      Vault vault = _repo.Get(newVaultEdit.Id);
      if (vault == null) { throw new Exception("Invalid Id Homie"); }
      vault.Name = newVaultEdit.Name;
      vault.Description = newVaultEdit.Description;
      //   vault.UserId = newVaultEdit.UserId; //FIXME ??

      _repo.Edit(vault);
      return vault;
    }

    public string Delete(int id)
    {
      Vault vault = _repo.Get(id);
      if (vault == null) { throw new Exception("Invalid Id Homie"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}