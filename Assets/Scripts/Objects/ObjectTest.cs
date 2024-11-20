using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

namespace Objects
{
    public class ObjectTest : MonoBehaviour
    {
        [Header("Test")]
        public ObjectLights objectLights;

        private void Start()
        {
            if (objectLights != null)
            {
                objectLights.ExecuteRandomAction();
            }
        }
    }
}

