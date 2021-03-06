﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Domain.Model.Posts
{
    public interface IPostReadOnlyRepository
    {
        Task<IEnumerable<Post>> GetBlogPosts(Guid blogId);
        Task<Post> GetPost(Guid id);
    }
}
