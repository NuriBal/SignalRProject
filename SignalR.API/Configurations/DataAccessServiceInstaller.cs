using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.EntityFramework;

namespace SignalR.API.Configurations;

public class DataAccessServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        string connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContext<SignalRContext>(options => options.UseSqlServer(connectionString));

        //Scoped Tanımlamalar Dal Eşleştirmeleri Alt Alta Ekle
        services.AddScoped<IAboutDal, EfAboutDal>();
        services.AddScoped<IBookingDal, EfBookingDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IFeatureDal, EfFeatureDal>();
        services.AddScoped<IProductDal, EfProductDal>();
        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        services.AddScoped<IDiscountDal, EfDiscountDal>();
    }
}
