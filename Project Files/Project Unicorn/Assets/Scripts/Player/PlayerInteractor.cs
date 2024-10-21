using ProjectUnicorn.InteractionSystem;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/**
 * File: PlayerInteractor.cs
 * Description: Holds the logic for detecting interactable objects and calling thier interact function.
 *              In the case of 2 or more eligible objects, decide by determining the least amount of distance.
 * Author: Bryan Sanchez (Tegomlee)
 * Date: 2024-09-20
 */

// modified by maalmo234

namespace ProjectUnicorn.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        // added
        static public PlayerInteractor playerInteractorCurrent;

        [SerializeField] private float _radius = 1f;

        // added
        //----------------------------------------------------------------------
        [SerializeField] private LayerMask _interactableLayer;
        [SerializeField] private GameObject _interactionUI;
        [SerializeField] private LabelInteract _label;

        public GameObject _currentInteractableObject = null;
        private Collider2D _interactableCollider = null;
        private bool _isInteractiveUIActive = false;

        private void Start() {
            if(_label != null) {
                _label.setActive(false);
            }
        }
        //----------------------------------------------------------------------

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                ActivateInteractable();

            // added
            //----------------------------------------------------------------------
            if (_label != null) {
                _interactableCollider = GetInteractable();
                if (_interactableCollider != null) {
                    if (_interactableCollider.gameObject != _currentInteractableObject) {
                        _label.setPosition(_interactableCollider.gameObject.transform.position);
                        _label.setActive(true);
                        _currentInteractableObject = _interactableCollider.gameObject;
                        Inventory.inventoryCurrent.setVisible(false);
                    }
                }
                else {
                    if(_currentInteractableObject != null) {
                        Inventory.inventoryCurrent.setVisible(false);
                    }
                    _label.setActive(false);
                    _currentInteractableObject = null;
                }
            
            if (_isInteractiveUIActive && GetInteractable() == null )
            {
                _isInteractiveUIActive = false;
                _interactionUI.SetActive(false);
            }
            //----------------------------------------------------------------------
        }

        private void ActivateInteractable()
        {
            // Detect any interactables, if more than one choose the one closest to the player
            var currentInteractable = GetInteractable();

            // Stop the interaction if no available object is found
            if (currentInteractable == null) return;

            // Activate thier Interact() function
            if (currentInteractable.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact();
            }
            else // Should never happen, but better to catch an error and deal with it than not. -Bryan
            {
                Debug.LogWarning($"{this.name}: function ActivateInteractable() found {currentInteractable.name} but holds no IInteractable implementation.");
            }
        }

        private Collider2D GetInteractable()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _interactableLayer);
            
            if (colliders.Length == 0) return null; // return null if the array is empty

            Collider2D closestCollider = null;
            float closestDistance = Mathf.Infinity;

            // Iterate through each collider looking for the one closest to the player
            foreach (Collider2D collider in colliders)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestCollider = collider;
                    closestDistance = distance;
                }
            }

            return closestCollider;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
