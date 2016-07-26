using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;

namespace MyLibrary.GoogleVision
{
    public class GoogleVisionService
    {
        public IList<AnnotateImageResponse> Result;

        private readonly VisionService _visionService;
        private readonly int _maxResults;

        public GoogleVisionService(string serviceAccountKeyPath, int maxResults)
        {
            if (string.IsNullOrEmpty(serviceAccountKeyPath))
            {
                _visionService = GoogleAuthenticator.CreateDefaultAuthorizedClient();
            }
            else
            {
                _visionService = GoogleAuthenticator.CreateAuthorizedClient(serviceAccountKeyPath);
            }

            _maxResults = maxResults;
        }

        public void SendRequest(string imagePath)
        {
            var imageArray = File.ReadAllBytes(imagePath);
            var imageContent = Convert.ToBase64String(imageArray);

            var responses = _visionService.Images.Annotate(new BatchAnnotateImagesRequest()
            {
                Requests = new[]
                {
                    new AnnotateImageRequest()
                    {
                        Features = new[]
                        {
                            new Feature()
                            {
                                Type = DetectionTypes.LabelDetection,
                                MaxResults = _maxResults
                            },
                            new Feature()
                            {
                                Type = DetectionTypes.TextDetection,
                                MaxResults = _maxResults
                            },
                            new Feature()
                            {
                                Type = DetectionTypes.LandmarkDetection,
                                MaxResults = _maxResults
                            },
                            new Feature()
                            {
                                Type = DetectionTypes.LogoDetection,
                                MaxResults = _maxResults
                            },
                            new Feature()
                            {
                                Type = DetectionTypes.FaceDetection,
                                MaxResults = _maxResults
                            },
                            new Feature()
                            {
                                Type = DetectionTypes.SafeSearchDetection,
                                MaxResults = _maxResults
                            },
                            new Feature()
                            {
                                Type = DetectionTypes.ImageProperties,
                                MaxResults = _maxResults
                            },
                        },
                        Image = new Image() {Content = imageContent}
                    }
                }
            }).Execute();

            Result = responses.Responses;
        }

        public void PrintResults()
        {
            foreach (var response in Result)
            {
                Console.WriteLine("Label Annotations");
                if (response.LabelAnnotations == null)
                {
                    Console.WriteLine("No labels detected.");
                }
                else
                {
                    foreach (var labelAnnotation in response.LabelAnnotations)
                    {
                        Console.WriteLine(labelAnnotation.Description + " (score: " + labelAnnotation.Score + ")");
                    }
                }

                Console.WriteLine("Landmark Annotations");
                if (response.LandmarkAnnotations == null)
                {
                    Console.WriteLine("No landmarks detected.");
                }
                else
                {
                    foreach (var landmarkAnnotation in response.LandmarkAnnotations)
                    {
                        Console.WriteLine(landmarkAnnotation.Description + " (score: " + landmarkAnnotation.Score + ")");
                    }
                }

                Console.WriteLine("Logo Annotations");
                if (response.LogoAnnotations == null)
                {
                    Console.WriteLine("No logos detected.");
                }
                else
                {
                    foreach (var logoAnnotation in response.LogoAnnotations)
                    {
                        Console.WriteLine(logoAnnotation.Description + " score=" + logoAnnotation.Score);
                    }
                }
                
                Console.WriteLine("Text Annotations");
                if (response.TextAnnotations == null)
                {
                    Console.WriteLine("No text detected.");
                }
                else
                {
                    foreach (var textAnnotation in response.TextAnnotations)
                    {
                        Console.WriteLine(textAnnotation.Description + " score=" + textAnnotation.Score);
                    }
                }
            }
        }
    }
}
