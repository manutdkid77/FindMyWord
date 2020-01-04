using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Shiny.Prism;

namespace FindMyWord
{
    public class ShinyAppStartup : PrismStartup
    {
        public ShinyAppStartup() : base(PrismContainerExtension.Current)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            //Enable your shiny services here
        }
    }
}
