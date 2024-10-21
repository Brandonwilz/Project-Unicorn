using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using static Progress;

namespace MaskLayer
{
    public class LayerMask : MonoBehaviour {

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

                StartCoroutine(toggleMaskOverTime(1f));

                // update flags
                if (Progress.getFlag(State.layerMainActive)) {
                    Progress.setFlag(State.layerMainActive, false);
                    Progress.setFlag(State.layerOtherActive, true);
                }
                else if (Progress.getFlag(Progress.State.layerOtherActive)) {
                    Progress.setFlag(State.layerOtherActive, false);
                    Progress.setFlag(State.layerMainActive, true);
                }

                yield return new WaitWhile(() => Progress.getFlag(State.layerSwitchingActive));

                // toggle which layer is active
                layerCurrent.SetActive(false);

                // swap references to main and alternate layers
                layerHold = layerCurrent;
                layerCurrent = layerAlternate;
                layerAlternate = layerHold;
            }


        }

        public IEnumerator toggleMaskOverTime(float time) {
            Functions.Bool isComplete = new Functions.Bool();
            if (!Progress.getFlag(Progress.State.layerSwitchingActive)) {
                if (Progress.getFlag(Progress.State.layerMainActive)) {
                    Progress.setFlag(Progress.State.layerSwitchingActive, true);
                    StartCoroutine(Functions.MoveOverSeconds(this.gameObject, positionMaskOn, time, isComplete));
                    yield return new WaitUntil(() => isComplete.value);
                    Progress.setFlag(Progress.State.layerSwitchingActive, false);
                }
                else if (Progress.getFlag(Progress.State.layerOtherActive)) {
                    Progress.setFlag(Progress.State.layerSwitchingActive, true);
                    StartCoroutine(Functions.MoveOverSeconds(this.gameObject, positionMaskOff, time, isComplete));
                    yield return new WaitUntil(() => isComplete.value);
                    Progress.setFlag(Progress.State.layerSwitchingActive, false);
                }
            }
        }
    }
}
