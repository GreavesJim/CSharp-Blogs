using System;
using System.Collections.Generic;
using CSharp_Blogs.Models;
using CSharp_Blogs.Repositories;

namespace CSharp_Blogs.Services
{
    public class BlogsService
    {
        private readonly BlogsRepository _repo;
        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Blog> Get()
        {
            return _repo.Get();
        }

        internal Blog Create(Blog newBlog)
        {
            return _repo.Create(newBlog);
        }

        internal Blog Edit(Blog Update)
        {
            Blog exists = _repo.GetById(Update.Id);
            if (exists == null) { throw new Exception("Invalid Request"); }
            if (exists.CreatorId != Update.CreatorId) { throw new Exception("Cannot edit things you did not create"); }

            return _repo.Edit(Update);
        }
    }
}