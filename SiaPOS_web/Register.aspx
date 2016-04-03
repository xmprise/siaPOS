<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
    <h2>회원 등록 페이지</h2>
<p>회원 등록을 위해 아래 정보를 입력 하시고 관리자의 승인을 기다려 주십시오.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>    
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" Width="490px"  
         ContinueDestinationPageUrl="~/Default.aspx" ContinueButtonText="회원 정보 저장"
         ContinueButtonStyle-ForeColor="#CC3300"
         BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px"
         Font-Names="Verdana" Font-Size="10pt">
         <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
         <ContinueButtonStyle ForeColor="#CC0000" BackColor="#FFFBFF" BorderColor="#CCCCCC"
          BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"></ContinueButtonStyle>
         <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC"
          ForeColor="#284775" />
         <HeaderStyle BackColor="#6B696B" Font-Bold="true" ForeColor="#FFFFFF" 
          HorizontalAlign="Center" />
         <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#284775" />
        <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
        <StepStyle BorderWidth="0px" />
        <WizardSteps>
            <asp:WizardStep runat="server" Title="회원 정보 수집" ID="UserInfo">
            
            <!--회원 등록 폼 시작-->
   <asp:ValidationSummary
         Id="MyValidationSummary"
         HeaderText="다음과 같은 에러가 발견되었습니다."
         DisplayMode="bulletlist"
         ShowMessageBox="true"
         ShowSummary="false"
         runat="server" />
    <table width="490px" cellspacing="0" cellpadding="0" border="0">
       <tr style="height:25px; text-align:center; width:100%;
               background-color:#6B696B">
           <td colspan="3" style="text-align:center;  width:100%;
               background-color:#6B696B">
               <font color="white"><b>회원 정보 수집</b></font>
           </td>
       </tr>  
       <tr style="padding-top:10px; height:30px">
           <td style="width: 5px;">*</td>
           <td  style="width: 140px" >성명(실명)</td>
           <td style="width: 340px" >
               <asp:TextBox ID="RealName" runat="server" MaxLength="8" 
                   style="margin-left: 0px" Width="140px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredName" runat="server" 
                   ControlToValidate="RealName" ErrorMessage="이름을 입력하십시오." Text="*"></asp:RequiredFieldValidator>
               &nbsp;&nbsp;한글명
           </td>
       </tr>
       <tr style="padding-top:10px; height:25px">
           <td style="width: 5px">*</td>
           <td style="width: 140px" >성별</td>
           <td style="width: 340px" >
               <asp:RadioButton ID="man" runat="server" Checked="True" GroupName="Gender" 
                   Text="남자" />
               <asp:RadioButton ID="woman" runat="server" GroupName="Gender" Text="여자" />
           </td>
       </tr>
       <tr style="padding-top:10px; height:25px">
           <td style="width: 5px">*</td>
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
       <tr style="padding-top:10px; height:25px">
           <td style="width: 5px">*</td>
           <td  style="width: 140px">지역</td>
           <td style="width: 340px">
               <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                   DataSourceID="SqlDataSource" DataTextField="Region" DataValueField="Region">
               </asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
                   SelectCommand="SELECT Region FROM Person.RegionCode"></asp:SqlDataSource>
               <asp:RequiredFieldValidator
                    Id="RequiredFieldValidator2"
                    ControlToValidate="Address"
                    Text="*"
                    ErrorMessage="지역을 입력하십시오."
                    runat="server" />
           </td>
       </tr>
       <tr style="padding-top:10px; height:25px">
           <td style="width: 5px">*</td>
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
       <tr style="padding-top:10px; height:25px">
           <td style="width: 5px"></td>
           <td style="width: 140px">자기소개</td>
           <td style="width: 340px">
               <asp:TextBox textmode="multiline" id="Intro" width="250px" 
	           runat="server">간단히 자기 소개를 해 주세요.</asp:TextBox>
           </td>
        </tr>
    </table>
            </asp:WizardStep>
            
            <asp:WizardStep runat="server" Title="업종 형태" ID="UserShopInfo">
               <asp:ValidationSummary
         Id="ValidationSummary1"
         HeaderText="다음과 같은 에러가 발견되었습니다."
         DisplayMode="bulletlist"
         ShowMessageBox="true"
         ShowSummary="false"
         runat="server" />
    <table width="490px" cellspacing="0" cellpadding="0" border="0">
       <tr style="height:25px; text-align:center; width:100%;
               background-color:#6B696B">
           <td colspan="3" style="text-align:center;  width:100%;
               background-color:#6B696B">
               <font color="white"><b>매장 정보 입력</b></font>
           </td>
       </tr>  
       <tr style="padding-top:10px; height:25px">
           <td style="width: 5px">*</td>
           <td  style="width: 140px">매장 이름</td>
           <td style="width: 340px">
               <asp:TextBox id="ShopName1" width="250px" maxlength="300" runat="server" />
               <asp:RequiredFieldValidator
                    Id="RequiredFieldValidator4"
                    ControlToValidate="ShopName1"
                    Text="*"
                    ErrorMessage="매장 이름을 입력해 주세요."
                    runat="server" />
           </td>
       </tr>
       <tr style="padding-top:10px; height:25px">
           <td style="width: 5px"></td>
           <td  style="width: 140px">업종형태</td>
           <td style="width: 340px">
               <asp:DropDownList id="ShopType1" runat="server">
                    <asp:ListItem Value="" Text="선택하여 주십시오" />
                    <asp:ListItem Value="테이크아웃" Text="테이크아웃" />
                    <asp:ListItem Value="레스토랑" Text="레스토랑" />
                    <asp:ListItem Value="펍" Text="펍" />
                    <asp:ListItem Value="슈퍼마켓" Text="슈퍼마켓" />
                    <asp:ListItem Value="기타" Text="기타" />
               </asp:DropDownList>
               <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator5"
                    ControlToValidate="ShopType1"
                    Text="*"
                    ErrorMessage="업종형태를 입력하세요."
                    runat="server" />
           </td>
       </tr>
           <tr style="padding-top:10px; height:25px">
           <td style="width: 5px">*</td>
           <td  style="width: 140px">테이블 수</td>
           <td style="width: 340px">
               <asp:TextBox id="ShopTableAccount" width="250px" maxlength="300" 
                   runat="server" />
               <asp:RequiredFieldValidator
                    Id="RequiredFieldValidator1"
                    ControlToValidate="ShopTableAccount"
                    Text="*"
                    ErrorMessage="매장 이름을 입력해 주세요."
                    runat="server" />
           </td>
       </tr>
    </table>
            </asp:WizardStep>
            
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                <ContentTemplate>
                    <table style="font-family:Verdana;font-size:100%;height:331px;width:490px;">
                        <tr>
                            <td align="center" colspan="2" 
                                style="color:White;background-color:#6B696B;font-weight:bold;">
                                새 계정에 등록</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">사용자 이름:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="사용자 이름이 필요합니다." 
                                    ToolTip="사용자 이름이 필요합니다." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">암호:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="암호가 필요합니다." ToolTip="암호가 필요합니다." 
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmPassword">암호 확인:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" ErrorMessage="암호 확인이 필요합니다." 
                                    ToolTip="암호 확인이 필요합니다." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">전자 메일:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" ErrorMessage="전자 메일이 필요합니다." ToolTip="전자 메일이 필요합니다." 
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">보안 질문:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                    ControlToValidate="Question" ErrorMessage="보안 질문이 필요합니다." 
                                    ToolTip="보안 질문이 필요합니다." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">보안 대답:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                    ControlToValidate="Answer" ErrorMessage="보안 대답이 필요합니다." ToolTip="보안 대답이 필요합니다." 
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" ErrorMessage="[암호]와 [암호 확인]에 입력한 내용은 일치해야 합니다." 
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" 
            HorizontalAlign="Center" />
        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#284775" />
        <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" 
            ForeColor="#FFFFFF" />
        <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" 
            VerticalAlign="Top" />
        <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>
</asp:Content>