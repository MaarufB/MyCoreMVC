using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyCoreMVC.Controllers
{
    public class OnvifController : Controller
    {
     
        public IActionResult Index()
        {

            //static UriBuilder deviceUri;
            //static OnvifBasic.onvif.Media2Client media;
            //static OnvifBasic.onvif.MediaProfile[] profiles;
            //var profileList = new List<string>();

            //deviceUri = new UriBuilder("http://onvif/device_service");
            //string _username = "admin";
            //string _password = "97315star";
            //string address = "220.130.148.107:80";
            //string[] add = address.Split(':');
            //deviceUri.Host = add[0];

            //if (add.Length == 2)
            //    deviceUri.Port = Convert.ToInt32(add[1]);

            //Binding binding;
            //HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
            //httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Digest;
            //binding = new CustomBinding(new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8), httpTransport);

            //device.DeviceClient device = new device.DeviceClient(binding, new EndpointAddress($"http://{address}/onvif/device_service"));
            //device.Service[] services = device.GetServices(false);

            //device.Service xmedia = services.FirstOrDefault(s => s.Namespace == "http://www.onvif.org/ver20/media/wsdl");

            //if (xmedia != null)
            //{
            //    media = new OnvifBasic.onvif.Media2Client(binding, new EndpointAddress(xmedia.XAddr));
            //    media.ClientCredentials.HttpDigest.ClientCredential.UserName = _username;
            //    media.ClientCredentials.HttpDigest.ClientCredential.Password = _password;
            //    media.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            //    try
            //    {
            //        profiles = media.GetProfiles(null, null);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"{ex}");
            //    }


            //    if (profiles != null)
            //    {
            //        foreach (var p in profiles)
            //        {
            //            profileList.Add(p.ToString());
            //            Console.WriteLine(p.Name);
            //        }
            //    }

            return View();


        }
    }
}
