<%@ WebService Language="C#" Class="CustomWebService" %>
<!-- server/CustomWebService.asmx aufrufbar, mit ?wsdl liefert wsdl (Schnittstelle) -->
using System;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")] 
public class CustomWebService : WebService {

    [WebMethod(Description = "Returns current time")]
    public string GetTime(bool shortForm) {
        if (shortForm) {
            return DateTime.Now.ToShortTimeString();
        }
        return DateTime.Now.ToString();
    }


    [WebMethod(Description = "Returns current time in JSON")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public GetTimeInJson(){
        return new JavaScriptSerializer().Serialize(new {
            time = DateTime.Now.ToString()
        });
    }


}