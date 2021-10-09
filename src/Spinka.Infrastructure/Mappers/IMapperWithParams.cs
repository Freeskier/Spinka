namespace Spinka.Infrastructure.Mappers
{
    public interface IMapperWithParams<in TEntity, out TViewModel> where TEntity : class where TViewModel : class
    {
        TViewModel MapObject(TEntity entity, params object[] parameters);
    }
}