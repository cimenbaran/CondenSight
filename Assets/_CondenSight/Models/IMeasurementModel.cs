using Condensight.Domain;
using UnityEngine;

namespace Condensight.Models
{
    public interface IMeasurementModel
    {

        void Update();
        
        // return unnormalized weight
        float Likelihood(in Particle p, in Vector2 z);
    }
}