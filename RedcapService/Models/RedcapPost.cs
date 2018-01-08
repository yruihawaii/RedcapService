using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedcapService.Models
{
    public class RedcapPost
    {
        public string project_id { get; set; }
        public string username { get; set; }
        public string instrument { get; set; }
        public string record { get; set; }
        public string redcap_event_name { get; set; }
        public string redcap_data_access_group { get; set; }
        public string redcap_url { get; set; }
        public string project_url { get; set; }
    }
}