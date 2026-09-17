using SignalR.Bussiness.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Entities;

namespace SignalR.Bussiness.Concrate;

public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void TAdd(Contact entity)
    {
        _contactDal.Add(entity);
    }

    public void TDelete(Contact entity)
    {
        _contactDal.Delete(entity);
    }

    public Contact TGetById(string id)
    {
        return _contactDal.GetById(id);
    }

    public List<Contact> TGetListAll()
    {
        return _contactDal.GetListAll();
    }

    public void TUpdate(Contact entity)
    {
        _contactDal.Update(entity);
    }
}
