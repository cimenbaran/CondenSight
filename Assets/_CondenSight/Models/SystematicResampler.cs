using Condensight.Domain;
using UnityEngine;

namespace Condensight.Models
{

    [CreateAssetMenu(fileName = "SystematicResampler", menuName = "Condensight/Resampler/Systematic")]
    public class SystematicResampler : ScriptableObject, IResampler
    {
        public void Resample(ref Particle[] P, IRandom rng)
        {
            int N = P.Length;
            var newP = new Particle[N];
            float step = 1f / N;
            float u = rng.Next01() * step;
            float c = P[0].weight;
            int i = 0;
            for (int m = 0; m < N; m++)
            {
                float U = u + m * step;
                while (U > c && i < N - 1)
                {
                    i++;
                    c += P[i].weight;
                }

                newP[m] = P[i];
                newP[m].weight = 1f / N;
            }

            P = newP;
        }
    }
}