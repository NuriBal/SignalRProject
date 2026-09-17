using SignalR.Bussiness.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Entities;

namespace SignalR.Bussiness.Concrate;

public class TestimonialManager : ITestimonialService
{
    private readonly ITestimonialDal _testimonialDal;

    public TestimonialManager(ITestimonialDal testimonialDal)
    {
        _testimonialDal = testimonialDal;
    }

    public void TAdd(Testimonial entity)
    {
        _testimonialDal.Add(entity);
    }

    public void TDelete(Testimonial entity)
    {
        _testimonialDal.Delete(entity);
    }

    public Testimonial TGetById(string id)
    {
        return _testimonialDal.GetById(id);
    }

    public List<Testimonial> TGetListAll()
    {
        return _testimonialDal.GetListAll();
    }

    public void TUpdate(Testimonial entity)
    {
        _testimonialDal.Update(entity);
    }
}
