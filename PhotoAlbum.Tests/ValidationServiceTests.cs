using System;
using PhotoAlbum.ConsoleApp;
using PhotoAlbum.Service;
using Xunit;

namespace PhotoAlbum.Tests
{
    public class ValidationServiceTests
    {
        [Fact]
        public void GetValidationResult_1IntArg_ResultIsValidIsTrue()
        {
            var args = new[] { "1" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void GetValidationResult_1IntArg_ResultHasWarningIsFalse()
        {
            var args = new[] { "1" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.False(result.HasWarning);
        }

        [Fact]
        public void GetValidationResult_1IntArg_ResultDescriptionIsValid()
        {
            var args = new[] { "1" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.Equal("Valid", result.Description);
        }

        [Fact]
        public void GetValidationResult_1IntArg_ResultIs1()
        {
            var args = new[] { "1" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.Equal(1, result.Result);
        }

        [Fact]
        public void GetValidationResult_2IntArg_ResultIsValidIsTrue()
        {
            var args = new[] { "1", "2" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void GetValidationResult_2IntArg_ResultHasWarningIsTrue()
        {
            var args = new[] { "1", "2" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.True(result.HasWarning);
        }

        [Fact]
        public void GetValidationResult_2IntArg_ResultDescriptionIsTooManyArgs()
        {
            var args = new[] { "1", "2" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.Equal("Too many arguments. Taking first argument and truncating the rest.", result.Description);
        }

        [Fact]
        public void GetValidationResult_2IntArg_ResultIs1()
        {
            var args = new[] { "1", "2" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.Equal(1, result.Result);
        }

        [Fact]
        public void GetValidationResult_1AlphaArg_ResultIsValidIsFalse()
        {
            var args = new[] { "a" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void GetValidationResult_1AlphaArg_InvalidResultDescriptionExpected()
        {
            var args = new[] { "a" };
            var expectedDescription = "Invalid Album ID provided.";

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.Equal(expectedDescription, result.Description);
        }

        [Fact]
        public void GetValidationResult_ZeroArgs_ResultIsValidIsFalse()
        {
            var args = Array.Empty<string>();

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void GetValidationResult_Negative1_ResultIsValidIsFalse()
        {
            var args = new[] { "-1" };

            var service = new ValidationService();

            var result = service.GetValidationResult(args);

            Assert.False(result.IsValid);
        }
    }
}
