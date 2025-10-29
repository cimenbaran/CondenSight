using UnityEngine;

namespace Condensight.Domain {
    [System.Serializable]
    public struct Particle {
        public Vector2 pos;
        public Vector2 vel;
        public float weight;
    }
}