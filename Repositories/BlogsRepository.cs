using System;
using System.Collections.Generic;
using System.Data;
using CSharp_Blogs.Models;
using Dapper;

namespace CSharp_Blogs.Repositories
{
    public class BlogsRepository
    {
        private readonly IDbConnection _db;

        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Blog> Get()
        {
            string sql = "SELECT * FROM blogs;";
            _db.Query<Blog>(sql);

        }

        internal Blog GetById(int id)
        {
            string sql = "SELECT * FROM blogs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Blog>(sql, new { id });
        }
        internal Blog Create(Blog newBlog)
        {
            string sql = @"INSERT INTO blogs (title, body, creatorId)
                            VALUES (@Title, @Body, @CreatorId);
                            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newBlog);
            newBlog.Id = id;
            return newBlog;
        }


        internal Blog Edit(Blog update)
        {
            throw new NotImplementedException();
        }
    }
}