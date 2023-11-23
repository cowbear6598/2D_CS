using Core.CursorSystem;
using Core.CursorSystem.DataAsset;
using Core.CursorSystem.Handler;
using Core.CursorSystem.Interface;
using NUnit.Framework;
using UnityEditor;
using VContainer;
using VContainer.Unity;

namespace Test.Cursor
{
    [TestFixture]
    public class CursorTests
    {
        [SetUp]
        public void Setup()
        {
            builder = new ContainerBuilder();

            var cursorAsset = AssetDatabase.LoadAssetAtPath<CursorAsset>("Assets/Data/Cursor/CursorAsset.asset");

            builder.RegisterInstance(cursorAsset);
            builder.Register<CursorHandler>(Lifetime.Singleton)
                   .AsImplementedInterfaces()
                   .AsSelf();
            builder.Register<CursorService>(Lifetime.Singleton)
                   .AsImplementedInterfaces()
                   .AsSelf();

            container = builder.Build();

            container.Resolve<IInitializable>().Initialize();
        }

        private ContainerBuilder builder;
        private IObjectResolver  container;

        [Test]
        public void Should_Change_To_Normal_When_Initialize()
        {
            var cursorService = container.Resolve<ICursorService>();

            Assert.AreEqual(CursorType.Normal, cursorService.GetCurrentCursorType());
        }

        [Test]
        public void Should_Change_To_Aim_Cursor_Success()
        {
            var cursorService = container.Resolve<ICursorService>();

            cursorService.ChangeToAimCursor();

            Assert.AreEqual(CursorType.Aim, cursorService.GetCurrentCursorType());
        }

        [Test]
        public void Should_Change_To_Normal_Cursor_Success()
        {
            var cursorService = container.Resolve<ICursorService>();

            cursorService.ChangeToAimCursor();

            Assert.AreEqual(CursorType.Aim, cursorService.GetCurrentCursorType());

            cursorService.ChangeToNormalCursor();

            Assert.AreEqual(CursorType.Normal, cursorService.GetCurrentCursorType());
        }
    }
}