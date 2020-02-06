using System;
using System.Data;
using CSharp_Blogs.Models;

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
      throw new NotImplementedException();
    }

    internal void Create(Player newData)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }

    internal Player Edit(Player update)
    {
      throw new NotImplementedException();
    }
  }
}