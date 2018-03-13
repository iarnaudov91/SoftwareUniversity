﻿using Forum.App.Services;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.UserInterface.ViewModel
{
    public class PostViewModel
    {
        private const int LINE_HEIGHT = 37;

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }
            
        private IList<string> GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();
            IList<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i+=LINE_HEIGHT)
            {
                char[] row = contentChars.Skip(i).Take(LINE_HEIGHT).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }

        public PostViewModel()
        {
            this.Content = new List<string>();
        }

        public PostViewModel(Post post)
        {
            this.PostId = post.Id;
            this.Title = post.Title;
            this.Content = this.GetLines(post.Content);
            this.Author = UserService.GetUser(post.AuthorId).Username;
            this.Category = PostService.GetCategory(post.CategoryId).Name;
            this.Replies = PostService.GetPostReplies(post.Id);
        }

    }
}
