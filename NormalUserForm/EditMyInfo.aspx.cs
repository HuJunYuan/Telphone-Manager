﻿/*----------------------------------------------------------------
// 文件名：EditMyInfo.aspx.cs
// 文件功能描述：修改我的信息
//
//
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using pdm;
public partial class SystemManagerForm_EditInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        username.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {
            
                if (Session.Count > 0 && Session["userID"].ToString() != "")
                { }
                else
                {
                    Response.Redirect("/loginout.aspx?method=sb");
                }
            

            ListItem prov = new ListItem();
                prov = new ListItem();
                prov.Text = "--省份--";
                prov.Value = "0";
                Province.Items.Add(prov);
            //为文本框赋值
            pdm.Model.DealerInfo temp = new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"].ToString()));
            dealer_name.Text = temp.Name;
            telephone_number.Text = temp.Tel.ToString();
            addr.Text = temp.Address;


                //生成省份下拉菜单选项
                DataSet ProvDS = new DataSet();
                string sql = "select * from Address_code where Code < 100";
                ProvDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql);
                int num = 0;

                if ((num = ProvDS.Tables[0].Rows.Count) > 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        prov = new ListItem();
                        prov.Value = ProvDS.Tables[0].Rows[i]["Code"].ToString();
                        prov.Text = ProvDS.Tables[0].Rows[i]["A_Name"].ToString();
                        Province.Items.Add(prov);
                    }
                }
                string level = Session["UserLevel"].ToString();
                switch (level)
                {
                    case "2"://省级
                        Province.SelectedValue = new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"].ToString())).Province.ToString();
                        Province.Enabled = false;
                        City.Visible = true;
                        County.Visible = false;
                        City.Items.Clear();
                        County.Items.Clear();
                        ListItem city = new ListItem();
                        city.Text = "--城市--";
                        city.Value = "0";
                        City.Items.Add(city);


                        DataSet cityDS = new DataSet();
                        int citycode = Convert.ToInt32(Province.SelectedValue) * 100;
                        // Response.Write("<script type='text/javascript'>alert('" + citycode + "')</script>");
                        string sqlcity = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
                        System.Data.SqlClient.SqlParameter ct = new System.Data.SqlClient.SqlParameter("@ccode", citycode);
                        cityDS = Maticsoft.DBUtility.DbHelperSQL.Query(sqlcity, ct);
                        num = 0;


                        if ((num = cityDS.Tables[0].Rows.Count) > 0)
                        {
                            for (int i = 0; i < num; i++)
                            {
                                city = new ListItem();
                                city.Value = cityDS.Tables[0].Rows[i]["Code"].ToString();
                                city.Text = cityDS.Tables[0].Rows[i]["A_Name"].ToString();
                                City.Items.Add(city);
                            }
                        }

                        break;
                    case "3"://市级
                             //省份选择：不可更改
                        Province.SelectedValue = new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"].ToString())).Province.ToString();
                        Province.Enabled = false;
                        //市区选择：不可更改
                        City.Visible = true;
                        County.Visible = false;
                        City.Items.Clear();
                        County.Items.Clear();
                        city = new ListItem();
                        city.Text = "--城市--";
                        city.Value = "0";
                        City.Items.Add(city);
                        sqlcity = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
                        citycode = Convert.ToInt32(Province.SelectedValue) * 100;
                        System.Data.SqlClient.SqlParameter ct1 = new System.Data.SqlClient.SqlParameter("@ccode", citycode);
                        cityDS = Maticsoft.DBUtility.DbHelperSQL.Query(sqlcity, ct1);
                        num = 0;


                        if ((num = cityDS.Tables[0].Rows.Count) > 0)
                        {
                            for (int i = 0; i < num; i++)
                            {
                                city = new ListItem();
                                city.Value = cityDS.Tables[0].Rows[i]["Code"].ToString();
                                city.Text = cityDS.Tables[0].Rows[i]["A_Name"].ToString();
                                City.Items.Add(city);
                            }
                        }

                        City.SelectedValue = new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"].ToString())).City.ToString();
                        City.Enabled = false;
                        //县级选择：允许更改
                        County.Visible = true;
                        County.Items.Clear();
                        ListItem county = new ListItem();
                        county.Text = "--县--";
                        county.Value = "0";
                        County.Items.Add(county);


                        DataSet countyDS = new DataSet();
                        int countycode = Convert.ToInt32(City.SelectedValue) * 100;
                        // Response.Write("<script type='text/javascript'>alert('" + citycode + "')</script>");
                        string countysql = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
                        System.Data.SqlClient.SqlParameter coun = new System.Data.SqlClient.SqlParameter("@ccode", countycode);
                        countyDS = Maticsoft.DBUtility.DbHelperSQL.Query(countysql, coun);
                        num = 0;


                        if ((num = countyDS.Tables[0].Rows.Count) > 0)
                        {
                            for (int i = 0; i < num; i++)
                            {
                                county = new ListItem();
                                county.Value = countyDS.Tables[0].Rows[i]["Code"].ToString();
                                county.Text = countyDS.Tables[0].Rows[i]["A_Name"].ToString();
                                County.Items.Add(county);
                            }
                        }
                        break;
                    case "4"://县级用户
                    Province.SelectedValue = new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"].ToString())).Province.ToString();
                    Province.Enabled = false;
                    //市区选择：不可更改
                    City.Visible = true;
                    County.Visible = false;
                    City.Items.Clear();
                    County.Items.Clear();
                    city = new ListItem();
                    city.Text = "--城市--";
                    city.Value = "0";
                    City.Items.Add(city);
                    sqlcity = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
                    citycode = Convert.ToInt32(Province.SelectedValue) * 100;
                    System.Data.SqlClient.SqlParameter ct2 = new System.Data.SqlClient.SqlParameter("@ccode", citycode);
                    cityDS = Maticsoft.DBUtility.DbHelperSQL.Query(sqlcity, ct2);
                    num = 0;


                    if ((num = cityDS.Tables[0].Rows.Count) > 0)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            city = new ListItem();
                            city.Value = cityDS.Tables[0].Rows[i]["Code"].ToString();
                            city.Text = cityDS.Tables[0].Rows[i]["A_Name"].ToString();
                            City.Items.Add(city);
                        }
                    }

                    City.SelectedValue = new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"].ToString())).City.ToString();
                    City.Enabled = false;
                    //县级选择：不允许更改
                    County.Visible = true;
                    County.Items.Clear();
                    county = new ListItem();
                    county.Text = "--县--";
                    county.Value = "0";
                    County.Items.Add(county);


                    DataSet couDS = new DataSet();
                    int coucode = Convert.ToInt32(City.SelectedValue) * 100;
                    // Response.Write("<script type='text/javascript'>alert('" + citycode + "')</script>");
                    string cousql = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
                    System.Data.SqlClient.SqlParameter cou = new System.Data.SqlClient.SqlParameter("@ccode", coucode);
                    countyDS = Maticsoft.DBUtility.DbHelperSQL.Query(cousql, cou);
                    num = 0;


                    if ((num = countyDS.Tables[0].Rows.Count) > 0)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            county = new ListItem();
                            county.Value = countyDS.Tables[0].Rows[i]["Code"].ToString();
                            county.Text = countyDS.Tables[0].Rows[i]["A_Name"].ToString();
                            County.Items.Add(county);
                        }
                    }
                    County.SelectedValue= new pdm.BLL.DealerInfo().GetModel(Convert.ToInt32(Session["userID"].ToString())).County.ToString();
                    County.Enabled = false;
                    break;



            }


        }
    }

    protected void Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        City.Visible = true;
        County.Visible = false;
        City.Items.Clear();
        County.Items.Clear();
        ListItem city = new ListItem();
        city.Text = "--城市--";
        city.Value = "0";
        City.Items.Add(city);


        DataSet cityDS = new DataSet();
        int citycode = Convert.ToInt32(Province.SelectedValue) * 100;
        // Response.Write("<script type='text/javascript'>alert('" + citycode + "')</script>");
        string sql = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
        System.Data.SqlClient.SqlParameter ct = new System.Data.SqlClient.SqlParameter("@ccode", citycode);
        cityDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, ct);
        int num = 0;


        if ((num = cityDS.Tables[0].Rows.Count) > 0)
        {
            for (int i = 0; i < num; i++)
            {
                city = new ListItem();
                city.Value = cityDS.Tables[0].Rows[i]["Code"].ToString();
                city.Text = cityDS.Tables[0].Rows[i]["A_Name"].ToString();
                City.Items.Add(city);
            }
        }
    }

    protected void City_SelectedIndexChanged(object sender, EventArgs e)
    {
        County.Visible = true;
        County.Items.Clear();
        ListItem county = new ListItem();
        county.Text = "--县--";
        county.Value = "0";
        County.Items.Add(county);


        DataSet countyDS = new DataSet();
        int countycode = Convert.ToInt32(City.SelectedValue) * 100;
        // Response.Write("<script type='text/javascript'>alert('" + citycode + "')</script>");
        string sql = "select * from Address_code where Code > @ccode and  Code < (@ccode+100)";
        System.Data.SqlClient.SqlParameter ct = new System.Data.SqlClient.SqlParameter("@ccode", countycode);
        countyDS = Maticsoft.DBUtility.DbHelperSQL.Query(sql, ct);
        int num = 0;


        if ((num = countyDS.Tables[0].Rows.Count) > 0)
        {
            for (int i = 0; i < num; i++)
            {
                county = new ListItem();
                county.Value = countyDS.Tables[0].Rows[i]["Code"].ToString();
                county.Text = countyDS.Tables[0].Rows[i]["A_Name"].ToString();
                County.Items.Add(county);
            }
        }


    }

    protected void sub_Click(object sender, EventArgs e)
    {
        
        pdm.Model.DealerInfo di = new pdm.Model.DealerInfo();
        di.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
        di.Name = dealer_name.Text.Trim();
        di.Province = Convert.ToInt32(Province.SelectedValue);
        di.City = Convert.ToInt32(City.SelectedValue);
        di.County = Convert.ToInt32(County.SelectedValue);
        di.Tel = Convert.ToInt32(telephone_number.Text);
        di.Address = addr.Text;
        new pdm.BLL.DealerInfo().Update(di);

        //添加操作日志
        pdm.Model.UseLog log = new pdm.Model.UseLog();
        log.Method = "edit_my_info";
        log.Time = DateTime.Now;
        log.Dealer_ID = Convert.ToInt32(Session["userID"].ToString());
        new pdm.BLL.UseLog().Add(log);

        Response.Write("<script type='text/javascript'>alert('修改成功')</script>");

    }

    protected void reset_Click(object sender, EventArgs e)
    {
        username.Text = "";
        dealer_name.Text = "";
        telephone_number.Text = "";
        addr.Text = "";
        Province.SelectedIndex = 0;
        City.Visible = false;
        County.Visible = false;
    }
}