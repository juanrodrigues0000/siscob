<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page - Product Admin Template</title>
    <link rel="stylesheet" href="./Login Page - Product Admin Template_files/css">
    <!-- https://fonts.google.com/specimen/Open+Sans -->
    <link rel="stylesheet" href="./Login Page - Product Admin Template_files/fontawesome.min.css">
    <!-- https://fontawesome.com/ -->
    <link rel="stylesheet" href="./Login Page - Product Admin Template_files/bootstrap.min.css">
    <!-- https://getbootstrap.com/ -->
    <link rel="stylesheet" href="./Login Page - Product Admin Template_files/templatemo-style.css">
	https://templatemo.com/tm-524-product-admin
</head>

<body>
    <form id="form1" runat="server">
        <div>
      <nav class="navbar navbar-expand-xl">
        <div class="container h-100">
          <a class="navbar-brand" href="https://technext.github.io/product-admin/index.html">
            <h1 class="tm-site-title mb-0">Product Admin</h1>
          </a>
          <button class="navbar-toggler ml-auto mr-0" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <i class="fas fa-bars tm-nav-icon"></i>
          </button>

          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mx-auto h-100">
              <li class="nav-item">
                <a class="nav-link" href="https://technext.github.io/product-admin/index.html">
                  <i class="fas fa-tachometer-alt"></i> Dashboard
                  <span class="sr-only">(current)</span>
                </a>
              </li>
              <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="https://technext.github.io/product-admin/login.html#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  <i class="far fa-file-alt"></i>
                  <span> Reports <i class="fas fa-angle-down"></i> </span>
                </a>
                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                  <a class="dropdown-item" href="https://technext.github.io/product-admin/login.html#">Daily Report</a>
                  <a class="dropdown-item" href="https://technext.github.io/product-admin/login.html#">Weekly Report</a>
                  <a class="dropdown-item" href="https://technext.github.io/product-admin/login.html#">Yearly Report</a>
                </div>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="https://technext.github.io/product-admin/products.html">
                  <i class="fas fa-shopping-cart"></i> Products
                </a>
              </li>

              <li class="nav-item">
                <a class="nav-link" href="https://technext.github.io/product-admin/accounts.html">
                  <i class="far fa-user"></i> Accounts
                </a>
              </li>
              <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="https://technext.github.io/product-admin/login.html#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  <i class="fas fa-cog"></i>
                  <span> Settings <i class="fas fa-angle-down"></i> </span>
                </a>
                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                  <a class="dropdown-item" href="https://technext.github.io/product-admin/login.html#">Profile</a>
                  <a class="dropdown-item" href="https://technext.github.io/product-admin/login.html#">Billing</a>
                  <a class="dropdown-item" href="https://technext.github.io/product-admin/login.html#">Customize</a>
                </div>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </div>

    <div class="container tm-mt-big tm-mb-big">
      <div class="row">
        <div class="col-12 mx-auto tm-login-col">
          <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
            <div class="row">
              <div class="col-12 text-center">
                <h2 class="tm-block-title mb-4">Entre no sistema</h2>
              </div>
            </div>
            <div class="row mt-2">
              <div class="col-12">

                <form action="https://technext.github.io/product-admin/index.html" method="post" class="tm-login-form">
                  
                  <div class="form-group">
                    <label for="username">Usuário</label>
                    <asp:TextBox ID="txtusername" class="form-control validate"  value="" required="" runat="server" OnTextChanged="txtusername_TextChanged"></asp:TextBox>
                  </div>

                  <div class="form-group mt-3">
                    <label for="password">Senha</label>
                    <asp:TextBox ID="txtpassword" class="form-control validate" textMode="Password" value="" required="" runat="server"></asp:TextBox>
    
                  </div>

                  <div class="form-group mt-4">
                    <asp:Button ID="btnlogin" type="submit" class="btn btn-primary btn-block text-uppercase" runat="server" Text="Login" OnClick="btnlogin_Click" />
                  </div>

                </form>

              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    </form>
</body>
</html>
