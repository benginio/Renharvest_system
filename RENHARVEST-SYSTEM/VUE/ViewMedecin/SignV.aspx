<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignV.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.SignV" %>

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
     <style type="text/css">
      /*.page{
        display: none;
      }
      #home{
        display: block;
      }*/
      .pag{
        display: none;
      }
      #profilS{
        display: block;
      }
    </style>
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
        <div class="right_col" role="main" id="Profil">{

          
          <div class="">
            <div class="page-title"><br/>
              <div class="title_left">
                    <h5><span><i class="fa fa-user"></i></span>       
                        <asp:Label ID="lnom" runat="server" Text=""></asp:Label> 
                        <asp:Label ID="lprenom" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lage" runat="server" Text=""></asp:Label>
                    </h5>
              </div>   <!--end title-left-->
                  <div class="pull-right">
                     <asp:LinkButton ID="btnliste" runat="server" class="btn btn-sm btn-pam" OnClick="btnliste_Click"><i class="fa fa-mail-reply-all"></i> Liste P</asp:LinkButton>
                 </div>
            </div><br/> <!--end page-title-->

             <div class="row">
              
               <div class="col-md-12 col-sm-12  ">
                <div class="x_panel">
                  <div class="x_content">
                    <ul class="nav nav-tabs bar_tabs" id="myTab" role="tablist">
                      <li class="nav-item">
                        <a class="nav-link" id="home-tab" onclick="viewprof8()"  href="AjouterConsultation1.aspx" role="tab"  aria-selected="true"><span><i class="fa fa-stethoscope"></i></span> Consultation</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" id="contact-tab" onclick="viewprof2()" href="Prescription.aspx" role="tab"  aria-selected="false" ><span><i class="fa fa-file-text"></i></span> Ordonance</a>
                      </li>
                         <li class="nav-item">
                        <a class="nav-link" id="profile-tab" onclick="viewprof()" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false"><span><i class="fa fa-exclamation-circle"></i></span> Info</a>
                      </li>
                         <li class="nav-item">
                        <a class="nav-link" id="profile-T" onclick="viewprof3()" data-toggle="tab" href="#profileT" role="tab" aria-controls="profileT" aria-selected="false"><span><i class="fa fa-eyedropper"></i></span> Traitement</a>
                      </li>
                        <li class="nav-item">
                        <a class="nav-link active" id="profile-S" onclick="viewprof4()" data-toggle="tab" href="#profileS" role="tab" aria-controls="profileS" aria-selected="false"><span><i class="fa fa-stethoscope"></i></span> S. Vitaux</a>
                      </li>
                    </ul>
                    <div class="tab-content" id="myTabContent">
                      
                     
                       <div class="tab-pane fade pag" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                           <asp:UpdatePanel runat="server"><ContentTemplate>
                           <div class="col-md-12 col-sm-12">
                                     <div class="x_content">
                              <ul class="list-unstyled timeline">
                                <li>
                                  <div class="block">
                                    <div class="tags">
                                      <a href="#" class="tag">
                                        <span>Info Personnelle</span>
                                      </a>
                                    </div>
                                    <div class="block_content">
                                        <h2 class="title">
                                          <b>Information Personnelle</b>
                                      </h2>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6">
                                                <h5>
                                                <strong>
                                                <asp:Label ID="lblcode1" runat="server" Text="Code Patient:      "></asp:Label>
                                                    <asp:Label ID="lblcode" runat="server" Text=""></asp:Label>
                                                    </h5>
                                                 </strong>
                                            </div>
                                            
                                            <div class="col-md-4 col-sm-4">
                                                <h5>
                                                <b>  <asp:Label ID="Label4" runat="server" Text="Age:        "></asp:Label></b>
                                                 <asp:Label ID="lblage" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6">
                                                <h5>
                                              <b>  <asp:Label ID="lblnom1" runat="server" Text="Nom:         "></asp:Label></b>
                                                <asp:Label ID="lblnom" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="col-md-4 col-sm-4">
                                                <h5>
                                                <b>  <asp:Label ID="lblprenom1" runat="server" Text="Prenom:         "></asp:Label></b>
                                                <asp:Label ID="lblprenom" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6">
                                                <h5>
                                              <b>  <asp:Label ID="Label5" runat="server" Text="Sexe:         "></asp:Label></b>
                                                <asp:Label ID="lblsexe" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="col-md-4 col-sm-4">
                                                <h5>
                                                <b>  <asp:Label ID="Label7" runat="server" Text="Date Naissance:         "></asp:Label></b>
                                                <asp:Label ID="lbldatenaiss" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                        </div>
                                         <div class="row">
                                            <div class="col-md-6 col-sm-6">
                                                <h5>
                                              <b>  <asp:Label ID="Label6" runat="server" Text="Matricule:       "></asp:Label></b>
                                                <asp:Label ID="lblmatricule" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="col-md-4 col-sm-4">
                                                <h5>
                                                <b>  <asp:Label ID="Label9" runat="server" Text="Profession:  "></asp:Label></b>
                                                <asp:Label ID="lbljob" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6">
                                                <h5>
                                              <b>  <asp:Label ID="Label8" runat="server" Text="Groupe Sanguin:   "></asp:Label></b>
                                                <asp:Label ID="lblgps" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="col-md-4 col-sm-4">
                                                <h5>
                                                <b>  <asp:Label ID="Label11" runat="server" Text="Personne responsable       "></asp:Label></b>
                                                <asp:Label ID="lblpersR" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6">
                                                <h5>
                                              <b>  <asp:Label ID="Label10" runat="server" Text="Lien A personne responsable:        "></asp:Label></b>
                                                <asp:Label ID="lbllienR" runat="server" Text=""></asp:Label>
                                                    </h5>
                                            </div>
                                        </div>

                                      
                                     
                                    </div>
                                  </div>
                                </li>
                                <li>
                                  <div class="block">
                                    <div class="tags">
                                      <a href="#" class="tag">
                                        <span>Coordonnees</span>
                                      </a>
                                    </div>
                                    <div class="block_content">
                                        <h2 class="title">
                                          <b>Coordonnees</b>
                                      </h2>
                                        <div class="row">

                                            <div class="col-md-6 col-sm-6">
                                                <h5>
                                              <b>  <asp:Label ID="Label12" runat="server" Text="Adresse:        "></asp:Label></b>
                                                <asp:Label ID="lbladresse" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="col-md-4 col-sm-4">
                                                <h5>
                                                <b>  <asp:Label ID="Label14" runat="server" Text="Telephone:        "></asp:Label></b>
                                                <asp:Label ID="lblphone" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6">
                                                <h5>
                                              <b>  <asp:Label ID="Label13" runat="server" Text="Email:      "></asp:Label></b>
                                                <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="col-md-4 col-sm-4">
                                                <h5>
                                                <b>  <asp:Label ID="Label16" runat="server" Text="Date Creation:        "></asp:Label></b>
                                                <asp:Label ID="lbldatecreated" runat="server" Text=""></asp:Label>
                                                    </h5>
                                            </div>
                                        </div>
                                     

                                    </div>
                                  </div>
                                </li>
                              </ul>

                            </div>
                               </div>
                               </ContentTemplate></asp:UpdatePanel>
                      </div><!--end profile-->

                         <div class="tab-pane fade show active" id="profileS" role="tabpanel" aria-labelledby="profile-S">
                                   <div class="pag" id="profilS">
                                       <asp:UpdatePanel runat="server"><ContentTemplate>
                                           <div class="page-title">
                                  <div class="pull-right">
                                  <asp:LinkButton ID="listeprescp" runat="server" class="btn btn-sm btn-success" OnClientClick="viewprof()"><i class="fa fa-list-ul"></i> Ajouter</asp:LinkButton>

                                 </div>
                            </div> <!--end page-title-->
                                        <div class="table-responsive">
                       <asp:GridView ID="magridSign" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codesigneV" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                            <Columns>  
                                            <asp:BoundField DataField="codesigneV" HeaderText="code" ReadOnly="True" SortExpression="code" />  
                                            <asp:BoundField DataField="codePatient" HeaderText="codePatient" SortExpression="codeP" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                            <asp:BoundField DataField="poids" HeaderText="Motif" SortExpression="Prenom" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="Temperature" HeaderText="temp" SortExpression="Sexe" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="tensionA" HeaderText="TA" SortExpression="TA" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                            <asp:BoundField DataField="taille" HeaderText="taille" SortExpression="taille" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                            <asp:BoundField DataField="createdby" HeaderText="createdby" SortExpression="Telephone" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                            <asp:BoundField DataField="datecreated" HeaderText="datecreated" SortExpression="Telephone" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" /> 
                                            <asp:TemplateField HeaderText="-->">                       
                                           <ItemTemplate>                            
                                               <asp:LinkButton ID="btnbul" runat="server" Height="30px" CssClass="btn btn-success menu "  OnClientClick="viewprof\()" ><span class="me-2"><i class="fa fa-eye"></i></span></asp:LinkButton> 
                                           </ItemTemplate>                         
                   </asp:TemplateField>
                             </Columns> 

                        </asp:GridView>
                                   </div>
                                        </ContentTemplate></asp:UpdatePanel>
                                       </div>
                                        
                                        <div class="x_content pag" id="listpresc1">
                                          <asp:UpdatePanel runat="server"><ContentTemplate>
                                              <div class="page-title">
                                  <div class="pull-right">
                                  <asp:LinkButton ID="btnretour" runat="server" class="btn btn-sm btn-pam" OnClick="btnretour_Click"><i class="fa fa-mail-reply"></i>Retour</asp:LinkButton>

                                 </div>
                            </div><!--end page-title-->
                            <div class="form-group row">
                                      <div class="col-md-8 col-sm-8 offset-2">
                                        <label for="inputname">Poids*</label>
                                          <asp:TextBox ID="tpoid" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                    </div>

                                        <div class="form-group row">
                                                    <div class="col-md-8 col-sm-8 offset-2">
                                                      <label for="inputname">Temprature*</label>
                                                        <asp:TextBox ID="ttemp" runat="server" class="form-control"  required='required'></asp:TextBox>
                                                    </div>
                                          </div>

                                        <div class="form-group row">
                                                <div class="col-md-8 col-sm-8 offset-2">
                                                  <label for="inputname">Tension Aterielle.*</label>
                                                    <asp:TextBox ID="tta" runat="server" class="form-control" ></asp:TextBox>
                                                </div>
                                        </div>
                                         <div class="form-group row">
                                                <div class="col-md-8 col-sm-8 offset-2">
                                                  <label for="inputname">Taille*</label>
                                                    <asp:TextBox ID="ttaille" runat="server" class="form-control" ></asp:TextBox>
                                                </div>
                                        </div>
                                        <div class="form-group row">
                                           <div class="col-md-8 col-sm-8 offset-2">
                                       <asp:LinkButton ID="btnsavesign" class="btn btn-pam" runat="server" OnClick="btnsavesign_Click" >Valider</asp:LinkButton>
                                        </div>
                                            </div>
                                
                              </ContentTemplate></asp:UpdatePanel>
                         </div>
                                       
                              
                      </div><!--end contact-->

                        

                    </div>
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

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    <script type="text/javascript">
      function viewprof() {
          document.getElementById('profilS').style.display = 'none';
          document.getElementById('listpresc1').style.display = 'block';
          

        }
        function viewprof1() {
            document.getElementById('profilS').style.display = 'none';
            document.getElementById('listpresc1').style.display = 'none';
            document.getElementById('profile').style.display = 'block';

        }
        function viewprof2() {
            document.getElementById('listpresc1').style.display = 'none';
            document.getElementById('profile').style.display = 'non';
            document.getElementById('profilS').style.display = 'block';

        }
    </script>
    
</body>
</html>


