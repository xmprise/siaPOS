<%@ Page Title="" Language="VB" MasterPageFile="~/SiaPOSMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="DAL_AccountGridView.aspx.vb" Inherits="Member_DAL_AccountGridView" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
    <h2>매장 매출 정보와 수집된 정보를 편집 합니다. </h2>
<p>수정된 정보는 되돌릴수 없으니 신중히 결정 하시기 바랍니다. </p>
<p><asp:Label ID="UserName" runat="server" />님의 매장 매출 정보 입니다. &nbsp;&nbsp;편집을 원하시면 "선택"을 클릭하세요.</p>
<p>&nbsp;</p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div id="master-detail">
        <div id="master">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" 
        DataSourceID="LinqDataSource1" SkinID="Master-Detail-GridView" 
        DataKeyNames="ShopAccountID">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ShopAccountID" HeaderText="순번" ReadOnly="True" 
                SortExpression="ShopAccountID" InsertVisible="False" />
            <asp:BoundField DataField="ShopID" HeaderText="매장ID" 
                SortExpression="ShopID" />
            <asp:BoundField DataField="MenuName" HeaderText="메뉴명" 
                SortExpression="MenuName" />
            <asp:BoundField DataField="Date" HeaderText="판매 날짜" 
                SortExpression="Date" />
            <asp:BoundField DataField="TableNumber" HeaderText="판매 테이블" 
                SortExpression="TableNumber" />
            <asp:BoundField DataField="MenuAccount" HeaderText="판매 수량" 
                SortExpression="MenuAccount" />
            <asp:BoundField DataField="Profit" HeaderText="판매 금액" SortExpression="Profit" />
            <asp:BoundField DataField="OrderState" HeaderText="판매 상태" 
                SortExpression="OrderState" />
        </Columns>
    </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="SiaPOSDataContext" EntityTypeName="" TableName="ShopAccount" 
        Where="(ShopID == @ShopID)" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True">
        <WhereParameters>
        <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
    </div>

    <div id="detail">
        <asp:Chart ID="Chart1" runat="server" Height="400px" DataSourceID="SqlDataSource1">
            <Series>
                <asp:Series Name="Series1" ChartType="Line" XValueMember="Date" 
                    YValueMembers="Profit">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString1 %>" 
            
            SelectCommand="SELECT DATEPART(mm, Date) AS Date, SUM(Profit * MenuAccount) AS Profit FROM Shop.ShopAccount WHERE (ShopID = @ShopID) GROUP BY DATEPART(mm, Date)">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


