using UnityEngine;

namespace Model2 {
    public static class Utils {
        public static Vector2Int PlayerActionToDirection(PlayerAction action) {
            switch (action) {
                case PlayerAction.M_LEFT: return -Vector2Int.right;
                case PlayerAction.M_RIGHT: return Vector2Int.right;
                case PlayerAction.M_UP: return Vector2Int.up;
                case PlayerAction.M_DOWN: return -Vector2Int.up;
                default: return Vector2Int.zero;
            }
        }
    }
}