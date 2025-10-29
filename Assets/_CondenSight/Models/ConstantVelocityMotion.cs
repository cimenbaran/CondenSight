using Condensight.Config;
using Condensight.Domain;
using UnityEngine;

namespace Condensight.Models
{
    [CreateAssetMenu(fileName="ConstantVelocityMotion", menuName="Condensight/Motion/ConstantVelocity")]
    public class ConstantVelocityMotion : ScriptableObject, IMotionModel {
        public MotionModelConfigSO config;
        public void Predict(ref Particle p, float dt, IRandom rng) {
            p.pos += p.vel * dt;
            p.vel += new Vector2(
                rng.NextGaussian(0f, config.velSigma),
                rng.NextGaussian(0f, config.velSigma)
            );
            p.pos += new Vector2(
                rng.NextGaussian(0f, config.posSigma),
                rng.NextGaussian(0f, config.posSigma)
            );
        }
    }
}