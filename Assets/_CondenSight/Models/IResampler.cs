using Condensight.Domain;

namespace Condensight.Models {
    public interface IResampler {
        void Resample(ref Particle[] particles, IRandom rng);
    }
}