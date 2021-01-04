using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Profile Get(string id)
    {
      string sql = @"
      SELECT * FROM profiles WHERE id = @id
      ";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    public Profile Create(Profile newProfile)
    {
      string sql = @"
      INSERT INTO profiles
      (name, email, picture, id)
      VALUES
      (@Name, @Email, @Picture, @Id)";
      _db.Execute(sql, newProfile);
      return newProfile;
    }
  }
}