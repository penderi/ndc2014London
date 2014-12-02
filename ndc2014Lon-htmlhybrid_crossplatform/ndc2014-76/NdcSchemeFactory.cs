using CefSharp;

namespace ndc2014London_hybridhtmlapps
{
    public class NdcSchemeFactory : ISchemeHandlerFactory
    {
        public ISchemeHandler Create()
        {
            return new NdcSchmeHandler();
        }
    }
}