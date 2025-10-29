using UnityEngine;

namespace CondenSight.Input
{
    public class TransformMeasurementSource : MonoBehaviour, IMeasurementSource {
        public Transform target;
        public Vector2 CurrentMeasurement() => target ? (Vector2)target.position : Vector2.zero;
    }
}