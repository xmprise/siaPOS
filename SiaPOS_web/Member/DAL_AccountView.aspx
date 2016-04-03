<%@ Page Title="" Language="VB" StylesheetTheme="SiaPOSTheme" CodeFile="DAL_AccountView.aspx.vb" Inherits="DAL_AccountView" MasterPageFile="~/ContentMaster.master" %>

<script runat="server">
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
    <h2> 현재 매장 현황 조회 페이지 </h2>
<p><asp:Label ID="UserName" runat="server" />님의 현재 매장 현황 입니다. &nbsp;&nbsp;</p>
<p>&nbsp;</p>
<div>
    <asp:DetailsView ID="DetailsView1" runat="server" Height="400px" Width="400px" 
        AllowPaging="True" AutoGenerateRows="False" DataSourceID="LinqDataSource1" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
        <EditRowStyle BackColor="#7C6F57" />
        <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="ShopID" HeaderText="매장ID" ReadOnly="True" 
                SortExpression="ShopID" />
            <asp:BoundField DataField="MenuName" HeaderText="메뉴명" ReadOnly="True" 
                SortExpression="MenuName"/>
            <asp:BoundField DataField="Date" HeaderText="판매 날짜" 
                ReadOnly="True" SortExpression="Date" />
            <asp:BoundField DataField="TableNumber" HeaderText="판매 테이블" 
                ReadOnly="True" SortExpression="TableNumber" />
            <asp:BoundField DataField="MenuAccount" HeaderText="판매 수량" ReadOnly="True" 
                SortExpression="MenuAccount" />
        </Fields>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
    </asp:DetailsView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="TempShopAccountDataContext" EntityTypeName="" 
        Select="new (MenuName, Date, TableNumber, MenuAccount, ShopID)" 
        TableName="TempShopAccount" Where="ShopID == @ShopID">
        <WhereParameters>
            <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" 
                Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
</div>
</asp:Content>

