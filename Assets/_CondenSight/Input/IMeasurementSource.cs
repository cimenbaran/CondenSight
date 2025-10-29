using UnityEngine;

namespace CondenSight.Input
{
    public interface IMeasurementSource {
        Vector2 CurrentMeasurement();
    }
}