using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UIElements;


public enum PlayerAction{
    M_RIGHT, M_LEFT, M_TOP, M_BOTTOM, IDLE
}

public class Game : MonoBehaviour
{
    public Field field;
    public Player player;

    private PlayerAction playerAction = PlayerAction.IDLE;

    private Vector2Int RIGHT = new Vector2Int(1, 0);
    private Vector2Int LEFT = new Vector2Int(-1, 0);
    private Vector2Int UP = new Vector2Int(0, 1);
    private Vector2Int DOWN = new Vector2Int(0, -1);

    void Start(){
        player.setPosition(new Vector2Int(1,1));
    }

    void Update() {
        Debug.Log(player.getPosition());

        updateState();

        if (playerAction != PlayerAction.IDLE){
            return;
        }


        if (Input.GetKeyDown("w")){
            playerAction = PlayerAction.M_TOP;
        }
        if (Input.GetKeyDown("a")){
           playerAction = PlayerAction.M_LEFT;
        }  
        if (Input.GetKeyDown("s")){
            playerAction = PlayerAction.M_BOTTOM;
        }  
        if (Input.GetKeyDown("d")){
           playerAction = PlayerAction.M_RIGHT;
        }  
        
    }
    public void updateState(){
        
        if(isActionPossible(playerAction) == false) {
            playerAction = PlayerAction.IDLE;
            return;
        }

        switch(playerAction){
            case PlayerAction.M_RIGHT:
                player.setPosition(player.getPosition() + RIGHT);
                break; 
            case PlayerAction.M_LEFT:
                player.setPosition(player.getPosition() + LEFT);
                break;
            case PlayerAction.M_TOP:
                player.setPosition(player.getPosition() + UP);
                break;
            case PlayerAction.M_BOTTOM:
                player.setPosition(player.getPosition() + DOWN);
                break;
        }
    }

    public bool isActionPossible(PlayerAction action){
        //check map border
        /*
        switch(action){
            case PlayerAction.M_RIGHT:
                if((player.getPosition() + RIGHT).x >= field.getSize().x){
                    return false;
                }
                break; 
            case PlayerAction.M_LEFT:
                if((player.getPosition() + LEFT).x < 0){
                    return false;
                }
                break;
            case PlayerAction.M_TOP:
                if((player.getPosition() + UP).y >= field.getSize().y){
                    return false;
                }
                break;
            case PlayerAction.M_BOTTOM:
                if((player.getPosition() + DOWN).y < 0){
                    return false;
                }
                break;
        }
*/
        // check walls
        switch(action){
            case PlayerAction.M_RIGHT:
                if(isWall(RIGHT)){
                    return false;
                }
                break; 
            case PlayerAction.M_LEFT:
                if(isWall(LEFT)){
                    return false;
                }
                break;
            case PlayerAction.M_TOP:
                if(isWall(UP)){
                    return false;
                }
                break;
            case PlayerAction.M_BOTTOM:
                if(isWall(DOWN)){
                    return false;
                }
                break;
        }


        return true;
    }

    public bool isWall(Vector2Int dir){
        if(field.getMap()[player.getPosition() + dir] == field.wall){
            return true;
        }
        return false;
    }
}
