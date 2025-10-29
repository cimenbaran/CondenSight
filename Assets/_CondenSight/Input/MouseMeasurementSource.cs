using UnityEngine;

namespace CondenSight.Input
{
    public class MouseMeasurementSource : MonoBehaviour, IMeasurementSource {
        public Camera cam;
        void Awake(){ if (cam == null) cam = Camera.main; }
        public Vector2 CurrentMeasurement() {
            Vector3 w = cam.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            return new Vector2(w.x, w.y);
        }
    }
}