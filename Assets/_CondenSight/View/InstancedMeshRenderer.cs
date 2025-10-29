using Condensight.Domain;
using UnityEngine;

namespace Condensight.View {
    public class InstancedMeshRenderer : MonoBehaviour, IParticleRenderer {
        public Mesh mesh;
        public Material material;
        public float scale = 0.05f;

        private Matrix4x4[] _batch = new Matrix4x4[1023];

        public void Render(Particle[] particles) {
            if (mesh == null || material == null || particles == null) return;
            int remaining = particles.Length;
            int offset = 0;
            while (remaining > 0) {
                int count = Mathf.Min(remaining, 1023);
                for (int i = 0; i < count; i++) {
                    var p = particles[offset + i].pos;
                    _batch[i] = Matrix4x4.TRS(new Vector3(p.x, p.y, 0f), Quaternion.identity, Vector3.one * scale);
                }
                Graphics.DrawMeshInstanced(mesh, 0, material, _batch, count);
                remaining -= count; offset += count;
            }
        }

        public void RenderEstimate(Vector2 mu) {
            Debug.DrawLine(new Vector3(mu.x-0.1f, mu.y, 0), new Vector3(mu.x+0.1f, mu.y, 0));
            Debug.DrawLine(new Vector3(mu.x, mu.y-0.1f, 0), new Vector3(mu.x, mu.y+0.1f, 0));
        }
    }
}