using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2Int getPosition(){
        return new Vector2Int((int)(transform.position.x-0.5f), (int) (transform.position.y-0.5f));
    }
    public void setPosition(Vector2Int position){
        transform.position = new Vector3(position.x, position.y, 0) + new Vector3(0.5f, 0.5f, 0);
    }
}
