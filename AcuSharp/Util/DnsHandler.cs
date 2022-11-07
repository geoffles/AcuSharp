using DnsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AcuSharp.Util
{
    public class DnsHandler : HttpClientHandler
    {
        private readonly IPEndPoint _targetDnsServer;
        private readonly LookupClient _lookupClient;

        public DnsHandler(IPEndPoint targetDnsServer= null)
        {
            if (targetDnsServer == null)
            {
                _targetDnsServer = NameServer.GooglePublicDns;
            }

            _lookupClient = new LookupClient(targetDnsServer);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var host = request.RequestUri.Host;
            var ip = _lookupClient.GetHostEntry(host);

            var builder = new UriBuilder(request.RequestUri);
            var targetAddress = ip.AddressList.FirstOrDefault();
            builder.Host = targetAddress.Address.ToString();

            request.RequestUri = builder.Uri;

            return base.SendAsync(request, cancellationToken);
        }
    }
}
