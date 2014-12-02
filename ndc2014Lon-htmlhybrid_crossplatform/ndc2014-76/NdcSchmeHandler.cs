using CefSharp;
using Common.Assets;

namespace ndc2014London_hybridhtmlapps
{
    public class NdcSchmeHandler : ISchemeHandler
    {
        public bool ProcessRequestAsync(IRequest request, ISchemeHandlerResponse response,
            OnRequestCompletedHandler requestCompletedCallback)
        {
            if (AssetProvider.IsLocal(request.Url))
            {
                AssetResource asset = AssetProvider.Get(request.Url);

                response.MimeType = asset.MimeType;
                response.ResponseStream = asset.Resource;
                requestCompletedCallback.Invoke();
                return true;
            }

            return false;
        }
    }
}