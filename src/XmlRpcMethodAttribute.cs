using System;

namespace SS.MetaWeblog
{
    public class XmlRpcMethodAttribute : Attribute
    {
        public XmlRpcMethodAttribute(string methodName)
        {
            MethodName = methodName;
        }

        public string MethodName { get; set; }
    }
}