using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRental.Startup))]
namespace MovieRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
