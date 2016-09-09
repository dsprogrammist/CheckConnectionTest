using System;
using System.Collections.Generic;
using System.Management;
using CheckConnection.Model;

namespace CheckConnection.Methods
{
    class WMIMethods
    {

        private ManagementObjectCollection moCollection;

        public WMIMethods()
        {
            string query = "SELECT * FROM Win32_NetworkAdapterConfiguration"
             + " WHERE IPEnabled = 'TRUE'";

            ManagementObjectSearcher moSearch = new ManagementObjectSearcher(query);
            moCollection = moSearch.Get();
        }

        public List<Connection> GetNetworkDevices( )
        {
            int Conn_id = 0;
            List<Connection> Connection_list = new List<Connection>();


            foreach (ManagementObject mo in moCollection)
            {
                try
                {
                    Connection item = new Connection();

                    if (mo["Description"] != null)
                        item.Name = mo["Description"].ToString();

                    item.Id = Conn_id;
                    item.Date = DateTime.Now;

                    if (mo["DHCPEnabled"] != null)
                        item.DHCP_Enabled = mo["DHCPEnabled"].ToString();

                    if (mo["IPAddress"] != null)
                    {
                        string[] addresses = (string[])mo["IPAddress"];
                        item.Ip_Address_v4 = addresses[0];
                        if (addresses.Length > 1)
                            item.Ip_Address_v6 = addresses[1];
                    }

                    if (mo["MACAddress"] != null)
                        item.MAC = mo["MACAddress"].ToString();

                    if (mo["DNSDomain"]!=null )
                     item.DNSDomain =  mo["DNSDomain"].ToString();

                    if (mo["IPSubnet"] != null) {
                        string[] subnets = (string[])mo["IPSubnet"];
                        foreach (string ipsubnet in subnets)
                        {
                            item.IPSubnetMask = ipsubnet;
                            break;
                        }
                    }

                    if (mo["DefaultIPGateway"] != null)
                    {
                        string[] defaultgateways = (string[])mo["DefaultIPGateway"];
                        foreach (string defaultipgateway in defaultgateways)
                        {
                            item.IPGateway = item.IPGateway + defaultipgateway + "; ";                            
                        }
                    }

                    if (mo["DNSServerSearchOrder"] != null)
                    {
                        string[] DNSarray = (string[])mo["DNSServerSearchOrder"];
                        foreach (string dns in DNSarray)
                        {
                            item.DNSServer = item.DNSServer + dns + "; ";                            
                        }
                    }
                    

                    if (mo["DHCPServer"] != null)
                        item.DHCPServer = mo["DHCPServer"].ToString();

                    Connection_list.Add(item);
                    Conn_id++;                    
                }
                catch (Exception)
                {
                    Connection item = new Connection();
                    item.Name = "empty";
                    item.Id = Conn_id;
                    Connection_list.Add(item);
                }
                //Только одно подключение
                break;
            }

            return Connection_list;
        }

        public List<DNS> GetDNSArray(int Connection_Id )
        {
            List<DNS> DNS_list = new List<DNS>();
            int Order_Id = 0;

            foreach (ManagementObject mo in moCollection)
            {
                if (mo["DNSServerSearchOrder"] != null)
                {                    
                    string[] str_array = (string[])mo["DNSServerSearchOrder"];
                    foreach (string str in str_array)
                    {
                        DNS dns = new DNS();
                        dns.DNSServer = str;                        
                        dns.Connection_Id = Connection_Id;
                        dns.Order_Id = Order_Id;
                        DNS_list.Add(dns);
                        Order_Id++;
                    }
                }
                //Только одно подключение
                break;
            }
            return DNS_list;
        }

        public List<Gateway> GetGatewayArray(int Connection_Id )
        {
            List<Gateway> Gateway_list = new List<Gateway>();
            foreach (ManagementObject mo in moCollection)
            {
                if (mo["DefaultIPGateway"] != null)
                {
                    
                    string[] defaultgateways = (string[])mo["DefaultIPGateway"];
                    foreach (string defaultipgateway in defaultgateways)
                    {
                        Gateway gtw = new Gateway();
                        gtw.IPGateway = defaultipgateway;
                        gtw.Connection_Id = Connection_Id;
                        Gateway_list.Add(gtw);
                    }
                }
                //Только одно подключение
                break;
            }
            return Gateway_list;
        }

        public void GetPingResult(string PingAddress, ref List<Ping> Ping_list)
        {

            string query = "SELECT * FROM Win32_PingStatus WHERE Address = '{0}'";
            query = String.Format(query, PingAddress);

            ManagementObjectSearcher moSearch = new ManagementObjectSearcher(query);
            ManagementObjectCollection moCollection = moSearch.Get();          

            //enumerate the collection.
            foreach (ManagementObject mo in moCollection) 
	        {
              Ping item = new Ping();

              // access properties of the WMI object
              Console.WriteLine("StatusCode : {0}", mo["StatusCode"]);

              Console.WriteLine("strStatusCode : {0}", GetStatusCode(Convert.ToInt32(mo["StatusCode"])));

              Console.WriteLine("ResponseTime : {0} ms", mo["ResponseTime"]);
              Console.WriteLine("TimeToLive : {0} ms", mo["TimeToLive"]);
              Console.WriteLine("Timeout : {0} ms", mo["Timeout"]);

              item.StatusCode = mo["StatusCode"].ToString();
              item.Connection_Id = 1;
              item.Date = DateTime.Now;
              item.Ip_Address = PingAddress; 
              item.Name = PingAddress;
              item.ResponseTime = mo["ResponseTime"].ToString();

              Ping_list.Add(item);
            }
        }

        private string GetStatusCode(int intCode) {

            string strStatus;

            switch (intCode)
            {
                case 0:
                    strStatus = "Success";
                    break;
                case 11001:
                    strStatus = "Buffer Too Small";
                    break;
                case 11002:
                    strStatus = "Destination Net Unreachable";
                    break;
                case 11003:
                    strStatus = "Destination Host Unreachable";
                    break;
                case 11004:
                    strStatus = "Destination Protocol Unreachable";
                    break;
                case 11005:
                    strStatus = "Destination Port Unreachable";
                    break;
                case 11006:
                    strStatus = "No Resources";
                    break;
                case 11007:
                    strStatus = "Bad Option";
                    break;
                case 11008:
                    strStatus = "Hardware Error";
                    break;
                case 11009:
                    strStatus = "Packet Too Big";
                    break;
                case 11010:
                    strStatus = "Request Timed Out";
                    break;
                case 11011:
                    strStatus = "Bad Request";
                    break;
                case 11012:
                    strStatus = "Bad Route";
                    break;
                case 11013:
                    strStatus = "TimeToLive Expired Transit";
                    break;
                case 11014:
                    strStatus = "TimeToLive Expired Reassembly";
                    break;
                case 11015:
                    strStatus = "Parameter Problem";
                    break;
                case 11016:
                    strStatus = "Source Quench";
                    break;
                case 11017:
                    strStatus = "Option Too Big";
                    break;
                case 11018:
                    strStatus = "Bad Destination";
                    break;
                case 11032:
                    strStatus = "Negotiating IPSEC";
                    break;
                case 11050:
                    strStatus = "General Failure";
                    break;
                default:
                    strStatus = intCode + " - Unknown";
                    break;
            }

            return strStatus;

        }
    }
}
