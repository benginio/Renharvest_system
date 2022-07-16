<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjouterMedicament.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.AjouterMedicament" %>

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
    <link href="../build/css/sweetalert2.min.css" rel="stylesheet" />
      <script type="text/javascript" src="../build/js/sweetalert2.js"></script>
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet"/>
    
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
                <h5>Ajouter Medicament|</h5>
              </div>
                  <div class="title_right">
                     <div class="col-md-8 col-sm-8 form-group  top_search offset-2"><br />
								<div class="input-group">
                                    <asp:TextBox ID="tsearch" runat="server" class="form-control" placeholder="Recherche..." Text=""></asp:TextBox>
									<span class="input-group-btn">
                                        <asp:LinkButton ID="tbnsearch" runat="server" class="btn btn-pam" OnClick="tbnsearch_Click">
                                            <span><i class="fa fa-search"></i></span>
                                        </asp:LinkButton>
									</span>
								</div>
							</div>
                 </div>
            </div>
               <div class="row">
              
                <div class="x_panel col-md-12 page" style="background: url('../build/images/bgform3.png');">
                  
                  <div class="x_content">
                      <div class="form-group row">
                          <div class="col-md-8 col-sm-8 ">
                              <div class="col-md-4 col-sm-4">
                                  <label>code</label>
                          <asp:Label ID="tcodeM" class="form-control" BackColor="#CCCCCC" runat="server" Text=""></asp:Label>
                        </div> 
                      <div class="col-md-6 col-sm-6 ">
                          <label>Nom Medicament</label>
                          <asp:TextBox ID="tnomM" class="form-control" placeholder=""  runat="server" OnTextChanged="tnomM_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                          <div class="col-md-2 col-sm-2">
                              <label>Dosage</label>
                          <asp:TextBox ID="tdosage" class="form-control" placeholder=""  runat="server" ></asp:TextBox>
                        </div>
                        </div><!--end col-8-->
                          <div class="col-md-4 col-sm-4 py-4">
                              <asp:LinkButton ID="btnajouter" CssClass="btn btn-success" OnClick="btnajouter_Click" runat="server">Ajouter</asp:LinkButton>
                              <asp:LinkButton ID="btnmodif" CssClass="btn btn-pam" OnClick="btnmodif_Click" runat="server">Modifier</asp:LinkButton>
                              <asp:LinkButton ID="btncancel" CssClass="btn btn-default" BorderColor="#29458D" OnClick="btncancel_Click" runat="server">Annuler</asp:LinkButton>

                         </div><!--end col-4-->
                      </div><!--end row-->

                      <div class="table-responsive">
                        <asp:GridView ID="magrid" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codeMed" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle BackColor="#34495E" Font-Bold="True" ForeColor="White" />

                            <Columns>  
                                <asp:BoundField DataField="codeMed" HeaderText="CodeMedicament" ReadOnly="True" SortExpression="code" />  
                                <asp:BoundField DataField="nomM" HeaderText="NomMedicament" SortExpression="Nom" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="dosage" HeaderText="Dosage" SortExpression="Prenom" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="createdby" HeaderText="Creer-Par" SortExpression="Sexe" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="datecreated" HeaderText="Date_creation" SortExpression="Date Naissance" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                            
                                <asp:TemplateField HeaderText="-->">                       
                                <ItemTemplate>                            
                                    <asp:LinkButton ID="btnbul" runat="server" Height="30px" CssClass="btn btn-success" OnClick="btnbul_Click" ><span class="me-2"><i class="fa fa-edit"></i></span>Edit</asp:LinkButton> 
                                    <asp:LinkButton ID="btnremove" runat="server" Height="30px" CssClass="btn btn-danger  " OnClick="btnremove_Click"  ><span class="me-2"><i class="fa fa-trash"></i></span>sup</asp:LinkButton>

                                </ItemTemplate>                         
                             </asp:TemplateField>
                             </Columns> 

                        </asp:GridView>
                        
                        </div>


                      </div>
                      
                </div><!--end add maladie-->

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

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    
        
</body>
</html>
