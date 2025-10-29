using Condensight.Config;
using Condensight.Domain;
using UnityEngine;


namespace Condensight.Models
{
    [CreateAssetMenu(fileName="GaussianPointMeasurement", menuName="Condensight/Measurement/GaussianPoint")]
    public class PointDistanceGaussianMeasurement : ScriptableObject, IMeasurementModel {
        public MeasurementModelConfigSO config;

        private float inv2Sigma2;
        public void Update()
        {
            // Use Update to recalculate inv2sigma2 value at the start of the frame
            
            inv2Sigma2 = 1f / (2f * config.measSigma * config.measSigma);
        }

        public float Likelihood(in Particle p, in Vector2 z) {
            float d2 = (p.pos - z).sqrMagnitude;
            // float inv2Sigma2 = 1f / (2f * config.measSigma * config.measSigma);
            return Mathf.Exp(-d2 * inv2Sigma2);
        }
    }
}