﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DogWalking
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewWalk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walks/User_Walk_Add_Page1.aspx");
        }
    }
}