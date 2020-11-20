using System;
using System.Collections.Generic;
using System.IO;
using NSubstitute;
using PhotoAlbum.Service;
using PhotoAlbum.Service.Models;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class PhotoWriterTests
    {
        [Fact]
        public void WritePhotos_EmptyList_WritesEmptyListMessage()
        {
            var photos = new List<Photo>();
            var photosResult = new GetPhotosResult
            {
                Photos = photos
            };
            var mockTextWriter = Substitute.For<TextWriter>();

            var photoWriter = new PhotoWriter(mockTextWriter);

            photoWriter.WritePhotos(photosResult);

            mockTextWriter.Received().WriteLine("No photos.");
        }

        [Fact]
        public void WritePhotos_NonEmptyList_WritesMessages()
        {
            var photos = new List<Photo>
            {
                new Photo {Id = 1 },
                new Photo {Id = 2 },
                new Photo {Id = 3 },
                new Photo {Id = 4 },
                new Photo {Id = 5 }
            };
            var photosResult = new GetPhotosResult
            {
                Photos = photos
            };
            var mockTextWriter = Substitute.For<TextWriter>();

            var photoWriter = new PhotoWriter(mockTextWriter);

            photoWriter.WritePhotos(photosResult);

            mockTextWriter.Received(5).WriteLine(Arg.Any<string>());
        }

        [Fact]
        public void WritePhotos_NonEmptyList_WritesListMessages()
        {
            var photos = new List<Photo>
            {
                new Photo {Id = 1, Title = "test" },
                new Photo {Id = 2, Title = "test" },
                new Photo {Id = 3, Title = "test" },
                new Photo {Id = 4, Title = "test" },
                new Photo {Id = 5, Title = "test" }
            };
            var photosResult = new GetPhotosResult
            {
                Photos = photos
            };
            var mockTextWriter = Substitute.For<TextWriter>();

            var photoWriter = new PhotoWriter(mockTextWriter);

            photoWriter.WritePhotos(photosResult);

            mockTextWriter.Received().WriteLine("[1] test");
            mockTextWriter.Received().WriteLine("[2] test");
            mockTextWriter.Received().WriteLine("[3] test");
            mockTextWriter.Received().WriteLine("[4] test");
            mockTextWriter.Received().WriteLine("[5] test");
        }

        [Fact]
        public void WritePhotos_ExceptionThrown_WritesExceptionMessage()
        {
            var photosResult = new GetPhotosResult
            {
                Photos = new List<Photo>(),
                ErrorMessage = "It's a trap!"
            };
            var mockTextWriter = Substitute.For<TextWriter>();

            var photoWriter = new PhotoWriter(mockTextWriter);

            photoWriter.WritePhotos(photosResult);

            mockTextWriter.Received(1).WriteLine("Failed to retrieve photos. It's a trap!");
        }
    }
}
