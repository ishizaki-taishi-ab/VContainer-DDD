using Cysharp.Threading.Tasks;
using Domain;
using UnityEngine;
using UnityEngine.Networking;

namespace Infrastructure
{
    /// <summary>
    /// placekitten からランダムな画像を取得する
    /// </summary>
    public class PlacekittenPhotoRepository : IPhotoRepository
    {
        private int _getCount;

        public async UniTask<PhotoData> GetAsync(int photoResolution)
        {
            // HACK: サイズを変えないと同じ画像が返ってくる
            photoResolution += _getCount++ % 100;

            UnityWebRequest request = UnityWebRequestTexture.GetTexture($"http://placekitten.com/{photoResolution}");

            await request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError(request.error);
            }

            return new PhotoData(((DownloadHandlerTexture) request.downloadHandler).texture);
        }
    }
}