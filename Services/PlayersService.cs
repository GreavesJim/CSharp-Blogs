using System;
using CSharp_Blogs.Models;
using CSharp_Blogs.Repositories;

namespace CSharp_Blogs.Services
{
  public class PlayersService
  {
    private readonly PlayersRepository _repo;

    public PlayersService(PlayersRepository pr)
    {
      _repo = pr;
    }
    internal Player GetById(int id)
    {
      var found = _repo.GetById(id);
      if (found == null) { throw new Exception("Invalid id"); }
      return found;
    }

    internal Player Create(Player newData)
    {
      throw new NotImplementedException();
    }

    internal object Delete(string creatorId, int id)
    {
      throw new NotImplementedException();
    }
  }
}