using SignalR.Bussiness.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Entities;

namespace SignalR.Bussiness.Concrate;

public class BookingManager : IBookingService
{
    private readonly IBookingDal _bookingDal;

    public BookingManager(IBookingDal bookingDal)
    {
        _bookingDal = bookingDal;
    }

    public void TAdd(Booking entity)
    {
        _bookingDal.Add(entity);
    }

    public void TDelete(Booking entity)
    {
        _bookingDal.Delete(entity);
    }

    public Booking TGetById(string id)
    {
        return _bookingDal.GetById(id);
    }

    public List<Booking> TGetListAll()
    {
        return _bookingDal.GetListAll();
    }

    public void TUpdate(Booking entity)
    {
        _bookingDal.Update(entity);
    }
}
