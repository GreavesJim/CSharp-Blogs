using System;
using System.Data;
using CSharp_Blogs.Models;
using Dapper;

namespace CSharp_Blogs.Repositories
{

  public class PlayersRepository
  {

    private readonly IDbConnection _db;

    public PlayersRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Player GetById(int id)
    {
      string sql = "SELECT * FROM players WHERE id = @id";

      return _db.QueryFirstOrDefault<Player>(sql, new { id });
    }

    internal Player Create(Player newData)
    {
      string sql = @"
      INSERT INTO players (name, teamId, number, creatorId)
      VALUES (@Name, @TeamId, @Number, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);

      newData.Id = id;
      return newData;
    }


    internal void Edit(Player update)
    {
      string sql = @"
      UPDATE players
      SET
      name = @Name,
      teamId = @TeamId,
      number = @Number
      WHERE id = @Id";
      _db.Execute(sql, update);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM players WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}