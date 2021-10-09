namespace Spinka.Infrastructure.Mappers
{
    public interface IMapper<in TEntity, out TViewModel> where TEntity : class where TViewModel : class
    {
        TViewModel MapObject(TEntity entity);
    }
}