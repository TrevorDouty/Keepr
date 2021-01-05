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


    public int Create(Keep Keep)
    {
      string sql = @"INSERT INTO keeps
      (name, description, img, creatorId)
      VALUES
      (@Name, @Description, @Img, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, Keep);
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM Keeps WHERE id = @id LIMIT 1;";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}