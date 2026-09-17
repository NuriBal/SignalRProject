namespace SignalR.DataAccess.Abstract;

public interface IGenericDal<T> where T : class
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    T GetById(string id);
    List<T> GetListAll();
}
