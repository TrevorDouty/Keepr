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


    public string Delete(int id)
    {
      Keep foundKeep = GetOne(id);
      if (_repo.Delete(id))
      {
        return "Keep has been Deleted";
      }
      throw new Exception("Could not delete the Keep");
    }

    internal Keep Create(Keep keep)
    {
      keep.Id = _repo.Create(keep);
      return keep;
    }
  }
}