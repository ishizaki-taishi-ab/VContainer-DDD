using Cysharp.Threading.Tasks;
using Domain;
using VContainer;

namespace Application
{
    public sealed class PhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        [Inject]
        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public UniTask<PhotoData> GetAsync(int photoResolution)
        {
            return _photoRepository.GetAsync(photoResolution);
        }
    }
}