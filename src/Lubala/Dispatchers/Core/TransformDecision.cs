namespace Lubala.Dispatchers.Core
{
    public abstract class TransformDecision<TInContext, TOutContext> : IDecision
    {
        private IDecision _nextDecision;
        public TransformDecision(IDecision nextDecision)
        {
            _nextDecision = nextDecision;
        }

        public object Decide(object context)
        {
            var convertedContext = (TInContext) context;
            var processedContext = Transform(convertedContext);
            return _nextDecision.Decide(processedContext);
        }

        public abstract bool IsSatisfied(object context);
        protected abstract TOutContext Transform(TInContext context);
    }
}
