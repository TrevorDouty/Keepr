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
      vault.Id = _repo.Create(vault);
      return vault;
    }

    public string Delete(int id)
    {
      Vault foundVault = GetOne(id);
      if (_repo.Delete(id))
      {
        return "Vault has been Deleted";
      }
      throw new Exception("Could not delete the vault");
    }
  }
}