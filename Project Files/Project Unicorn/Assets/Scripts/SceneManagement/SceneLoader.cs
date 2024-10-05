using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectUnicorn.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        public enum AnimationType
        {
            FromBottom,
            FromTop,
            FromLeft,
            FromRight,
            ToBottom,
            ToTop,
            ToLeft,
            ToRight,
        }

        [Serializable]
        private class AnimationProperties
        {
            public string AnimatorTriggerName;
            public AnimationType AnimationType;
        }

        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationProperties[] _animationProperties = new AnimationProperties[8];

        private void Awake()
        {
            // Search for other objects of the same type in the heirarchy and Destroy itself it one is already present.
            GameObject[] existingTransitions = GameObject.FindGameObjectsWithTag("SceneTransition");
            if (existingTransitions.Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }

            SceneSwitcher.OnSceneLoaded += LoadNewScene;
        }

        private void OnDestroy()
        {
            SceneSwitcher.OnSceneLoaded -= LoadNewScene;
        }

        private void LoadNewScene(string newSceneName, AnimationType fromType, AnimationType toType)
        {
            StartCoroutine(TransitionToScene(newSceneName, fromType, toType));
        }

        private IEnumerator TransitionToScene(string sceneName, AnimationType fromType, AnimationType toType)
        {
            string fromTrigger = GetAnimatorTriggerFrom(fromType);
            _animator.SetTrigger(fromTrigger);

            Debug.Log(fromTrigger);
            Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).IsName(fromTrigger));

            yield return new WaitForSeconds(GetAnimationStateLength(fromTrigger));

            SceneManager.LoadSceneAsync(sceneName);

            string toTrigger = GetAnimatorTriggerFrom(toType);
            _animator.SetTrigger(toTrigger);

            Debug.Log(toTrigger);
            Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).IsName(toTrigger));
        }

        private string GetAnimatorTriggerFrom(AnimationType animationType)
        {
            foreach (var property in _animationProperties)
            {
                if (property.AnimationType == animationType)
                {
                    return property.AnimatorTriggerName;
                }
            }
            Debug.LogError("No matching animation trigger found for: " + animationType);
            return string.Empty;
        }

        private float GetAnimationStateLength(string triggerName)
        {
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.length;
        }
    }
}
