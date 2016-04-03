<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> 
    <!-- 회원 등록 폼 시작 -->
    <asp:ValidationSummary
         Id="MyValidationSummary"
         HeaderText="다음과 같은 에러가 발견되었습니다."
         DisplayMode="bulletlist"
         ShowMessageBox="true"
         ShowSummary="false"
         runat="server" />
    <table width="490px" cellspacing="0" cellpadding="0" border="0">
       <tr>
           <td style="width: 5px; color: red">*</td>
           <td style="width: 140px" >성명(실명)</td>
           <td style="width: 340px" >
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
           <td  style="width: 140px">주민등록번호</td>
           <td style="width: 340px">
              <asp:TextBox id="SSN" width="140px" maxlength="14" runat="server" />
              <asp:RequiredFieldValidator 
                   Id="ValidateSSN"
	          ControlToValidate="SSN"
		 Text="*"
		 ErrorMessage="주민등록번호를 입력하십시오."
                   runat="server" />
              <asp:RegularExpressionValidator
                   Id="ValidSSN"
                   ControlToValidate="SSN"
                   ValidationExpression="^([0-9]{6}-[0-9]{7}$)"
                   Text="*"
                   ErrorMessage="주민등록번호 형식이 틀립니다."
                   runat="server" />예: 123456-1234567
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
              <asp:RegularExpressionValidator
                   Id="ValidPhone"
                   ControlToValidate="Phone"
                   ValidationExpression="^([0-9]{2,3}-[0-9]{3,4}-[0-9]{4}$)" 
                   Text="*"
                   ErrorMessage="전화번호 형식이 틀립니다."
                   runat="server" />예: 02-123-1234
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
           <td style="width: 5px"></td>
           <td  style="width: 140px">업종형태</td>
           <td style="width: 340px">
               <asp:DropDownList id="Job" runat="server">
                    <asp:ListItem Value="" Text="선택하여 주십시오" />
                    <asp:ListItem Value="치킨" Text="회사원" />
                    <asp:ListItem Value="치킨&피자" Text="학생" />
                    <asp:ListItem Value="피자" Text="주부" />
                    <asp:ListItem Value="분식류" Text="자영업" />
                    <asp:ListItem Value="기타" Text="공무원" />
               </asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td style="width: 5px"></td>
           <td style="width: 140px">매장소개</td>
           <td style="width: 340px">
               <asp:TextBox textmode="multiline" id="Intro" width="250px" Height="50px" 
	                Text="간단한 매장 소개를 해 주세요." runat="server"></asp:TextBox>
           </td>
        </tr>
    </table>
    <!-- 회원 등록 폼 끝 -->
    </div>
    </form>
</body>
</html>
