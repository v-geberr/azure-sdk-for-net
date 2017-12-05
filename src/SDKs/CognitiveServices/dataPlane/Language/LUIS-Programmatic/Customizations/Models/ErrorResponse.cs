
namespace Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class ErrorResponse
    {
        private string code;
        private string message;

        public string Code
        {
            get
            {
                if (code != null) return code;
                if (AdditionalProperties.TryGetValue("error", out object data))
                {
                    var error = JsonConvert.DeserializeObject<ApiError>(data.ToString());
                    code = error.Code;
                }
                else if (AdditionalProperties.TryGetValue("statusCode", out data))
                {
                    code = data.ToString();
                }
                return code;
            }
        }

        public string Message
        {
            get
            {
                if (message != null) return message;
                if (AdditionalProperties.TryGetValue("error", out object data))
                {
                    var error = JsonConvert.DeserializeObject<ApiError>(data.ToString());
                    message = error.Message;
                }
                else if (AdditionalProperties.TryGetValue("message", out data))
                {
                    message = data.ToString();
                }
                return message;
            }
        }

        partial void CustomInit()
        {
            if (AdditionalProperties == null)
            {
                AdditionalProperties = new Dictionary<string, object>();
            }
            ErrorType = nameof(ApiError);
        }
    }
}
