using SignalR.Bussiness.Abstract;
using SignalR.Bussiness.Concrate;

namespace SignalR.API.Configurations;

public class BussinessServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        //Scopped işlemleri Servis eşleştirmeleri Alt Alta Ekle
        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<IBookingService, BookingManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IDiscountService, DiscountManager>();
        services.AddScoped<IFeatureService, FeatureManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
    }
}
