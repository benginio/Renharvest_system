<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifierRDV.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.ModifierRDV" %>

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
    <link href="../build/css/sweetalert2.min.css" rel="stylesheet" />
      <script type="text/javascript" src="../build/js/sweetalert2.js"></script>
    <script type="text/javascript">
        function up() {
            Swal.fire('Sucess!', 'Modification effectuer avec success!', 'success');
        }
    </script>
    <!-- Custom Theme Style -->
    <style type="text/css">
      .page{
        display: none;
      }
      #liste{
        display: block;
      }
    </style>
    <link href="../build/css/custom.css" rel="stylesheet">
    
</head>
<body class="nav-md">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                        <a class="dropdown-item" href="#"> Profile</a>
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
        <div class="right_col page" role="main" id="edit">
             <asp:UpdatePanel runat="server" ID="update"><ContentTemplate>
          <div class="">
             <div class="page-title"><br/>
              <div class="title_left">
                 <h5><span><i class="fa fa-user"></i></span>       
                            <asp:Label ID="Labe1" runat="server" Text="Label"></asp:Label> 
                             <asp:Label ID="Label2" runat="server" Text=""></asp:Label></h5>

              </div>   
                  <div class="pull-right">
                     <asp:LinkButton ID="btnliste" runat="server" class="btn btn-sm btn-pam" OnClick="btnliste_Click"><i class="fa fa-list-ul"></i> Liste</asp:LinkButton>
                 </div>
            </div><br/>

            <div class="row">
              
                <div class="x_panel col-md-12" style="background: url('../build/images/bgform3.png');">
                  <div class="x_title">
                    <div class="form-group row">
                      <div class="col-md-5 col-sm-5">
                           <h5> Patient:
                           <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        &nbsp;Medecin: <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </h5>
                          
                        </div> 
                        </div>
                  </div>
                  <div class="x_content">
                       <div class="form-horizontal">
                      
                        <div class="form-group row">
                                <div class="col-md-8 col-sm-8 offset-3">
                                    <label for="inputname">Motif*</label>
                                    <asp:TextBox ID="tmotif" TextMode="MultiLine" Rows="3" runat="server" class="form-control" ></asp:TextBox>
                                </div>
                        </div>
                      <div class="form-group row">
                        <div class="col-md-6 col-sm-6 offset-3">
                          <label>Date*</label>
                            <asp:TextBox ID="tdate" class="date-picker form-control" placeholder="dd-mm-yyyy" type="text" required="required"  onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'" onmouseout="timeFunctionLong(this)" runat="server"></asp:TextBox>
												<script>
                                                    function timeFunctionLong(TextBox) {
                                                        setTimeout(function (input) {
                                                            input.type = 'text';
                                                        }, 60000);
                                                    }
                                                </script>
                           </div>
                          </div>

                        <div class="form-group row">
                          <div class="col-md-6 col-sm-6 offset-3">
                            <label>Heure*</label>
                              <asp:TextBox ID="theure" runat="server" class="form-control time"  type="time" name="time" required="required"></asp:TextBox>
                            </div>
                        </div>
                           
                          <div class="form-group row">
                            <div class="col-md-6 col-sm-6 offset-3">
                              <label>Specialiste*</label>
                                <asp:TextBox ID="tspecial" class="form-control" placeholder="" runat="server" Enabled="False"></asp:TextBox>
                              </div>
                            </div>

                      <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-4">
                            <asp:Button ID="btnvalider" class="btn btn-pam" runat="server" Text="Valider" OnClick="btnvalider_Click" />
                            <asp:Button ID="btnannuler" class="btn btn-default" BorderColor="#29458D" OnClick="btnannuler_Click" runat="server" Text="Annuler" />

                        </div>
                      </div>
  
                    </div>
  
                    
                  </div>
                </div>
                </div>
            </div>

                
          </div>
             </ContentTemplate>
                           <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="btnvalider" EventName="click" />
                         </Triggers>
             </asp:UpdatePanel>
        </div>
        <!-- /page content -->

                <!-- page content -->
                <div class="right_col" role="main" id="liste">
                     <asp:UpdatePanel runat="server" ID="update1"><ContentTemplate>
                    <div class="">

                        <div class="page-title">
                            <div class="title_left">
                                <br />
                                <h5> Modifier Rendez-vous |</h5>
                            </div>
                             <div class="title_right">
							<div class="col-md-8 col-sm-8 form-group  top_search"><br />
								<div class="input-group">
                                    <asp:TextBox ID="tsearch" runat="server" class="form-control" placeholder="Recherche..."></asp:TextBox>
									<span class="input-group-btn">
                                        <asp:LinkButton ID="tbnsearch" runat="server" class="btn btn-pam" OnClick="tbnsearch_Click">
                                            <span><i class="fa fa-search"></i></span>
                                        </asp:LinkButton>
									</span>
								</div>
							</div>
                                 <div class="col-md-4 col-sm-4 form-group"><br />
                                 <h6>Filter  <asp:DropDownList ID="DDtrier" class="form-control" runat="server" ForeColor="#0D5B86" OnSelectedIndexChanged="DDtrier_SelectedIndexChanged" AutoPostBack="true">
                                     <asp:ListItem>Id RDV</asp:ListItem>
                                     <asp:ListItem>Date RDV</asp:ListItem>
                                     <asp:ListItem>Prenom Patient</asp:ListItem>
                                     <asp:ListItem>Nom Patient</asp:ListItem>
                                </asp:DropDownList> </h6>
                                    </div>
						</div>
                        </div>
                        <div class="x_panel col-lg-12">
                        <div class="x_title">
                    
                        </div>
                    <div class="x_content">
                        <div class="table-responsive">
                        <asp:GridView ID="magride" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="id" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle BackColor="#34495E" Font-Bold="True" ForeColor="White" />

                            <Columns>  
                                <asp:TemplateField HeaderText="-->">                       
                                           <ItemTemplate>                            
                                               <asp:LinkButton ID="btnbul" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btnbul_Click" OnClientClick="viewprof()" ><span class="me-2"><i class="fa fa-check-square-o"></i></span></asp:LinkButton> 
                                           </ItemTemplate> 
                                                  </asp:TemplateField>
                                 <asp:BoundField DataField="id" HeaderText="num" ReadOnly="True" SortExpression="num" />  
                                <asp:BoundField DataField="nomP" HeaderText="Nom" SortExpression="Nom" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="prenomP" HeaderText="Prenom" SortExpression="Prenom" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="adresse" HeaderText="Adresse" SortExpression="Adresse" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="sexe" HeaderText="Sexe" SortExpression="Sexe" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="motifRDV" HeaderText="Motif" SortExpression="Motif" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="daterdv" HeaderText="date" SortExpression="date" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="heure" HeaderText="heure" SortExpression="heure" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                <asp:BoundField DataField="createdby" HeaderText="createdby" SortExpression="createdby" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="datecreated" HeaderText="dateCreated" SortExpression="date" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" /> 
                                            
                 
                             </Columns> 

                        </asp:GridView>
                        
                        </div>
                    </div>
                </div>

                    </div>
                    </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="btnvalider" EventName="click" />
                         </Triggers>
                     </asp:UpdatePanel>
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
    <script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
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
         /*function showPage(page) {
            document.querySelectorAll('.page').forEach(page => {
                page.style.display = 'none';
             })

             document.querySelector(`#${page}`).style.display = 'block';
         }

         document.addEventListener('DOMContentLoaded', function () {
             document.querySelectorAll('.menu').forEach(menu => {
                 menu.onclick = function () {
                     showPage(this.dataset.page);
                 }
             });

         });*/
         $('#mymoda').modal({
             backdrop: false
         });
         
         function viewprof() {
             document.getElementById('liste').style.display = 'none';

             document.getElementById('edit').style.display = 'block';

         }
         function viewprof1() {
             document.getElementById('liste').style.display = 'block';

             document.getElementById('edit').style.display = 'none';
             

         }
         
     </script>
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    

</body>
</html>

