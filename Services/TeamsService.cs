using System;
using CSharp_Blogs.Models;
using CSharp_Blogs.Repositories;

namespace CSharp_Blogs.Services
{
  public class TeamsService
  {
    private readonly TeamsRepository _repo;

    public TeamsService(TeamsRepository pr)
    {
      _repo = pr;
    }
    internal Team GetById(int id)
    {
      var found = _repo.GetById(id);
      if (found == null) { throw new Exception("Invalid id"); }
      return found;
    }

    internal Team Create(Team newData)
    {
      _repo.Create(newData);
      return newData;
    }

    internal Team Edit(Team update)
    {
      Team exists = _repo.GetById(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      if (exists.CreatorId != update.CreatorId)
      {
        throw new Exception("I can't let you do that");
      }
      _repo.Edit(update);
      return update;
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