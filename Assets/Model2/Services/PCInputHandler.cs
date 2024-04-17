using UnityEngine;

namespace Model2 {
    public class PCInputHandler : MonoBehaviour, IInputHandler {
        public PlayerAction GetPlayerAction() {
            if (Input.GetKeyDown("w")){
                return PlayerAction.M_UP;
            }
            if (Input.GetKeyDown("a")){
                return PlayerAction.M_LEFT;
            }  
            if (Input.GetKeyDown("s")){
                return PlayerAction.M_DOWN;
            }  
            if (Input.GetKeyDown("d")){
                return PlayerAction.M_RIGHT;
            }
            return PlayerAction.IDLE;
        }
    }
}