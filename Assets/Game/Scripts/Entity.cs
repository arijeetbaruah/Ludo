using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Entity : MonoBehaviour
    {
        public void StartTurn()
        {
            print($"Turn Start {name}");
        }
    }
}
