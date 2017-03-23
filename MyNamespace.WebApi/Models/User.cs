using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace MyNamespace.WebApi.Models
{
    
    //[DataContract(Namespace = "")]
    public class User
    {
        //[DataMember]
        public string Name { get; set; }
        //[DataMember]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}