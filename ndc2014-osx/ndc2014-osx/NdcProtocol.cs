
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace ndc2014osx
{
	public class NdcProtocol : NSUrlProtocol
	{
		public NdcProtocol(IntPtr ptr): base (ptr)     
		{    
		} 

		[Export ("canonicalRequestForRequest:")]  
		new public static NSUrlRequest GetCanonicalRequest (NSUrlRequest request)  
		{  
			return request;  
		}  

		[Export ("canInitWithRequest:")]  
		new public static bool CanInitWithRequest (NSUrlRequest request)  
		{  
			return request.Url.Scheme == "ndc";  
		} 
		public override void StartLoading ()
		{

			base.StartLoading ();
		}

		public override void StopLoading ()     
		{     
		} 
	}
}

