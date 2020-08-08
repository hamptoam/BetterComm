﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BetterComm.Models
{
    public class CalleeCampaign
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Callee")]
        public int CalleeId { get; set; }
        public Callee Callee { get; set; }

        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}