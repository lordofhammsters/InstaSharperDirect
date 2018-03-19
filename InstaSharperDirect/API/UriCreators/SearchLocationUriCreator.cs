using System;

namespace InstaSharper.API.UriCreators
{
    internal class SearchLocationUriCreator : IUriCreator
    {
        private const string SearchLocation = "location_search";

        public Uri GetUri()
        {
            Uri instaUri;
            if (!Uri.TryCreate(InstaApiConstants.BaseInstagramUri, SearchLocation, out instaUri))
                throw new Exception("Can't create URI for searchiing location");
            return instaUri;
        }
    }
}