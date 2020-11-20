using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using NSubstitute;
using PhotoAlbum.Service;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class PhotoServiceTests
    {
        [Fact]
        public void GetPhotosByAlbumId_Non200Response_ThrowsException()
        {
            var mockGetService = Substitute.For<IGetService>();
            var testService = new PhotoService(mockGetService, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            mockGetService.Get(Arg.Any<string>()).Returns(new HttpResponseMessage(HttpStatusCode.InternalServerError));

            var ex = Assert.Throws<HttpRequestException>(() => testService.GetPhotosByAlbumId(1));

            Assert.NotNull(ex);
        }
    }
}
