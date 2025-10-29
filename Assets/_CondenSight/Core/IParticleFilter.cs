using Condensight.Domain;
using UnityEngine;

namespace Condensight.Core
{
    public interface IParticleFilter
    {
        // Use Update to recalculate static values in a single frame 
        
        void Update();
        void Initialize(int count, System.Func<Particle> initFn);
        void Predict(float dt);
        void Weight(Vector2 measurement);
        void Normalize();
        void Resample();
        Vector2 Estimate();
        Particle[] Particles { get; }
    }
}
