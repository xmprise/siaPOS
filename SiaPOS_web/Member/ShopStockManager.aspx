<%@ Page Title="" Language="VB" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" MasterPageFile="~/ContentMaster.master" CodeFile="ShopStockManager.aspx.vb" Inherits="ShopStockManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
<h2>매장 재고 관리 페이지</h2>
<p>매장 재고를 조회하고 수정합니다.</p>
<p><asp:Label ID="UserName" runat="server"/>님의 매장 매출 정보 입니다. &nbsp;&nbsp;편집을 원하시면 "선택"을 클릭하세요.</p>
<p>
    <!--UpdatePanel 안에 ListView가 들어감. AJAX ScriptManager -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" 
                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                CellSpacing="2" DataKeyNames="ShopStockID" DataSourceID="LinqDataSource1">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="ShopID" HeaderText="ShopID" 
                        SortExpression="ShopID" />
                    <asp:BoundField DataField="MenuName" HeaderText="MenuName" 
                        SortExpression="MenuName" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                    <asp:BoundField DataField="StockDate" HeaderText="StockDate" 
                        SortExpression="StockDate" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
                ContextTypeName="ShopStockDataContext" EnableInsert="True" EnableUpdate="True" 
                EntityTypeName="" TableName="ShopStock" Where="ShopID == @ShopID">
                <WhereParameters>
                    <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" 
                        Type="String" />
                </WhereParameters>
            </asp:LinqDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    </p>
    </asp:Content>

