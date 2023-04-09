using FluentAssertions;
using Moq;
using System.Net;

namespace MoqHttpExtensions.UnitTests;

public class SomeClientTests
{
    [Fact]
    public async void Returns_Response_Result_Plus_One()
    {
        var fakeBaseAddress = "https://www.example.com";

        var httpMessageHandler = new Mock<HttpMessageHandler>();
        httpMessageHandler
            .SetupSendAsync(HttpMethod.Get, $"{fakeBaseAddress}/myEndpoint")
            .ReturnsHttpResponseAsync(10, HttpStatusCode.OK);

        var httpClient = new HttpClient(httpMessageHandler.Object)
        {
            BaseAddress = new Uri(fakeBaseAddress)
        };
        var client = new SomeClient(httpClient);

        var result = await client.AddOneToResponseResult();
        result.Should().Be(11);
    }
}