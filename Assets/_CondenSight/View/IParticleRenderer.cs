using Condensight.Domain;
using UnityEngine;

namespace Condensight.View {
    public interface IParticleRenderer {
        void Render(Particle[] particles);
        void RenderEstimate(Vector2 estimate);
    }
}