using Core.CursorSystem.Handler;

namespace Core.CursorSystem.Interface
{
    public interface ICursorService
    {
        void ChangeToNormalCursor();
        void ChangeToAimCursor();
        CursorType GetCurrentCursorType();
    }
}