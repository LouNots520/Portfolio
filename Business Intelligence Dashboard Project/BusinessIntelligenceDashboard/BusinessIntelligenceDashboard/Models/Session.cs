using DocuWare.Platform.ServerClient;
using System;
using System.Diagnostics;

namespace BusinessIntelligenceDashboard.Models
{
    // This Class is for Connecting to DocuWare System
    public class Session
    {
        public static Uri uri = new Uri("https://docuware-online.com/DocuWare/Platform");

        public static bool Connect(String username, String password, String company)
        {
            ServiceConnection sc = null;
            //Attempt for successful login
            try
            {
                sc = ServiceConnection.Create(uri, username, password, organization: company);
                Debug.WriteLine("Successful Login with: " + username);
                return true;
            }
            //Failed login
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " - " + ex.GetType().ToString());
                Debug.WriteLine("Login Failed!");
                return false;
            }
        }
    }
}