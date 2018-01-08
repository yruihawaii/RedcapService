using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedcapService.Models
{
    public class RedcapDET
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string ProjectId { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string Instrument { get; set; }

        [StringLength(255)]
        public string RecordName { get; set; }

        [StringLength(255)]
        public string EventName { get; set; }

        [StringLength(255)]
        public string ProjectUrl { get; set; }

        public DateTime TriggerTime { get; set; }

    }
}