using UnityEngine;
using System.Collections.Generic;

namespace Model2 {
    public class GameController : MonoBehaviour {
        [SerializeField] PCInputHandler inputHandler;
        [SerializeField] Level level;
        [SerializeField] GamePresenter gamePresenter;

        Game game;

        Queue<PlayerAction> actionQueue = new();

        void Start() {
            level.Generate();
            game = new Game(level);
        }

        void Update() {
            var playerAction = inputHandler.GetPlayerAction();
            if (playerAction != PlayerAction.IDLE) {
                actionQueue.Enqueue(playerAction);
            }
            if (gamePresenter.Animating) return;

            if (actionQueue.Count != 0) {
                var nextPlayerAction = actionQueue.Dequeue();
                game.UpdateState(nextPlayerAction);
            }

            gamePresenter.Present(game);
        }
    }
}