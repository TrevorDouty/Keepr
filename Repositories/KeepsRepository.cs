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
    private readonly string populateCreator = "SELECT keep.*, profile.* FROM keeps keep INNER JOIN profiles profile ON keep.creatorId = profileId";

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> Get()
    {
      string sql = populateCreator;
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
    }

    public Keep GetOne(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }


    public int Create(Keep Keep)
    {
      string sql = @"INSERT INTO keeps
      (name, description, img, creatorId, shares, views, keeps)
      VALUES
      (@Name, @Description, @Img, @CreatorId, @Shares, @Views, @Keeps);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, Keep);
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM Keeps WHERE id = @id LIMIT 1;";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    internal IEnumerable<Keep> GetKeepsByProfile(string profileId)
    {
      string sql = @"SELECT keep.*, p.*
   FROM keeps keep 
   JOIN profiles p ON keep.creatorId = p.id
   WHERE keep.creatorId = @profileId;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { profileId }, splitOn: "id");
    }

    internal void Edit(Keep editKeep)
    {
      string sql = @"
      UPDATE keeps SET 
      name = @Name,
      description =@Description,
      img = @Img,
      shares = @Shares,
      views = @Views,
      keeps = @Keeps
      WHERE id = @Id;";
      _db.Execute(sql, editKeep);
    }
  }
}