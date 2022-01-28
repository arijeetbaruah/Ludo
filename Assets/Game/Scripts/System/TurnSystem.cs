using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Pun.UtilityScripts;

namespace Game.System
{
    public class TurnSystem : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Entity[] entities;
        
        private int currentEntity = 0;

        private void Start()
        {
            entities[currentEntity].StartTurn();
        }

        public void NextTurn()
        {
            if (currentEntity != entities.Length - 1)
            {
                currentEntity++;
            }
            else
            {
                currentEntity = 0;
            }
            entities[currentEntity].StartTurn();
        }
    }
}
