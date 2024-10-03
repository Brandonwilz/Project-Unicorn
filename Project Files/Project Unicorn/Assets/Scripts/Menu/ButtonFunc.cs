using System;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectUnicorn.Menu
{
    public class ButtonFunc : MonoBehaviour
    {
        public static event Action OnUnpause;
        public static event Action OnSettings;
        public static event Action OnExit;

        public void UnPause()
        {
            OnUnpause?.Invoke();
        }

        public void Settings()
        {
            OnSettings?.Invoke();
        }

        public void Exit()
        {
            OnExit?.Invoke();
        }

        public void Play()
        {
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Single); // This is just for testing puposes, Ideally it would be using the scene index instead for safety. -Tegomlee
        }
    }
}
