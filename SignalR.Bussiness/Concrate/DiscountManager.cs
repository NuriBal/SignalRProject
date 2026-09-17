using SignalR.Bussiness.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Entities;

namespace SignalR.Bussiness.Concrate;

public class DiscountManager : IDiscountService
{
    private readonly IDiscountDal _discountDal;

    public DiscountManager(IDiscountDal discountDal)
    {
        _discountDal = discountDal;
    }

    public void TAdd(Discount entity)
    {
        _discountDal.Add(entity);
    }

    public void TDelete(Discount entity)
    {
        _discountDal.Delete(entity);
    }

    public Discount TGetById(string id)
    {
        return _discountDal.GetById(id);
    }

    public List<Discount> TGetListAll()
    {
        return _discountDal.GetListAll();
    }

    public void TUpdate(Discount entity)
    {
        _discountDal.Update(entity);
    }
}
