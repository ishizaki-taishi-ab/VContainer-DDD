using Cysharp.Threading.Tasks;
using Domain;
using UnityEngine.Networking;

namespace Infrastructure
{
    /// <summary>
    /// Lorem Picsum からランダムな画像を取得する
    /// </summary>
    public class LoremPicsumPhotoRepository : IPhotoRepository
    {
        public async UniTask<PhotoData> GetAsync(int photoResolution)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture($"https://picsum.photos/{photoResolution}");

            await request.SendWebRequest();

            return new PhotoData(((DownloadHandlerTexture) request.downloadHandler).texture);
        }
    }
}