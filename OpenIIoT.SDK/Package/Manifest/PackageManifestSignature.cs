﻿using Newtonsoft.Json;

namespace OpenIIoT.SDK.Package.Manifest
{
    public class PackageManifestSignature : IPackageManifestSignature
    {
        #region Public Properties

        [JsonProperty(Order = 1)]
        public string Digest { get; set; }

        [JsonProperty(Order = 2)]
        public string Key { get; set; }

        [JsonProperty(Order = 3)]
        public string Trust { get; set; }

        #endregion Public Properties
    }
}