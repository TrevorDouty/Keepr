using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
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

    internal Vault GetOne(int id)
    {
      Vault foundVault = _repo.GetOne(id);
      if (foundVault == null)
      {
        throw new Exception("This Vault doesn't exist");
      }
      return foundVault;

    }

    public Vault Create(Vault vault)
    {
      return _repo.Create(vault);
    }
  }
}