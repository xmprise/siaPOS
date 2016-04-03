<%@ Page Title="" Language="VB" StylesheetTheme="SiaPOSTheme" MasterPageFile="~/ContentMaster.master" AutoEventWireup="false" CodeFile="UpdateCommand.aspx.vb" Inherits="UpdateCommand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
    <h2>지시사항 수정 페이지</h2>
<p>지시사항을 수정하시려면 아래 정보를 수정한 후에 수정 버튼을 클릭하세요.</p>
<p>&nbsp;</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<asp:Label id="Message" runat="server">&nbsp;</asp:Label>            
     <asp:ValidationSummary
          Id = "ValidatorSummary"
          HeaderText = "입력과정에서 다음과 같은 오류가 발생했습니다."
          DisplayMode="BulletList"
          ShowMessageBox="true"
          ShowSummary = "false"
          runat="server" />
                     
<table>
    <tr valign="middle">
       <td height="25" bgcolor="#dddddd" 
           style="border-bottom: dashed 1px solid; padding-left: 10px; width: 100px; ">
            서비스 요청인</td>
       <td width="10px">&nbsp;&nbsp;</td>
       <td width="160px" style="border: 1px dashed;">
           <font color="5d7b9d">
              &nbsp;
              <asp:Label ID="lblUserName" runat="server" 
                         Font-Bold="True" Height="20px" Width="150px" />
           </font></td>
        <td>
        </td>
       <td rowspan="5" width="200px" align="center" valign="middle">
           <asp:Calendar id="MyCalendar" 
                OnSelectionChanged="MyCalendar_SelectionChanged"
                ForeColor="#000000"
                BorderColor="#999999"
                BackColor="#dddddd"
                Font-Size="12px" width="180px" 
                OtherMonthDayStyle-ForeColor="#666666"
                TodayDayStyle-ForeColor="green"
                DayHeaderStyle-ForeColor="maroon"
                DayHeaderStyle-BackColor="#aaaaaa"
                TitleStyle-ForeColor="white"
                TitleStyle-BackColor="#666666"
                SelectionMode="Day"
                runat="server" Height="121px" >
               <TodayDayStyle ForeColor="Green" />
               <OtherMonthDayStyle ForeColor="#666666" />
               <DayHeaderStyle BackColor="#AAAAAA" ForeColor="Maroon" />
               <TitleStyle BackColor="#666666" ForeColor="White" />
           </asp:Calendar>
       </td>                      
   </tr>
   
   <tr>
       <td height="20px" bgcolor="#dddddd" 
           style="border: dashed 1px solid; padding-left: 10px; width: 100px; ">
           서비스 날짜</td>
       <td width="10px">
           <asp:RequiredFieldValidator
                Id = "RequiredServiceDate"
                ControlToValidate = "ServiceDate"
                Text = "*"
                ErrorMessage = "서비스가 필요한 날짜를 기입해 주세요."
                runat = "server" />                     
           <asp:RegularExpressionValidator
                id="ValidDate"
         	    ControlToValidate = "ServiceDate" 
                ValidationExpression = "\d{2,4}\-\d{1,2}\-\d{1,2}"
                Text = "*"
                ErrorMessage = "날짜를 정확히 기입해 주세요."
                runat = "server" /></td>  
       <td width="160px" 
           style="border: dashed 1px; padding-left: 10px" height="20px">  
           <asp:TextBox id="ServiceDate" width="155px" runat="server" 
                        maxlength="100" Text="달력에서 선택하세요" />
   </td>
   </tr>
   <tr>
       <td bgcolor="#dddddd" 
           
           style="border-style: dashed; border-color: inherit; border-width: 1px; padding-left: 10px; " 
           class="style3">
           서비스 타입</td>
       <td width="10px" class="style4">                                                     
           <asp:CustomValidator
        	    id="ValidServiceType"
                Text = "*"
                ErrorMessage = "서비스 타입을 선택해 주세요."
                runat = "server" /></td>
       <td width="160px" style="border: dashed 1px; padding-left: 10px" class="style4">
           <asp:DropDownList 
	            id="ServiceTypeDDL" 
	            Width="160px"
	            DataTextField="MessageType" 
	            DataValueField="MessageType" 
	            runat="server"/>
    </td>
    </tr>
     <tr>
         <td height="25px" bgcolor="#dddddd" 
             style="border: dashed 1px ; padding-left: 10px; width: 100px; ">
             서비스 내용</td>
         <td width="10px">&nbsp;</td>
         <td colspan="2" width="350px" style="border: 1px dashed; padding-left: 10px">
             <asp:TextBox textmode="multiline" id="ServiceDescription" 
                          width="340px" Height="80px" runat="server" >요구하신 서비스에 대해 자세히 설명해 주세요.
             </asp:TextBox></td>
     </tr>
     <tr>
         <td colspan="4" align="center">
             <asp:Button id="AddServiceBtn" Text="수정" runat="server" />                 
         </td>                                
     </tr>
 </table>   
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

