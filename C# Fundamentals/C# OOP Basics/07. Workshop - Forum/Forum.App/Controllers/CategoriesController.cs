﻿namespace Forum.App.Services
{
    using System;

    using Forum.App.Services.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Forum.Data;
    using System.Linq;
    using Forum.App.Views;

    public class CategoriesController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public int CurrentPage { get; set; }

        private string[] AllCategoryNames { get; set; }

        private string[] CurrentPageCategories { get; set; }

        private int LastPage => this.AllCategoryNames.Length / (PAGE_OFFSET + 1);

        private bool IsFirstPage => this.CurrentPage == 0;

        private bool IsLastPage => this.CurrentPage == this.LastPage;

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
        }

        public CategoriesController()
        {
            this.CurrentPage = 0;
            this.LoadCategories();
        }

        private void LoadCategories()
        {
            this.AllCategoryNames = PostService.GetAllCategoryNames();

            this.CurrentPageCategories = this.AllCategoryNames
                .Skip(CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .ToArray();
        }
       
        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;

                case Command.ViewCategory:
                    return MenuState.OpenCategory;

                case Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.Rerender;

                case Command.NextPage:
                    this.ChangePage();
                    return MenuState.Rerender;
            }
            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            LoadCategories();
            return new CategoriesView(this.CurrentPageCategories, this.IsFirstPage, this.IsLastPage);
        }

        private enum Command
        {
            Back = 0,
            ViewCategory = 1,
            ViewPost,
            PreviousPage = 11,
            NextPage = 12
        }
    }
}
