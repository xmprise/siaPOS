<%@ Page Title="" Language="VB" MasterPageFile="~/SiaPOSMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="SalesTable.aspx.vb" Inherits="Member_SalesTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
<h2>Amount of sales by Table</h2>
    <p><asp:Label ID="UserName" runat="server" />&#39;s Shop Information.</p>
    <p>&nbsp;&nbsp;&nbsp;</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="Panel1" runat="server" Direction="LeftToRight" Wrap="False">
        <asp:Panel ID="Panel2" runat="server">
        <div id="master-detail">
        <div id="master">
        
            Start Date:
            <asp:Label ID="StartDate" runat="server" BorderStyle="Solid" Text="2011-12-1"></asp:Label>
            <br />
            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
                BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                ShowGridLines="True" Width="353px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                    ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>          
            <br />
        
        </div>
        <div id="detail">
        
            End Date:
            <asp:Label ID="EndDate" runat="server" BorderStyle="Solid" Text="2011-12-30"></asp:Label>
            <br />
            <asp:Calendar ID="Calendar3" runat="server" BackColor="#FFFFCC" 
                BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                ShowGridLines="True" Width="353px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                    ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
        
        </div>
        </div>
        </asp:Panel>
    </asp:Panel>
    <p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" DataSourceID="SqlDataSource1" Height="226px" 
            Width="653px" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="TableNumber" HeaderText="Table" 
                        SortExpression="TableNumber" />
                    <asp:BoundField DataField="MenuCount" HeaderText="Sales Count" ReadOnly="True" 
                        SortExpression="MenuCount" />
                    <asp:BoundField DataField="Expr1" HeaderText="Profit" ReadOnly="True" 
                        SortExpression="Expr1" DataFormatString="{0:N0}" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
    </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Chart ID="Chart1" runat="server" Height="350px" Width="613px" 
                DataSourceID="SqlDataSource2" Palette="Fire">
                <Series>
                    <asp:Series Name="Series1" XValueMember="TableNumber" YValueMembers="MenuCount">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" SelectCommand="SELECT TableNumber,COUNT(MenuName)as MenuCount
FROM Shop.ShopAccount WHERE (ShopID = @ShopID) AND (Date BETWEEN @startdate AND @enddate) 
GROUP BY TableNumber">
                <SelectParameters>
                    <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
                    <asp:ControlParameter ControlID="StartDate" Name="startdate" 
                        PropertyName="Text" />
                    <asp:ControlParameter ControlID="EndDate" Name="enddate" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" SelectCommand="SELECT TableNumber,COUNT(MenuName)as MenuCount ,SUM(MenuAccount * Profit) AS Expr1 
FROM Shop.ShopAccount WHERE (ShopID = @ShopID) AND (Date BETWEEN @startdate AND @enddate) 
GROUP BY TableNumber">
                <SelectParameters>
                    <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
                    <asp:ControlParameter ControlID="StartDate" Name="startdate" 
                        PropertyName="Text" />
                    <asp:ControlParameter ControlID="EndDate" Name="enddate" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

