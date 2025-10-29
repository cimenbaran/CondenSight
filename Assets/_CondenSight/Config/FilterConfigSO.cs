using UnityEngine;

namespace CondenSight.Config
{
    [CreateAssetMenu(fileName = "FilterConfig", menuName = "Condensight/Config/Filter")]
    public class FilterConfigSO : ScriptableObject
    {
        public int numParticles = 2000;
    }
}