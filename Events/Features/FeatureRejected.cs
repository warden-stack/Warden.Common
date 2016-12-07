using System;

namespace Warden.Common.Events.Features
{
    public class FeatureRejected : IRejectedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public string Feature { get; }
        public string Code { get; }
        public string Reason { get; }

        protected FeatureRejected()
        {
        }

        public FeatureRejected(Guid requestId, string userId,
            string feature, string code, string reason)
        {
            RequestId = requestId;
            UserId = userId;
            Feature = feature;
            Code = code;
            Reason = reason;
        }
    }
}