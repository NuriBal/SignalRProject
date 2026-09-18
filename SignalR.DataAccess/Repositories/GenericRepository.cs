using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.Entity.Abstract;

namespace SignalR.DataAccess.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly SignalRContext _context;

    public GenericRepository(SignalRContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public T GetById(string id)
    {
        return _context.Set<T>().Find(id);
    }

    public List<T> GetListAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Update(T entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.UpdatedDate = DateTime.Now;
        }
        _context.Update(entity);
        _context.SaveChanges();
    }
}
