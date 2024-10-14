using DG.Tweening;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ProjectUnicorn.Room
{
    public class TransitionController : MonoBehaviour
    {
        public enum TransitionPosition
        {
            Center,
            Top,
            Bottom,
            Left,
            Right
        }

        [SerializeField] private Image _transitionBox;

        private readonly Dictionary<TransitionPosition, Vector2> _transitionBoxPositions = new Dictionary<TransitionPosition, Vector2>() 
        {
            { TransitionPosition.Center, Vector2.zero },
            { TransitionPosition.Top, new Vector2(0, 1000) },
            { TransitionPosition.Bottom, new Vector2(0, -1000) },
            { TransitionPosition.Left, new Vector2(-1500, 0) },
            { TransitionPosition.Right, new Vector2(1500, 0) }
        };

        private Coroutine _roomChangedCoroutine;

        private void Awake()
        {
            TransitionAgent.OnRoomTransitionAnimation += StartTransitionFromTo;
        }

        private void OnDestroy()
        {
            TransitionAgent.OnRoomTransitionAnimation -= StartTransitionFromTo;
        }

        private void OnDisable()
        {
            TransitionAgent.OnRoomTransitionAnimation -= StartTransitionFromTo;
        }

        private void Start()
        {
            _transitionBox.rectTransform.anchoredPosition = GetPositionFromEnum(TransitionPosition.Top);
        }

        private void StartTransitionFromTo(TransitionPosition start, TransitionPosition end)
        {
            var startPosition = GetPositionFromEnum(start);
            var endPosition = GetPositionFromEnum(end);

            if (_roomChangedCoroutine != null)
            {
                StopCoroutine(_roomChangedCoroutine);
            }

            _roomChangedCoroutine = StartCoroutine(TransitionRoom(startPosition, endPosition));
        }

        private IEnumerator TransitionRoom(Vector2 startPosition, Vector2 endPosition)
        {
            var centerPosition = GetPositionFromEnum(TransitionPosition.Center);

            _transitionBox.rectTransform.anchoredPosition = startPosition;
            _transitionBox.rectTransform.DOAnchorPos(centerPosition, 1.0f); // OnComplete() Research.

            yield return new WaitForSeconds(1);

            // Invoke any room changing events


            _transitionBox.rectTransform.DOAnchorPos(endPosition, 1.0f);

            yield return new WaitForSeconds(1);
        }

        private Vector2 GetPositionFromEnum(TransitionPosition transitionPosition)
        {
            if (_transitionBoxPositions.TryGetValue(transitionPosition, out Vector2 position))
            {
                return position;
            }
            else
            {
                Debug.LogError($"TransitionPosition {transitionPosition} not found!");
                return Vector2.zero;
            }
        }
    }
}
