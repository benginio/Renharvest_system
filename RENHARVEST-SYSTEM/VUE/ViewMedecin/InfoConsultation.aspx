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
<body class="nav-md" id="printttdiv" runat="server">
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
        <div class="top_nav navbar-fixed-top hidden-print">
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
              <div class="pull-right hidden-print" >
                  <asp:LinkButton ID="btnExportpdf" CssClass="btn btn-default" OnClick="btnExportpdf_Click" OnClientClick="Printt()" runat="server"><span><i class="fa fa-print"></i></span> Export pdf</asp:LinkButton>
              </div>
                <div class="x_panel" id="fieldPdf" runat="server">
             <div class="page-title">
                 <div class="title_left">
                  <div class="form-group row">
                    <div class="col-sm-1 col-md-1">
                     <div class="profile clearfix">
                    <div class="profile_pic">
                    
                    </div>
                    </div>
                </div><!--end col-->
                <div class="col-sm-10 col-md-10 py-2 px-1">
                    <h5>
                        <strong>Nom et Prenom:</strong>
                     &nbsp; <asp:Label ID="tnomP" runat="server" Text=""></asp:Label>
                      <asp:Label ID="tprenomP" runat="server" Text=""></asp:Label>
                    </h5>
                </div><!--end col-->
                 </div><!--end row-->
                 </div>
                 <div class="pull-right">
                     <div class="col-md-6 col-sm-6 py-2">
                     <label><b>D creation:</b></label>
                      <asp:Label ID="tdatecreation" runat="server" Text=""></asp:Label>
                </div><!--end col-->
                     <div class="col-md-6 col-sm-6 py-2">
                     <label><b>Heure:</b></label>
                      <asp:Label ID="lblheure" runat="server" Text=""></asp:Label>
                </div><!--end col-->
                 </div>
              </div>
            <div class="x_content">

                <div class="col-sm-12 mail_list_column">
                <div class="mail_list">
                <div class="left">
                </div>
                <div class="right">
                    <h3 class="bg-pam">Information personnelle</h3>
                    <div class="form-group row">
                        <div class="col-md-5 col-sm-2">
                              <label><b>Sexe:</b></label>
                            <asp:Label ID="tsexe" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="col-md-4 col-sm-4">
                            <label><b>Date Naiss:</b></label>
                             <asp:Label ID="tdatenaiss" runat="server" Text=""></asp:Label>
                        </div>
                        
                         <div class="col-md-3 col-sm-1">
                            <label><b>Age:</b></label>
                             <asp:Label ID="tage" runat="server" Text=""></asp:Label>
                        </div>
                        
                    </div><!--end row-->
                     <div class="form-group row">
                         <div class="col-md-5 col-sm-5">
                            <label><b>Adresse:</b></label>
                             <asp:Label ID="tadresse" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="col-md-4 col-sm-2">
                            <label><b>Tel:</b></label>
                             <asp:Label ID="tphone" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="col-md-3 col-sm-4">
                            <label><b>Profession:</b></label>
                             <asp:Label ID="tjob" runat="server" Text=""></asp:Label>
                        </div>
                        
                    </div><!--end row-->
                    <div class="form-group row">
                         <div class="col-md-5 col-sm-5">
                              <label><b>Email:</b></label>
                            <asp:Label ID="temail" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <label><b>Matricule:</b></label>
                             <asp:Label ID="tmatricule" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="col-md-3 col-sm-3">
                            <label><b>G S:</b></label>
                             <asp:Label ID="tgs" runat="server" Text=""></asp:Label>
                        </div>
                        
                    </div><!--end row-->
                    <div class="form-group row">
                         <div class="col-md-5 col-sm-5">
                            <label><b>Pers responsable:</b></label>
                             <asp:Label ID="tprespon" runat="server" Text=""></asp:Label>
                        </div>
                         <div class="col-md-5 col-sm-5">
                            <label><b>Lien P responsable:</b></label>
                             <asp:Label ID="tlienrespon" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                </div><!--end mail-list-->

                <div class="mail_list">
                <div class="left">
                    <i class="fa fa-code-fork"></i>
                </div>
                <div class="right">
                    <h3 class="bg-pam">Antecedent</h3>
                    <div class="form-group row">
                    <div class="col-md-6 col-sm-6">
                         <div class="table-responsive">
                        <asp:GridView ID="Gridantfamille" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="descriptionAnt" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle  Font-Bold="True" ForeColor="black" />

                            <Columns>  
                                <asp:BoundField DataField="descriptionAnt" HeaderText="familliaux" ReadOnly="True" SortExpression="nom" /> 
                                <asp:BoundField DataField="datecreated" HeaderText="D_creation" ReadOnly="True" SortExpression="date" /> 
                              </Columns> 

                        </asp:GridView>
                                </div>
                    </div><!--end col-->
                    <div class="col-md-6 col-sm-6">
                         <div class="table-responsive">
                        <asp:GridView ID="Gridantpers" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="descriptionAnt" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle  Font-Bold="True" ForeColor="black" />

                            <Columns>  
                                <asp:BoundField DataField="descriptionAnt" HeaderText="Personnels" ReadOnly="True" SortExpression="nom" /> 
                                <asp:BoundField DataField="datecreated" HeaderText="D_creation" ReadOnly="True" SortExpression="date" /> 
                              </Columns> 

                        </asp:GridView>
                                </div>
                    </div><!--end col-->
                        </div><!--end row-->

                         <div class="form-group row">
                    <div class="col-md-6 col-sm-6">
                         <div class="table-responsive">
                        <asp:GridView ID="Gridoperation" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="descriptionAnt" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle  Font-Bold="True" ForeColor="black" />

                            <Columns>  
                                <asp:BoundField DataField="descriptionAnt" HeaderText="Chirurgicaux" ReadOnly="True" SortExpression="nom" /> 
                                <asp:BoundField DataField="dateOperation" HeaderText="Date operation" ReadOnly="True" SortExpression="date" /> 
                               <asp:BoundField DataField="datecreated" HeaderText="D_creation" ReadOnly="True" SortExpression="date" /> 
                              </Columns> 

                        </asp:GridView>
                                </div>
                    </div><!--end col-->
                         <div class="col-md-6 col-sm-6">
                         <div class="table-responsive">
                        <asp:GridView ID="Gridhabitude" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="descriptionAnt" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle  Font-Bold="True" ForeColor="black" />

                            <Columns>  
                                <asp:BoundField DataField="descriptionAnt" HeaderText="Habitudes" ReadOnly="True" SortExpression="nom" /> 
                                <asp:BoundField DataField="datecreated" HeaderText="D_creation" ReadOnly="True" SortExpression="date" /> 
                              </Columns> 

                        </asp:GridView>
                                </div>
                    </div><!--end col-->
                      </div><!--end row-->
                </div>
                </div><!--end mail-list-->

                <div class="mail_list">
                <div class="left">
                    <i class="fa fa-stethoscope"></i>
                </div>
                <div class="right">
                    <h3 class="bg-pam">Consultation</h3>
                    <div class="col-md-9 col-sm-9">
                        <div class="row">
                            <h5>Examen</h5>
                        <div class="col-md-12 col-sm-12">
                             <div class="table-responsive">
                        <asp:GridView ID="gridexamen" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codePatient" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle  Font-Bold="True" ForeColor="black" />

                            <Columns>  
                            <asp:BoundField DataField="codePatient" HeaderText="code_patient" ReadOnly="True" SortExpression="codeM" />  
                            <asp:BoundField DataField="descriptionE" HeaderText="Description" SortExpression="Description" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                            <asp:BoundField DataField="resultatE" HeaderText="Resultat" SortExpression="Resultat" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                            <asp:BoundField DataField="datecreated" HeaderText="creation" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                            
                                </Columns> 
                        </asp:GridView>
                                </div>
                        </div><!--end col6-->
                        </div><!--end row-->
                        
                    </div><!--end col8-->
                    <div class="col-md-3 col-sm-3">
                         <h5 >Signe vitaux</h5>
                         <div class="row">
                             <label><strong>Poids (Kg): </strong></label><br />
                             <asp:Label ID="lblpoid" runat="server" Text=""></asp:Label>
                        </div><!--end row-->
                        <div class="row">
                             <label><strong>Temperature (C°): </strong></label><br />
                             <asp:Label ID="lbltemp" runat="server" Text=""></asp:Label>
                        </div><!--end row-->
                        <div class="row">
                             <label><strong>Taille (m): </strong></label><br />
                             <asp:Label ID="lbltaille" runat="server" Text=""></asp:Label>
                        </div><!--end row-->
                        <div class="row">
                             <label><strong> TA (mm/Hg): </strong></label><br />
                             <asp:Label ID="lblta" runat="server" Text=""></asp:Label>
                        </div><!--end row-->
                        <div class="row">
                             <label><strong>Pouls: </strong></label><br />
                             <asp:Label ID="lblpouls" runat="server" Text=""></asp:Label>
                        </div><!--end row-->
                    </div><!--end col4-->
                    <div class="col-md-12 col-sm-12">
                        <div class="x_panel">
                            <h5 >Consultation</h5><br />
                            
                            <div class="form-group row">
                            <div class="col-md-4">
                                 <label><strong>Code Patient:</strong></label>
                             <asp:Label ID="lblcodepatient" runat="server" Text=""></asp:Label>
                            </div><!--end col-4-->
                            <div class="col-md-4">
                                 <label><strong>Age:</strong></label>
                             <asp:Label ID="lblagep" runat="server" Text=""></asp:Label>
                            </div><!--end col-4-->
                             </div><!--end row-->
                            <div class="form-group row">
                            <div class="col-md-4">
                                 <label><strong>Signe:</strong></label><br />
                             <asp:Label ID="lblsigne" runat="server" Text=""></asp:Label>
                            </div><!--end col-4-->
                            <div class="col-md-4">
                                 <label><strong>Symptomes:</strong></label><br />
                             <asp:Label ID="lblsymp" runat="server" Text=""></asp:Label>
                            </div><!--end col-4-->
                            <div class="col-md-4">
                                 <label><strong>Histoire:</strong></label><br />
                             <asp:Label ID="lblhistoire" runat="server" Text=""></asp:Label>
                            </div><!--end col-4-->
                             </div><!--end row-->
                            <div class="form-group row">
                            <div class="col-md-4">
                                 <label><strong>Diagnostique:</strong></label><br />
                             <asp:Label ID="lbldiag" runat="server" Text=""></asp:Label>
                            </div><!--end col-4-->
                            <div class="col-md-4">
                                 <label><strong>Notes:</strong></label><br />
                             <asp:Label ID="lblcomment" runat="server" Text=""></asp:Label>
                            </div><!--end col-4-->
                            <div class="col-md-4">
                                 <label><strong>Date creation:</strong></label><br />
                             <asp:Label ID="lbldcreated" runat="server" Text=""></asp:Label>
                            </div><!--end col-4-->
                             </div>
                            </div>
                    </div><!--end col-->
                    
                </div>
                </div><!--end mail-list-->

                 <div class="mail_list">
                <div class="left">
                    <i class="fa fa-list-alt"></i>
                </div>
                <div class="right">
                    <h3 class="bg-pam">Traitment</h3>
                    <div class="form-group row">
                        <div class="col-md-6 col-sm-6">
                            <label><strong>Prevention: </strong></label>
                            <asp:Label ID="lblprevention" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="col-md-6 col-sm-6">
                            <label><strong>Duree: </strong> </label>
                            <asp:Label ID="lbldurer" runat="server" Text="Label"></asp:Label>
                        </div>
                    
                    </div>
                    <div class="form-group row">
                        <h5>Ordonnance</h5>
                        <div class="table-responsive">
                            <asp:GridView ID="GridOrdonance" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codeMed" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                                <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                <Columns>
                                    <asp:BoundField DataField="codeMed" HeaderText="codeMedicament" ReadOnly="True" SortExpression="codeM" />
                                    <asp:BoundField DataField="nomM" HeaderText="Nom_Medicament" ReadOnly="True" SortExpression="codeM" />
                                    <asp:BoundField DataField="dosage" HeaderText="Dosage" ReadOnly="True" SortExpression="codeM" />
                                    <asp:BoundField DataField="nbrFois" HeaderText="Posologie" SortExpression="Nbrfois" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                    <asp:BoundField DataField="quant" HeaderText="Quantite" SortExpression="quant" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                                    <asp:BoundField DataField="form" HeaderText="Form" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />
                                     <asp:BoundField DataField="datecreated" HeaderText="creation" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />

                                </Columns>

                            </asp:GridView>
                        </div>
                        </div>
                    </div>
                </div><!--end mail-list-->
                     <div class="mail_list">
                <div class="left">
                    <i class="fa fa-user-md"></i>
                </div>
                <div class="right">
                    <div class="form-group row">
                        <div class="col-md-8 col-sm-8 offset-4">
                        <div class="col-md-4 col-sm-4">
                            <label >Prestataire: </label>
                            <asp:Label ID="lblnomcomplet" runat="server" Text="complet"></asp:Label>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <label>Specialisation: </label>
                            <asp:Label ID="lblspecial" runat="server" Text="complet"></asp:Label>
                        </div>
                            </div>
                        </div>
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
          <div class="pull-right no-print">
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

        function Printt() {
            var divcontents = document.getElementById('printttdiv').innerHTML;
            var rada = document.getElementById('fieldPdf').innerHTML;

            document.getElementById('printttdiv').innerHTML = rada;
            window.print();
            document.getElementById('printttdiv').innerHTML = divcontents;
                    
        }
    </script>
    
</body>
</html>

