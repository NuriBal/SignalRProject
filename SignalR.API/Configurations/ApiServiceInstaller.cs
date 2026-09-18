using SignalR.API.Mapping;

namespace SignalR.API.Configurations;

public class ApiServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(typeof(AboutMapping).Assembly);
            cfg.AddMaps(typeof(BookingMapping).Assembly);
            cfg.AddMaps(typeof(CategoryMapping).Assembly);
            cfg.AddMaps(typeof(ContactMapping).Assembly);
            cfg.AddMaps(typeof(DiscountMapping).Assembly);
            cfg.AddMaps(typeof(FeatureMapping).Assembly);
            cfg.AddMaps(typeof(ProductMapping).Assembly);
            cfg.AddMaps(typeof(SocialMediaMapping).Assembly);
            cfg.AddMaps(typeof(TestimonialMapping).Assembly);
        });
    }
}
