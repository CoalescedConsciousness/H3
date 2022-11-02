using EFGetStarted.Models;
using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            InsertBlog();
            //LoadingAllData();

            //Post post = new Post()
            //{
            //    BlogId = 1,
            //    Title = "Test",
            //    Content = "test test",

            //};
            //using (var context = new BloggingContext())
            //{
            //    context.Post.Add(new Post { Content = "Test", Title = "Test", BlogId = 1 });
            //    context.SaveChanges();
            //}
        }

            static void LoadingAllData()
            {
                using (var context = new BloggingContext())
                {
                    var blog = context.Blogs.First();
                }
            }
            #region INSERT
            private static void InsertBlog()
            {
                // Contexten har også en Add() metode og kan selv mappe objektet ind på den korrekte DbSet.
                using (var context = new BloggingContext())
                {
                    context.Blogs.Add(new Blog { Url = "http://dotnet.com" });
                    //context.Add(new Blog { Url = "http://dotnet.com" });
                    context.SaveChanges();
                }
            }

            private static void InsertMultipleBlogs()
            {
                using (var context = new BloggingContext())
                {
                    Blog blog1 = new Blog { Url = "http://itdata.net" };
                    Blog blog2 = new Blog { Url = "http://abctv.dk" };
                    context.Blogs.AddRange(blog1, blog2);
                    context.SaveChanges();
                }
            }
            #endregion
        }
    } 



