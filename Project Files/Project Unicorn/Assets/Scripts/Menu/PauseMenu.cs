using UnityEngine;

namespace ProjectUnicorn.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;

        private bool _isPaused = false;

        private void OnEnable()
        {
            ButtonFunc.OnUnpause += SetPauseState;
        }

        private void OnDisable()
        {
            ButtonFunc.OnUnpause -= SetPauseState;
        }

        private void Start()
        {
            _pauseMenu.SetActive(false);
            _isPaused = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPauseState();
            }
        }

        private void SetPauseState()
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                Time.timeScale = 0.0f;
                _pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                _pauseMenu.SetActive(false);
            }
        }
    }
}
