using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Text.RegularExpressions;
using Report_Tool_Web.SSRS;

namespace Report_Tool_Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                PopulatesSrcCountries();


                PopulatesTrgCountries();

                
            }




        }

        string pathRS = @"\\xx.xx.xx.xx\\d$\\Projects";
        List<string> newcheckedlist = new List<string>();
        List<string> logMessages = new List<string>();
        List<string> depMessages = new List<string>();



        public void PopulatesSrcCountries()
        {

            string[] srcdests = Directory.GetDirectories(pathRS);
            List<string> newcountrylist = new List<string>();
            foreach (string srcdest in srcdests)
            {
                string lastPart = srcdest.Substring(srcdest.LastIndexOf("\\") + 1);
                newcountrylist.Add(lastPart);

            }
            List<string> finallist = new List<string>();
            foreach (string newcountry in newcountrylist)
            {
                if (newcountry == "A Reports" || newcountry == "CA Reports" || newcountry == "CN Reports" ||
                    newcountry == "CR Reports" || newcountry == "CU Reports" || newcountry == "CY Reports" ||
                    newcountry == "DO Reports" || newcountry == "DU Reports" || newcountry == "EG Reports" ||
                    newcountry == "GR Reports" || newcountry == "IQ Reports" || newcountry == "LE Reports" ||
                    newcountry == "MA Reports" || newcountry == "MT Reports" || newcountry == "MX Reports" ||
                    newcountry == "OM Reports" || newcountry == "TU Reports" || newcountry == "AZ Reports"
                    || newcountry == "MPG Reports" || newcountry == "LB Reports" || newcountry == "GM Reports"
                    || newcountry == "CUB Reports" || newcountry == "BH Reports"
                    )

                    finallist.Add(newcountry);

            }

            foreach (string fin in finallist)
            {
                DropDownList1.Items.Add(new ListItem(fin));


            }

            DropDownList2.Items.Add(new ListItem("Accounting"));
            DropDownList2.Items.Add(new ListItem("Contracting"));
            DropDownList2.Items.Add(new ListItem("Definitions"));
            DropDownList2.Items.Add(new ListItem("Main Data"));
            DropDownList2.Items.Add(new ListItem("Operations"));
            DropDownList2.Items.Add(new ListItem("Reservations"));
            DropDownList2.Items.Add(new ListItem("Management"));
            DropDownList2.Items.Add(new ListItem("Other"));
            DropDownList2.Items.Add(new ListItem("Parent Directory"));






        }

        public void PopulatesTrgCountries()
        {

            string[] srcdests = Directory.GetDirectories(pathRS);
            List<string> newcountrylist = new List<string>();
            foreach (string srcdest in srcdests)
            {
                string lastPart = srcdest.Substring(srcdest.LastIndexOf("\\") + 1);
                newcountrylist.Add(lastPart);

            }
            List<string> finallist = new List<string>();
            foreach (string newcountry in newcountrylist)
            {
                if (newcountry == "A Reports" || newcountry == "CA Reports" || newcountry == "CN Reports" ||
                    newcountry == "CR Reports" || newcountry == "CU Reports" || newcountry == "CY Reports" ||
                    newcountry == "DO Reports" || newcountry == "DU Reports" || newcountry == "EG Reports" ||
                    newcountry == "GR Reports" || newcountry == "IQ Reports" || newcountry == "LE Reports" ||
                    newcountry == "MA Reports" || newcountry == "MT Reports" || newcountry == "MX Reports" ||
                    newcountry == "OM Reports" || newcountry == "TU Reports" || newcountry == "AZ Reports"
                    || newcountry == "MPG Reports" || newcountry == "LB Reports" || newcountry == "GM Reports"
                    || newcountry == "CUB Reports" || newcountry == "BH Reports"
                    )

                    finallist.Add(newcountry);

            }

            foreach (string fin in finallist)
            {
                CheckBoxList.Items.Add(new ListItem(fin));


            }

            DropDownList4.Items.Add(new ListItem("Accounting"));
            DropDownList4.Items.Add(new ListItem("Contracting"));
            DropDownList4.Items.Add(new ListItem("Definitions"));
            DropDownList4.Items.Add(new ListItem("Main Data"));
            DropDownList4.Items.Add(new ListItem("Operations"));
            DropDownList4.Items.Add(new ListItem("Reservations"));
            DropDownList4.Items.Add(new ListItem("Management"));
            DropDownList4.Items.Add(new ListItem("Other"));
            DropDownList4.Items.Add(new ListItem("Parent Directory"));






        }



        public void DropDownList1_Changed(object sender, EventArgs e)

        {

            //DropDownList2.Items.Clear();
            DropDownList3.ClearSelection();
            DropDownList3.Items.Clear();
            //PopulatesSrcCountries();
            //string sel = DropDownList2.SelectedValue;




        }

        public void DropDownList2_Changed(object sender, EventArgs e)

        {
            DropDownList3.ClearSelection();
            DropDownList3.Items.Clear();
            string rdlpath = pathRS + "\\" + DropDownList1.SelectedValue + "\\" + DropDownList2.SelectedValue;
            bool folderExists = Directory.Exists(rdlpath);


            if ((DropDownList2.SelectedIndex == -1 || DropDownList2.SelectedValue == "--select one--") && DropDownList1.SelectedIndex != -1 && DropDownList1.SelectedValue != "--select one--")
            {

                DropDownList1.Items.Remove("--select one--");
                string msg = DropDownList1.Items.Count + " total destinations, Current is " + DropDownList1.SelectedValue + " - Please select Source Folder !!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);

            }


            else if ((DropDownList2.SelectedIndex == -1 || DropDownList2.SelectedValue == "--select one--") && (DropDownList1.SelectedIndex == -1 || DropDownList1.SelectedValue == "--select one--"))
            {
                DropDownList1.Items.Remove("--select one--");
                string msg = DropDownList1.Items.Count + " total destinations, Please select Source Country and Source Folder !!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);

            }

            else if (!folderExists && DropDownList2.SelectedValue != "Parent Directory" && DropDownList1.SelectedValue != "--select one--")
            {
                DropDownList1.Items.Remove("--select one--");
                string msg = DropDownList1.Items.Count + " total destinations, Current is " + DropDownList1.SelectedValue + " - There is no such Source Folder, Please create Missing Subfolder !!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
                DropDownList2.SelectedIndex = -1;
            }

            else if ((DropDownList1.SelectedValue == "--select one--" || DropDownList1.SelectedIndex == -1) && DropDownList2.SelectedIndex != -1 && DropDownList2.SelectedValue != "--select one--")
            {
                DropDownList1.Items.Remove("--select one--");
                string msg = DropDownList1.Items.Count + " total destinations, Please First select Source Country !!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
                DropDownList2.SelectedIndex = -1;
            }


            else if (DropDownList1.SelectedIndex != -1 && DropDownList2.SelectedValue == "Parent Directory" && DropDownList1.SelectedValue != "--select one--")
            {

                string rdlparentpath = pathRS + "\\" + DropDownList1.SelectedValue + "\\" + DropDownList1.SelectedValue;
                string[] rdlFiles = Directory.GetFiles(rdlparentpath, "*.rdl", SearchOption.TopDirectoryOnly);

                foreach (string rdlFile in rdlFiles)
                {

                    DropDownList3.Items.Add(new ListItem(Path.GetFileName((rdlFile))));


                }

                DropDownList1.Items.Remove("--select one--");
                string totsel = DropDownList1.Items.Count + " total destinations, Current is " + DropDownList1.SelectedValue + " / SubFolder " + DropDownList2.SelectedValue + " - Included *.rdl files " + DropDownList3.Items.Count + " /  Current Selected Report : " + DropDownList3.SelectedValue;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + totsel + "');", true);

            }

            else
            {

                string[] rdlFiles = Directory.GetFiles(rdlpath, "*.rdl", SearchOption.TopDirectoryOnly);

                foreach (string rdlFile in rdlFiles)
                {

                    DropDownList3.Items.Add(new ListItem(Path.GetFileName((rdlFile))));


                }

                DropDownList1.Items.Remove("--select one--");
                string totsel = DropDownList1.Items.Count + " total destinations, Current is " + DropDownList1.SelectedValue + " / SubFolder " + DropDownList2.SelectedValue + " - Included *.rdl files " + DropDownList3.Items.Count + " /  Current Selected Report : " + DropDownList3.SelectedValue;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + totsel + "');", true);

            }
        }

        public void DropDownList3_Changed(object sender, EventArgs e)
        {
            string mgs = "Selected Report : " + DropDownList3.SelectedValue;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mgs + "');", true);


        }


        public void CheckAll_Click(object sender, EventArgs e)

        {
            foreach (ListItem chkitem in CheckBoxList.Items)
            {

                chkitem.Selected = true;
                string checkedtot = "All Target Countries are selected !!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + checkedtot + "');", true);


            }

        }

        public void UnCheckAll_Click(object sender, EventArgs e)

        {
            foreach (ListItem chkitem in CheckBoxList.Items)
            {

                chkitem.Selected = false;
                string checkedtot = "All Target Countries are UNselected !!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + checkedtot + "');", true);
            }
        }

        public void GetSelected_Click(object sender, EventArgs e)

        {
            List<string> checkedlist = new List<string>();
            string strChkBox = string.Empty;

            foreach (ListItem chkitem in CheckBoxList.Items)
            {
                if (chkitem.Selected)
                {
                    checkedlist.Add(chkitem.Value);
                    strChkBox += chkitem.Value + "; ";

                }


            }
            string checkedtot = checkedlist.Count.ToString() + " are selected - " + strChkBox;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + checkedtot + "');", true);



        }

        public void DropDownList4_Changed(object sender, EventArgs e)

        {
            if (CheckBoxList.SelectedIndex == -1)
            {
                string conmsg = "Please select Target Country/ies !!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + conmsg + "');", true);
                DropDownList4.ClearSelection();


            }
            else if (DropDownList4.SelectedValue == "--select one--")
            {
                string conmsg = "Please select a valid Target Folder !!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + conmsg + "');", true);

            }


        }

        public void ClearAll_Click(object sender, EventArgs e)
        {
            DropDownList1.ClearSelection();
            DropDownList1.Items.Add("--select one--");
            DropDownList1.SelectedValue = "--select one--";
            DropDownList2.ClearSelection();
            DropDownList3.Items.Clear();
            CheckBoxList.ClearSelection();
            DropDownList4.ClearSelection();
            string cls = "All Selections Cleared !!";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + cls + "');", true);
            Session.Remove("deploy_list");
            Button5.Enabled = false;


        }

        public void Replace_Click(object sender, EventArgs e)

        {
            List<string> varglob = new List<string>();
            if ((DropDownList1.SelectedIndex == -1 || DropDownList1.SelectedValue == "--select one--") ||
               (DropDownList2.SelectedIndex == -1 || DropDownList2.SelectedValue == "--select one--") ||
               (DropDownList3.SelectedIndex == -1 || DropDownList3.SelectedValue == "--select one--") ||
               CheckBoxList.SelectedIndex == -1 ||
               (DropDownList4.SelectedIndex == -1 || DropDownList4.SelectedValue == "--select one--"))
            {

                string finmsg = "Please Fill all inputs fields !!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + finmsg + "');", true);
            }
            else
            {

                foreach (ListItem chkitem in CheckBoxList.Items)
                {
                    if (chkitem.Selected)
                    {
                        newcheckedlist.Add(chkitem.Value);
                    }
                }
                foreach (string chked in newcheckedlist)
                {
                    if (DropDownList2.SelectedValue != "Parent Directory" && DropDownList4.SelectedValue != "Parent Directory")
                    {
                        string selecdirtarg = pathRS + '\\' + chked.ToString() + '\\' + DropDownList4.SelectedValue;
                        string dirsourceRDL = pathRS + '\\' + DropDownList1.SelectedValue + '\\' + DropDownList2.SelectedValue + '\\' + DropDownList3.SelectedValue;

                        if (Directory.Exists(selecdirtarg))
                        {

                            string dirtargRDL = selecdirtarg + '\\' + DropDownList3.SelectedValue;

                            var fileContents = File.ReadAllText(@dirsourceRDL);

                            if (File.Exists(dirtargRDL))
                            {
                                string extension = Path.GetExtension(DropDownList3.SelectedValue);
                                string noextname = DropDownList3.SelectedValue.Substring(0, DropDownList3.SelectedValue.Length - extension.Length);
                                string newrdlname = noextname + "_backup_v_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rdl";
                                File.Move(selecdirtarg + '\\' + DropDownList3.SelectedValue, selecdirtarg + '\\' + newrdlname);

                            }

                            File.WriteAllText(dirtargRDL, fileContents);
                            var fileContentstarg = File.ReadAllText(@dirtargRDL);

                            string srctrimprefix = DropDownList1.SelectedValue.Replace(" Reports", "");
                            string srcprefix = '_' + srctrimprefix + '_';
                            string srcdtsrcprefix = srctrimprefix + "_DataSource";
                            string trgtrimprefix = chked.Replace(" Reports", "");
                            string trgprefix = '_' + trgtrimprefix + '_';
                            string trgdtsrcprefix = trgtrimprefix + "_DataSource";
                            fileContentstarg = Regex.Replace(fileContentstarg, srcprefix, trgprefix, RegexOptions.IgnoreCase);
                            fileContentstarg = Regex.Replace(fileContentstarg, srcdtsrcprefix, trgdtsrcprefix, RegexOptions.IgnoreCase);
                            File.WriteAllText(@dirtargRDL, fileContentstarg);
                            varglob.Add(@dirtargRDL);
                            string dirmsg = "Report " + DropDownList3.SelectedValue + " copied FROM " + DropDownList1.SelectedValue + @"\\" + DropDownList2.SelectedValue + " TO " + chked.ToString() + @"\\" + DropDownList4.SelectedValue + " !!!";
                            logMessages.Add(dirmsg);
                        }
                        else
                        {

                            string selecnewdirtarg = pathRS + '\\' + chked.ToString() + '\\' + chked.ToString();
                            string dirtargRDL = selecnewdirtarg + '\\' + DropDownList3.SelectedValue;

                            var fileContents = File.ReadAllText(@dirsourceRDL);

                            if (File.Exists(dirtargRDL))
                            {
                                string extension = Path.GetExtension(DropDownList3.SelectedValue);
                                string noextname = DropDownList3.SelectedValue.Substring(0, DropDownList3.SelectedValue.Length - extension.Length);
                                string newrdlname = noextname + "_backup_v_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rdl";
                                File.Move(selecnewdirtarg + '\\' + DropDownList3.SelectedValue, selecnewdirtarg + '\\' + newrdlname);

                            }

                            File.WriteAllText(dirtargRDL, fileContents);
                            var fileContentstarg = File.ReadAllText(@dirtargRDL);

                            string srctrimprefix = DropDownList1.SelectedValue.Replace(" Reports", "");
                            string srcprefix = '_' + srctrimprefix + '_';
                            string srcdtsrcprefix = srctrimprefix + "_DataSource";
                            string trgtrimprefix = chked.Replace(" Reports", "");
                            string trgprefix = '_' + trgtrimprefix + '_';
                            string trgdtsrcprefix = trgtrimprefix + "_DataSource";
                            fileContentstarg = Regex.Replace(fileContentstarg, srcprefix, trgprefix, RegexOptions.IgnoreCase);
                            fileContentstarg = Regex.Replace(fileContentstarg, srcdtsrcprefix, trgdtsrcprefix, RegexOptions.IgnoreCase);
                            File.WriteAllText(@dirtargRDL, fileContentstarg);
                            varglob.Add(@dirtargRDL);
                            string nodirmsg = "Directory " + chked.ToString() + @"\\" + DropDownList4.SelectedValue + " not exist, Report " + DropDownList3.SelectedValue + " copied FROM " + DropDownList1.SelectedValue + @"\\" + DropDownList2.SelectedValue + " TO " + chked.ToString() + @"\\Parent Directory !!!";
                            logMessages.Add(nodirmsg);

                        }
                    }
                    else if (DropDownList2.SelectedValue != "Parent Directory" && DropDownList4.SelectedValue == "Parent Directory")
                    {
                        string selecdirtarg = pathRS + '\\' + chked.ToString() + '\\' + chked.ToString();

                        string dirsourceRDL = pathRS + '\\' + DropDownList1.SelectedValue + '\\' + DropDownList2.SelectedValue + '\\' + DropDownList3.SelectedValue;

                        string dirtargRDL = selecdirtarg + '\\' + DropDownList3.SelectedValue;

                        var fileContents = File.ReadAllText(@dirsourceRDL);

                        if (File.Exists(dirtargRDL))
                        {
                            string extension = Path.GetExtension(DropDownList3.SelectedValue);
                            string noextname = DropDownList3.SelectedValue.Substring(0, DropDownList3.SelectedValue.Length - extension.Length);
                            string newrdlname = noextname + "_backup_v_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rdl";
                            File.Move(selecdirtarg + '\\' + DropDownList3.SelectedValue, selecdirtarg + '\\' + newrdlname);

                        }

                        File.WriteAllText(dirtargRDL, fileContents);
                        var fileContentstarg = File.ReadAllText(@dirtargRDL);

                        string srctrimprefix = DropDownList1.SelectedValue.Replace(" Reports", "");
                        string srcprefix = '_' + srctrimprefix + '_';
                        string srcdtsrcprefix = srctrimprefix + "_DataSource";
                        string trgtrimprefix = chked.Replace(" Reports", "");
                        string trgprefix = '_' + trgtrimprefix + '_';
                        string trgdtsrcprefix = trgtrimprefix + "_DataSource";
                        fileContentstarg = Regex.Replace(fileContentstarg, srcprefix, trgprefix, RegexOptions.IgnoreCase);
                        fileContentstarg = Regex.Replace(fileContentstarg, srcdtsrcprefix, trgdtsrcprefix, RegexOptions.IgnoreCase);
                        File.WriteAllText(@dirtargRDL, fileContentstarg);
                        varglob.Add(@dirtargRDL);
                        string nodirmsg = "Report " + DropDownList3.SelectedValue + " copied FROM " + DropDownList1.SelectedValue + @"\\" + DropDownList2.SelectedValue + " TO " + chked.ToString() + @"\\Parent Directory !!!";
                        logMessages.Add(nodirmsg);

                    }
                    else if (DropDownList2.SelectedValue == "Parent Directory" && DropDownList4.SelectedValue != "Parent Directory")
                    {


                        string selecdirtarg = pathRS + '\\' + chked.ToString() + '\\' + DropDownList4.SelectedValue;
                        string dirsourceRDL = pathRS + '\\' + DropDownList1.SelectedValue + '\\' + DropDownList1.SelectedValue + '\\' + DropDownList3.SelectedValue;
                        string dirtargRDL = selecdirtarg + '\\' + DropDownList3.SelectedValue;

                        if (Directory.Exists(selecdirtarg))
                        {


                            var fileContents = File.ReadAllText(@dirsourceRDL);

                            if (File.Exists(dirtargRDL))
                            {
                                string extension = Path.GetExtension(DropDownList3.SelectedValue);
                                string noextname = DropDownList3.SelectedValue.Substring(0, DropDownList3.SelectedValue.Length - extension.Length);
                                string newrdlname = noextname + "_backup_v_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rdl";
                                File.Move(selecdirtarg + '\\' + DropDownList3.SelectedValue, selecdirtarg + '\\' + newrdlname);

                            }

                            File.WriteAllText(dirtargRDL, fileContents);
                            var fileContentstarg = File.ReadAllText(@dirtargRDL);

                            string srctrimprefix = DropDownList1.SelectedValue.Replace(" Reports", "");
                            string srcprefix = '_' + srctrimprefix + '_';
                            string srcdtsrcprefix = srctrimprefix + "_DataSource";
                            string trgtrimprefix = chked.Replace(" Reports", "");
                            string trgprefix = '_' + trgtrimprefix + '_';
                            string trgdtsrcprefix = trgtrimprefix + "_DataSource";
                            fileContentstarg = Regex.Replace(fileContentstarg, srcprefix, trgprefix, RegexOptions.IgnoreCase);
                            fileContentstarg = Regex.Replace(fileContentstarg, srcdtsrcprefix, trgdtsrcprefix, RegexOptions.IgnoreCase);
                            File.WriteAllText(@dirtargRDL, fileContentstarg);
                            varglob.Add(@dirtargRDL);

                            string nodirmsg = "Report " + DropDownList3.SelectedValue + " copied FROM " + DropDownList1.SelectedValue + @"\\Parent Directory TO " + chked.ToString() + @"\\" + DropDownList4.SelectedValue + "!!!";
                            logMessages.Add(nodirmsg);


                        }
                        else
                        {


                            string selecnewdirtarg = pathRS + '\\' + chked.ToString() + '\\' + chked.ToString();
                            string dirnewtargRDL = selecnewdirtarg + '\\' + DropDownList3.SelectedValue;

                            var fileContents = File.ReadAllText(@dirsourceRDL);

                            if (File.Exists(dirnewtargRDL))
                            {
                                string extension = Path.GetExtension(DropDownList3.SelectedValue);
                                string noextname = DropDownList3.SelectedValue.Substring(0, DropDownList3.SelectedValue.Length - extension.Length);
                                string newrdlname = noextname + "_backup_v_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rdl";
                                File.Move(selecnewdirtarg + '\\' + DropDownList3.SelectedValue, selecnewdirtarg + '\\' + newrdlname);

                            }

                            File.WriteAllText(@dirnewtargRDL, fileContents);
                            var fileContentstarg = File.ReadAllText(@dirnewtargRDL);

                            string srctrimprefix = DropDownList1.SelectedValue.Replace(" Reports", "");
                            string srcprefix = '_' + srctrimprefix + '_';
                            string srcdtsrcprefix = srctrimprefix + "_DataSource";
                            string trgtrimprefix = chked.Replace(" Reports", "");
                            string trgprefix = '_' + trgtrimprefix + '_';
                            string trgdtsrcprefix = trgtrimprefix + "_DataSource";
                            fileContentstarg = Regex.Replace(fileContentstarg, srcprefix, trgprefix, RegexOptions.IgnoreCase);
                            fileContentstarg = Regex.Replace(fileContentstarg, srcdtsrcprefix, trgdtsrcprefix, RegexOptions.IgnoreCase);
                            File.WriteAllText(@dirnewtargRDL, fileContentstarg);
                            varglob.Add(@dirnewtargRDL);

                            string nodirmsg = "Directory " + chked.ToString() + @"\\" + DropDownList4.SelectedValue + " not exist, Report " + DropDownList3.SelectedValue + " copied FROM " + DropDownList1.SelectedValue + @"\\Parent Directory TO " + chked.ToString() + @"\\Parent Directory !!!";
                            logMessages.Add(nodirmsg);


                        }
                    }
                    else if (DropDownList2.SelectedValue == "Parent Directory" && DropDownList4.SelectedValue == "Parent Directory")
                    {

                        string selecdirtarg = pathRS + '\\' + chked.ToString() + '\\' + chked.ToString();
                        string dirsourceRDL = pathRS + '\\' + DropDownList1.SelectedValue + '\\' + DropDownList1.SelectedValue + '\\' + DropDownList3.SelectedValue;
                        string dirtargRDL = selecdirtarg + '\\' + DropDownList3.SelectedValue;

                        var fileContents = File.ReadAllText(@dirsourceRDL);

                        if (File.Exists(dirtargRDL))
                        {
                            string extension = Path.GetExtension(DropDownList3.SelectedValue);
                            string noextname = DropDownList3.SelectedValue.Substring(0, DropDownList3.SelectedValue.Length - extension.Length);
                            string newrdlname = noextname + "_backup_v_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rdl";
                            File.Move(selecdirtarg + '\\' + DropDownList3.SelectedValue, selecdirtarg + '\\' + newrdlname);

                        }

                        File.WriteAllText(dirtargRDL, fileContents);
                        var fileContentstarg = File.ReadAllText(@dirtargRDL);

                        string srctrimprefix = DropDownList1.SelectedValue.Replace(" Reports", "");
                        string srcprefix = '_' + srctrimprefix + '_';
                        string srcdtsrcprefix = srctrimprefix + "_DataSource";
                        string trgtrimprefix = chked.Replace(" Reports", "");
                        string trgprefix = '_' + trgtrimprefix + '_';
                        string trgdtsrcprefix = trgtrimprefix + "_DataSource";
                        fileContentstarg = Regex.Replace(fileContentstarg, srcprefix, trgprefix, RegexOptions.IgnoreCase);
                        fileContentstarg = Regex.Replace(fileContentstarg, srcdtsrcprefix, trgdtsrcprefix, RegexOptions.IgnoreCase);
                        File.WriteAllText(@dirtargRDL, fileContentstarg);
                        varglob.Add(@dirtargRDL);
            
                        string dirmsg = "Report " + DropDownList3.SelectedValue + " copied FROM " + DropDownList1.SelectedValue + @"\\Parent Directory TO " + chked.ToString() + @"\\Parent Directory !!!";
                        logMessages.Add(dirmsg);


                    }
                }
                string repmsg = newcheckedlist.Count().ToString() + " replacement(s) done !!!";
                logMessages.Add(repmsg );
                logMessages.Add("You may now procced to RDL Deployment on SSRS site....");
                string finallogMessages = String.Join("\\n\\n", logMessages);
                //finallogMessages.Add(String.Join(System.Environment.NewLine, @logMessages)); 
                //finallogMessages.Add(String.Join(";", logMessages));
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + finallogMessages + "');", true);
                Button5.Enabled = true;
                //List<string> varglobnew = new List<string>();
                //List<string> varglobnew = new List<string>(varglob);
            }

            Session.Add("deploy_list", varglob);
        }


        public void Deploy_Click(object sender, EventArgs e)
        {
            List<string> varglobs = (List<string>) Session["deploy_list"];
            //List<string> deploylist = new List<string>(varglobnew);
            foreach (string vrg in varglobs)
            {
                string[] newvrg = vrg.Split('\\');
                SSRS.ReportingService2010 rs = new ReportingService2010();
                rs.Url = "http://xx.xx.xx.xx/ReportServer_SSRS/ReportService2010.asmx";
                rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
                Byte[] definition = null;
                Warning[] warnings = null;
                string pubname = newvrg[9];

                try
                {
                    FileStream stream = File.OpenRead(vrg);
                    definition = new Byte[stream.Length];
                    stream.Read(definition, 0, (int)stream.Length);
                    stream.Close();
                }
                catch (IOException er)
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + er + "');", true);
                }



                string parent = '/' + newvrg[7] + '/' + newvrg[8];
                
                string firtsfolder = '/' + newvrg[7];
                CatalogItem[] listfolderpar = rs.ListChildren(firtsfolder, false);
                //var replist = listfolderpar.Select(s => new { s.ID, s.Name, s.Path }).ToList();
                List<string> expectednames = new List<string>();
                expectednames.Add("Accounting");
                expectednames.Add("Contracting");
                expectednames.Add("Definitions");
                expectednames.Add("Main Data");
                expectednames.Add("Operations");
                expectednames.Add("Reservations");
                expectednames.Add("Management");
                expectednames.Add("Other");
                bool alreadyExist = rs.ListChildren(firtsfolder, false).Any(s => expectednames.Contains(s.Name));
                //var filteredList = replist.Where(s => s.Name == "Contracting").ToList();
                //var result = list.where(i => i.age > 45);


                //List<Tuple<string, string, string>> newdeplist = replist;

                //bool alreadyExist = (
                //    replist[0].Name == "Accounting" || replist[1].Name == "Accounting" || replist[2].Name == "Accounting" ||
                //    replist[0].Name == "Contracting" || replist[1].Name == "Contracting" || replist[2].Name == "Contracting" ||
                //    replist[0].Name == "Definitions" || replist[1].Name == "Definitions" || replist[2].Name == "Definitions" ||
                //    replist[0].Name == "Main Data" || replist[1].Name == "Main Data" || replist[2].Name == "Main Data" ||
                //    replist[0].Name == "Operations" || replist[1].Name == "Operations" || replist[2].Name == "Operations" ||
                //    replist[0].Name == "Reservations" || replist[1].Name == "Reservations" || replist[2].Name == "Reservations" ||
                //    replist[0].Name == "Management" || replist[1].Name == "Management" || replist[2].Name == "Management" ||
                //    replist[0].Name == "Other" || replist[1].Name == "Other" || replist[2].Name == "Other" 
                //    );

                //var replist = listfolderpar.AsQueryable().Contains(parent);

                if ( alreadyExist==true  && !newvrg[8].Contains("Reports"))
                {
                    CatalogItem report = rs.CreateCatalogItem("Report", pubname.Remove(pubname.Length - 4, 4), parent, true, definition, null, out warnings);

                    DataSourceReference reference = new DataSourceReference();
                    DataSource ds = new DataSource();

                    reference.Reference = @"/Data Sources/" + Regex.Replace(newvrg[7], " Reports", "", RegexOptions.IgnoreCase) + "_DataSource";
                    DataSource[] dsarray = rs.GetItemDataSources(parent + '/' + pubname.Remove(pubname.Length - 4, 4));
                    ds = dsarray[0];
                    ds.Item = (DataSourceReference)reference;
                    ds.Name = Regex.Replace(newvrg[7], " Reports", "", RegexOptions.IgnoreCase) + "_DataSource";
                    rs.SetItemDataSources(parent + '/' + pubname.Remove(pubname.Length - 4, 4), dsarray);

                    string depmsg = "Report " + newvrg[9] + " published successfully on " + newvrg[7] + "/" + newvrg[8];
                    depMessages.Add(depmsg);



                }
                else
                  {
                        CatalogItem report = rs.CreateCatalogItem("Report", pubname.Remove(pubname.Length - 4, 4), firtsfolder, true, definition, null, out warnings);

                        DataSourceReference reference = new DataSourceReference();
                        DataSource ds = new DataSource();

                        reference.Reference = @"/Data Sources/" + Regex.Replace(newvrg[7], " Reports", "", RegexOptions.IgnoreCase) + "_DataSource";
                        DataSource[] dsarray = rs.GetItemDataSources(firtsfolder + '/' + pubname.Remove(pubname.Length - 4, 4));
                        ds = dsarray[0];
                        ds.Item = (DataSourceReference)reference;
                        ds.Name = Regex.Replace(newvrg[7], " Reports", "", RegexOptions.IgnoreCase) + "_DataSource";
                        rs.SetItemDataSources(firtsfolder + '/' + pubname.Remove(pubname.Length - 4, 4), dsarray);

                        string depmsg = "Report " + newvrg[9] + " published successfully on " + newvrg[7] ;
                        depMessages.Add(depmsg);



                    }

                


                //--Folder Research
                //var ssrspath = rs.ListParents(parent);
                //CatalogItem[] listfolders = rs.ListChildren(firtsfolder,false);
                //CatalogItem[] listfolderpar = rs.ListChildren(parent, false);
                //var items = rs.li
                //--Folder Research




            }

            //string finallogMessages = String.Join("\\n\\n", logMessages);
            //finallogMessages.Add(String.Join(System.Environment.NewLine, @logMessages)); 
            //finallogMessages.Add(String.Join(";", logMessages));
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + String.Join("\\n\\n", depMessages) + "');", true);
            Button5.Enabled = false;

            
            Session.Remove("deploy_list");
        }
    }
}

        
    



    



    

