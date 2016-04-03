<%@ Page Title="" Language="VB" MasterPageFile="~/SiaPOSMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="ShopAnalysis.aspx.vb" Inherits="Member_ShopAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
    <h2>매장 매출 분석</h2>
    <p>등록된 매장의 매출을 분석 합니다.&nbsp;&nbsp;</p>
    <p><asp:Label ID="UserName" runat="server" />님의 매장 정보 입니다. &nbsp;&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
        <div id="master-detail">
            <div id="master">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" 
                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CellSpacing="2">
                <Columns>
                    <asp:BoundField DataField="MenuName" HeaderText="메뉴" ReadOnly="True" 
                        SortExpression="MenuName" />
                    <asp:BoundField DataField="Date" HeaderText="판매 날짜" ReadOnly="True" 
                        SortExpression="Date" />
                    <asp:BoundField DataField="TableNumber" HeaderText="판매 테이블" 
                        ReadOnly="True" SortExpression="TableNumber" />
                    <asp:BoundField DataField="MenuAccount" HeaderText="판매 수량" 
                        ReadOnly="True" SortExpression="MenuAccount" />
                    <asp:BoundField DataField="Profit" HeaderText="판매액" ReadOnly="True" 
                        SortExpression="Profit" />
                    <asp:BoundField DataField="OrderState" HeaderText="판매 상태" ReadOnly="True" 
                        SortExpression="OrderState" />
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
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>일자별 메뉴 판매량</p>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1">
                <Series>
                    <asp:Series Name="Series1" XValueMember="MenuName" YValueMembers="Account">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <p>&nbsp;</p>
            <p>기준 시간별 매출 추이</p>
            <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3">
                <Series>
                    <asp:Series Name="Series1" ChartType="Line" XValueMember="Date" 
                        YValueMembers="Total">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>   
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString1 %>" 
                    
                    SelectCommand="SELECT MenuName, COUNT(OrderState) AS OrderState FROM Shop.ShopAccount WHERE (ShopID = @shopid) AND (Date BETWEEN @startdate AND @enddate) GROUP BY MenuName">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="UserName" Name="shopid" PropertyName="Text" />
                        <asp:ControlParameter ControlID="StartDate" DefaultValue="2011-08-22" 
                            Name="startdate" PropertyName="Text" />
                        <asp:ControlParameter ControlID="EndDate" DefaultValue="2011-08-23" 
                            Name="enddate" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
                ContextTypeName="SiaPOSDataContext" EntityTypeName="" 
                Select="new (MenuName, Date, TableNumber, MenuAccount, Profit, OrderState)" 
                TableName="ShopAccount" Where="ShopID == @ShopID">
                <WhereParameters>
                    <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" 
                        Type="String" />
                </WhereParameters>
            </asp:LinqDataSource>
        </div>
        <div id="detail">
                <p>기준 날짜를 지정 합니다. </p>
                <asp:Panel ID="Panel1" runat="server">
                시작일: 
                <asp:RadioButton ID="RadioStart" runat="server" GroupName="1" />
                <asp:TextBox ID="StartDate" runat="server" AutoPostBack="true">2011-08-22</asp:TextBox>
                <br />
                마지막일: 
                <asp:RadioButton ID="RadioEnd" runat="server" GroupName="1" />
                <asp:TextBox ID="EndDate" runat="server">2011-08-23</asp:TextBox>
                    <br />
                </asp:Panel>
            <asp:Calendar ID="Calendar1" runat="server" Width="220px" BackColor="White" 
                BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="#003399" Height="200px">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                    Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />       

            </asp:Calendar>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>테이블별 판매 수량</p>
            <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2">
                <Series>
                    <asp:Series Name="Series1" XValueMember="TableNumber" YValueMembers="Expr1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
             <p>기준 시간별 불용수량</p>
                <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource4">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Bar" XValueMember="MenuName" 
                            YValueMembers="OrderState">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString1 %>" 
                    SelectCommand="SELECT SUM(MenuAccount * Profit) AS Total, Date FROM Shop.ShopAccount WHERE (ShopID = @shopid) AND (Date BETWEEN @startdate AND @enddate) GROUP BY Date">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="UserName" Name="shopid" PropertyName="Text" />
                        <asp:ControlParameter ControlID="StartDate" DefaultValue="2011-08-22" 
                            Name="startdate" PropertyName="Text" />
                        <asp:ControlParameter ControlID="EndDate" DefaultValue="2011-08-23" 
                            Name="enddate" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString1 %>" 
                    SelectCommand="SELECT TableNumber, SUM(MenuAccount * Profit) AS Expr1 FROM Shop.ShopAccount WHERE (ShopID = @ShopID) AND (Date BETWEEN @startdate AND @enddate) GROUP BY TableNumber">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="UserName" DefaultValue="y4321" Name="ShopID" 
                            PropertyName="Text" />
                        <asp:ControlParameter ControlID="StartDate" DefaultValue="2011-08-22" 
                            Name="startdate" PropertyName="Text" />
                        <asp:ControlParameter ControlID="EndDate" DefaultValue="2011-08-24" 
                            Name="enddate" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString1 %>" 
                
                    
                    SelectCommand="SELECT MenuName, COUNT(MenuAccount) AS Account FROM Shop.ShopAccount WHERE (ShopID = @ShopID) AND (Date BETWEEN @startdate AND @enddate) GROUP BY MenuName">
                <SelectParameters>
                    <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" 
                        DefaultValue="y4321" />
                    <asp:ControlParameter ControlID="StartDate" Name="startdate" 
                        PropertyName="Text" DefaultValue="2011-08-23" />
                    <asp:ControlParameter ControlID="EndDate" Name="enddate" PropertyName="Text" 
                        DefaultValue="2011-08-24" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    

</asp:Content>

