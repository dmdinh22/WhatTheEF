using System;
using System.Collections.Generic;

namespace AdventureworksModel.Models
{
    public class BuildVersion
    {
        public byte SystemInformationID { get; set; }
        public string Database_Version { get; set; }
        public System.DateTime VersionDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
