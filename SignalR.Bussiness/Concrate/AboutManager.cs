using SignalR.Bussiness.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Entities;

namespace SignalR.Bussiness.Concrate;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void TAdd(About entity)
    {
        _aboutDal.Add(entity);
    }

    public void TDelete(About entity)
    {
        _aboutDal.Delete(entity);
    }

    public About TGetById(string id)
    {
        return _aboutDal.GetById(id);
    }

    public List<About> TGetListAll()
    {
        return _aboutDal.GetListAll();
    }

    public void TUpdate(About entity)
    {
        _aboutDal.Update(entity);
    }
}
