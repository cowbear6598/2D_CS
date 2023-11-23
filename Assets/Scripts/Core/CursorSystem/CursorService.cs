using Core.CursorSystem.Handler;
using Core.CursorSystem.Interface;
using VContainer;

namespace Core.CursorSystem
{
    public class CursorService : ICursorService
    {
        [Inject] private readonly CursorHandler cursorHandler;

        public void ChangeToNormalCursor() => cursorHandler.ChangeToNormalCursor();
        public void ChangeToAimCursor() => cursorHandler.ChangeToAimCursor();

        public CursorType GetCurrentCursorType() => cursorHandler.GetCurrentCursorType();
    }
}