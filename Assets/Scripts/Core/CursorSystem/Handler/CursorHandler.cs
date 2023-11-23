using System;
using Core.CursorSystem.DataAsset;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.CursorSystem.Handler
{
    public enum CursorType
    {
        System,
        Normal,
        Aim,
    }

    public class CursorHandler : IInitializable
    {
        [Inject] private readonly CursorAsset cursorAsset;

        private CursorType currentCursorType = CursorType.System;

        public void Initialize()
        {
            ChangeToNormalCursor();
        }

        public void ChangeToNormalCursor()
        {
            Cursor.SetCursor(cursorAsset.normalCursor, Vector2.zero, CursorMode.Auto);

            currentCursorType = CursorType.Normal;
        }

        public void ChangeToAimCursor()
        {
            Cursor.SetCursor(cursorAsset.aimCursor, Vector2.zero, CursorMode.Auto);

            currentCursorType = CursorType.Aim;
        }

        public CursorType GetCurrentCursorType() => currentCursorType;
    }
}