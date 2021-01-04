using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public VaultKeep Create(VaultKeep vaultKeep)
    {
      vaultKeep.Id = _repo.Create(vaultKeep);
      return vaultKeep;
    }

    public string Delete(int id, string userId)
    {
      VaultKeep original = _repo.Get(id);
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

    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      return _repo.GetKeepsByVaultId(vaultId);
    }
  }
}