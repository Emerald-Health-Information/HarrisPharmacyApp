using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisPharmacy.App.Models
{
    public class FidoRegistrationChallengeDTO
    {
        public string UserId { get; set; }

        public byte[] Challenge { get; set; }

        public string RelyingPartyId { get; set; }

        public byte[] UserHandle { get; set; }

        public string DeviceFriendlyName { get; set; }

        public IEnumerable<byte[]> ExcludedKeyIds { get; set; }
    }
}