using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for the type of chat message that carries text.
    /// </summary>
    public class ChatMessageText : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/chat-conversation/{1}/message-text";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TEXT = "text";


        /// <summary>
        /// The id of the newly created chat message.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Add a new text message to a specific conversation.
        /// </summary>
        /// <param name="text">The textual content of this message. Cannot be empty.</param>
        public static BunqResponse<int> Create(int chatConversationId, string text,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_TEXT, text},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), chatConversationId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ChatMessageText CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ChatMessageText>(json);
        }
    }
}