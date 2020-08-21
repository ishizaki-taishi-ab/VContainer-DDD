using Application;
using Domain;
using Infrastructure;
using Presentation;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class SampleSceneLifetimeScope : LifetimeScope
{
    [SerializeField] private PhotoType _photoType;

    protected override void Configure(IContainerBuilder builder)
    {
        switch (_photoType)
        {
            case PhotoType.LoremPicsum:
                builder.Register<IPhotoRepository, LoremPicsumPhotoRepository>(Lifetime.Singleton);
                break;
            case PhotoType.Placekitten:
                builder.Register<IPhotoRepository, PlacekittenPhotoRepository>(Lifetime.Singleton);
                break;
        }

        builder.Register<PhotoService>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<Presenter>();
    }
}

public enum PhotoType
{
    LoremPicsum,
    Placekitten
}