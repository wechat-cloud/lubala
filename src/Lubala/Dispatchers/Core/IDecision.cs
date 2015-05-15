namespace Lubala.Dispatchers.Core
{
    public interface IDecision
    {
        object Decide(object context);
        bool IsSatisfied(object context);
    }
}
