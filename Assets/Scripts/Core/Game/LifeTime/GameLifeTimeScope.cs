using System;
using Core.CursorSystem;
using Core.CursorSystem.DataAsset;
using Core.CursorSystem.Handler;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Game.LifeTime
{
    public class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private GameSettings settings;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterCursor(builder);
        }

        private void RegisterCursor(IContainerBuilder builder)
        {
            builder.Register<CursorHandler>(Lifetime.Singleton);
            builder.Register<CursorService>(Lifetime.Singleton)
                   .AsImplementedInterfaces()
                   .AsSelf();
            builder.RegisterInstance(settings.cursorAsset);
        }

        [Serializable]
        public class GameSettings
        {
            public CursorAsset cursorAsset;
        }
    }
}