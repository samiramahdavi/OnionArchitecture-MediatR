﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace OnionArchitecture.Service.Middleware
{
    public class TransactionBehaviorMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse> where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using (var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                TResponse response = await next();

                transaction.Complete();

                return response;
            }
        }
    }

}
