<%@ Page Title="" Language="VB" MasterPageFile="~/SiaPOSMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="TimesSales.aspx.vb" Inherits="Member_TimesSales" %>

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
                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                GridLines="None" Height="252px" Width="587px" AllowPaging="True">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Sales Date" 
                        SortExpression="Date" />
                    <asp:BoundField DataField="Total" HeaderText="Amount of Sales" ReadOnly="True" 
                        SortExpression="Total" DataFormatString="{0:N0}" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
    </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2" 
                Height="323px" Palette="SemiTransparent" Width="830px">
                <Series>
                    <asp:Series ChartType="Line" Color="255, 128, 128" 
                        LabelBackColor="255, 255, 192" Legend="Legend1" 
                        MarkerBorderColor="255, 128, 128" MarkerBorderWidth="2" Name="TimeLine" 
                        XValueMember="Date" XValueType="DateTime" YValueMembers="Total">
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" SelectCommand="SELECT Date, SUM(MenuAccount * Profit) AS Total
FROM Shop.ShopAccount 
WHERE (ShopID = @ShopID) AND (Date BETWEEN @startdate AND @enddate) 
GROUP BY Date">
                <SelectParameters>
                    <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" />
                    <asp:ControlParameter ControlID="StartDate" Name="startdate" 
                        PropertyName="Text" />
                    <asp:ControlParameter ControlID="EndDate" Name="enddate" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" SelectCommand="SELECT Date, SUM(MenuAccount * Profit) AS Total
FROM Shop.ShopAccount 
WHERE (ShopID = @ShopID) AND (Date BETWEEN @StartDate AND @EndDate) 
GROUP BY Date">
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

