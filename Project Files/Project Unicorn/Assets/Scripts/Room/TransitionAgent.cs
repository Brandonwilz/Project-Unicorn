using ProjectUnicorn.InteractionSystem;

using System;

using UnityEngine;

namespace ProjectUnicorn.Room
{
    public class TransitionAgent : MonoBehaviour, IInteractable
    {
        // Created this class to represent an "array" that must explicitly contain a start and end position. This will prevent any breakage of the transition system put in place. -Tegomlee
        [Serializable]
        private class RoomTransitionPoints
        {
            public TransitionController.TransitionPosition StartPosition;
            public TransitionController.TransitionPosition EndPosition;
        }

        public static event Action<TransitionController.TransitionPosition, TransitionController.TransitionPosition> OnRoomChanged;

        [SerializeField] private RoomTransitionPoints _roomTransitionPoints;

        public void Interact()
        {
            OnRoomChanged?.Invoke(_roomTransitionPoints.StartPosition, _roomTransitionPoints.EndPosition);
        }
    }
}
