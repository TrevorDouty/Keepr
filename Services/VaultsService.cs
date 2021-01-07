using System;
using System.Collections.Generic;
using System.Linq;
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

    public IEnumerable<Vault> Get(string userId)
    {
      return _repo.Get().ToList().FindAll(v => v.CreatorId == userId);
    }

    internal Vault GetOne(int id)
    {
      Vault foundVault = _repo.GetOne(id);
      if (foundVault == null)
      {
        throw new Exception("This Vault doesn't exist");
      }
      if (foundVault.isPrivate)
      {
        throw new Exception("This Vault is Private");
      }
      return foundVault;

    }


    public string Delete(int id, string userId)
    {
      Vault original = _repo.GetOne(id);
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

    internal Vault Create(Vault vault)
    {
      vault.Id = _repo.Create(vault);
      return vault;
    }

    internal IEnumerable<Vault> GetVaultsByProfile(string profileId, string userId)
    {
      return _repo.GetVaultsByProfile(profileId).ToList().FindAll(v => v.CreatorId == userId || v.isPrivate == false); ;
    }

    internal Vault Edit(Vault editVault, string userId)
    {
      Vault original = _repo.GetOne(editVault.Id);
      if (original == null)
      {
        throw new Exception("Incorrect Id");
      }
      if (original.CreatorId != userId)
      {
        throw new Exception("You can't edit this vault");
      }
      _repo.Edit(editVault);

      return original;

    }
  }
}