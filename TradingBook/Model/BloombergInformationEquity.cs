using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TradingBook.Model
{
    class BloombergInformationEquity
    {

        private SessionOptions sessionOptions;
        private Session session;
        bool result;

        Service referenceService;

        Request request;

        public BloombergInformationEquity()
        {
            sessionOptions = new SessionOptions();

            sessionOptions.ServerHost = "localhost";
            sessionOptions.ServerPort = 8194;

            session = new Session(sessionOptions);

            result = session.Start();

            result = session.OpenService("//blp/refdata");
            MessageBox.Show("instru " + result);

            referenceService = session.GetService("//blp/refdata");

            request = referenceService.CreateRequest("ReferenceDataRequest");
        }


        public Dictionary<String, String> SearchInformation(String security)
        {
            Element securities = request.GetElement("securities");
            securities.AppendValue(security);
            Element fields = request.GetElement("fields");
            fields.AppendValue("INDUSTRY_SECTOR");
            fields.AppendValue("INDUSTRY_GROUP");
            fields.AppendValue("CRNCY");
            fields.AppendValue("CDS_SPREAD_TICKER_5Y");
            fields.AppendValue("BLOOMBERG_PEERS");
            session.SendRequest(request, null);

            bool done = false;

            Dictionary<String, String> result = new Dictionary<string, string>();

            while (!done)
            {
                // Grab the next Event object
                Event eventObject = session.NextEvent();
                // If this event type is Response then process the messages
                if (eventObject.Type == Event.EventType.RESPONSE)
                {

                    // Loop over all of the messages in this Event
                    foreach (Bloomberglp.Blpapi.Message msg in eventObject.GetMessages())
                    {
                        Element secDataArray = msg.GetElement("securityData");

                        for (int index = 0; index <= secDataArray.NumValues - 1; index++)
                        {
                            Element fieldData = secDataArray.GetValueAsElement(index);
                            Element field = fieldData.GetElement("fieldData");

                            if (field.HasElement("CRNCY")) result.Add("currency", field.GetElementAsString("CRNCY"));
                            if (field.HasElement("INDUSTRY_SECTOR")) result.Add("industrySector", field.GetElementAsString("INDUSTRY_SECTOR"));
                            if (field.HasElement("INDUSTRY_GROUP")) result.Add("industryGroup", field.GetElementAsString("INDUSTRY_GROUP"));
                            if (field.HasElement("CDS_SPREAD_TICKER_5Y")) result.Add("tickerCDS", field.GetElementAsString("CDS_SPREAD_TICKER_5Y"));
                            Element fieldPeers = field.GetElement("BLOOMBERG_PEERS");
                            Element firstPeer = fieldPeers.GetValueAsElement(0);
                            if (firstPeer.HasElement("Peer Ticker")) result.Add("peers", firstPeer.GetElementAsString("Peer Ticker"));
                        }
                    }
                    done = true;
                }
            }

            return result;
        }

        public String GetNameCompanyOfEquity(String ticker)
        {
            Element securities = request.GetElement("securities");
            securities.AppendValue(ticker);
            Element fields = request.GetElement("fields");
            fields.AppendValue("NAME");
            session.SendRequest(request, null);

            bool done = false;

            String result = "";
            while (!done)
            {
                // Grab the next Event object
                Event eventObject = session.NextEvent();
                // If this event type is Response then process the messages
                if (eventObject.Type == Event.EventType.RESPONSE)
                {

                    // Loop over all of the messages in this Event
                    foreach (Bloomberglp.Blpapi.Message msg in eventObject.GetMessages())
                    {
                        Element secDataArray = msg.GetElement("securityData");
                        for (int index = 0; index <= secDataArray.NumValues - 1; index++)
                        {
                            Element fieldData = secDataArray.GetValueAsElement(index);
                            Element field = fieldData.GetElement("fieldData");
                            if (field.HasElement("NAME")) result = field.GetElementAsString("NAME");
                        }
                    }
                    done = true;
                }
            }
            return result;
        }

        public void CloseSession()
        {
            // Close the session 
            session.Stop();
        }
    }
}
