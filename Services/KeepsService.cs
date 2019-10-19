using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{

  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public Keep Get(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    public IEnumerable<Keep> GetUsersKeeps(string userId)
    {
      return _repo.GetUsersKeeps(userId);
    }
    public Keep Create(Keep newKeep, string userId)
    {
      newKeep.UserId = userId;
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public Keep Edit(Keep newData)
    {
      Keep keep = _repo.Get(newData.Id);
      if (keep == null) { throw new Exception("Invalid Id Homie"); }
      keep.Name = newData.Name;
      keep.Description = newData.Description;
      keep.Img = newData.Img;
      keep.isPrivate = newData.isPrivate;
      keep.Views = newData.Views;
      keep.Shares = newData.Shares;

      // keep.UserId = newData.UserId;

      _repo.Edit(keep);
      return keep;
    }

    public string Delete(int id)
    {
      Keep keep = _repo.Get(id);
      if (keep == null) { throw new Exception("Invalid Id Homie"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}