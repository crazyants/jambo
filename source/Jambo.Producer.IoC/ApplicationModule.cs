﻿using Autofac;
using Jambo.Producer.Application.Queries;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Producer.Infrastructure;
using Jambo.Producer.Infrastructure.Repositories;
using Jambo.Producer.Infrastructure.Repositories.Blogs;
using Jambo.Producer.Infrastructure.Repositories.Posts;

namespace Jambo.Producer.IoC
{
    public class ApplicationModule : Module
    {
        public readonly string _connectionString;
        public readonly string _database;

        public ApplicationModule(string connectionString, string database)
        {
            _connectionString = connectionString;
            _database = database;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new BlogQueries(_connectionString, _database))
                .As<IBlogQueries>();

            builder.Register(c => new PostQueries(_connectionString, _database))
                .As<IPostQueries>();

            builder.Register(c => new MongoContext(_connectionString, _database))
                .As<MongoContext>().SingleInstance();

            builder.RegisterType<BlogReadOnlyRepository>()
                .As<IBlogReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostReadOnlyRepository>()
                .As<IPostReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}