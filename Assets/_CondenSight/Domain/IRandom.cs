namespace Condensight.Domain
{
    public interface IRandom
    {
        float Next01();
        float NextGaussian(float mean = 0f, float sigma = 1f); // Box–Muller
    }
}