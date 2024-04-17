using UnityEngine;

namespace Model2 {
    public class Game {
        public Level Level { get; private set; }
        public Vector2Int PlayerPosition { get; private set; }

        public Game(Level level) {
            this.Level = level;
            PlayerPosition = level.PlayerInitialPosition;
        }

        public void UpdateState(PlayerAction playerAction) {
            if (playerAction == PlayerAction.IDLE) return;
            
            var dir = Utils.PlayerActionToDirection(playerAction);
            var pos = PlayerPosition;
            while (Level.Tiles[pos + dir] != Tile.Wall) pos += dir;
            if (PlayerPosition != pos) {
                PlayerPosition = pos;
            }
        }
    }
}