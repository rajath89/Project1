<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<%@ Register TagPrefix="cc" Namespace="CustomControll" Assembly="CustomControll" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div>
            <!-- Using the WelcomeLabel custom control -->
            <cc:WelcomeLabel ID="WelcomeLabel1" runat="server" 
                Text="Hello" 
                DefaultUserName="Guest" />
        </div>

    <%--<cc:CalendarControl ID="Calendar" runat="server" />--%>
<%--    <cc:DynamicGridControll ID="DynamicGrid1" runat="server" PageSize="5" />

        <form id="form1" runat="server">
        <div class="progress-container">
            <!-- Static ProgressBar -->
            <cc:ProgressBar ID="ProgressBar1" runat="server" Percentage="70" BarColor="#2196f3" BorderColor="#333" />
        </div>
        <div class="progress-container">
            <!-- Dynamic ProgressBar -->
            <cc:ProgressBar ID="ProgressBar2" runat="server" Percentage="0" BarColor="#ff5722" BorderColor="#555" />
        </div>
        <asp:Button ID="btnIncrease" runat="server" Text="Increase Progress" OnClick="btnIncrease_Click" />
    </form>--%>


    <div>
        <!-- Static ProgressBar -->
        <%--<cc:ProgressBar ID="ProgressBar1" runat="server" Percentage="70" BarColor="#2196f3" BorderColor="#333" />--%>
    </div>
    <div>
        <!-- Dynamic ProgressBar -->
        <%--<cc:ProgressBar ID="ProgressBar2" runat="server" Percentage="50" BarColor="#ff5722" BorderColor="#555" />--%>
<%--        <form id="form1" runat="server">
        <cc:AccountDropdown ID="AccountDropdown1" runat="server" />
    </form>--%>
    </div>


    <%--<main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Getting started</h2>
                <p>
                    ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Get more libraries</h2>
                <p>
                    NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Web Hosting</h2>
                <p>
                    You can easily find a web hosting company that offers the right mix of features and price for your applications.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>--%>

</asp:Content>
