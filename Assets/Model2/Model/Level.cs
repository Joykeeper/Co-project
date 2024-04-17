using System.Collections.Generic;
using UnityEngine;

namespace Model2 {
    [CreateAssetMenu(fileName="New level", menuName="Game/Level")]
    public class Level : ScriptableObject {
        public Dictionary<Vector2Int, Tile> Tiles;
        public Vector2Int PlayerInitialPosition;

        public void Generate()
        {
            Tiles = new Dictionary<Vector2Int, Tile>();
            PlayerInitialPosition = new Vector2Int(1, 1);
            
            var size = new Vector2Int(10, 10);
            for (var i = 0; i < size.y; i++){
                for (var j = 0; j < size.x; j++){
                    if (i == 0 || j == 0 || i == size.y-1 || j == size.x-1){
                        Tiles[new Vector2Int(j, i)] = Tile.Wall;
                    } else {
                        Tiles[new Vector2Int(j, i)] = Tile.Grass;
                    }
                }
            }
            
            Tiles[new Vector2Int(6, 7)] = Tile.Wall;
            Tiles[new Vector2Int(6, 8)] = Tile.Wall;
            Tiles[new Vector2Int(6, 9)] = Tile.Wall;
            Tiles[new Vector2Int(5, 9)] = Tile.Wall;
            Tiles[new Vector2Int(5, 3)] = Tile.Wall;
            Tiles[new Vector2Int(6, 3)] = Tile.Wall;
            Tiles[new Vector2Int(7, 3)] = Tile.Wall;
            Tiles[new Vector2Int(8, 3)] = Tile.Wall;
            Tiles[new Vector2Int(9, 3)] = Tile.Wall;
        }
    }
}