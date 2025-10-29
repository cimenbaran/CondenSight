using UnityEngine;

namespace Condensight.Config
{
    [CreateAssetMenu(fileName="MeasurementModelConfig", menuName="Condensight/Config/Measurement")]
    public class MeasurementModelConfigSO : ScriptableObject {
        [Header("Observation noise (σ)")]
        public float measSigma = 0.3f;
    }
}