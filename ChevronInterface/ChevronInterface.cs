using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayloadUtils;

namespace ChevronInterface
{
    public static class ChevronInterface
    {
        /// <summary>
        /// This sends either an MSA or Claims Payload to Chevron for processing
        /// </summary>
        /// <param name="Error">Information about what happened if an error occurs</param>
        /// <param name="connection">The connection string for the database that contains the data to be sent</param>
        /// <param name="ClientID">The ClientID required by Chevron for processing</param>
        /// <param name="ClientSecret">The ClientSecret provided by Chevron to facilitate processing</param>
        /// <param name="Resource">The ResourceID provided by Chevron for processing.</param>
        /// <param name="SubscriptionKey">The SubscriptionKey provided by Chevron for processing</param>
        /// <param name="TokenUrl">The URL designated by Chevron for obtaining a Token</param>
        /// <param name="PostUrl">The URL used to Post requests to Chevron</param>
        /// <param name="DoClaims">True for sending Claims False for sending MSA records</param>
        /// <param name="NumberInBatch">How many records are sent within a batch</param>
        /// <returns>True of all records are send and false if an error occurs.</returns>
        public static bool SendChevronPackage(out string Error,
            string connection,
            string ClientID,
            string ClientSecret,
            string Resource,
            string SubscriptionKey,
            string TokenUrl,
            string PostUrl,
            bool DoClaims,
            int NumberInBatch)
        {
            return PayloadUtils.PayloadUtils.BuildAndSendJsonPayloadFromDatabase(out Error, 
                connection,
                ClientID, 
                ClientSecret, 
                Resource, SubscriptionKey, 
                TokenUrl, 
                PostUrl, 
                DoClaims, 
                NumberInBatch);
        }
    }

}
