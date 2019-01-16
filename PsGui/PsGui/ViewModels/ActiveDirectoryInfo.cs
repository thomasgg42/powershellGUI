﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.DirectoryServices;

namespace PsGui.ViewModels
    {
    class ActiveDirectoryInfo
        {
        public string TabName { get; } = "AD Info";

        private string _phone;
        private string _principalName;
        private string _department;
        private string _homeDirectory;
        private string _givenName;
        private string _surName;
        private string _mail;
        private string _title;
        private string _extensionAttribute10;
        private string _extensionAttribute8;

        private string _test;
        private string _test2;



        public ActiveDirectoryInfo()
            {
        //    _test = GetTest();
          //  _test2 = GetTest2();
            }

        public string Title
            {
            get
                {
                return _title;
                }

            set
                {
                _title = value;
                }
            }
        
        /// <summary>
        /// Sets or gets the mail.
        /// </summary>
        public string Mail
            {
            get
                {
                return _mail;
                }
            set
                {
                _mail = value;
                }
            }

        /// <summary>
        /// Sets or gets the surname.
        /// </summary>
        public string SurName
            {
            get
                {
                return _surName;
                }
            set
                {
                _surName = value;
                }
            }

        /// <summary>
        /// Sets or gets the given name.
        /// </summary>
        public string GivenName
            {
            get
                {
                return _givenName;
                }
            set
                {
                _givenName = value;
                }
            }

        /// <summary>
        /// Sets or gets the home directory.
        /// </summary>
        public string HomeDirectory
            {
            get
                {
                return _homeDirectory;
                }
            set
                {
                _homeDirectory = value;
                }
            }

        /// <summary>
        /// Sets or gets the department.
        /// </summary>
        public string Department
            {
            get
                {
                return _department;
                }
            set
                {
                _department = value;
                }
            }

        /// <summary>
        /// Sets or gets extension attribute 10.
        /// </summary>
        public string ExtensionAttribute8
            {
            get
                {
                return _extensionAttribute8;
                }
            set
                {
                _extensionAttribute8 = value;
                }
            }

        /// <summary>
        /// Sets or gets extension attribute 10.
        /// </summary>
        public string ExtensionAttribute10
            {
            get
                {
                return _extensionAttribute10;
                }
            set
                {
                _extensionAttribute10 = value;
                }
            }

        /// <summary>
        /// Sets or gets the principal name.
        /// </summary>
        public string PrincipalName
            {
            get
                {
                return _principalName;
                }
            set
                {
                _principalName = value;
                }
            }

        /// <summary>
        /// Sets or gets the phone number.
        /// </summary>
        public string Phone
            {
            get
                {
                return _phone;
                }
            set
                {
                _phone = value;
                }
            }



        public string GetTest()
            {
            /*
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("https://www.nrk.no");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
   //         Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.

            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
           */
            /*
            // Parse site
            var html = @"https://html-agility-pack.net/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
            return "Node Name: " + node.Name + "\n" + node.OuterHtml;
            */
            return "";
            }

        public string GetTest2()
            {
            string tmp = "";
            // create new ldap connection
            DirectoryEntry ldapCon = new DirectoryEntry("eikdc201.eikanett.eika.no", "h804602x", "jegkan14");
            ldapCon.Path = "LDAP://OU=Customers,OU=SKALA,DC=EIKANETT,DC=eika,DC=no";
            ldapCon.AuthenticationType = AuthenticationTypes.Secure;

            DirectorySearcher search = new DirectorySearcher(ldapCon);
            // search.Filter = "CN=Thomas Gundersen,OU=Users,OU=KO-ESS,OU=Konsern,OU=Customers,OU=SKALA,DC=EIKANETT,DC=eika,DC=no";
            // search.Filter = "OU=KO-ESS,OU=Konsern,OU=Customers,OU=SKALA,DC=EIKANETT,DC=eika,DC=no";
            search.Filter = "(samaccountname=H804602)";
            SearchResult result = search.FindOne();
            if (result != null)
                {
                ResultPropertyCollection fields = result.Properties;
                foreach (String ldapField in fields.PropertyNames)
                    {
                    foreach (Object myColl in fields[ldapField])
                        {
                        tmp += ldapField + ": " + myColl.ToString() + "\n";
                        }
                    }
                }
            else
                {
                tmp = "fail";
                }

            return tmp;
            }

        public string Test
            {
            get
                {
                return _test;
                }
            set
                {
                _test = value;
                }
            }

        public string Test2
            {
            get
                {
                return _test2;
                }
            set
                {
                _test2 = value;
                }
            }

        }
    }
