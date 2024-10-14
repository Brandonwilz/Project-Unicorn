using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using static Progress;

namespace MaskLayer
{
    public class LayerMaskBehaviour : MonoBehaviour {

        [SerializeField] private GameObject layerCurrent;
        [SerializeField] private GameObject layerAlternate;

        private Vector3 positionMaskOn;
        private Vector3 positionMaskOff;

        // Start is called before the first frame update
        void Start() {
            positionMaskOff = transform.position;

            if (layerCurrent != null) {
                positionMaskOn = layerCurrent.transform.position;
            }
            else {
                positionMaskOn = transform.position;
                positionMaskOn.y -= transform.position.y;
            }

            Progress.setFlag(State.layerMainActive, true);
            Progress.setFlag(State.layerOtherActive, false);

            setMaskInteractions();
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.S)) {
                StartCoroutine(switchLayers());
            }
        }

        public void setMaskInteractions() {
            SpriteRenderer[] sprites;

            if (layerCurrent != null) {
                sprites = layerCurrent.GetComponentsInChildren<SpriteRenderer>(true);
                for (int i = 0; i < sprites.Length; i++) {
                    sprites[i].maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
                }
            }

            if (layerAlternate != null) {
                sprites = layerAlternate.GetComponentsInChildren<SpriteRenderer>(true);
                for (int i = 0; i < sprites.Length; i++) {
                    sprites[i].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                }
            }

            gameObject.GetComponentInChildren<SpriteRenderer>(true).maskInteraction = SpriteMaskInteraction.None;
        }

        public IEnumerator switchLayers() {

            GameObject layerHold;

            if (layerCurrent != null && layerAlternate != null && !Progress.getFlag(State.layerSwitchingActive)) {
                layerAlternate.SetActive(true);

                toggleMaskOverTime(1f);

                // update flags
                if (Progress.getFlag(State.layerMainActive)) {
                    Progress.setFlag(State.layerMainActive, false);
                    Progress.setFlag(State.layerOtherActive, true);
                }
                else if (Progress.getFlag(Progress.State.layerOtherActive)) {
                    Progress.setFlag(State.layerOtherActive, false);
                    Progress.setFlag(State.layerMainActive, true);
                }

                yield return new WaitUntil(isSwitchComplete);

                // toggle which layer is active
                layerCurrent.SetActive(false);

                // swap references to main and alternate layers
                layerHold = layerCurrent;
                layerCurrent = layerAlternate;
                layerAlternate = layerHold;
            }


        }

        public bool isSwitchComplete() {
            return !Progress.getFlag(State.layerSwitchingActive);
        }

        // adapted from Lakeffect at the URL "https://discussions.unity.com/t/way-to-move-object-over-time/86379/3"
        // --
        public void toggleMaskOverTime(float time) {
            if (!Progress.getFlag(Progress.State.layerSwitchingActive)) {
                if (Progress.getFlag(Progress.State.layerMainActive)) {
                    Progress.setFlag(Progress.State.layerSwitchingActive, true);
                    StartCoroutine(MoveOverSeconds(this.gameObject, positionMaskOn, time));
                }
                else if (Progress.getFlag(Progress.State.layerOtherActive)) {
                    Progress.setFlag(Progress.State.layerSwitchingActive, true);
                    StartCoroutine(MoveOverSeconds(this.gameObject, positionMaskOff, time));
                }
            }
        }

        public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 positionEnd, float speed) {
            // speed should be 1 unit per second
            while (objectToMove.transform.position != positionEnd) {
                objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, positionEnd, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }

        public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds) {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            while (elapsedTime < seconds) {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.position = end;
            Progress.setFlag(Progress.State.layerSwitchingActive, false);
        }
        // --
    }
}
