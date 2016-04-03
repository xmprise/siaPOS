<%@ Page Title="" Language="C#" MasterPageFile="~/ContentMaster.master" StylesheetTheme="SiaPOSTheme" AutoEventWireup="true" CodeFile="MenuManager.aspx.cs" Inherits="Member_MenuManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 90px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" Runat="Server">
    <h2>매장의 메뉴정보를 관리 합니다. </h2>
<p>매장에 판매될 메뉴를 지정하고 수정 하는 페이지 입니다. </p>
<p><asp:Label ID="UserName" runat="server" />님의 메뉴 정보 입니다. &nbsp;&nbsp;</p>
<p></p>
<table width="520px" cellspacing="0" cellpadding="0" border="0">
<tr style="height:25px; text-align:center; width:100%;
               background-color:#6B696B">
           <td colspan="3" style="text-align:center;  width:100%;
               background-color:#6B696B">
               <font color="white"><b>메뉴 추가 하기</b></font>
           </td>
           </tr>  
           <tr style="padding-top:10px; height:30px">
           <td class="style1" >메뉴명</td>
           <td style="width: 340px" >
               <asp:TextBox ID="MenuName" runat="server" MaxLength="8" 
                   style="margin-left: 0px" Width="200px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredName" runat="server" 
                   ControlToValidate="MenuName" ErrorMessage="메뉴를 입력하십시오." Text="*"></asp:RequiredFieldValidator>
               &nbsp;&nbsp;한글명
           </td>
           </tr>
           <tr style="padding-top:10px; height:30px">
           <td class="style1" >메뉴</td>
           <td style="width: 340px" >
           <asp:FileUpload ID="FileUpload1" runat="server" />    
           <asp:RequiredFieldValidator
                   Id="RequiredFieldValidator2"
                   ControlToValidate="FileUpload1"
                   Text="*"
                   ErrorMessage="파일을 선택 하세요."
                   runat="server" />
           </td>
           </tr>
           <tr style="padding-top:10px; height:25px">
           <td class="style1">메뉴 가격</td>
           <td style="width: 340px">
              <asp:TextBox id="Price" width="200px" maxlength="15" runat="server" />
              <asp:RequiredFieldValidator
                   Id="RequiredPhone"
                   ControlToValidate="Price"
                   Text="*"
                   ErrorMessage="가격을 입력하십시오."
                   runat="server" />
                   <asp:CompareValidator ID="CompareValidator1" ControlToValidate="Price" Text="*"
                        ErrorMessage="숫자만 입력 하십시요." Operator="DataTypeCheck" Type="Integer" runat="server" />
                   
                예: 16000
           </td>
           </tr>
           <tr style="padding-top:10px; height:30px">
           <td class="style1" >메뉴 정보</td>
           <td style="width: 340px" >
               <asp:TextBox ID="MenuInfo" runat="server" MaxLength="100" 
                   style="margin-left: 0px" Width="310px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                   ControlToValidate="MenuInfo" ErrorMessage="메뉴정보를 입력하십시오." Text="*"></asp:RequiredFieldValidator>
               &nbsp;&nbsp;</td>
           </tr>
           <tr style="padding-top:10px; height:30px">
           <td class="style1" ></td>
           <td style="width: 340px" >
               <asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" Text="메뉴 추가" /></td>
           </tr> 
</table>
<p>&nbsp;&nbsp;</p>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlData" AllowPaging="True" 
                      AllowSorting="True" CellPadding="4" ForeColor="#333333" 
        GridLines="None" DataKeyNames="MenuName" Width="630px">
                  
                      <AlternatingRowStyle BackColor="White" />
                  
                      <Columns>
                          <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                          <asp:BoundField DataField="MenuName" HeaderText="MenuName" ReadOnly="True" 
                              SortExpression="MenuName" />
                          <asp:TemplateField HeaderText="Menu">
                          <ItemTemplate>
                           <asp:Image ID="Image1" runat="server" Width="100px" 
                                ImageUrl='<%# "Handler.ashx?MenuName=" + Eval("MenuName") %>' />
                           </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="MenuPrice" HeaderText="MenuPrice" 
                              SortExpression="MenuPrice" />
                          <asp:BoundField DataField="MenuInfomation" HeaderText="MenuInfomation" 
                              SortExpression="MenuInfomation" />
                      </Columns>
                  
                      <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                      <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                      <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                      <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                      <SortedAscendingCellStyle BackColor="#FDF5AC" />
                      <SortedAscendingHeaderStyle BackColor="#4D0000" />
                      <SortedDescendingCellStyle BackColor="#FCF6C0" />
                      <SortedDescendingHeaderStyle BackColor="#820000" />
                  
                  </asp:GridView>
                  <asp:SqlDataSource ID="SqlData" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SibalChk2011ConnectionString %>" 
        
        SelectCommand="SELECT [MenuName], [MenuPrice], [MenuInfomation] FROM Product.MenuInformation WHERE ([ShopID] = @ShopID)" 
        ConflictDetection="CompareAllValues" 
        DeleteCommand="DELETE FROM Product.MenuInformation WHERE [MenuName] = @original_MenuName AND [MenuPrice] = @original_MenuPrice AND (([MenuInfomation] = @original_MenuInfomation) OR ([MenuInfomation] IS NULL AND @original_MenuInfomation IS NULL))" 
        InsertCommand="INSERT INTO Product.MenuInformation ([MenuName], [MenuPrice], [MenuInfomation]) VALUES (@MenuName, @MenuPrice, @MenuInfomation)" 
        OldValuesParameterFormatString="original_{0}" 
        UpdateCommand="UPDATE Product.MenuInformation SET [MenuPrice] = @MenuPrice, [MenuInfomation] = @MenuInfomation WHERE [MenuName] = @original_MenuName AND [MenuPrice] = @original_MenuPrice AND (([MenuInfomation] = @original_MenuInfomation) OR ([MenuInfomation] IS NULL AND @original_MenuInfomation IS NULL))">
                      <DeleteParameters>
                          <asp:Parameter Name="original_MenuName" Type="String" />
                          <asp:Parameter Name="original_MenuPrice" Type="Int32" />
                          <asp:Parameter Name="original_MenuInfomation" Type="String" />
                      </DeleteParameters>
                      <InsertParameters>
                          <asp:Parameter Name="MenuName" Type="String" />
                          <asp:Parameter Name="MenuPrice" Type="Int32" />
                          <asp:Parameter Name="MenuInfomation" Type="String" />
                      </InsertParameters>
                      <SelectParameters>
                          <asp:ControlParameter ControlID="UserName" Name="ShopID" PropertyName="Text" 
                              Type="String" />
                      </SelectParameters>
                      <UpdateParameters>
                          <asp:Parameter Name="MenuPrice" Type="Int32" />
                          <asp:Parameter Name="MenuInfomation" Type="String" />
                          <asp:Parameter Name="original_MenuName" Type="String" />
                          <asp:Parameter Name="original_MenuPrice" Type="Int32" />
                          <asp:Parameter Name="original_MenuInfomation" Type="String" />
                      </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

