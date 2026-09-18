using SignalR.Bussiness.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Entities;

namespace SignalR.Bussiness.Concrate;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void TAdd(Product entity)
    {
        _productDal.Add(entity);
    }

    public void TDelete(Product entity)
    {
        _productDal.Delete(entity);
    }

    public Product TGetById(string id)
    {
        return _productDal.GetById(id);
    }

    public List<Product> TGetListAll()
    {
        return _productDal.GetListAll();
    }

    public List<Product> TGetProductsWithCategories()
    {
        return _productDal.GetProductsWithCategories();
    }

    public void TUpdate(Product entity)
    {
        _productDal.Update(entity);
    }
}
