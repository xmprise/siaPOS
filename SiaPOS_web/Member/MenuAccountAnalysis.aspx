<%@ Page Title="" Language="VB" MasterPageFile="~/SiaPOSMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="MenuAccountAnalysis.aspx.vb" Inherits="Member_MenuAccountAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">

    <h2>Shop Sales Analysis</h2>
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
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="226px" 
            Width="653px" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="MenuName" HeaderText="MenuName" 
                    SortExpression="MenuName" />
                <asp:BoundField DataField="Date" HeaderText="Date" 
                    SortExpression="Date" />
                <asp:BoundField DataField="TableNumber" HeaderText="TableNumber" 
                    SortExpression="TableNumber" />
                <asp:BoundField DataField="MenuAccount" HeaderText="MenuAccount" 
                    SortExpression="MenuAccount" />
                <asp:BoundField DataField="Profit" HeaderText="Profit" ReadOnly="True" 
                    SortExpression="Profit" DataFormatString="{0:N0}" />
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
            SelectCommand="SELECT MenuName, Date, TableNumber, MenuAccount, MenuAccount * Profit AS Profit FROM Shop.ShopAccount WHERE (ShopID = @ShopID) AND (Date BETWEEN @StartDate AND @EndDate) AND (OrderState = 1)">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
                <asp:ControlParameter ControlID="StartDate" Name="StartDate" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="EndDate" Name="EndDate" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
            Height="350px" Width="613px">
            <Series>
                <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Min" 
                    XValueMember="ShopID" YValueMembers="MinValue">
                </asp:Series>
                <asp:Series Name="Average" XValueMember="ShopID" YValueMembers="Average" 
                    Legend="Legend1">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" Name="Max" XValueMember="ShopID" 
                    YValueMembers="MaxValue" Legend="Legend1">
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
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
            
            SelectCommand="SELECT ShopID, AVG(MenuAccount * Profit) AS Average, MAX(MenuAccount * Profit) AS MaxValue, MIN(MenuAccount * Profit) AS MinValue FROM Shop.ShopAccount WHERE (ShopID = @ShopID) AND (Date BETWEEN @StartDate AND @EndDate) AND (OrderState = 1) GROUP BY ShopID">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
                <asp:ControlParameter ControlID="StartDate" Name="StartDate" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="EndDate" Name="EndDate" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" 
            DataSourceID="SqlDataSource3" ForeColor="#333333">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#E3EAEB" />
            <ItemTemplate>
                ShopID:
                <asp:Label ID="ShopIDLabel" runat="server" Text='<%# Eval("ShopID") %>' />
                <br />
                Average:
                <asp:Label ID="AverageLabel" runat="server" Text='<%# Eval("Average") %>' />
                <br />
                MaxValue:
                <asp:Label ID="MaxValueLabel" runat="server" Text='<%# Eval("MaxValue") %>' />
                <br />
                MinValue:
                <asp:Label ID="MinValueLabel" runat="server" Text='<%# Eval("MinValue") %>' />
                <br />
                StandardDeviation:
                <asp:Label ID="StandardDeviationLabel" runat="server" 
                    Text='<%# Eval("StandardDeviation") %>' />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" SelectCommand="SELECT ShopID, AVG(MenuAccount * Profit)as Average, MAX(MenuAccount * Profit) as MaxValue, MIN(MenuAccount * Profit) as MinValue, STDEV(MenuAccount * Profit)as StandardDeviation
FROM Shop.ShopAccount
WHERE (ShopID=@ShopID) and (DATE BETWEEN @StartDate and @EndDate) and OrderState = 1
GROUP BY ShopID">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
                <asp:ControlParameter ControlID="StartDate" Name="StartDate" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="EndDate" Name="EndDate" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

