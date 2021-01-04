using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> Get()
    {
      string sql = @"
SELECT * from Keeps
";
      return _db.Query<Keep>(sql);
    }

    public Keep GetOne(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }


    public Keep Create(Keep Keep)
    {
      string sql = @"INSERT INTO keeps
      (name, description, isPrivate)
      VALUES
      (@Name, @Description, @isPrivate);
      SELECT LAST_INSERT_ID();";
      Keep.Id = _db.ExecuteScalar<int>(sql, Keep);
      return Keep;
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM Keeps WHERE id = @id LIMIT 1;";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}