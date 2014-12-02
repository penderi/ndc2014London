using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Common.Assets;

namespace ndc2014London_hybridhtmlapps
{
    public partial class WinContainerForm : Form
    {
        private readonly ChromiumWebBrowser _browser;
        private CsObjectToBindToJsVm _csObjectToBindToJsVm;
        private readonly Button _buttonReload;
        private string NAME_CS_OBJECT_BOUND_JVM = "csfromjs";

        public WinContainerForm()
        {
            InitializeComponent();

            _browser = CreateBrowserAndInitCef();
            Controls.Add(_browser);

            _buttonReload = CreateRefreshButton();
            Controls.Add(_buttonReload);
        }

        private void Browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            if (e.IsBrowserInitialized)
            {
                _csObjectToBindToJsVm = new CsObjectToBindToJsVm();
                _csObjectToBindToJsVm.CalledFromCs += raiseEventToUi;

                //object -csfromjs- bound to window MUST match that called from HTML / assets
                _browser.RegisterJsObject(NAME_CS_OBJECT_BOUND_JVM, _csObjectToBindToJsVm);

                LoadStartPage();
            }
        }

        private void LoadStartPage()
        {
            //   string html = @"https://developer.mozilla.org/en-US/demos/detail/guitar-chord-diagrams-html5-web-component/launch";
            // browser.Load(html);
            _browser.Load("ndc://index.html");
            _browser.ShowDevTools();
        }

        private ChromiumWebBrowser CreateBrowserAndInitCef()
        {
            var scheme = new CefCustomScheme
            {
                SchemeName = AssetProvider.SCHEME,
                SchemeHandlerFactory = new NdcSchemeFactory()
            };
            var setting = new CefSettings
            {
                BrowserSubprocessPath = "CefSharp.BrowserSubprocess.exe",
                PackLoadingDisabled = false
            };
            setting.RegisterScheme(scheme);
            Cef.Initialize(setting);

            var browser = new ChromiumWebBrowser("") {Dock = DockStyle.Fill};
            browser.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;
            return browser;
        }

        private void raiseEventToUi(string fromcs)
        {
            //function -toUI- bound to window MUST match that defined in HTML / Assets
            _browser.ExecuteScriptAsync("window.toUI('string sent from cs event to poek js. Passing string from event -" + fromcs + "');");
        }

        private Button CreateRefreshButton()
        {
            var button = new Button();
            button.Dock = DockStyle.Bottom;
            button.Text = "Reload page"; // to see transfer speed in dev tools 
            button.Click += (sender, args) => LoadStartPage();
            return button;
        }
    }
}