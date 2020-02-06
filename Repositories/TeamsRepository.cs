using System;
using System.Collections.Generic;
using System.Data;
using CSharp_Blogs.Models;
using Dapper;

namespace CSharp_Blogs.Repositories
{

  public class TeamsRepository
  {

    private readonly IDbConnection _db;

    public TeamsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Team GetById(int id)
    {
      string sql = "SELECT * FROM teams WHERE id = @id";

      return _db.QueryFirstOrDefault<Team>(sql, new { id });
    }

    internal IEnumerable<Team> Get()
    {
      string sql = "SELECT * FROM teams;";
      return _db.Query<Team>(sql);
    }

    internal Team Create(Team newData)
    {
      string sql = @"
      INSERT INTO teams (name, creatorId)
      VALUES (@Name, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);

      newData.Id = id;
      return newData;
    }


    internal void Edit(Team update)
    {
      string sql = @"
      UPDATE teams
      SET
      name = @Name
      WHERE id = @Id";
      _db.Execute(sql, update);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM teams WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}