using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Field : MonoBehaviour
{

    public Tilemap grid;
    public Tile wall;
    public Tile grass;
    public Tile redWall;
    public Tile redButton;
    private Vector2Int size;
    private Dictionary<Vector2Int, Tile> map = new Dictionary<Vector2Int, Tile>();

    public void Start(){
        this.size = new Vector2Int(10, 10);
        for (var i = 0; i < this.size.y; i++){
            for (var j = 0; j < this.size.x; j++){
                if (i == 0 || j == 0 || i == this.size.y-1 || j == this.size.x-1){
                    map[new Vector2Int(j, i)] = wall;
                } else {
                    map[new Vector2Int(j, i)] = grass;
                }
            }
        }
        DrawMap();
    }

    public Vector2Int getSize(){
        return size;
    }

    private void DrawMap(){    
        map[new Vector2Int(6, 7)] = wall;
        map[new Vector2Int(6, 8)] = wall;
        map[new Vector2Int(6, 9)] = wall;
        map[new Vector2Int(5, 9)] = wall;
        map[new Vector2Int(5, 3)] = wall;
        map[new Vector2Int(6, 3)] = wall;
        map[new Vector2Int(7, 3)] = wall;
        map[new Vector2Int(8, 3)] = wall;
        map[new Vector2Int(9, 3)] = wall;

        foreach (var tile in map){
            grid.SetTile(new Vector3Int(tile.Key.x, tile.Key.y, 0), tile.Value);
        }

        
    }

    public Dictionary<Vector2Int, Tile> getMap(){
        return this.map;
    }
}
