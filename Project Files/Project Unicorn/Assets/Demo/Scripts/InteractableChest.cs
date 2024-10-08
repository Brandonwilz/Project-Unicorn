using ProjectUnicorn.InteractionSystem;

using UnityEngine;

/**
 * File: InteractableChest.cs
 * Description: A demo implementation of an interactable object.
 * Author: Bryan Sanchez (Tegomlee)
 * Date: 2024-09-20
 */

namespace ProjectUnicorn.Demo
{
    public class InteractableChest : MonoBehaviour, IInteractable
    {
        // This is a demo implementation of the interaction system in the form of a chest.
        public void Interact()
        {
            Debug.Log("You have opened the chest and found some stuff");
        }
    }
}
