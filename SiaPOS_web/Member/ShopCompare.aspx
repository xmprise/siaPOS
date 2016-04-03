<%@ Page Title="" Language="VB" MasterPageFile="~/SiaPOSMaster.master" AutoEventWireup="false" StylesheetTheme="SiaPOSTheme" CodeFile="ShopCompare.aspx.vb" Inherits="Member_ShopCompare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
<h2>Shop Sales Compared</h2>
    <p><asp:Label ID="UserName" runat="server" />&#39;s Shop Information.</p>
    <p>&nbsp;&nbsp;&nbsp;</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" 
            ForeColor="#333333" GridLines="None" Height="300px" Width="606px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="DayFinishDate" HeaderText="DayFinishDate" 
                    SortExpression="DayFinishDate" />
                <asp:BoundField DataField="ShopTotalProfit" DataFormatString="{0:N0}" 
                    HeaderText="ShopTotalProfit" SortExpression="ShopTotalProfit" />
                <asp:BoundField DataField="ShopMissingProfig" DataFormatString="{0:N0}" 
                    HeaderText="ShopMissingProfit" SortExpression="ShopMissingProfig" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" SelectCommand="select DayFinishDate, ShopTotalProfit,ShopMissingProfig
from Shop.ShopDayFinish
where ShopID=@ShopID">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <span class="hps" 
            style="color: rgb(51, 51, 51); font-family: arial, sans-serif; font-size: 24px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(245, 245, 245); ">
        <br />
        Compared to</span><span class="Apple-style-span" 
            style="color: rgb(51, 51, 51); font-family: arial, sans-serif; font-size: 24px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(245, 245, 245); display: inline !important; float: none; "><span 
            class="Apple-converted-space">&nbsp;</span></span><span class="hps" 
            style="color: rgb(51, 51, 51); font-family: arial, sans-serif; font-size: 24px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(245, 245, 245); ">sales 
        of</span><span class="Apple-style-span" 
            style="color: rgb(51, 51, 51); font-family: arial, sans-serif; font-size: 24px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(245, 245, 245); display: inline !important; float: none; "><span 
            class="Apple-converted-space">&nbsp;</span></span><span class="hps" 
            style="color: rgb(51, 51, 51); font-family: arial, sans-serif; font-size: 24px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(245, 245, 245); ">other 
        stores</span><br />
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
            Palette="Bright" Width="534px">
            <Series>
                <asp:Series Legend="Legend1" Name="YourShop" YValueMembers="Your_Shop">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="TotalShop" 
                    YValueMembers="Total_Shop">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" SelectCommand="select (select AVG(a.ShopTotalProfit)
		from shop.ShopDayFinish a
		where a.ShopID = @ShopID) as Your_Shop, AVG(ShopTotalProfit) as Total_Shop
from shop.ShopDayFinish ">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

