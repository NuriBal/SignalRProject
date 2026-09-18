using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entity.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    private readonly SignalRContext _context;

    public EfProductDal(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public List<Product> GetProductsWithCategories()
    {
        var response = _context.Products.Include(x => x.Category).ToList();
        return response;
    }
}
