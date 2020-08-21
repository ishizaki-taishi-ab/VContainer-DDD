using Cysharp.Threading.Tasks;

namespace Domain
{
    public interface IPhotoRepository
    {
        UniTask<PhotoData> GetAsync(int photoResolution);
    }
}