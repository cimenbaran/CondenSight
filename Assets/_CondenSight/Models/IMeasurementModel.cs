using Condensight.Domain;
using UnityEngine;

namespace Condensight.Models
{
    public interface IMeasurementModel
    {
        // return unnormalized weight
        float Likelihood(in Particle p, in Vector2 z);
    }
}