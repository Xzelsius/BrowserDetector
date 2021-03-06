using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Shyjus.BrowserDetection.Browsers;

namespace Shyjus.BrowserDetection.Tests
{
    /// <summary>
    /// OSX Tests - Desktop
    /// </summary>
    public partial class BrowserDetectorTests
    {
        [Fact]
        public void Opera_OSX()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Opera_OSX }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.Opera, actual.Name);
        }

        [Fact]
        public void Chrome_OSX()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Chrome_OSX }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.Chrome, actual.Name);
        }

        [Fact]
        public void Safari_OSX()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Safari12_OSX }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.Safari, actual.Name);
        }

        [Fact]
        public void Firefox_OSX()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Firefox_OSX }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.Firefox, actual.Name);
        }
    }
}
