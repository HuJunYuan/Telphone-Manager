﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pdm;

public partial class SystemManagerForm_Dealer_Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       pdm.Model.DealerInfo di =  new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Request.QueryString["id"]));
        username.Text = Request.QueryString["uname"];
        dealer_name.Text = di.Name;
        telephone_number.Text = di.Tel.ToString();
        addr.Text = di.Address;
        string province = new pdm.BLL.Address_code().GetModel( Convert.ToInt32( di.Province)).A_Name;
        string city = new pdm.BLL.Address_code().GetModel(Convert.ToInt32(di.City)).A_Name;
        string county = new pdm.BLL.Address_code().GetModel(Convert.ToInt32(di.County)).A_Name;
        pd.Text = province + city + county;
    }
}