<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="VeriListeleme.aspx.cs" Inherits="VeriListeleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 73%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Oturumu Kapat" />
            </td>
        </tr>
    </table>
</asp:Content>

