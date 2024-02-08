﻿using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.IRepositories
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogAsync();

        Task<Blog> AddBlogAsnyc(Blog blog);

        void UpdateBlog(Blog blog);

        Task<Blog> GetBlogByIdAsync(int id);

        void DeleteBlog(Blog blog);
    }
}