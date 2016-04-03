<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="UpdateMyInfo.aspx.vb" Inherits="UpdateMyInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
    <h2>회원 정보 수정 페이지</h2>
<p>회원 정보를 수정하시려면 아래 폼에서 데이터를 수정하신 뒤 수정 버튼을 클릭하세요.</p>
<p>&nbsp;</p>
        <asp:Label ID="Message" style="color: Green" runat="server" />
         <asp:ValidationSummary
         Id="MyValidationSummary"
         HeaderText="다음과 같은 에러가 발견되었습니다."
         DisplayMode="bulletlist"
         ShowMessageBox="true"
         ShowSummary="false"
         runat="server" />
    <table cellspacing="0" cellpadding="0" border="0" width="460px" style="text-align: left; background-color: #F7F7DE; border-color: #CCCC99;">
       <tr style="background-color:#6B696B; color:#FFFFFF; font-weight:bold; height:25px">
           <td style="width:5px; height:20px"></td>
           <td style="width:140px; height:20px">사용자 이름</td>
           <td style="width:340px; height:20px">
               <asp:Label ID="lblUserName" runat="server" Font-Bold="true" />
           </td>
           </tr>
           <tr style="height:25px;">
           <td style="width: 5px;"></td>
           <td style="width: 140px">회원 번호</td>
           <td style="width: 340px">
           <asp:Label ID="lblMemberId" Width="140" maxlength="8" runat="server" />
           </td>
           </tr>
           <tr>
           <td style="color: red" class="style1">*</td>
           <td class="style2" >성명(실명)</td>
           <td class="style3" >
              <asp:TextBox id="RealName" width="140" maxlength="8" runat="server" 
                   style="margin-left: 0px" />
              <asp:RequiredFieldValidator 
                   Id="RequiredName"
                   ControlToValidate="RealName"
                   Text="*"
                   ErrorMessage="이름을 입력하십시오."
                   runat="server" />&nbsp;&nbsp;한글명
           </td>
       </tr>
       <tr>
           <td style="width: 5px; color: red">*</td>
           <td  style="width: 140px" >성별</td>
           <td style="width: 340px" >
              <asp:RadioButton Text="남자" GroupName="Gender" ID="man" checked="true" runat="server" />
              <asp:RadioButton Text="여자" GroupName="Gender" ID="woman" runat="server" />
           </td>
       </tr>
       <tr>
           <td style="width: 5px; color: red">*</td>
           <td  style="width: 140px">전화번호</td>
           <td style="width: 340px">
              <asp:TextBox id="Phone" width="140px" maxlength="15" runat="server" />
              <asp:RequiredFieldValidator
                   Id="RequiredPhone"
                   ControlToValidate="Phone"
                   Text="*"
                   ErrorMessage="전화번호를 입력하십시오."
                   runat="server" />
               예: 02-123-1234
           </td>
       </tr>
       <tr>
           <td style="width: 5px; color: red">*</td>
           <td  style="width: 140px">지역</td>
           <td style="width: 340px">
               <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                   DataSourceID="SqlDataSource1" DataTextField="Region" DataValueField="Region">
               </asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
                   SelectCommand="SELECT Region FROM Person.RegionCode"></asp:SqlDataSource>
               <asp:RequiredFieldValidator
                    Id="RequiredFieldValidator1"
                    ControlToValidate="Address"
                    Text="*"
                    ErrorMessage="주소를 입력하십시오."
                    runat="server" />
           </td>
       </tr>
       <tr>
           <td style="width: 5px; color: red">*</td>
           <td  style="width: 140px">주소</td>
           <td style="width: 340px">
               <asp:TextBox id="Address" width="250px" maxlength="300" runat="server" />
               <asp:RequiredFieldValidator
                    Id="RequiredAddress"
                    ControlToValidate="Address"
                    Text="*"
                    ErrorMessage="주소를 입력하십시오."
                    runat="server" />
           </td>
       </tr>
       <tr>
           <td style="width:5px; color:Red;">*</td>
           <td style="width: 100px;">Email 주소</td>
           <td width="350">
               <asp:TextBox ID="Email" Width="200" MaxLength="40" runat="server" />
               <asp:RequiredFieldValidator ID="RequiredEmail" ControlToValidate="Email" Text="*"
                    ErrorMessage="이메일 주소를 입력하세요." runat="server" />
           </td>
       </tr>
       <tr>
           <td style="width: 5px"></td>
           <td  style="width: 140px">업종형태</td>
           <td style="width: 340px">
               <asp:DropDownList id="Job" runat="server">
                    <asp:ListItem Value="" Text="선택하여 주십시오" />
                    <asp:ListItem Value="치킨" Text="치킨" />
                    <asp:ListItem Value="치킨&피자" Text="치킨&피자" />
                    <asp:ListItem Value="피자" Text="피자" />
                    <asp:ListItem Value="분식류" Text="분식류" />
                    <asp:ListItem Value="기타" Text="기타" />
               </asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td style="width: 5px"></td>
           <td style="width: 140px">매장소개</td>
           <td style="width: 340px">
               <asp:TextBox textmode="multiline" id="Intro" width="250px" Height="66px" 
	                Text="간단한 매장 소개를 해 주세요." runat="server"></asp:TextBox>
           </td>
        </tr>
    <tr>
    <td colspan="3" align="center"><br />
       <asp:Button ID="UpdateBtn" Text="수정하기" runat="server" BackColor="#FFFBFF" ForeColor="#284775" BorderColor="#CCCCCC" />
    </td>
    </tr>
    </table>
           

</asp:Content>

