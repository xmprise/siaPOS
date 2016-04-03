<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="false" CodeFile="PasswordRecovery.aspx.vb" Inherits="PasswordRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
    <h2>암호 복구 페이지</h2>
<p>암호 질문에 답을 하시면 임시 암호가 이메일로 전송 됩니다. 임시 암호로 로그인하신 후에 다시 설정 하십시오.</p>
<p>&nbsp;</p><p>&nbsp;</p>
<div id="PasswordRecovery" style="text-align: center;">
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" 
         MailDefinition-Subject="암호 복구 안내문" 
         MailDefinition-From="xmprise@pknu.ac.kr" BackColor="#F7F7DE"
         BorderColor="#CCCCC99" BorderStyle="Solid" BorderWidth="1px"
         Font-Names="Verdana" Font-Size="10pt" Height="150px" Width="350px"
         UserNameLabelText="사용자 ID: "
         UserNameInstructionText="암호를 찾으려면 사용자 ID를 입력 하십시오."
         UserNameRequiredErrorMessage="사용자 ID가 필요합니다.">
         <MailDefinition From="xmprise@pknu.ac.kr" Subject="암호 복구 안내문"></MailDefinition>
         <TitleTextStyle BackColor="#6B696B" Font-Bold="true" ForeColor="#FFFFFF" />
         </asp:PasswordRecovery>
</div> 
</asp:Content>

