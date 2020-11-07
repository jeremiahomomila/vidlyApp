﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> membershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.id != 0)
                    return "Edit Customer";
                return "New Customer";
            }
        }

    }
}