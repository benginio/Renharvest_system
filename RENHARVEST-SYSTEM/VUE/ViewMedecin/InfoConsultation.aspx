<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoConsultation.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.InfoConsultation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">

    <title>RenHarvest-System | TGL</title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet"/>

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.css" rel="stylesheet">
</head>
<body class="nav-md">
    <form id="form1" runat="server">

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
                  <li><a><i class="fa fa-stethoscope"></i> Consultation <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterConsultation.aspx">Ajouter</a></li>
                      <li><a href="#">Lister</a></li>
                      
                     
                    </ul>
                  </li>
                  <li><a><i class="fa fa-user-md"></i> Rendez-vous <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterRDV.aspx">Ajouter</a></li>
                      <li><a href="#">Modifier</a></li>
                      <li><a href="#">lister</a></li>
                      <li><a href="#">Annuler</a></li>
                      
                    </ul>
                  </li>
                  <li><a><i class="fa fa-table"></i> Agenda <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="#">....</a></li>
                      <li><a href="#">....</a></li>
                    </ul>
                  </li>
                  <li><a><i class="fa fa-bar-chart-o"></i> Rapport <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="#">....</a></li>
                      <li><a href="#">....</a></li>
                      
                    </ul>
                  </li>
                    <li><a><i class="fa fa-cogs"></i> Parametre <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterMedicament.aspx">Medicament</a></li>
                      <li><a href="AjouterMaladie.aspx">Maladie</a></li>
                      
                    </ul>
                  </li>
                </ul>
              </div><!--menu-section-->
             

            </div>
            <!-- /sidebar menu -->


            <!-- /menu footer buttons -->
            <div class="sidebar-footer hidden-small">
              
              <a data-toggle="tooltip" data-placement="top" title="FullScreen">
                <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
              </a>
              
              <a data-toggle="tooltip" data-placement="top" title="Logout" href="login.html">
                <i class="fa fa-sign-out pull-right"></i>
              </a>
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
                      <a class="dropdown-item"  href="#"> Profile</a>
                      <asp:LinkButton ID="btnlogout" runat="server" class="dropdown-item" OnClick="btnlogout_Click"><i class="fa fa-sign-out pull-right"></i> Log Out</asp:LinkButton>

                    </div>

                  </li>
                  <li role="presentation" class="nav-item dropdown open">
                    <a href="javascript:;" class="dropdown-toggle info-number" id="navbarDropdown1" data-toggle="dropdown" aria-expanded="false">
                      <i class="fa fa-envelope-o"></i>
                      <span class="badge bg-green">1</span>
                    </a>
                      
                    
                  </li>
                </ul>
              </nav>
            </div>
          </div>
        <!-- /top navigation -->

        <!-- page content -->
        <div class="right_col" role="main">
          <div class=""><br/><br/>
                <div class="x_panel">
             <div class="page-title">
                 <div class="title_left">
                  <div class="form-group row">
                    <div class="col-sm-1 col-md-1">
                     <div class="profile clearfix">
                    <div class="profile_pic">
                    <img src="../build/images/userP.png" alt="..." class=" profile_img">
                    </div>
                    </div>
                </div><!--end col-->
                <div class="col-sm-11 col-md-11 py-2">
                    <h6>
                      <asp:Label ID="tnomP" runat="server" Text="Labeldhdhghfgdgdghdhgdh"></asp:Label>
                      <asp:Label ID="tprenomP" runat="server" Text="Labeldhdhghfgdgdghdhg"></asp:Label>
                    </h6>
                </div><!--end col-->
                 </div><!--end row-->
                 </div>
                 <div class="pull-right">
                     <div class="col-md-12 col-sm-12 py-2">
                     <label><b>D creation:</b></label>
                      <asp:Label ID="tdatecreation" runat="server" Text="02/10/2020"></asp:Label>
                </div><!--end col-->
                 </div>
              </div>
            <div class="x_content">

                <div class="col-sm-12 mail_list_column">
                <div class="mail_list">
                <div class="left">
                </div>
                <div class="right">
                    <h3>Information personnelle</h3>
                    <div class="form-group row">
                        <div class="col-md-2 col-sm-2">
                              <label><b>Sexe:</b></label>
                            <asp:Label ID="tsexe" runat="server" Text="Masculin"></asp:Label>
                        </div>
                         <div class="col-md-4 col-sm-4">
                            <label><b>Date Naiss:</b></label>
                             <asp:Label ID="tdatenaiss" runat="server" Text="02/10/2020"></asp:Label>
                        </div>
                        <div class="col-md-5 col-sm-5">
                            <label><b>Adresse:</b></label>
                             <asp:Label ID="tadresse" runat="server" Text="Labeldhdhghfgdgdghdhgdhghgddgfdff"></asp:Label>
                        </div>
                         <div class="col-md-1 col-sm-1">
                            <label><b>Age:</b></label>
                             <asp:Label ID="tage" runat="server" Text="122"></asp:Label>
                        </div>
                        
                    </div><!--end row-->
                     <div class="form-group row">
                         <div class="col-md-2 col-sm-2">
                            <label><b>Tel:</b></label>
                             <asp:Label ID="tphone" runat="server" Text="(509) 1234-1234"></asp:Label>
                        </div>
                         <div class="col-md-4 col-sm-4">
                            <label><b>Profession:</b></label>
                             <asp:Label ID="tjob" runat="server" Text="dhgdgdghdgdhgssgshghsgfsfs"></asp:Label>
                        </div>
                         <div class="col-md-5 col-sm-5">
                              <label><b>Email:</b></label>
                            <asp:Label ID="temail" runat="server" Text="Labeldhdhghfgdgdghdhgdhghgddfjfhfhfgkjg"></asp:Label>
                        </div>
                         <div class="col-md-1 col-sm-1">
                            <label><b>G S:</b></label>
                             <asp:Label ID="tgs" runat="server" Text="O+"></asp:Label>
                        </div>
                    </div><!--end row-->
                    <div class="form-group row">
                         <div class="col-md-6 col-sm-6">
                            <label><b>Pers responsable:</b></label>
                             <asp:Label ID="tprespon" runat="server" Text="dhgdgdghdgdhgssgshghsgfsfs"></asp:Label>
                        </div>
                         <div class="col-md-6 col-sm-6">
                            <label><b>Lien P responsable:</b></label>
                             <asp:Label ID="tlienrespon" runat="server" Text="dhgdgdghdgdhgssgshghsgfsfs"></asp:Label>
                        </div>
                    </div><!--end row-->
                </div>
                </div><!--end mail-list-->

                <div class="mail_list">
                <div class="left">
                    <i class="fa fa-code-fork"></i>
                </div>
                <div class="right">
                    <h3>Antecedent</h3>
                    <p> Ut enim ad minim veniam, quis nostrud exercitation enim ad minim veniam, quis nostrud exercitation...</p>
                </div>
                </div><!--end mail-list-->

                <div class="mail_list">
                <div class="left">
                    <i class="fa fa-stethoscope"></i>
                </div>
                <div class="right">
                    <h3>Consultation</h3>
                    <p> Ut enim ad minim veniam, quis nostrud exercitation enim ad minim veniam, quis nostrud exercitation...</p>
                </div>
                </div><!--end mail-list-->

                 <div class="mail_list">
                <div class="left">
                    <i class="fa fa-list-alt"></i>
                </div>
                <div class="right">
                    <h3>Ordonnace</h3>
                    <p> Ut enim ad minim veniam, quis nostrud exercitation enim ad minim veniam, quis nostrud exercitation...</p>
                </div>
                </div><!--end mail-list-->
                        
            </div>
            <!-- /MAIL LIST -->



            </div><!--x_content-->
             </div><!--x_panel-->

          </div><!--end class-->
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

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>

    
</body>
</html>

