using ProjectUnicorn.InteractionSystem;

using System;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectUnicorn.SceneManagement
{
    public class SceneSwitcher : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _sceneToLoadName;
        [SerializeField] private SceneLoader.AnimationType[] _animationType = new SceneLoader.AnimationType[2];

        [SerializeField] private Vector2 _playerPositionInNewScene;

        public static event Action<string, SceneLoader.AnimationType, SceneLoader.AnimationType, Vector2> OnSceneLoaded;

        public void Interact()
        {
            OnSceneLoaded?.Invoke(_sceneToLoadName, _animationType[0], _animationType[1], _playerPositionInNewScene);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                OnSceneLoaded?.Invoke(_sceneToLoadName, _animationType[0], _animationType[1], _playerPositionInNewScene);
            }
        }
    }
}
