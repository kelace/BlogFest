using BlogFest.Domain.Administration.Events;
using BlogFest.Domain.Base;

namespace BlogFest.Domain.Administration
{
    public class Manager : AggregateRoot
    {

        private readonly AdministrationType _managerType;
        private List<Category> _categories;

        public Manager(Guid Id, AdministrationType managerType, List<Category> categories) : base(Id)
        {
            _managerType = managerType;
            _categories = categories;
        }
        public Result<SuccessInfo,Error> RemoveCategory(Guid id)
        {
            if (DoesCategoryExist(id))
            {
                var category = GetCategoryById(id);
                _categories.Remove(category);

                AddEvent(new CategoryHaveBeenRemoved
                {
                    Id = id
                });

                return new SuccessInfo { Id = id };
            }

            return new Error("Administration.RemoveCategory.CategoryNotExists", "Category does not exist");
        }
        public void AddOrUpdateCategories(List<Category> categories)
        {
            var @event = new CategoriesHaveBeenAdded();

            foreach (var category in categories)
            {
                if (DoesCategoryExist(category))
                {
                    var existedCategory = GetCategoryById(category.Id);

                    if(existedCategory.Title != category.Title || existedCategory.Enabled != category.Enabled)
                    {
                        existedCategory.Title = category.Title;
                        existedCategory.Enabled = category.Enabled;

                        @event.Categories.Add(new CategoryEventInfo
                        {
                            Id = category.Id,
                            Title = category.Title,
                            Enabled = category.Enabled,
                            ModifiedEntity = true
                        });
                    }

                    continue;
                }

                _categories.Add(category);

                @event.Categories.Add(new CategoryEventInfo
                {
                    Id = Guid.NewGuid(),
                    Title = category.Title,
                    Enabled = category.Enabled,
                    ModifiedEntity = false
                });
            }

            AddEvent(@event);
        }
        public void AddCategory(Category category)
        {
            if (DoesCategoryExist(category))
            {
                return;
            }

            _categories.Add(category);
            AddEvent(new CategoryHasBeenCreated
            {
                Id = category.Id,
                Title = category.Title,
            });
        }

        public void EditUserSettings(List<UserSettings> currentUserSettings)
        {

            AddEvent(new UserSettingsHasBeenEditedEvent
            {
                ManagerId = Id,
                NewUserSettings = currentUserSettings.ToList()
            });
        }

        private bool DoesCategoryExist(Category category)
        {
            return _categories.Any(x => x.Id == category.Id);
        }
        private bool DoesCategoryExist(Guid id)
        {
            return _categories.Any(x => x.Id == id);
        }

        private Category GetCategoryById(Guid Id)
        {
            return _categories.Where(x => x.Id == Id).FirstOrDefault();
        }

    }

    public enum UserStatus
    {

    }

    public enum AdministrationType
    {
        Admin,
        Moderator
    }
}
