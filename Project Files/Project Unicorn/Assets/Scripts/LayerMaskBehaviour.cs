using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Layers;

namespace MaskLayer
{
    public class LayerMaskBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start() {
            Layers.maskLayerBehaviour = this;
        }

        // Update is called once per frame
        void Update() {

        }

        // adapted from Lakeffect at the URL "https://discussions.unity.com/t/way-to-move-object-over-time/86379/3"
        // --
        public void toggleMaskOverTime(float time) {
            if (!Progress.getFlag(Progress.State.layerSwitchingActive)) {
                if (Progress.getFlag(Progress.State.layerMainActive)) {
                    Progress.setFlag(Progress.State.layerSwitchingActive, true);
                    StartCoroutine(MoveOverSeconds(this.gameObject, POSITION_MASK_ON, time));
                }
                else if (Progress.getFlag(Progress.State.layerOtherActive)) {
                    Progress.setFlag(Progress.State.layerSwitchingActive, true);
                    StartCoroutine(MoveOverSeconds(this.gameObject, POSITION_MASK_OFF, time));
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
