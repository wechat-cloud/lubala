namespace Lubala.Dispatchers.Core
{
    public interface IDecision
    {
        object Deciding(object context);
        bool IsSatisfied(object context);
    }
}
