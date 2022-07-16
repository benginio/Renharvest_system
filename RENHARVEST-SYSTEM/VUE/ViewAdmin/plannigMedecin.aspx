<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plannigMedecin.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewAdmin.plannigMedecin" %>

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
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.css" rel="stylesheet">
    <style type="text/css">
      .page{
        display: none;
      }
      #tbox{
        display: block;
      }
    </style>
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
                            &nbsp;&nbsp;<asp:Label ID="tdatenow" runat="server" Text="" ForeColor="White"></asp:Label>
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
                  <li><a><i class="fa fa-user-md"></i> Medecin <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterMedecin.aspx" >Ajouter</a></li>
                      <li><a href="ModiferMedecin.aspx">Modifier</a></li>
                      <li><a href="ListerMedecin.aspx">lister</a></li>
                      
                    </ul>
                  </li>
                  <li><a><i class="fa fa-user-md"></i> Rendez-vous <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterRDV.aspx">Ajouter</a></li>
                      <li><a href="ModifierRDV.aspx">Modifier</a></li>
                      <li><a href="ListerRDV">lister</a></li>
                      
                    </ul>
                  </li>
                  <li><a><i class="fa fa-table"></i> Agenda <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AllrendezVous.aspx">Des Medecin</a></li>
                      <li><a href="plannigMedecin.aspx">D'un Medecin</a></li>
                    </ul>
                  </li>
                  <li><a><i class="fa fa-area-chart"></i> Rapport <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="rapport.aspx">Du mois</a></li>
                      <li><a href="#">....</a></li>
                      
                    </ul>
                  </li>
                </ul>
              </div><!--menu-section-->
             

            </div>
            <!-- /sidebar menu -->

                        <!-- /menu footer buttons -->
                        <div class="sidebar-footer hidden-small">

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
                                  <asp:LinkButton ID="btnlogout" runat="server" class="dropdown-item" OnClick="btnlogout_Click"><i class="fa fa-sign-out pull-right"></i> Log Out</asp:LinkButton>

                                </div>
                                </li>

                               
                            </ul>
                        </nav>
                    </div>
                </div>
                <!-- /top navigation -->
                

                <!-- page content -->
                <div class="right_col" role="main" id="liste">
                     
                    <div class="">

                        <div class="page-title">
                            <div class="title_left">
                                <br />
                                <h5> Agenda des Medecin |</h5>
                            </div>
                             <div class="title_right">
							<div class="col-md-8 col-sm-8 form-group  top_search"><br />
								<div class="input-group col-sm-12 col-md-12" >
                                    <div id="tbox" runat="server">
                                        <%--<asp:UpdatePanel runat="server" ID="update1"><ContentTemplate>--%>
                                      <asp:TextBox ID="tsearch" runat="server" class="form-control" placeholder="Recherche..." Text=""></asp:TextBox>
                                            <span class="input-group-btn">
                                        <asp:LinkButton ID="tbnsearch" runat="server" class="btn btn-pam" OnClick="tbnsearch_Click">
                                            <span><i class="fa fa-search"></i></span>
                                        </asp:LinkButton>
									</span>
                                       <%-- </ContentTemplate></asp:UpdatePanel>--%>
                                    </div>
                                    <div class="page" id="ddrop" runat="server">
                                        <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1"><ContentTemplate>--%>
                                            <asp:DropDownList ID="ddspecial" OnSelectedIndexChanged="ddspecial_SelectedIndexChanged" runat="server">

                                            </asp:DropDownList>
                                             <%--</ContentTemplate></asp:UpdatePanel>--%>
                                        </div>
									
								</div>
							</div>
                                 <div class="col-md-4 col-sm-4 form-group"><br />
                                 <h6>Filter  <asp:DropDownList ID="DDtrier" OnSelectedIndexChanged="DDtrier_SelectedIndexChanged" runat="server" ForeColor="#0D5B86" AutoPostBack="true">
                                    <asp:ListItem>Prenom</asp:ListItem>
                                    <asp:ListItem>Nom</asp:ListItem>
                                    <asp:ListItem>Specialisation</asp:ListItem>
                                </asp:DropDownList> </h6>
                                    </div>
						</div>
                        </div>
                        <div class="x_panel col-lg-12">
                        <div class="x_title">
                    
                        </div>
                    <div class="x_content">
                        <div class="table-responsive">
                        <asp:GridView ID="magride" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codepers" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle BackColor="#34495E" Font-Bold="True" ForeColor="White" />

                            <Columns>  
                                <asp:TemplateField HeaderText="-->">                       
                                           <ItemTemplate>                            
                                               <asp:LinkButton ID="btnbul" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btnbul_Click" ><span class="me-2"><i class="fa fa-check-square"></i></span></asp:LinkButton> 
                                           </ItemTemplate>                         
                   </asp:TemplateField>
                                            <asp:BoundField DataField="codepers" HeaderText="code" ReadOnly="True" SortExpression="codePatient" />  
                                            <asp:BoundField DataField="nomP" HeaderText="Nom" SortExpression="Nom" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                            <asp:BoundField DataField="prenomP" HeaderText="Prenom" SortExpression="Prenom" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="sexe" HeaderText="Sexe" SortExpression="Sexe" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="dateNaiss" HeaderText="Date_Naissance" SortExpression="Date Naissance" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                            <asp:BoundField DataField="adresse" HeaderText="Addresse" SortExpression="Adresse" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                            <asp:BoundField DataField="telephone" HeaderText="Telephone" SortExpression="Telephone" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="Email" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                            <asp:BoundField DataField="matricule" HeaderText="Matricule" SortExpression="Matricule" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                            <asp:BoundField DataField="specialisation" HeaderText="specialisation" SortExpression="specialisation" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                            <asp:BoundField DataField="job" HeaderText="Profession" SortExpression="Profession" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                             
                                            
                             </Columns> 

                        </asp:GridView>
                        
                        </div>
                    </div>
                </div>

                    </div>
                </div>
                <!-- /page content -->

                <!-- footer content -->
                <footer>
                    <div class="pull-right">
                        <strong>Copyright &copy; 2021-2025 <a href="#">TGLcomputing</a>.</strong> tout droit reservé.
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

     <script type="text/javascript">
         
         function viewprof() {
             document.getElementById('tbox').style.display = 'none';

             document.getElementById('ddrop').style.display = 'block';

         }
     </script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    

</body>
</html>
