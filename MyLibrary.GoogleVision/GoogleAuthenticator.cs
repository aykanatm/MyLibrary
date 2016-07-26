using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;

namespace MyLibrary.GoogleVision
{
    public static class GoogleAuthenticator
    {
        public static VisionService CreateDefaultAuthorizedClient()
        {
            var credential = GoogleCredential.GetApplicationDefaultAsync().Result;

            if (credential.IsCreateScopedRequired)
            {
                credential = credential.CreateScoped(new[] {VisionService.Scope.CloudPlatform});
            }
            return new VisionService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                GZipEnabled = false
            });
        }

        public static VisionService CreateAuthorizedClient(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var credential = GoogleCredential.FromStream(fs);

                if (credential.IsCreateScopedRequired)
                {
                    credential = credential.CreateScoped(new[] { VisionService.Scope.CloudPlatform });
                }
                return new VisionService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    GZipEnabled = false
                });
            }
        }
    }
}
