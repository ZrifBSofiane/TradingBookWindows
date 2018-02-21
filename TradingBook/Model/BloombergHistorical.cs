using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloomberglp.Blpapi;

namespace TradingBook.Model
{
    class BloombergHistorical
    {

        private SessionOptions sessionOptions;
        private Session session;
        bool result;

        Service referenceService;
        Request request;


        public BloombergHistorical()
        {
            sessionOptions = new SessionOptions();

            sessionOptions.ServerHost = "localhost";
            sessionOptions.ServerPort = 8194;

            session = new Session(sessionOptions);

            result = session.Start();

            result = session.OpenService("//blp/refdata");

            referenceService = session.GetService("//blp/refdata");

            request = referenceService.CreateRequest("HistoricalDataRequest");
        }

        public List<Object> GetPriceVolumeValue(String ticker, string periodicity, string startResearch, string endResearch)
        {

            request.Append("securities", ticker);
            request.Append("fields", "PX_LAST");
            request.Append("fields", "VOLUME");
            request.Append("fields", "LAST_TRADE");
            request.Append("fields", "LAST_PRICE");

            request.Set("startDate", startResearch);
            request.Set("endDate", endResearch);

            request.Set("periodicitySelection", periodicity);

            session.SendRequest(request, null);

            bool done = false;

            List<String> date = new List<string>();
            List<double> price = new List<double>();
            List<double> volume = new List<double>();

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
                        Element secDataArray = msg.GetElement("securityData");
                        Element securityData = secDataArray.GetElement(3);
                        for (int index = 0; index < securityData.NumValues - 1; index++)
                        {
                            Element fieldData = securityData.GetValueAsElement(index);
                            if (fieldData.HasElement("PX_LAST") && fieldData.HasElement("date") && fieldData.HasElement("VOLUME"))
                            {
                                price.Add(Convert.ToDouble(fieldData.GetElementAsFloat64("PX_LAST")));
                                date.Add(Convert.ToString(fieldData.GetElementAsString("date")));
                                volume.Add(Convert.ToDouble(fieldData.GetElementAsInt64("VOLUME")));
                            }
                        }
                    }
                    done = true;
                } // End if event type is Response
            }

            List<Object> result = new List<object>();
            result.Add(date);
            result.Add(price);
            result.Add(volume);
            return result;
        }

        public void CloseSession()
        {
            // Close the session 
            session.Stop();
        }


    }
}
