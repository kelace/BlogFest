using BlogFest.Infrastruction;

namespace BlogFest.Web.Services
{
    public class WebHostEnvironmentAccessor : IWebHostEnvironmentAccessor
    {
        private readonly IWebHostEnvironment _environment;
        public WebHostEnvironmentAccessor(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string ContentRootPath => _environment.ContentRootPath;
    }
}
