using Condensight.Domain;
using Condensight.Models;
using UnityEngine;

namespace Condensight.Core
{
    public sealed class ParticleFilter : IParticleFilter {
        private Particle[] _P;
        private readonly IMotionModel _motion;
        private readonly IMeasurementModel _meas;
        private readonly IResampler _resampler;
        private readonly IRandom _rng;

        public Particle[] Particles => _P;

        public ParticleFilter(IMotionModel motion, IMeasurementModel meas, IResampler resampler, IRandom rng) {
            _motion = motion; _meas = meas; _resampler = resampler; _rng = rng;
        }

        public void Initialize(int count, System.Func<Particle> initFn) {
            _P = new Particle[count];
            for (int i = 0; i < count; i++) _P[i] = initFn();
        }

        public void Predict(float dt) {
            for (int i = 0; i < _P.Length; i++) _motion.Predict(ref _P[i], dt, _rng);
        }

        public void Weight(Vector2 z) {
            for (int i = 0; i < _P.Length; i++) _P[i].weight = _meas.Likelihood(_P[i], z);
        }

        public void Normalize() {
            float sum = 0f; for (int i = 0; i < _P.Length; i++) sum += _P[i].weight;
            if (sum <= 1e-12f) { float u = 1f / _P.Length; for (int i=0;i<_P.Length;i++) _P[i].weight = u; return; }
            float inv = 1f / sum; for (int i = 0; i < _P.Length; i++) _P[i].weight *= inv;
        }

        public void Resample() => _resampler.Resample(ref _P, _rng);

        public Vector2 Estimate() {
            Vector2 mu = Vector2.zero;
            for (int i = 0; i < _P.Length; i++) mu += _P[i].pos * _P[i].weight;
            return mu;
        }
    }
}