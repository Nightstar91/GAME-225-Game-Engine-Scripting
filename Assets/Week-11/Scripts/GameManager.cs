using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Week11
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public UnityEvent gameResetEvent;

        GameObject barrelTrapPrefab;
        GameObject coinPrefab;
        GameObject keyPrefab;

        private void Awake()
        {
            instance = this;
        }

        [ContextMenu("Test Reset")]
        public void OnGameReset() 
        {
            gameResetEvent.Invoke();
        }

        public static UnityEvent GetGameResetEvent()
        {
            return instance.gameResetEvent;
        }
    }
}
