using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Pokedex.UnitTests.Helpers
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Queue<(string, string, HttpMethod, HttpResponseMessage)> _queue;

        public MockHttpMessageHandler()
        {
            _queue = new Queue<(string, string, HttpMethod, HttpResponseMessage)>();
        }

        public void AddNewMockResponse(string requestMustContain, string requestBody, HttpStatusCode statusCode, HttpMethod method = null, string content = null, string mediaType = "text/plain")
        {
            var response = new HttpResponseMessage(statusCode);
            if (content != null)
                response.Content = new StringContent(content, System.Text.Encoding.UTF8, mediaType);
            _queue.Enqueue((requestMustContain, requestBody, method, response));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var next = _queue.Dequeue();
            if (!request.RequestUri.ToString().Contains(next.Item1))
            {
                throw new Exception($"Request URI did not contain '{next.Item1}'");
            }

            var requestContent = request.Content == null ? "" : await request.Content.ReadAsStringAsync();
            if (!requestContent.Contains(next.Item2))
            {
                throw new Exception($"Request Body did not contain '{requestContent}'");
            }

            if (next.Item3 != null && next.Item3 != request.Method)
            {
                throw new Exception($"Request Method {request.Method} did not match '{next.Item3}'");
            }

            return next.Item4;

        }
    }
}
