<%@ Page Title="" Language="VB" MasterPageFile="~/SiaPOSMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="DiscardMenu.aspx.vb" Inherits="Member_DiscardMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
<h2>Status Discard Menu</h2>
    <p><asp:Label ID="UserName" runat="server" />&#39;s Shop Information.</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            DataSourceID="SqlDataSource1" GridLines="Horizontal" Height="290px" 
            Width="579px" AllowSorting="True">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="MenuName" HeaderText="MenuName" 
                    SortExpression="MenuName" />
                <asp:BoundField DataField="OrderState" HeaderText="Quantity" ReadOnly="True" 
                    SortExpression="OrderState" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    </p>
    <p>&nbsp;</p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
            SelectCommand="SELECT MenuName, COUNT(OrderState) AS OrderState FROM Shop.ShopAccount WHERE (ShopID = @ShopID) AND (OrderState = 0) GROUP BY MenuName">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2" 
            Height="358px" Palette="Berry" Width="676px">
            <Series>
                <asp:Series ChartType="Bar" Name="Series1" XValueMember="MenuName" 
                    YValueMembers="OrderState">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
            SelectCommand="SELECT MenuName, COUNT(OrderState) AS OrderState FROM Shop.ShopAccount WHERE (ShopID = @ShopID) AND (OrderState = 0) GROUP BY MenuName">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

