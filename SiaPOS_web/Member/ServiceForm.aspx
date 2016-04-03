<%@ Page Language="VB" MasterPageFile="~/ContentMaster.master" 
         styleSheetTheme="SiaPOSTheme"
         AutoEventWireup="false" 
         title="매장 지시 사항 전달" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftcolumnContent" Runat="Server">

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
           style="border: dashed 1px; padding-left: 10px; width: 100px; ">
            서비스 요청인</td>
       <td width="10px">&nbsp;&nbsp;</td>
       <td width="160px" style="border: 1px dashed;">
           <font color="5d7b9d">
              &nbsp;
              <asp:Label ID="lblUserName" runat="server" 
                         Font-Bold="True" Height="20px" Width="150px" />
           </font></td>
       <td rowspan="5" width="200px" align="center" valign="middle">
           <asp:Calendar id="MyCalendar" 
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
           style="border: dashed 1px ; padding-left: 10px; width: 100px; ">
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
       <td height="20px" bgcolor="#dddddd" 
           style="border: dashed 1px ; padding-left: 10px; width: 100px; ">
           서비스 타입</td>
       <td width="10px">                                                     
           <asp:CustomValidator
        	    id="ValidServiceType"
                Text = "*"
                ErrorMessage = "서비스 타입을 선택해 주세요."
                runat = "server" /></td>
       <td width="160px" style="border: dashed 1px; padding-left: 10px">
           <asp:DropDownList 
	            id="ServiceTypeDDL" 
	            Width="160px"
	            DataTextField="ServiceTypeName" 
	            DataValueField="ServiceTypeName" 
	            runat="server"/>
    </td>
    </tr>
    <tr>
         <td height="20px" bgcolor="#dddddd" 
             style="border: dashed 1px ; padding-left: 10px; width: 100px; ">
            서비스 시간</td>
        <td width="10px">
            <asp:RangeValidator
                 Id = "HoursRange"
                 ControlToValidate = "ServiceHours"
                 Type = "Integer"
                 MinimumValue = "1"
                 MaximumValue = "10"
                 Text = "*"
                 ErrorMessage = "소요시간을 선택해 주세요."
                 runat = "server" /></td>                                   
        <td width="160px" style="border: 1px dashed; padding-left: 10px">
            <asp:DropDownList id="ServiceHours" width="160px" runat="server">
                 <asp:ListItem Value="0" Text="선택하세요" />
                 <asp:ListItem Value="1" Text="1 시간" />
                 <asp:ListItem Value="2" Text="2 시간" />
                 <asp:ListItem Value="3" Text="3 시간" />
                 <asp:ListItem Value="4" Text="4 시간" />
                 <asp:ListItem Value="5" Text="5 시간" />
                 <asp:ListItem Value="6" Text="6 시간" />
                 <asp:ListItem Value="7" Text="7 시간" />
                 <asp:ListItem Value="8" Text="8 시간" />
                 <asp:ListItem Value="9" Text="9 시간" />
                 <asp:ListItem Value="10" Text="10 시간" />
           </asp:DropDownList> 
       </td>
   </tr>
   <tr>
       <td height="20px" bgcolor="#dddddd" 
           style="border: dashed 1px ; padding-left: 10px; width: 100px; ">
           서비스 인원</td>
       <td width="10px">
           <asp:RangeValidator
                Id = "NumberOfDoumiRange"
                ControlToValidate = "NumberOfDoumi"
                Type = "Integer"
                MinimumValue = "1"
                MaximumValue = "10"
                Text = "*"
                ErrorMessage = "소요인원을 선택해 주세요."
                runat="server" /></td>
       <td width="160px" style="border: 1px dashed; padding-left: 10px">
           <asp:DropDownList id="NumberOfDoumi" width="160px" runat="server">
                <asp:ListItem Value="0" Text="선택하세요" />
                <asp:ListItem Value="1" Text="1 사람" />
                <asp:ListItem Value="2" Text="2 사람" />
                <asp:ListItem Value="3" Text="3 사람" />
                <asp:ListItem Value="4" Text="4 사람" />
                <asp:ListItem Value="5" Text="5 사람" />
                <asp:ListItem Value="6" Text="6 사람" />
                <asp:ListItem Value="7" Text="7 사람" />
                <asp:ListItem Value="8" Text="8 사람" />
                <asp:ListItem Value="9" Text="9 사람" />
                <asp:ListItem Value="10" Text="10 사람" />
          </asp:DropDownList> 
        </td>
    </tr>
    <tr>
         <td height="20px" bgcolor="#dddddd" 
             style="border: dashed 1px ; padding-left: 10px; width: 100px; ">
            도우미 성별</td>
        <td width="10px">&nbsp;</td>
        <td colspan="2" style="border: 1px dashed; padding-left: 10px;">
            <asp:RadioButtonList ID="DoumiGender" runat="server" 
                                 RepeatDirection="Horizontal">
                 <asp:ListItem>남자</asp:ListItem>
                 <asp:ListItem>여자</asp:ListItem>
                 <asp:ListItem Selected="True">남녀불문</asp:ListItem>                                
            </asp:RadioButtonList>
         </td>
     </tr>
     <tr>
         <td height="20px" bgcolor="#dddddd" 
             style="border: dashed 1px ; padding-left: 10px; width: 100px; ">
             연락 전화번호</td>
         <td width="10px">
             <asp:RequiredFieldValidator
                  Id = "RequiredPhoneNum"
                  ControlToValidate = "ServicePhone"
                  Text = "*"
                  ErrorMessage = "연락 전화번호를 기입해 주세요."
                  runat = "server" />
             <asp:RegularExpressionValidator
                  Id = "ValidPhoneNum"
                  ControlToValidate = "ServicePhone"
                  ValidationExpression = "^\d{2,3}-\d{3,4}-\d{4}$"
                  Text = "*"
                  ErrorMessage = "전화번호 형식이 틀렸습니다."
                  runat = "server" />
         </td>                                
         <td colspan="2" width="350px" style="border: 1px dashed; padding-left: 10px">
             <asp:TextBox id="ServicePhone" width="230px" 
                          maxlength="100" runat="server" />
                  예: 02-123-1234
         </td>
     </tr>  
   	 <tr>
         <td height="20px" bgcolor="#dddddd" 
             style="border: dashed 1px ; padding-left: 10px; width: 100px; ">
             서비스 주소
         </td>
         <td width="10px">
             <asp:RequiredFieldValidator
                  Id = "RequiredLocation"
                  ControlToValidate = "ServiceLocation"
                  Text = "*"
                  ErrorMessage = "<font size=2>서비스가 요구되는 장소를 기입해 주세요."
                  runat = "server" /></td>                      
         <td colspan="2" width="350px" 
             style="border: 1px dashed; padding-left: 10px">
             <asp:TextBox id="ServiceLocation" width="340px" 
                          maxlength="500" runat="server" />
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
             <asp:Button id="AddServiceBtn" Text="서비스 등록" runat="server" />                 
         </td>                                
     </tr>
 </table>   
		
</asp:Content>

