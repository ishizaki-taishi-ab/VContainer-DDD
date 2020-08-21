using UnityEngine;

namespace Domain
{
    public class PhotoData
    {
        public readonly Texture2D Texture;

        public PhotoData(Texture2D texture)
        {
            Texture = texture;
        }
    }
}