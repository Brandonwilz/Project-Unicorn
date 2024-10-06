using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectUnicorn.SceneManagement
{
    public class PlayerPositioner : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneLoader.OnPlayerPositionChange += ChangePosition;
        }

        private void OnDisable()
        {
            SceneLoader.OnPlayerPositionChange -= ChangePosition;
        }

        private void OnDestroy()
        {
            SceneLoader.OnPlayerPositionChange -= ChangePosition;
        }

        private void ChangePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }
    }
}
