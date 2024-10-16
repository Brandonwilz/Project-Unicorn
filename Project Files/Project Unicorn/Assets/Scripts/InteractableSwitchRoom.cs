using ProjectUnicorn.InteractionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static RoomController;

public class InteractableSwitchRoom : MonoBehaviour, Interactable {
    [SerializeField] GameObject roomDestination;
    [SerializeField] GameObject positionDestination;
    [SerializeField] RoomController roomController;

    public void Interact() {
        roomController.switchRoom(roomDestination, positionDestination);
    }
}
