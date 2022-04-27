<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">

  <head>
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>RenHarvest | SYSTEM</title>
        <link href="build/css/login.css" rel="stylesheet" />
        <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/js/all.min.js" crossorigin="anonymous"></script>
    </head>
    <body class="bg-primary">
    <form id="form1" runat="server">
        <div id="layoutAuthentication">
            <div id="layoutAuthentication_content">
                
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-5">
                                <div class="card shadow-lg border-0 rounded-lg mt-5">
                                    <div class="card-header"><h3 class="text-center font-weight-light my-4">Connexion</h3></div>
                                    <div class="card-body">
                                        
                                            <div class="form-floating mb-3">


                                                 <asp:TextBox ID="tuser"  class="form-control"  placeholder="username..." runat="server" Text=""></asp:TextBox>
                                                
                                                <label for="inputEmail">Nom d'utilisateur</label>
                                            </div>
                                            <div class="form-floating mb-3">

                                                     <asp:TextBox ID="tpass" TextMode="Password" class="form-control" placeholder="Password..." runat="server" Text=""></asp:TextBox>

                                               
                                                <label for="inputPassword">Mot de passe</label>
                                            </div>
                                            <!--<div class="form-check mb-3">
                                                <input class="form-check-input" id="inputRememberPassword" type="checkbox" value="" />
                                                <label class="form-check-label" for="inputRememberPassword">Souvenir</label>
                                            </div>-->
                                            <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                                <a class="small" href="password.html">Mot de passe oublie</a>
                                                <asp:Button ID="btnvalider" class="btn btn-primary" runat="server" Text="Connecter" OnClick="btnvalider_Click" />
                                                </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                
            </div>
            <div id="layoutAuthentication_footer">
                <footer class="py-4 bg-light mt-auto">
                    <div class="container-fluid px-4">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Copyright &copy; RenHarvest 2021</div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
        </form>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="build/js/jslogin.js"></script>
    </body>
</html>

