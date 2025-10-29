using Condensight.Domain;
using UnityEngine;

namespace Condensight.Models {
    public interface IMotionModel {
        void Predict(ref Particle p, float dt, IRandom rng);
    }
}