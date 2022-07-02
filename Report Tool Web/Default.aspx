<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Report_Tool_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>SSRS Deployment WebApp</h1>
        <p class="lead">GwG Destinations Reporting Tool </p>
        </div>

    <div class="row">
        <div class="col-md-4">
            <h3>Source Country 
                <asp:DropDownList ID="DropDownList1" runat="server" Width="50%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_Changed" >
                      <asp:ListItem Text="">--select one--</asp:ListItem>       
                </asp:DropDownList>
            </h3> 
            <h3>Source Folder <asp:DropDownList ID="DropDownList2" runat="server" Width="50%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_Changed">
                    <asp:ListItem Text="">--select one--</asp:ListItem> 
              </asp:DropDownList></h3> 
             
            <h3>Report File <asp:DropDownList ID="DropDownList3" runat="server" Width="150%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_Changed">
                    <asp:ListItem Text=""></asp:ListItem> 
                </asp:DropDownList></h3> 
        </div>
        <div class="col-md-4">
            <h3>Target Country <asp:CheckBoxList ID="CheckBoxList" runat="server" Width="50%" Font-Names="Courier New" Font-Size="Small"
                AutoPostBack="true" RepeatColumns="6"></asp:CheckBoxList></h3>
            <h5>
                <asp:Button ID="Button1" runat="server" Text="Check All" OnClick="CheckAll_Click" /></h5> 
            <h5>
                <asp:Button ID="Button2" runat="server" Text="UnCheck All" OnClick="UnCheckAll_Click" /></h5>
             <h5>
                <asp:Button ID="Button3" runat="server" Text="Get Selected" OnClick="GetSelected_Click"/></h5>  
            <h3>Target Folder <asp:DropDownList ID="DropDownList4" runat="server" Width="50%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList4_Changed">
                <asp:ListItem Text="">--select one--</asp:ListItem> </asp:DropDownList>
            </h3> 
        </div>
        <div class="col-md-4">
            <h2>Actions</h2>
            <p>
                RDL Replacement on RS server <asp:Button ID="Button4" runat="server" Text="Replace" OnClick="Replace_Click" Enabled="true" />
            </p>
            <p>
                Report Deployment on SSRS site <asp:Button ID="Button5" runat="server" Text="Deploy" Enabled="false" OnClick="Deploy_Click" />
                </p>
                      <p>
                <asp:Button ID="Button7" runat="server" Text="Clear All Selections"  OnClick="ClearAll_Click"/>
                </p>

            <p Text="msg"</p>
        </div>
    </div>

</asp:Content>
