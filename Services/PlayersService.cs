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
      _repo.Create(newData);
      return newData;
    }

    internal Player Edit(Player update)
    {
      Player exists = _repo.GetById(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      if (exists.CreatorId != update.CreatorId)
      {
        throw new Exception("I can't let you do that");
      }
      return _repo.Edit(update);
    }

    internal object Delete(string creatorId, int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      if (exists.CreatorId != creatorId)
      {
        throw new Exception("I can't let you do that");
      }
      _repo.Delete(id);
      return "Successfully deleted";
    }
  }
}