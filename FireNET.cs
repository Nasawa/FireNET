using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FireNET
{
    public class FireNET
    {
        private String root, current;
        private System.Net.HttpWebRequest request;

        public FireNET(String URL, String auth = null)
        {
            current = root = URL;
        }

        public String getRoot()
        {
            return root;
        }

        public String getChildren(String child = "")
        {
            request = System.Net.WebRequest.Create(current + child + ".json") as System.Net.HttpWebRequest;
            request.Method = "GET";
            request.ContentLength = 0;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public String getChild(String child)
        {
            return getChildren(child);
        }

        public void descend(String child)
        {
            current += child;
        }

        public void ascend(String parent)
        {
            var t = current.LastIndexOf(parent);
            current = current.Substring(0, t + parent.Length);
        }
    }
}
