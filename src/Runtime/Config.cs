// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.OpcUa.Services.Twin.Runtime {
    using Microsoft.Azure.IIoT.Services.Runtime;
    using Microsoft.Azure.IIoT.Hub;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Web service configuration - wraps a configuration root
    /// </summary>
    public class Config : ServiceConfig, IIoTHubConfig {

        /// <summary>
        /// Service configuration
        /// </summary>
        private const string kIoTHubConnectionStringKey = "IoTHubConnectionString";
        /// <summary>IoT hub connection string</summary>
        public string IoTHubConnString => GetString(kIoTHubConnectionStringKey,
            GetString(ServiceInfo.ID + "_HUB_CS",
                GetString("PCS_IOTHUB_CONNSTRING", GetString("_HUB_CS", null))));
        /// <summary>Resource Id</summary>
        public string IoTHubResourceId => null;

        /// <summary>
        /// Configuration constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Config(IConfigurationRoot configuration) :
            base (Uptime.ProcessId, ServiceInfo.ID, configuration) {
        }
    }
}
