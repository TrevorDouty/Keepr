using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> Get()
    {
      string sql = @"
SELECT * from Vaults
";
      return _db.Query<Vault>(sql);
    }

    public Vault GetOne(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }


    public int Create(Vault vault)
    {
      string sql = @"INSERT INTO vaults
      (name, description, isPrivate, img, creatorId)
      VALUES
      (@Name, @Description, @isPrivate,@Img, @creatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, vault);
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    internal IEnumerable<Vault> GetVaultsByProfile(string profileId)
    {
      string sql = @"SELECT vault.*, p.*
   FROM vaults vault 
   JOIN profiles p ON vault.creatorId = p.id
   WHERE vault.creatorId = @profileId;";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { profileId }, splitOn: "id");
    }


    internal void Edit(Vault editVault)
    {
      string sql = @"
      UPDATE vaults SET 
      name = @Name,
      description =@Description,
      WHERE id = @Id;";
      _db.Execute(sql, editVault);
    }

  }
}