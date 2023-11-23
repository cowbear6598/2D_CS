using UnityEngine;

namespace Core.CursorSystem.DataAsset
{
    [CreateAssetMenu(fileName = "CursorAsset", menuName = "Data/CursorAsset", order = 0)]
    public class CursorAsset : ScriptableObject
    {
        public Texture2D normalCursor;
        public Texture2D aimCursor;
    }
}