using System;
using System.Data;

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
  }
}