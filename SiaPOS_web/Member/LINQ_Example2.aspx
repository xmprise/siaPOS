<%@ Page Title="" Language="VB" StylesheetTheme="SiaPOSTheme" MasterPageFile="~/ContentMaster.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
    <h2>LINQ 테스트 페이지-2</h2>
<p>LinqDataSource 컨트롤을 이용하여 LINQ를 사용하는 예를 보여 줍니다.</p>
<p>&nbsp;</p>
<p>LINQ Example</p>
<p>&nbsp;</p>
<div id="InsertTest">
     <span>UserID를 입력하고 아래 버튼을 클릭하세요.</span>
     <asp:TextBox ID="UserIDBox" runat="server"
          AutoPostBack="true"></asp:TextBox>
     <p>&nbsp;</p>
     <asp:Button ID="Button1" runat="server"
          Text="GetServicesByUserID" />
</div>
<p>&nbsp;</p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" 
        DataSourceID="LinqDataSource1">
        <Columns>
            <asp:BoundField DataField="ShopAccountID" HeaderText="ShopAccountID" 
                ReadOnly="True" SortExpression="ShopAccountID" />
            <asp:BoundField DataField="MenuName" HeaderText="MenuName" 
                SortExpression="MenuName" ReadOnly="True" />
            <asp:BoundField DataField="Date" HeaderText="Date" 
                SortExpression="Date" ReadOnly="True" />
            <asp:BoundField DataField="TableNumber" HeaderText="TableNumber" DataFormatString="{0:d}" 
                SortExpression="TableNumber" ReadOnly="True" />
            <asp:BoundField DataField="MenuAccount" HeaderText="MenuAccount" 
                SortExpression="MenuAccount" ReadOnly="True" />
            <asp:BoundField DataField="Profit" HeaderText="Profit" 
                SortExpression="Profit" ReadOnly="True" />
            <asp:BoundField DataField="OrderState" HeaderText="OrderState" 
                SortExpression="OrderState" ReadOnly="True" />
            <asp:BoundField DataField="Total" HeaderText="Total"
                SortExpression="Total" ReadOnly="true" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="SiaPOSDataContext" EntityTypeName="" TableName="ShopAccount" 
        Where="ShopID == @ShopID" 
        
        Select="new (ShopAccountID, MenuName, Date, TableNumber, MenuAccount, Profit, OrderState, (Profit * MenuAccount) as Total)">
        <WhereParameters>
            <asp:ControlParameter ControlID="UserIDBox" Name="ShopID" PropertyName="Text" 
                Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
</asp:Content>

