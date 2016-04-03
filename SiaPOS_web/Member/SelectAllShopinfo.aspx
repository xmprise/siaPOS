<%@ Page Title="" Language="VB" MasterPageFile="~/SiaPOSMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="SelectAllShopinfo.aspx.vb" Inherits="SelectAllShopinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
    <h2>매장 정보 종합 조회</h2>
<p>등록된 매장의 모든 정보를 종합하여 나열 합니다.&nbsp;&nbsp;</p>
<p><asp:Label ID="UserName" runat="server" />님의 매장 정보 입니다. &nbsp;&nbsp;</p>
<p>&nbsp;</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div id="master-detail">
        <div id="master">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="97%"  
                DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" 
                CellPadding="4" ForeColor="#333333" 
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="MenuName" HeaderText="MenuName" 
                        SortExpression="MenuName" />
                    <asp:BoundField DataField="TableNumber" HeaderText="TableNumber" 
                        SortExpression="TableNumber" />
                    <asp:BoundField DataField="MenuPrice" HeaderText="MenuPrice" 
                        SortExpression="MenuPrice" />
                    <asp:BoundField DataField="MenuAccount" HeaderText="MenuAccount" 
                        SortExpression="MenuAccount" />
                    <asp:BoundField DataField="Profit" HeaderText="Profit" 
                        SortExpression="Profit" ReadOnly="True" />
                    <asp:BoundField DataField="OrderState" HeaderText="OrderState" 
                        SortExpression="OrderState" />
                    <asp:BoundField DataField="Date" HeaderText="Date" 
                        SortExpression="Date" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
                
                SelectCommand="SELECT Ts.MenuName, Ts.TableNumber, Mu.MenuPrice, Ts.MenuAccount, Mu.MenuPrice * Ts.MenuAccount AS Profit, Ts.OrderState, Ts.Date FROM Shop.ShopAccount AS Ts INNER JOIN Person.MemberInfo AS Us ON Ts.ShopID = Us.UserName INNER JOIN Product.MenuInformation AS Mu ON Ts.MenuName = Mu.MenuName WHERE (Ts.ShopID = @ShopID) AND (Us.UserName = @ShopID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
    </div>

    <div id="detail">
  
        <asp:DetailsView ID="DetailsView1" runat="server" Height="200px" Width="33%" 
            AutoGenerateRows="False" BackColor="White" BorderColor="#E7E7FF" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="UserName" 
            DataSourceID="SqlDataSource2" GridLines="Horizontal" 
            SkinID="Master-Detail-DetailsView">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <Fields>
                <asp:BoundField DataField="UserName" HeaderText="ShopID" ReadOnly="True" 
                    SortExpression="UserName" />
                <asp:BoundField DataField="UserShopName" HeaderText="ShopName" 
                    SortExpression="UserShopName" />
                <asp:BoundField DataField="RealName" HeaderText="RealName" 
                    SortExpression="RealName" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" 
                    SortExpression="Gender" />
                <asp:BoundField DataField="Region" HeaderText="Region" 
                    SortExpression="Region" />
                <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" 
                    SortExpression="Phone" />
                <asp:BoundField DataField="ShopTableAccount" HeaderText="TableAccount" 
                    SortExpression="ShopTableAccount" />
                <asp:BoundField DataField="UserShopType" HeaderText="ShopType" 
                    SortExpression="UserShopType" />
                <asp:BoundField DataField="Intro" HeaderText="Introduce" 
                    SortExpression="Intro" />
                <asp:BoundField DataField="총 판매 현황" HeaderText="Total Account" ReadOnly="True" 
                    SortExpression="총 판매 현황" />
            </Fields>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
            
            SelectCommand="SELECT Ts.UserShopName, Tm.Phone ,Tm.Region, Ts.ShopTableAccount, Tm.RealName, Tm.Address, Tm.UserName, tm.Gender,
            Ts.UserShopType, Tm.Intro, COUNT(Ta.TableNumber) AS '총 판매 현황'
FROM  Person.MemberInfo AS Tm INNER JOIN
            Shop.ShopAccount AS Ta ON Tm.UserName = Ta.ShopID INNER JOIN
            Person.MemberShop AS Ts ON Tm.UserName = Ts.UserName 
WHERE (Ta.ShopID = @ShopID)
GROUP BY Tm.Address, Tm.RealName,tm.Gender, Ts.ShopTableAccount, Tm.Region, Tm.Phone, Ts.UserShopName, Tm.UserName, 
            Ta.ShopID, Ts.UserShopType, Tm.Intro">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

