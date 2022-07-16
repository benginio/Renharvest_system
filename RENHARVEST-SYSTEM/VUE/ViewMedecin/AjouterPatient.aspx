<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjouterPatient.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.AjouterPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>RenHarvest-System | TGL</title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <link href="../build/css/sweetalert2.min.css" rel="stylesheet" />
      <script type="text/javascript" src="../build/js/sweetalert2.js"></script>
   
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet"/>
    <!--pop for validation-->
    <link href="../build/css/bootstrap-4.min.css" rel="stylesheet">
    <!-- Custom Theme Style -->
    <link href="../build/css/custom.css" rel="stylesheet">
  </head>

<body class="nav-md">
    <form id="form1" runat="server" class="needs-validation" novalidate>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container body">
      <div class="main_container">
        <div class="col-md-3 left_col menu_fixed">
          <div class="left_col scroll-view">
            <div class="navbar nav_title" style="border: 0;">
              <a href="Default.html" class="site_title"><i class="fa fa-stethoscope"></i> <span>RenHarvest</span></a>
            </div>

            <div class="clearfix"></div>

            <!-- menu profile quick info -->
            <div class="profile clearfix">
              <div class="profile_pic">
                <img src="../build/images/User2.png" alt="..." class="img-circle profile_img">
              </div>
              <div class="profile_info">
                <span>Welcome, </span>
                 <asp:Label ID="tusername" runat="server" Text="" Class="label1" ForeColor="White"></asp:Label>
                
                  
              </div>
                  &nbsp;&nbsp;<asp:Label ID="tdatenow"  runat="server" Text="" ForeColor="White"></asp:Label>
            </div>
            <!-- /menu profile quick info -->


            <!-- sidebar menu -->
             <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
              <div class="menu_section">
               <a href="Accueil.aspx"> <h2><i class="fa fa-home"></i>Accueil</h2></a>
                <ul class="nav side-menu">
                  
                  <li><a><i class="fa fa-user"></i> Patients <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                     <li><a href="AjouterPatient.aspx">Ajouter</a></li>
                      <li><a href="ModifierPatient.aspx">Modifier</a></li>
                      <li><a href="ListePatient.aspx">Lister</a></li>
                    </ul>
                  </li>
                    <li><a href="DossierPatient.aspx"><i class="fa fa-list"></i> Dossier Patient </a>
                    
                  </li>
                  <li><a><i class="fa fa-stethoscope"></i> Consultation <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterConsultation.aspx">Ajouter</a></li>
                         <li><a href="suividossier.aspx">Suivi</a></li>
                      <li><a href="ListeConsultation.aspx">Lister</a></li>
                      
                     
                    </ul>
                  </li>
                  <li><a><i class="fa fa-user-md"></i> Rendez-vous <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterRDV.aspx">Ajouter</a></li>
                      <li><a href="ModifierRDV.aspx">Modifier</a></li>
                      <li><a href="ListeRDV.aspx">Lister</a></li>
                      <li><a href="listRDVannuler.aspx">Liste Annuler</a></li>
                      
                    </ul>
                  </li>
                  <li><a href="rendezVous.aspx"><i class="fa fa-table"></i> Agenda </a>
                    
                  </li>
                    <li><a><i class="fa fa-cogs"></i> Parametre <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterMedicament.aspx">Medicament</a></li>
                      <li><a href="AjouterMaladie.aspx">Maladie</a></li>
                      <li><a href="ajouterTypeExamen.aspx">Type Examen</a></li>
                      <li><a href="ajouterMotifCons.aspx">Motif Consultation</a></li>
                      
                    </ul>
                  </li>
                </ul>
              </div><!--menu-section-->
             

            </div>
            <!-- /sidebar menu -->
			
			

            <!-- /menu footer buttons -->
            <div class="sidebar-footer hidden-small">
              
<%--              <a data-toggle="tooltip" data-placement="top" title="FullScreen">
                <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
              </a>
              
              <a data-toggle="tooltip" data-placement="top" title="Logout" href="login.html">
                <i class="fa fa-sign-out pull-right"></i>
              </a>--%>
            </div> 
            <!-- /menu footer buttons -->
          </div>
        </div>

        <!-- top navigation -->
        <div class="top_nav navbar-fixed-top">
            <div class="nav_menu">
                <div class="nav toggle">
                  <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                </div>
                <nav class="nav navbar-nav">
                <ul class=" navbar-right">
                  <li class="nav-item dropdown open" style="padding-left: 15px;">
                    <a href="javascript:;" class="user-profile dropdown-toggle" aria-haspopup="true" id="navbarDropdown" data-toggle="dropdown" aria-expanded="false">
                      <i class="fa fa-user"></i> &nbsp;<asp:Label ID="Username1" runat="server" Text=""></asp:Label>
                    </a>
                    <div class="dropdown-menu dropdown-usermenu pull-right" aria-labelledby="navbarDropdown">
                      <%--<a class="dropdown-item"  href="javascript:;"> Profile</a>--%>
                     <asp:LinkButton ID="btnlogout" runat="server" class="dropdown-item" OnClick="btnlogout_Click"><i class="fa fa-sign-out pull-right"></i> Log Out</asp:LinkButton>
                    </div>
                  </li>
                </ul>
              </nav>
            </div>
          </div>
        <!-- /top navigation --><br/>

        <!-- page content -->
        <div class="right_col" role="main">
          <div class="">
             <div class="page-title">
              <div class="title_left">
                <h5> Ajouter Patients |</h5>
              </div>
                 <div class="pull-right">
                     <asp:LinkButton ID="btnliste" runat="server" class="btn btn-sm btn-pam" OnClick="btnliste_Click"><i class="fa fa-list-ul"></i> Liste</asp:LinkButton>
                 </div>
            </div>

            <div class="row">
              
                <div class="x_panel col-md-12" style="background: url('../build/images/bgform3.png');">
                   <div class="form-group row">
                      <div class="col-md-4 col-sm-4">
                           <label>Code:</label>
                          <asp:Label ID="tcodep" runat="server" Text=""></asp:Label>
                        </div> 
                        </div>
                  <div class="x_content">
                    <div class="form-horizontal form-label-left">
                      <div class="form-group row">
                        <div class="col-sm-4 col-md-4">
                        <label for="firstName" class="form-label">Nom</label>
                        <asp:TextBox ID="tnomp" class="form-control" placeholder="" runat="server" required="required"></asp:TextBox>
                        <span id="nom_ma"></span>
                        </div>
                       
                          <div class="col-sm-4 col-md-4">
                            <label for="LastName" class="form-label">Prenom</label>
                              <asp:TextBox ID="tprenomp" class="form-control" placeholder="" runat="server" AutoPostBack="true" OnTextChanged="tprenomp_TextChanged" required="required"></asp:TextBox>
                              <span id="prenom_ma"></span>
                            </div>

                           <div class="col-md-4 col-sm-4">
                              <label for="Sexe" class="form-label">Sexe</label>
                                <asp:DropDownList ID="ddsexe" class="form-control" runat="server" style="width: 100%;">
                                    <asp:ListItem Selected="True" disabled="disabled">--Choisir--</asp:ListItem>
                                    <asp:ListItem>Masculin</asp:ListItem>
                                    <asp:ListItem>Feminin</asp:ListItem>
                                    <asp:ListItem>Autre</asp:ListItem>
                                </asp:DropDownList>
                                <span id="sexe_ma"></span>
                              </div>
                            
                      </div>

                      <div class="form-group row">
                         
                        <div class="col-md-4 col-sm-4">
                          <label>Date Naissance</label>
                            <asp:TextBox ID="tdatenaiss" class="date-picker form-control" placeholder="dd-mm-yyyy" type="text"  onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'" onmouseout="timeFunctionLong(this)" OnTextChanged="tdatenaiss_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
												<script>
                                                    function timeFunctionLong(TextBox) {
                                                        setTimeout(function (input) {
                                                            input.type = 'text';
                                                        }, 60000);
                                                    }
                                                </script>
                             <span id="date_ma"></span>
                          </div>
                          <div class="col-md-4 col-sm-4">
                              <label>Age</label>
                              <asp:TextBox ID="tage" CssClass="form-control" runat="server" Text="" disabled="disabled"></asp:TextBox>
                              </div>
                          <div class="col-md-4 col-sm-4">
                            <label>Adresse</label>
                              <asp:TextBox ID="tadresse" TextMode="MultiLine" class="form-control" placeholder="" Rows="1" runat="server" ></asp:TextBox>
                             <span id="address_ma"></span>
                          </div>
                            
                      </div>

                      <div class="form-group row">
                          <div class="col-md-4 col-sm-4">
                              <label>Telephone</label>
                                <asp:TextBox ID="tphone" TextMode="Phone" class="form-control" placeholder="" runat="server" data-inputmask="'mask' : '(999) 9999-9999'"  ></asp:TextBox>
                               <span id="phone_ma"></span>
                          </div>
                        <div class="col-md-4 col-sm-4">
                          <label>Email</label>
                            <asp:TextBox ID="temail" TextMode="Email" class="form-control" placeholder="" runat="server"></asp:TextBox>
                         <span id="email_ma"></span>  
                        </div>

                           <div class="col-md-4 col-sm-4">
                              <label>Matricule</label>
                                <asp:TextBox ID="tmatricule"  class="form-control" placeholder="" runat="server" OnTextChanged="tmatricule_TextChanged" AutoPostBack="true" required="required"></asp:TextBox>
                                <span id="matri_ma"></span>
                               </div>

                      </div>
                        
                      <div class="form-group row">
                           <div class="col-md-4 col-sm-4">
                            <label>Profession</label>
                              <asp:TextBox ID="tjob" class="form-control" placeholder="" runat="server" required="required"></asp:TextBox>
                                <span id="job_ma"></span>
                            </div>
                            <div class="col-md-4 col-sm-4">
                              <label>Groupe Sanguin</label>
                                <asp:DropDownList ID="ddg_s" class="form-control" placeholder="" runat="server">
                                    <asp:ListItem Selected="True" disabled="disabled">--Choisir--</asp:ListItem>
                                    <asp:ListItem>O+</asp:ListItem>
                                    <asp:ListItem>O-</asp:ListItem>
                                    <asp:ListItem>AB</asp:ListItem>
                                    <asp:ListItem>B+</asp:ListItem>
                                    <asp:ListItem>A+</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                </asp:DropDownList>
                              </div>

                      </div><!--end row-->

                        <h6 class="bg-pam">Responsable</h6>
                        <div class="form-group row">
                            <div class="col-md-3 col-sm-3">
                          <label>Personne Responsable</label>
                            <asp:TextBox ID="tp_respon" class="form-control" placeholder="" runat="server" ></asp:TextBox>
                                 <span id="pRes_ma"></span>
                          </div>
                          <div class="col-md-2 col-sm-2">
                            <label>Lien A P. Responsable</label>
                              <asp:DropDownList ID="ddlienp" class="form-control"  runat="server" required="required" style="width: 100%;">
                                  <asp:ListItem Selected="True" disabled="disabled">--Choisir--</asp:ListItem>
                                  <asp:ListItem>Mere</asp:ListItem>
                                    <asp:ListItem>Pere</asp:ListItem>
                                    <asp:ListItem>Frere</asp:ListItem>
                                  <asp:ListItem>Soeur</asp:ListItem>
                                    <asp:ListItem>Cousin</asp:ListItem>
                                    <asp:ListItem>Cousine</asp:ListItem>
                                  <asp:ListItem>Oncle</asp:ListItem>
                                    <asp:ListItem>Tante</asp:ListItem>
                                    <asp:ListItem>Grand-Mere</asp:ListItem>
                                  <asp:ListItem>Grand-Pere</asp:ListItem>
                                    <asp:ListItem>Amis</asp:ListItem>
                              </asp:DropDownList>
                            </div>
                             <div class="col-md-4 col-sm-4">
                                 <label>Adresse REsponsable</label>
                              <asp:TextBox ID="taddressResp" TextMode="MultiLine" class="form-control" placeholder="" Rows="1" runat="server"></asp:TextBox>
                                 
                                </div>
                            <div class="col-md-3 col-sm-3">
                              <label>Telephone Responsable</label>
                                <asp:TextBox ID="tphoneResp" TextMode="Phone" class="form-control" placeholder="" runat="server" data-inputmask="'mask' : '(999) 9999-9999'"  ></asp:TextBox>
                              </div>
                        </div>

                    </div>
                  </div>
                </div>
                <div class="x_content">
                     <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-5">
                            <asp:Button ID="btnvalider" class="btn btn-success" type="submit" runat="server" Text="Enregistrer"  OnClick="btnvalider_Click" />
                            <asp:Button ID="btnannuler" class="btn btn-default" BorderColor="#29458D" OnClick="btnannuler_Click" runat="server" Text="Annuler" />
                        </div>
                      </div>
                </div>
              
            </div>

                </div>
          
        </div>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="pull-right">
            <strong >Copyright &copy; 2021-2025 <a href="#">TGLcomputing</a>.</strong> tout droit reservé.
          </div>
          <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->
      </div>
    </div>

         </form>
    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
   <script src="../vendors/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- jQuery custom content scroller -->
    <script src="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js"></script>
     <!-- jquery.inputmask -->
    <script src="../vendors/jquery.inputmask/dist/min/jquery.inputmask.bundle.min.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
     <script src="../build/js/validation.js" type="text/javascript"> </script>
    
    
  </body>
</html>
