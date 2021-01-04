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


    public Vault Create(Vault vault)
    {
      string sql = @"INSERT INTO vaults
      (name, description, isPrivate)
      VALUES
      (@Name, @Description, @isPrivate);
      SELECT LAST_INSERT_ID();";
      vault.Id = _db.ExecuteScalar<int>(sql, vault);
      return vault;
    }
  }
}