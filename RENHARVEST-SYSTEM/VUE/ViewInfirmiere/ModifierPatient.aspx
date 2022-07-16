<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifierPatient.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewInfirmiere.ModifierPatient" %>

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
    <script src="../build/js/sweetalert2.min.js"></script>
    <!-- jQuery custom content scroller -->
    <link href="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet" />
    <link href="../build/css/sweetalert2.min.css" rel="stylesheet" />
      <script type="text/javascript" src="../build/js/sweetalert2.js"></script>
     <!--pop for validation-->
    <link href="../build/css/bootstrap-4.min.css" rel="stylesheet">
    <!-- Custom Theme Style -->
    <link href="../build/css/custom.css" rel="stylesheet">
    <style type="text/css">
      .page{
        display: none;
      }
      #liste{
        display: block;
      }
    </style>
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
                  <li><a><i class="fa fa-stethoscope"></i> Signe Vitaux <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="AjouterSigneV.aspx">Ajouter</a></li>
                      <li><a href="ListerSigneV">Lister</a></li>
                      
                    </ul>
                  </li>
                 
                  
                </ul>
              </div><!--menu-section-->
             

            </div>
            <!-- /sidebar menu -->

                        <!-- /menu footer buttons -->
                        <div class="sidebar-footer hidden-small">

                           <%-- <a data-toggle="tooltip" data-placement="top" title="FullScreen">
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
                                       <%-- <a class="dropdown-item" href="#"> Profile</a>--%>
                                         <asp:LinkButton ID="btnlogout" runat="server" class="dropdown-item" OnClick="btnlogout_Click"><i class="fa fa-sign-out pull-right"></i> Log Out</asp:LinkButton>
                                    </div>
                                </li>

                            </ul>
                        </nav>
                    </div>
                </div>
                <!-- /top navigation --><br />
                

             <!-- page content -->
                <div class="right_col" role="main" id="liste">
                     <asp:UpdatePanel runat="server" ID="update1"><ContentTemplate>
                    <div class="">

                        <div class="page-title">
                            <div class="title_left">
                                <br />
                                <h5> Rechercher Patient |</h5>
                            </div>
                             <div class="title_right">
							<div class="col-md-8 col-sm-8 form-group  top_search"><br />
								<div class="input-group">
                                    <asp:TextBox ID="tsearch" runat="server" class="form-control" Text="Recherche..."></asp:TextBox>
									<span class="input-group-btn">
                                        <asp:LinkButton ID="tbnsearch" runat="server" class="btn btn-pam" OnClick="tbnsearch_Click">
                                            <span><i class="fa fa-search"></i></span>
                                        </asp:LinkButton>
									</span>
								</div>
							</div>
                                 <div class="col-md-4 col-sm-4 form-group"><br />
                                 <h6>Filter  <asp:DropDownList ID="DDtrier" runat="server" ForeColor="#0D5B86" AutoPostBack="true">
                                    <asp:ListItem>Prenom</asp:ListItem>
                                    <asp:ListItem>Nom</asp:ListItem>
                                    <asp:ListItem>Matricule</asp:ListItem>
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
                                    <asp:LinkButton ID="btnbul" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btnbul_Click" OnClientClick="viewprof()" ><span class="me-2"><i class="fa fa-check-square"></i></span></asp:LinkButton> 
                                </ItemTemplate>                         
                             </asp:TemplateField>
                                <asp:BoundField DataField="codepers" HeaderText="code" ReadOnly="True" SortExpression="codePatient" />  
                                <asp:BoundField DataField="nomP" HeaderText="Nom" SortExpression="Nom" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="prenomP" HeaderText="Prenom" SortExpression="Prenom" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="sexe" HeaderText="Sexe" SortExpression="Sexe" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="dateNaiss" HeaderText="Date_Naiss" SortExpression="Date Naissance" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="adresse" HeaderText="Addresse" SortExpression="Adresse" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="telephone" HeaderText="Telephone" SortExpression="Telephone" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="Email" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="matricule" HeaderText="matricule" SortExpression="matricule" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                         
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
                
                <!-- page content -->
        <div class="right_col page" role="main" id="edit">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1"><ContentTemplate>
          <div class="">
             <div class="page-title">
              <div class="title_left">
                 <h5> Modifier Patient |</h5>
              </div>   
                  <div class="pull-right">
                     <asp:LinkButton ID="btnliste" runat="server" class="btn btn-sm btn-pam" OnClick="btnliste_Click"><i class="fa fa-list-ul"></i> Liste</asp:LinkButton>
                 </div>
            </div>

            <div class="row">
              
                <div class="x_panel col-md-12" style="background: url('../build/images/bgform3.png');">
                    <div class="form-group row">
                        <div class="col-md-4 col-sm-4">
                            <h5><span><i class="fa fa-user"></i></span>       
                            <asp:Label ID="Labe1" runat="server" Text=""></asp:Label> 
                             <asp:Label ID="Label2" runat="server" Text=""></asp:Label></h5>
                            </div>
                      <div class="col-md-3 col-sm-3">
                           <h5><strong>Code:</strong> 
                           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </h5>
                          
                        </div> 
                        </div>
                  <div class="x_content">
                    <div class="form-horizontal form-label-left">
                      <div class="form-group row">
                        <div class="col-sm-4 col-md-4">
                        <label for="firstName" class="form-label">Nom</label>
                        <asp:TextBox ID="tnomp" class="form-control" placeholder="" runat="server"></asp:TextBox>
                        <span id="nom_ma"></span>
                        </div>
                       
                          <div class="col-sm-4 col-md-4">
                            <label for="LastName" class="form-label">Prenom</label>
                              <asp:TextBox ID="tprenomp" class="form-control" placeholder="" runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="tdatenaiss" class="date-picker form-control" placeholder="dd-mm-yyyy" type="text"  onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'" onmouseout="timeFunctionLong(this)" runat="server"></asp:TextBox>
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
                    <div class="form-horizontal form-label-left">
                      <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-5">
                            <asp:Button ID="btnvalider" class="btn btn-pam" runat="server" Text="Modifier" OnClientClick="valide()" OnClick="btnvalider_Click" />
                            <asp:Button ID="btnannuler" class="btn btn-default" BorderColor="#29458D" OnClick="btnannuler_Click" runat="server" Text="Annuler" />

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
     <!-- jquery.inputmask -->
    <script src="../vendors/jquery.inputmask/dist/min/jquery.inputmask.bundle.min.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- jQuery custom content scroller -->
    <script src="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js"></script>

     <script type="text/javascript">
         
         function viewprof() {
             document.getElementById('liste').style.display = 'none';

             document.getElementById('edit').style.display = 'block';

         }
         function viewprof1() {
             document.getElementById('liste').style.display = 'block';

             document.getElementById('edit').style.display = 'none';

         }

         function valide() {

             var nom_v = /^[a-zA-Z][a-z]+([-'\s][a-zA-ZE][a-zei]+)?/;
             var prenom_v = /^[a-zA-ZIEe][a-ze]+([-'\s][a-zA-ZE][a-zei]+)?/;
             var email_v = /^([a-z0-9._-]+)@([a-z0-9._-]+)\.([a-z]{2,6})$/;
             var numero_v = /^[0-9]{4,}$/;
             var job_v = /^[a-zA-Z][a-z]+([-'\s][a-zA-ZE][a-zei]+)?/;
             var validation = document.getElementById('btnvalider');
             var nom = document.getElementById('tnomp');
             var nom_m = document.getElementById('nom_ma');
             var prenom = document.getElementById('tprenomp');
             var prenom_m = document.getElementById('prenom_ma');
             var sexe = document.getElementById('ddsexe');
             var sexe_m = document.getElementById('sexe_ma');
             var job = document.getElementById('tjob');
             var job_m = document.getElementById('job_ma');
             var date = document.getElementById('tdatenaiss');
             var date_m = document.getElementById('date_ma');
             var email = document.getElementById('temail');
             var email_m = document.getElementById('email_ma');
             var adresse = document.getElementById('tadresse');
             var adress_m = document.getElementById('address_ma');
             var phone = document.getElementById('tphone');
             var phone_m = document.getElementById('phone_ma');
             var matricule = document.getElementById('tmatricule');
             var matri_m = document.getElementById('matri_ma');
             var g_s = document.getElementById('ddg_s');
             var p_respon = document.getElementById('tp_respon');
             var pRes_m = document.getElementById('pRes_ma');




             validation.addEventListener('click', f_valid);

             function f_valid(e) {
                 //nom
                 if (nom.value == '') {
                     e.preventDefault();
                     nom_m.textContent = 'Veuillez saisir le nom svp';
                     nom_m.style.color = 'red';
                     /* nom.style.borderColor = 'red';*/
                 } else if (!nom_v.test(nom.value)) {
                     e.preventDefault();
                     nom_m.textContent = 'Format incorrect';
                     nom_m.style.color = 'orange';
                 } else {
                     nom_m.textContent = '';
                 }
                 nom.addEventListener('change', nomValide);
                 function nomValide(e) {
                     if (nom.value == '') {


                     } else if (!nom_v.test(nom.value)) {
                         nom_m.textContent = 'Format incorrect';
                         nom_m.style.color = 'orange';
                     } else {
                         nom_m.textContent = '';
                     }

                 }

                 //prenom
                 if (prenom.value == "") {
                     e.preventDefault();
                     prenom_m.textContent = 'Veuillez saisir le prenom svp';
                     /*prenom.style.borderColor = 'red';*/
                     prenom_m.style.color = 'red';
                 } else if (!prenom_v.test(prenom.value)) {
                     e.preventDefault();
                     prenom_m.textContent = 'Format incorrect';
                     prenom_m.style.color = 'orange';
                 } else {
                     prenom_m.textContent = '';
                 }
                 prenom.addEventListener('change', nomValidpre);
                 function nomValidpre(e) {
                     if (prenom.value == '') {

                     } else if (!prenom_v.test(prenom.value)) {
                         prenom_m.textContent = 'Format incorrect';
                         prenom_m.style.color = 'orange';
                     } else {
                         prenom_m.textContent = '';
                     }
                 }

                 //sexe
                 if (sexe.value == "--Choisir--") {
                     e.preventDefault();
                     sexe_m.textContent = 'Veuillez selectionner!';
                     /*sexe.style.borderColor = 'red';*/
                     sexe_m.style.color = 'red';
                 } else {
                     sexe_m.textContent = '';
                 }
                 sexe.addEventListener('change', nomValidsex);
                 function nomValidsex(e) {
                     if (sexe.value == "--Choisir--") {
                         sexe_m.textContent = 'Veuillez selectionner!';
                     } else {
                         prenom_m.textContent = '';

                     }

                 }
                 //profession
                 if (job.value == "") {
                     e.preventDefault();
                     job_m.textContent = 'Veuillez saisir la profession svp';
                     /*prenom.style.borderColor = 'red';*/
                     job_m.style.color = 'red';
                 } else if (!job_v.test(job.value)) {
                     e.preventDefault();
                     job_m.textContent = 'Format incorrect';
                     job_m.style.color = 'orange';
                 } else {
                     job_m.textContent = '';
                 }
                 adresse.addEventListener('change', nomValidjob);
                 function nomValidjob(e) {
                     if (!job_v.test(job.value)) {
                         job_m.textContent = 'Format incorrect';
                         job_m.style.color = 'orange';
                     } else {
                         job_m.textContent = '';
                         job_m.style.color = 'green';
                     }

                 }

                 //datenaiss
                 if (date.value == "") {
                     e.preventDefault();
                     date_m.textContent = 'Veuillez saisir la date de naissance!';
                     /*date.style.borderColor = 'red';*/
                     date_m.style.color = 'red';
                 } else {
                     sexe_m.textContent = '';
                 }
                 date.addEventListener('change', nomValiddate);
                 function nomValiddate(e) {
                     if (date.value == "") {
                         date_m.textContent = 'Veuillez saisir la date de naissance!';
                     } else {
                         date_m.textContent = '';
                         /* date_m.style.color = 'green';*/
                     }

                 }

                 //adresse
                 if (adresse.value == "") {
                     e.preventDefault();
                     adress_m.textContent = 'Veuillez saisir ladresse!';
                     /*adresse.style.borderColor = 'red';*/
                     adress_m.style.color = 'red';
                 } else {
                     adress_m.textContent = '';
                 }
                 adresse.addEventListener('change', nomValidadress);
                 function nomValidadress(e) {
                     if (adresse.value == "") {
                         adress_m.textContent = 'Veuillez saisir ladresse!';
                     } else {
                         adress_m.textContent = '';
                         /* adresse_m.style.color = 'green';*/
                     }

                 }

                 //email
                 if (email.value == "") { email_m.textContent = ''; }
                 else {
                     if (!email_v.test(job.value)) {
                         e.preventDefault();
                         email_m.textContent = 'Format incorrect';
                         email_m.style.color = 'orange';
                     } else {
                         email_m.textContent = '';
                     }
                 }
                 email.addEventListener('change', nomValidemail);
                 function nomValidemail(e) {
                     if (email.value == "") { }
                     else {
                         if (!email_v.test(job.value)) {
                             e.preventDefault();
                             email_m.textContent = 'Format incorrect';
                             email_m.style.color = 'orange';
                         } else {
                             email_m.textContent = '';
                         }
                     }

                 }


                 //pers responsable
                 if (p_respon.value == "") { pRes_m.textContent = ''; }
                 else {
                     if (!prenom_v.test(p_respon.value)) {
                         e.preventDefault();
                         pRes_m.textContent = 'Format incorrect';
                         pRes_m.style.color = 'orange';
                     } else {
                         pRes_m.textContent = '';
                     }
                 }
                 prenom.addEventListener('change', nomValidpers);
                 function nomValidpers(e) {
                     if (p_respon.value == "") { }
                     else {
                         if (!prenom_v.test(p_respon.value)) {
                             e.preventDefault();
                             pRes_m.textContent = 'Format incorrect';
                             pRes_m.style.color = 'orange';
                         } else {
                             pRes_m.textContent = '';
                         }
                     }
                 }
                 //phone
                 if (phone.value == "") {
                     e.preventDefault();
                     phone_m.textContent = 'Veuillez saisir le telephone svp';
                     /*prenom.style.borderColor = 'red';*/
                     phone_m.style.color = 'red';
                 } else {
                     phone_m.textContent = '';
                 }
                 prenom.addEventListener('change', nomValidphone);
                 function nomValidphone(e) {
                     if (phone.value == "") {
                         e.preventDefault();
                         phone_m.textContent = 'Veuillez saisir le telephone svp';
                         /*prenom.style.borderColor = 'red';*/
                         phone_m.style.color = 'red';
                     } else {
                         phone_m.textContent = '';
                     }
                 }


             }


         }
     </script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
     
    

</body>
</html>
