﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BetterComm.Models
{
    public class CampaignFunds
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        [ForeignKey("Funds")]
        public int FundId { get; set; }
        public Funds Funds { get; set; }

        public Double FundAmount { get; set; }
    }
}