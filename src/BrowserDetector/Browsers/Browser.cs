﻿using System;
using System.Linq;

namespace Shyjus.BrowserDetection.Browsers
{
    internal abstract class Browser : IBrowser
    {
        public abstract string Name { get; }

        private string platform;

        public string DeviceType { get; }
        //public Version Version { get; }

        public string Version { get; }
        public string OS { get; }
        protected Browser(ReadOnlySpan<char> userAgent, string version)
        {
            var platform = PlatformDetector.GetPlatformAndOS(userAgent);

            this.platform = platform.Platform;
            this.OS = platform.OS;

            this.DeviceType = GetDeviceType(platform);

            this.Version = version;
        }
        private string GetDeviceType((string Platform, string OS, bool MobileDetected) platform)
        {
            // to do  : Check a dictionary and see allocations difference

            if (this.platform == Platforms.iPhone)
            {
                return DeviceTypes.Mobile;
            }
            else if (this.platform == Platforms.iPad || this.platform == "GalaxyTabS4")
            {
                return DeviceTypes.Tablet;
            }

            // IPad also has Mobile in it. So make sure to check that first
            if (platform.MobileDetected)
            {
                return DeviceTypes.Mobile;
            }

            else if (this.platform == Platforms.Macintosh || this.platform.StartsWith("Windows NT"))
            {
                return DeviceTypes.Desktop;
            }
            //Samsung Chrome_GalaxyTabS4 does not have "Mobile", but it has Linux and Android.
            if (this.platform == "Linux" && platform.OS=="Android" && platform.MobileDetected == false)
            {
                return DeviceTypes.Tablet;
            }
            return string.Empty;
        }

        protected static string GetVersionIfKeyPresent(ReadOnlySpan<char> userAgent, string key)
        {
            var keyStartIndex = userAgent.IndexOf(key.AsSpan());

            if (keyStartIndex == -1)
            {
                return null;
            }

            var sliceWithVersionPart = userAgent.Slice(keyStartIndex + key.Length);

            var endIndex = sliceWithVersionPart.IndexOf(' ');
            if (endIndex > -1)
            {
                return sliceWithVersionPart.Slice(0, endIndex).ToString(); ;
            }

            return sliceWithVersionPart.ToString();

        }

    }
}
