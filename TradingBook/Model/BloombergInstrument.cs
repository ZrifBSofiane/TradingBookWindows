using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Element = Bloomberglp.Blpapi.Element;
using Event = Bloomberglp.Blpapi.Event;
using EventHandler = Bloomberglp.Blpapi.EventHandler;
using EventQueue = Bloomberglp.Blpapi.EventQueue;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using Service = Bloomberglp.Blpapi.Service;
using Session = Bloomberglp.Blpapi.Session;
using SessionOptions = Bloomberglp.Blpapi.SessionOptions;
using Subscription = Bloomberglp.Blpapi.Subscription;
using Request = Bloomberglp.Blpapi.Request;
using Bloomberglp.Blpapi;
using System.Windows;

namespace TradingBook.Model
{
    class BloombergInstrument
    {
        private SessionOptions sessionOptions;
        private Session session;
        bool result;

        Service referenceService;

        Request request;


        public BloombergInstrument()
        {
            sessionOptions = new SessionOptions();

            sessionOptions.ServerHost = "localhost";
            sessionOptions.ServerPort = 8194;

            session = new Session(sessionOptions);

            result = session.Start();

            result = session.OpenService("//blp/instruments");
            MessageBox.Show("instru " + result);

            referenceService = session.GetService("//blp/instruments");

            request = referenceService.CreateRequest("instrumentListRequest");
        }

        public List<String> SearchTicker(String ticker)
        {
            List<String> listTicker = new List<string>();
            // request.AsElement.SetElement("partialMatch", true);
            request.AsElement.SetElement("query", ticker);// this plus the previous line permits to retrieve all the thicker that begins with T
            request.AsElement.SetElement("languageOverride", "LANG_OVERRIDE_NONE");
            request.AsElement.SetElement("maxResults", 10);
            session.SendRequest(request, null);

            bool done = false;

            while (!done)
            {
                // Grab the next Event object
                Event eventObject = session.NextEvent();
                // If this event type is Response then process the messages
                if (eventObject.Type == Event.EventType.RESPONSE)
                {

                    // Loop over all of the messages in this Event
                    foreach (Message msg in eventObject.GetMessages())
                    {
                        Console.WriteLine(msg);
                        Element secDataArray = msg.GetElement("results");

                        for (int index = 0; index < secDataArray.NumValues - 1; index++)
                        {
                            Element fieldData = secDataArray.GetValueAsElement(index);
                            if (fieldData.HasElement("security"))
                                listTicker.Add(fieldData.GetElementAsString("security"));
                        }
                    }
                    done = true;
                }
            }

            return listTicker;
        }



        public void CloseSession()
        {
            // Close the session 
            session.Stop();
        }
    }
}
