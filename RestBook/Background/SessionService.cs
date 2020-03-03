using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestBook.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestBook.Background
{
    public class SessionService : BackgroundService
    {
        private readonly IServiceProvider m_provider; 

        private static readonly TimeSpan m_session_timeout = TimeSpan.FromHours(1);

        public SessionService(IServiceProvider serviceProvider)
        {
            m_provider = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            for (TimeSpan waitTime = m_session_timeout; !stoppingToken.IsCancellationRequested; await Task.Delay(waitTime, stoppingToken))
            {
                using (IServiceScope scope = m_provider.CreateScope())
                {
                    IAccessTokenService ts = scope.ServiceProvider.GetRequiredService<IAccessTokenService>();
                    await ts.ReleaseExpiredTokens(100);
                }
            }
        }
    }
}
