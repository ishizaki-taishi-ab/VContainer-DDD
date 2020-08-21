using Application;
using Domain;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Presentation
{
    public class Presenter : MonoBehaviour
    {
        [SerializeField] private int _photoResolution = 256;
        [SerializeField] private RawImage _photoImage;
        [SerializeField] private Button _reloadButton;

        private PhotoService _photoService;

        [Inject]
        public void Construct(PhotoService photoService)
        {
            _photoService = photoService;
        }

        private void Start()
        {
            _reloadButton.onClick.AddListener(async () =>
            {
                _reloadButton.interactable = false;
                PhotoData photoData = await _photoService.GetAsync(_photoResolution);
                _photoImage.texture = photoData.Texture;
                _reloadButton.interactable = true;
            });
        }
    }
}