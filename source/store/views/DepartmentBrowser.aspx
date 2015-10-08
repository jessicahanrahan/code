<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="code.features.catalog_browsing" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
              <%-- for each department --%>
              <% foreach (var department in ((IEnumerable<MainDepartment>)Context.Items["report"])) { %>
              <tr class="ListItem">
               <td><a href="#"><%= department.name %></a></td>
           	  </tr>        
                <% } %>
      	    </table>            
</asp:Content>
