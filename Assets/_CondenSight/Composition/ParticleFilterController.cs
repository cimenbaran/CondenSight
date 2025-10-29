using CondenSight.Config;
using Condensight.Core;
using Condensight.Domain;
using CondenSight.Input;
using Condensight.Models;
using Condensight.View;
using UnityEngine;

namespace Condensight.Composition {
    public class ParticleFilterController : MonoBehaviour {
        [Header("Configs & Strategies")]
        public FilterConfigSO filterConfig;
        public ConstantVelocityMotion motion;
        public PointDistanceGaussianMeasurement measurement;
        public SystematicResampler resampler;

        [Header("Scene References")]
        public MonoBehaviour measurementSourceBehaviour; // IMeasurementSource
        public InstancedMeshRenderer particleRenderer;

        [Header("Simulation")]
        [Tooltip("Multiplier for simulated time. 1 = real-time, 0.1 = 10× slower, 2 = 2× faster, 0 = pause.")]
        [Range(0f, 10f)]
        public float simulationTimeScale = 1f;
        
        private IMeasurementSource _source;
        private IParticleFilter _filter;
        private IRandom _rng;

        private float _lastTime;

        void Awake() {
            _source = measurementSourceBehaviour as IMeasurementSource;
            _rng = new GaussianRandom(123);

            // DI by hand (no framework necessary)
            _filter = new ParticleFilter(motion, measurement, resampler, _rng);

            _filter.Initialize(filterConfig.numParticles, () => new Particle {
                pos = Random.insideUnitCircle * 2f,
                vel = Vector2.zero,
                weight = 1f / filterConfig.numParticles
            });

            _lastTime = Time.time;
        }

        void Update() {
            float now = Time.time;
            float dtReal = Mathf.Max(1e-4f, now - _lastTime);
            _lastTime = now;

            float dt = dtReal * simulationTimeScale;
            
            Vector2 z = _source != null ? _source.CurrentMeasurement() : Vector2.zero;
            _filter.Update();
            
            _filter.Predict(dt);
            _filter.Weight(z);
            _filter.Normalize();
            _filter.Resample();

            particleRenderer?.Render(_filter.Particles);
            particleRenderer?.RenderEstimate(_filter.Estimate());
        }
    }
}