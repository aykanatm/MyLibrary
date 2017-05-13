using System;
using System.Collections.Generic;
using System.IO;

namespace IOUtils
{
    public class SettingsFileReader
    {
        private const int PropertyNameIndex = 0;
        private const int PropertyValueIndex = 1;

        private readonly string _filePath;
        private readonly string _componentStartCharacter;
        private readonly string _componentEndCharacter;
        private readonly string _propertyWrapperCharacter;
        private readonly char _propertyValueSetterCharater;

        public SettingsFileReader(string filePath, string componentStartCharacter, string componentEndCharacter, string propertyWrapperCharacter, char propertyValueSetterCharater)
        {
            _filePath = filePath;
            _componentStartCharacter = componentStartCharacter;
            _componentEndCharacter = componentEndCharacter;
            _propertyWrapperCharacter = propertyWrapperCharacter;
            _propertyValueSetterCharater = propertyValueSetterCharater;
        }

        public List<string> GetValues(string componentName)
        {
            try
            {
                var result = new List<string>();
                using (var sr = new StreamReader(_filePath))
                {
                    bool componentFound = false;
                    string line = null;
                    do
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            if (line.StartsWith(_componentStartCharacter))
                            {
                                componentFound = false;
                                var processedLine = line.Replace(_componentStartCharacter, String.Empty).Replace(_componentEndCharacter, String.Empty).Trim();
                                if (processedLine == componentName)
                                {
                                    componentFound = true;
                                }
                            }
                            else
                            {
                                if (componentFound)
                                {
                                    var processedLine = line.Replace(_propertyWrapperCharacter, "");
                                    var keyValuePair = processedLine.Split(_propertyValueSetterCharater);

                                    result.Add(keyValuePair[PropertyValueIndex].Trim());
                                }
                            }
                        }
                    } while (line != null);
                }
                return result;
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while getting values. " + e.Message;
                throw new Exception(errorMessage);
            }
        }
        public string GetValue(string componentName, string propertyName, string defaultValue)
        {
            try
            {
                string result = defaultValue;
                using (var sr = new StreamReader(_filePath))
                {
                    bool componentFound = false;
                    string line = null;
                    do
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            if (line.StartsWith(_componentStartCharacter))
                            {
                                componentFound = false;

                                var processedLine = line.Replace(_componentStartCharacter, String.Empty).Replace(_componentEndCharacter, String.Empty).Trim();
                                if (processedLine == componentName)
                                {
                                    componentFound = true;
                                }
                            }
                            else
                            {
                                if (componentFound)
                                {
                                    var processedLine = line.Replace(_propertyWrapperCharacter, "").Trim();
                                    var keyValuePair = processedLine.Split(_propertyValueSetterCharater);
                                    if (keyValuePair[PropertyNameIndex].Trim() == propertyName)
                                    {
                                        result = keyValuePair[PropertyValueIndex].Trim();
                                    }
                                }
                            }
                        }
                    } while (line != null);
                }
                return result;
            }
            catch (Exception e)
            {
                var errorMessage = "An error occured while getting the value. " + e.Message;
                throw;
            }
        }
    }
}
