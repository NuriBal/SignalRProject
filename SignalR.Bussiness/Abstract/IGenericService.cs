namespace SignalR.Bussiness.Abstract;

public interface IGenericService<T> where T : class
{
    void TAdd(T entity);
    void TDelete(T entity);
    void TUpdate(T entity);
    T TGetById(string id);
    List<T> TGetListAll();
}
