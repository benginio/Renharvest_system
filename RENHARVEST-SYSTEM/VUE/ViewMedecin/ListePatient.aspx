<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListePatient.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.ListePatient" %>

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
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet"/>
     <style type="text/css">
      .pag{
          display: none;
      }
      #Search{
        display: block;
      }
      
    </style>
    <!-- Custom Theme Style -->
    <link href="../build/css/custom.css" rel="stylesheet">
</head>
<body class="nav-md">
    <form id="form1" runat="server">
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
                      <li><a href="listecons.aspx">Lister</a></li>
                      
                     
                    </ul>
                  </li>
                  <li><a><i class="fa fa-user-md"></i> Rendez-vous <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterRDV.aspx">Ajouter</a></li>
                      <li><a href="ModifierRDV.aspx">Modifier</a></li>
                      <li><a href="ListeRDV.aspx">lister</a></li>
                      <li><a href="AnnulerRDV.aspx">Annuler</a></li>
                      
                    </ul>
                  </li>
                  <li><a href="rendezVous.aspx"><i class="fa fa-table"></i> Agenda <span class="fa fa-chevron-down"></span></a>
                    
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
          <div class="">

             <div class="page-title">
              <div class="title_left"><br/>
                <h5> Liste Patient |</h5>
              </div>
            </div>
              <div class="row">
                  <div class="col-sm-2 col-md-2">
                      <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" runat="server" OnClick="LinkButton1_Click">Ajouter <span><i class="fa fa-plus-circle"></i></span></asp:LinkButton>
                  </div>
                  <div class="col-sm-10 col-md-10">
                      
                      <div class="col-md-8 col-sm-8" id="Search">
                          <asp:UpdatePanel runat="server"><ContentTemplate>
                           <div class="col-md-5 col-sm-5">
                               <asp:TextBox ID="tsearchNP" runat="server" class="form-control" placeholder="Rechercher..."></asp:TextBox>
                           </div>
                           <div class="col-md-5 col-sm-5">
                               <asp:DropDownList ID="DDsexe" CssClass="form-control" runat="server">
                                   <asp:ListItem>--choisir Sexe--</asp:ListItem>
                                   <asp:ListItem>Masculin</asp:ListItem>
                                    <asp:ListItem>Feminin</asp:ListItem>
                               </asp:DropDownList>
                           </div>
                           <div class="col-md-2 col-sm-2">
                               <span class="input-group-btn">
                                        <asp:LinkButton ID="btnsearch" runat="server" class="btn btn-pam" OnClick="btnsearch_Click">
                                            <span><i class="fa fa-search"></i></span>
                                        </asp:LinkButton>
									</span>
                               </div>
                              </ContentTemplate></asp:UpdatePanel>
                            </div>
                       <div class="col-md-8 col-sm-8 pag" id="Searchage">
                           <asp:UpdatePanel runat="server"><ContentTemplate>
                           <div class="col-md-5 col-sm-5">
                               <asp:TextBox ID="tagebebut" runat="server" class="form-control" ></asp:TextBox>
                           </div>
                           <div class="col-md-5 col-sm-5">
                               <asp:TextBox ID="tagefin" runat="server" class="form-control" ></asp:TextBox>
                           </div>
                           <div class="col-md-2 col-sm-2">
                               <span class="input-group-btn">
                                        <asp:LinkButton ID="btnsearchage" runat="server" class="btn btn-pam" OnClick="btnsearchage_Click">
                                            <span><i class="fa fa-search"></i></span>
                                        </asp:LinkButton>
									</span>
                               </div>
                               </ContentTemplate></asp:UpdatePanel>
                            </div>
                            <div class="col-md-8 col-sm-8 pag" id="Searchsexe">
                                <asp:UpdatePanel runat="server"><ContentTemplate>
                           <div class="col-md-5 col-sm-5 offset-2">
                               <asp:DropDownList ID="DDsexe1" CssClass="form-control" runat="server" OnSelectedIndexChanged="DDsexe1_SelectedIndexChanged" AutoPostBack="true">
                                   <asp:ListItem>--choisir Sexe--</asp:ListItem>
                                   <asp:ListItem>Masculin</asp:ListItem>
                                    <asp:ListItem>Feminin</asp:ListItem>
                               </asp:DropDownList>
                           </div>
                                  </ContentTemplate></asp:UpdatePanel>
                            </div>
                        
                            <div class="col-md-4 col-sm-4">
                                <div class="col-md-6 col-sm-6">
                                <asp:UpdatePanel runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddsearch" CssClass="form-control" OnSelectedIndexChanged="ddsearch_SelectedIndexChanged" runat="server" AutoPostBack="true">
                                    
                                    <asp:ListItem>Prenom</asp:ListItem>
                                    <asp:ListItem>Nom</asp:ListItem>
                                    <asp:ListItem>Age</asp:ListItem>
                                    <asp:ListItem>Sexe</asp:ListItem>
                                </asp:DropDownList>
                                  </ContentTemplate></asp:UpdatePanel>
                                    </div>
                                 <div class="col-md-6 col-sm-6">
                                     <asp:LinkButton ID="navbarDropdown2" class="btn btn-default dropdown-toggle" aria-haspopup="true"  data-toggle="dropdown" aria-expanded="false" runat="server" BorderColor="#29458D">
                                         <i class="fa fa-print"></i>Export
                                     </asp:LinkButton>
                                     <div class="dropdown-menu dropdown-usermenu pull-right" aria-labelledby="navbarDropdown2">
                                     <asp:LinkButton ID="btnpdf" CssClass="dropdown-item" runat="server" OnClick="btnpdf_Click"><i class="fa fa-file-pdf-o"></i> Pdf</asp:LinkButton>
                                     <asp:LinkButton ID="btnexcel" CssClass="dropdown-item" runat="server" OnClick="btnexcel_Click"><i class="fa fa-file-excel-o"></i> Excel</asp:LinkButton>
                                 </div>
                              </div>
                  </div>
                </div>
                  </div>
              <div class="row" id="export" runat="server">
                <div class="x_panel col-lg-12">
                        <div class="x_title">
                    
                        </div>
                    <div class="x_content">
                        <div class="table-responsive">
                        <asp:GridView ID="magride" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codepers" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle BackColor="#34495E" Font-Bold="True" ForeColor="White" />

                            <Columns> 
                                <asp:BoundField DataField="codepers" HeaderText="codePatient" ReadOnly="True" SortExpression="codePatient" />  
                                <asp:BoundField DataField="nomP" HeaderText="Nom" SortExpression="Nom" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="prenomP" HeaderText="Prenom" SortExpression="Prenom" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="sexe" HeaderText="Sexe" SortExpression="Sexe" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="dateNaiss" HeaderText="Date_Naissance" SortExpression="Date Naissance" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="adresse" HeaderText="Addresse" SortExpression="Adresse" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="telephone" HeaderText="Telephone" SortExpression="Telephone" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="Email" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="job" HeaderText="Profession" SortExpression="Profession" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                <asp:BoundField DataField="gps" HeaderText="G_S" SortExpression="Groupe_S." HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="persResp" HeaderText="Responsable" SortExpression="Personne_Respnsable" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                <asp:BoundField DataField="lienApersResp" HeaderText="Lien_respon" SortExpression="Lien_Personne responsable" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="createdby" HeaderText="CreerPar" SortExpression="Createdby" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="datecreated" HeaderText="DCreation" SortExpression="datecreated" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                            
                             </Columns> 

                        </asp:GridView>
                        
                        
                    </div>
                    
                </div>
             </div>
                 <%-- </ContentTemplate></asp:UpdatePanel>--%>
          </div>
        </div> <!-- clSS -->
            </div>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="pull-right" >
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
    <script type="text/javascript">
         function Searchage() {
             document.getElementById('Searchage').style.display = 'block';
             document.getElementById('Searchsexe').style.display = 'none';
             document.getElementById('Search').style.display = 'none';
        }
        function Searchsexe() {
            document.getElementById('Searchsexe').style.display = 'block';
            document.getElementById('Searchage').style.display = 'none';
            document.getElementById('Search').style.display = 'none';
        }
        function Search() {
            document.getElementById('Search').style.display = 'block';
            document.getElementById('Searchsexe').style.display = 'none';
            document.getElementById('Searchage').style.display = 'none';
        }
    </script>
    

</body>
</html>
