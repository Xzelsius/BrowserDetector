﻿using System;

namespace Shyjus.BrowserDetection.Browsers
{
    internal class Firefox : Browser
    {

        public string Platform { get; }

        public override string Name => BrowserNames.Firefox;

        private Firefox(ReadOnlySpan<char> userAgent, string version):base(userAgent, version)
        {           
        }

        public static bool TryParse(ReadOnlySpan<char> userAgent, out Firefox result)
        {
            // Windows, Mac
            var fireFoxVersion = GetVersionIfKeyPresent(userAgent, "Firefox/");
            if (fireFoxVersion != null)
            {
                result = new Firefox(userAgent, fireFoxVersion);
                return true;
            }

            // IOS
            var fxiosVersion = GetVersionIfKeyPresent(userAgent, "FxiOS/");
            if (fxiosVersion != null)
            {
                result = new Firefox(userAgent, fxiosVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
