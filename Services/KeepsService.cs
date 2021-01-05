using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
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

    internal Keep GetOne(int id)
    {
      Keep foundKeep = _repo.GetOne(id);
      if (foundKeep == null)
      {
        throw new Exception("This Keep doesn't exist");
      }
      return foundKeep;

    }


    public string Delete(int id, string userId)
    {
      Keep original = _repo.GetOne(id);
      if (original == null)
      {
        throw new Exception("Incorrect Id");
      }
      else if (original.CreatorId != userId)
      {
        throw new Exception("Not allowed");
      }
      else if (_repo.Delete(id))
      {
        return "Deleted";
      }
      return "Could not delete";
    }

    internal Keep Create(Keep keep)
    {
      keep.Id = _repo.Create(keep);
      return keep;
    }

    internal IEnumerable<Keep> GetKeepsByProfile(string profileId, string userId)
    {
      return _repo.GetKeepsByProfile(profileId);
    }

    internal Keep Edit(Keep editKeep, string userId)
    {
      Keep original = _repo.GetOne(editKeep.Id);
      if (original == null)
      {
        throw new Exception("Incorrect Id");
      }
      if (original.CreatorId != userId)
      {
        throw new Exception("You can't edit this keep");
      }
      _repo.Edit(editKeep);

      return original;

    }
  }
}