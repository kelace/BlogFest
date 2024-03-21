namespace BlogFest.Web.ViewModels.Administration
{
    public class AdministrationBaseViewModel<T>
    {
        public string Tab { get; set; }
        public T Content { get; set; }
    }
}
