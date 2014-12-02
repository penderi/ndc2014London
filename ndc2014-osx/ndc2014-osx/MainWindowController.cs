
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace ndc2014osx
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion

		public override void AwakeFromNib ()
		{
			NSUrlProtocol.RegisterClass(new MonoMac.ObjCRuntime.Class(typeof(NdcProtocol)));

			string html = "https://developer.mozilla.org/en-US/demos/detail/guitar-chord-diagrams-html5-web-component/launch";
			html = "ndc://test.html";
			browser.MainFrame.LoadRequest(NSUrlRequest.FromUrl(NSUrl.FromString(html)));
			base.AwakeFromNib ();
		}

		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}
	}
}

