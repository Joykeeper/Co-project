using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Collections;

namespace Model2 {
    public class GamePresenter : MonoBehaviour {
        [SerializeField] Tilemap grid;
        [SerializeField] UnityEngine.Tilemaps.Tile grassTile;
        [SerializeField] UnityEngine.Tilemaps.Tile wallTile;
        [SerializeField] GameObject player;

        
        Dictionary<Tile, UnityEngine.Tilemaps.Tile> tiles = new();

        Vector2Int previousPos = Vector2Int.zero;

        public bool Animating = false;

        void Start()
        {
            tiles[Tile.Grass] = grassTile;
            tiles[Tile.Wall] = wallTile;
        }

        public void Present(Game game) {
            foreach (var (key, value) in game.Level.Tiles){
                grid.SetTile(new Vector3Int(key.x, key.y, 0), tiles[value]);
            }
            
            if (previousPos != game.PlayerPosition) {
                var target = new Vector3(game.PlayerPosition.x, game.PlayerPosition.y, 0) + new Vector3(0.5f, 0.5f, 0);
                var dist = (game.PlayerPosition - previousPos).magnitude;
                // 1 cell - 100ms
                // 10 cells - 1s
                StartCoroutine(MovePlayer(target, dist * 0.1f));
                previousPos = game.PlayerPosition;
            }
        }

        IEnumerator MovePlayer(Vector3 newPos, float time)
        {
            Animating = true;
            var oldPos = player.transform.position;
            float alpha = 0f;
            while (alpha < time)
            {
                alpha += Time.deltaTime;
                player.transform.position = Vector3.Lerp(oldPos, newPos, alpha / time);
                yield return null;
            }
            Animating = false;
        }
    }
}
