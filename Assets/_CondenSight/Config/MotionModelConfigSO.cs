using UnityEngine;

namespace Condensight.Config
{
    [CreateAssetMenu(fileName="MotionModelConfig", menuName="Condensight/Config/Motion")]
    public class MotionModelConfigSO : ScriptableObject {
        [Header("Process noise (σ)")]
        public float posSigma = 0.05f;
        public float velSigma = 0.02f;
    }
}