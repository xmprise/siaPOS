<%@ Page Title="" Language="VB" StylesheetTheme="SiaPOSTheme" MasterPageFile="~/ContentMaster.master" %>

<script runat="server">

</script>

<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
    <h2>LINQ 테스트 페이지-1</h2>
<p>LinqDataSource 컨트롤을 이용하여 LINQ를 사용하는 예를 보여 줍니다.</p>
<p>&nbsp;</p>
<p>Select="new (ShopAccountID, ShopID, MenuName, Date, TableNumber, MenuAccount, Profit, OrderState)"<br />
   where="ShopID == @ShopID" &amp; &quot;OrderState ==0 &quot; </p>
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
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ShopAccountID" 
        DataSourceID="LinqDataSource1" SkinID="TestGridView">
        <Columns>
            <asp:BoundField DataField="ShopAccountID" HeaderText="ShopAccountID" 
                InsertVisible="False" ReadOnly="True" SortExpression="ShopAccountID" />
            <asp:BoundField DataField="ShopID" HeaderText="ShopID" 
                SortExpression="ShopID" />
            <asp:BoundField DataField="MenuName" HeaderText="MenuName" 
                SortExpression="MenuName" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="TableNumber" HeaderText="TableNumber" 
                SortExpression="TableNumber" />
            <asp:BoundField DataField="MenuAccount" HeaderText="MenuAccount" 
                SortExpression="MenuAccount" />
            <asp:BoundField DataField="Profit" HeaderText="Profit" 
                SortExpression="Profit" />
            <asp:BoundField DataField="OrderState" HeaderText="OrderState" 
                SortExpression="OrderState" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="SiaPOSDataContext" EntityTypeName="" TableName="ShopAccount" 
        Where="ShopID == @ShopID &amp;&amp; OrderState == @OrderState">
        <WhereParameters>
            <asp:ControlParameter ControlID="UserIDBox" Name="ShopID" PropertyName="Text" 
                Type="String" />
            <asp:Parameter DefaultValue="0" Name="OrderState" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>
</asp:Content>

