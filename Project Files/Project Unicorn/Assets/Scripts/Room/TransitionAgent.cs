using ProjectUnicorn.InteractionSystem;

using System;

using UnityEngine;

namespace ProjectUnicorn.Room
{
    public class TransitionAgent : MonoBehaviour, IInteractable
    {
        // Created this class to represent an "array" that must explicitly contain a start and end position. This will prevent any breakage of the transition system put in place. -Tegomlee
        [Serializable]
        private struct RoomTransitionPoints
        {
            public TransitionController.TransitionPosition StartPosition;
            public TransitionController.TransitionPosition EndPosition;
        }

        public static event Action<TransitionController.TransitionPosition, TransitionController.TransitionPosition> OnRoomTransitionAnimation;

        [SerializeField] private RoomTransitionPoints _roomTransitionPoints;

        private void Start()
        {
            if (_roomTransitionPoints.StartPosition == TransitionController.TransitionPosition.Center
                && _roomTransitionPoints.EndPosition == TransitionController.TransitionPosition.Center)
            {
                Debug.LogWarning($"Transition Point [{gameObject.name}] was not set up with proper transitions.\n" +
                                 $"Please ensure that transitions have a start and end position selected.");
            }
        }

        public void Interact()
        {
            OnRoomTransitionAnimation?.Invoke(_roomTransitionPoints.StartPosition, _roomTransitionPoints.EndPosition);
        }
    }
}
