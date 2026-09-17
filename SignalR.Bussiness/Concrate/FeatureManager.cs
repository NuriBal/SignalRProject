using SignalR.Bussiness.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Entities;

namespace SignalR.Bussiness.Concrate;

public class FeatureManager : IFeatureService
{
    private readonly IFeatureDal _featureDal;

    public FeatureManager(IFeatureDal featureDal)
    {
        _featureDal = featureDal;
    }

    public void TAdd(Feature entity)
    {
        _featureDal.Add(entity);
    }

    public void TDelete(Feature entity)
    {
        _featureDal.Delete(entity);
    }

    public Feature TGetById(string id)
    {
        return _featureDal.GetById(id);
    }

    public List<Feature> TGetListAll()
    {
        return _featureDal.GetListAll();
    }

    public void TUpdate(Feature entity)
    {
        _featureDal.Update(entity);
    }
}
