<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printpresc.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.printpresc" %>

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
                 
                </ul>
              </nav>
            </div>
          </div>
        <!-- /top navigation -->

        <!-- page content -->
        <div class="right_col" role="main">
          <div class=""><br/><br/>
              <div class="pull-right hidden-print" >
                  <asp:LinkButton ID="btnExportpdf" CssClass="btn btn-default" OnClientClick="Printt()" BorderColor="#29458D" runat="server"><span><i class="fa fa-print"></i></span> Imprimer</asp:LinkButton>
              </div>
              <div class="row">
                <div class="x_panel col-md-8 col-sm-8 offset-1" id="printdiv" runat="server">
              <div class="x_content ">
              <div class="row">
                <div class="col-sm-10 col-md-10 offset-3">
                  <h3>&nbsp;&nbsp; Hopital Double Harvest</h3>
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4 col-md-4">
                  <strong>
                  10, Rue Accul<br/>
                  Roche Blanche<br/>
                  Croix-des-Bouquets
                </strong>
                </div>
                <div class="col-sm-4 col-md-4">
                   <%-- <div class="imgPam">--%>
                        <img src="../build/images/DHLOGO.png" alt="..." style="width:100%; height:auto">
                   <%-- </div>--%>
                </div>
                <div class="col-sm-4 col-md-4">
                  <strong>Tel:</strong> 509 2227-9892<br/>
                  <strong>Email:</strong>doubleharvesthaiti@yahoo.fr

                </div>
              </div>
              <div class="x_title"></div>
              <div class="row">
                <div class="col-sm-8 col-md-8">
                  <label><strong>Patient:</strong></label>
                    <asp:Label ID="tinfopatient" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-4 col-md-4">
                  <label><strong>Date:</strong></label>
                    <asp:Label ID="tdate" runat="server" Text=""></asp:Label>
                </div>
              </div>
              <div class="x_title"></div>
              <div class="row">
               <div class="col-md-6 col-sm-6 offset-2">
                <label><strong>Precaution: </strong> </label>
                   <asp:Label ID="tprevention" runat="server" Text=""></asp:Label>
               </div>
               <div class="col-md-4 col-sm-4">
                <label><strong>Durer: </strong> </label>
                    <asp:Label ID="tdurer" runat="server" Text=""></asp:Label>
               </div>
                      </div>
             <br />
                  <div class="row">
                      <div class="table-responsive">
                            <asp:GridView ID="GridOrdonance" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="nomM" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                                <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                <Columns>
                                    <%--<asp:BoundField DataField="codeMed" HeaderText="codeMedicament" ReadOnly="True" SortExpression="codeM" />--%>
                                    <asp:BoundField DataField="nomM" HeaderText="Nom_Medicament" ReadOnly="True" SortExpression="codeM" />
                                    <asp:BoundField DataField="dosage" HeaderText="Dosage" ReadOnly="True" SortExpression="codeM" />
                                    <asp:BoundField DataField="nbrFois" HeaderText="Posologie" SortExpression="Nbrfois" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                    <asp:BoundField DataField="quant" HeaderText="Quantite" SortExpression="quant" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                                    <asp:BoundField DataField="form" HeaderText="Form" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />
                                     <asp:BoundField DataField="datecreated" HeaderText="creation" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />

                                </Columns>

                            </asp:GridView>
                        </div>

                  </div><br /><br />

              
              <div class="row">
                  <div class="col-sm-3 col-md-3"></div>
                <div class="col-md-4 col-sm-4">
                 <label><strong>Prestataire: </strong> </label>
                    <asp:Label ID="tprestataire" runat="server" Text=""></asp:Label>
                </div>
                  
                <div class="col-md-3 col-sm-3">
                 <label><strong>Specialite: </strong> </label> 
                    <asp:Label ID="tspecial" runat="server" Text=""></asp:Label>
                </div>
                   </div>
                  <div class="x_title"></div>
                  <div class="row">
                       <div class="col-sm-4 col-md-4"></div>
                      <div class="col-sm-6 col-md-6">
                  <strong>
                  10, Rue Accul, Roche Blanche Croix-des-Bouquets<br />
                </strong>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Tel:</strong> 509 2227-9892<br/>
                </div>
                  </div>

      </div>
                    </div>
                  </div>
                    <div class=" row offset-4">
                      <asp:LinkButton ID="btninfocons" CssClass="btn btn-pam" OnClick="btninfocons_Click" runat="server"><span><i class="fa fa-file"></i></span> Dossier Patient </asp:LinkButton>
                  </div>
              

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
    <script type="text/javascript">

        function Printt() {
            var divcontents = document.getElementById('printttdiv').innerHTML;
            var rada = document.getElementById('printdiv').innerHTML;

            document.getElementById('printttdiv').innerHTML = rada;
            window.print();
            document.getElementById('printttdiv').innerHTML = divcontents;
            //var printWindow = window.open('', 'printdiv', 'height=400, width=600');
            //printWindow.document.write('<html><head><title>RenHarvest-System | TGL</title>');
            //printWindow.document.write('</head><body> ');
            //    printWindow.document.write(divcontents);
            //printWindow.document.write('</body></html> ');
            //printWindow.document.close();

            //printWindow.onload = function(){
            //    printWindow.focus();
            //    printWindow.print();
            //    printWindow.close();
            //};
                    
        }
    </script>
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>

    
</body>
</html>
