using UnityEngine;

namespace Condensight.Domain {
    public sealed class GaussianRandom : IRandom {
        private System.Random _rng;
        public GaussianRandom(int seed = 123) => _rng = new System.Random(seed);

        public float Next01() => (float)_rng.NextDouble();

        public float NextGaussian(float mean = 0f, float sigma = 1f) {
            // Box–Muller
            float u1 = System.Math.Max(1e-7f, Next01());
            float u2 = Next01();
            float r = (float)System.Math.Sqrt(-2.0 * System.Math.Log(u1));
            float theta = 2f * Mathf.PI * u2;
            return mean + sigma * r * Mathf.Cos(theta);
        }
    }
}