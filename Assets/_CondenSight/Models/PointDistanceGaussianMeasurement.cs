using Condensight.Config;
using Condensight.Domain;
using UnityEngine;


namespace Condensight.Models
{
    [CreateAssetMenu(fileName="GaussianPointMeasurement", menuName="Condensight/Measurement/GaussianPoint")]
    public class PointDistanceGaussianMeasurement : ScriptableObject, IMeasurementModel {
        public MeasurementModelConfigSO config;
        public float Likelihood(in Particle p, in Vector2 z) {
            float d2 = (p.pos - z).sqrMagnitude;
            float inv2Sigma2 = 1f / (2f * config.measSigma * config.measSigma);
            return Mathf.Exp(-d2 * inv2Sigma2);
        }
    }
}