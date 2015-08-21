namespace Lubala.Dispatchers.Core
{
    internal abstract class TransformDecision<TContext, TResult> : DecisionBase<TContext, TResult>
    {
        private IDecision _nextDecision;
        public TransformDecision(IDecision nextDecision)
        {
            _nextDecision = nextDecision;
        }

        public override TResult Deciding(TContext context)
        {
            var convertedContext = (TContext)context;
            var processedContext = Transform(convertedContext);
            return (TResult)_nextDecision.Deciding(processedContext);
        }

        public abstract override bool IsSatisfied(TContext context);
        protected abstract TResult Transform(TContext context);
    }
}
