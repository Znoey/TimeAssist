﻿using System;
using System.IO;
using System.Net;

namespace WebRequestGetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create(
                "http://www.contoso.com/default.html");
            // Create a request for the URL. 
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}