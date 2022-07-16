<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DossierPatient.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.DossierPatient" %>

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
    <style type="text/css">
      .page{
        display: none;
      }
      #liste{
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
                <div class="right_col" role="main" id="liste">
                     <asp:UpdatePanel runat="server" ID="update1"><ContentTemplate>
                    <div class="">

                        <div class="page-title">
                            <div class="title_left">
                                <br />
                                <h5> Recherche Patient |</h5>
                            </div>
                             <div class="title_right">
							<div class="col-md-8 col-sm-8 form-group  top_search"><br />
								<div class="input-group">
                                    <asp:TextBox ID="tsearch" runat="server" class="form-control" Text="" placeHolder="Recherche..."></asp:TextBox>
									<span class="input-group-btn">
                                        <asp:LinkButton ID="tbnsearch" runat="server" class="btn btn-pam" OnClick="tbnsearch_Click">
                                            <span><i class="fa fa-search"></i></span>
                                        </asp:LinkButton>
									</span>
								</div>
							</div>
                                 <div class="col-md-4 col-sm-4 form-group"><br />
                                 <h6>Filter  <asp:DropDownList ID="DDtrier" class="form-control" runat="server" ForeColor="#0D5B86" AutoPostBack="true">
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
                                    <asp:LinkButton ID="btnbul" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btnbul_Click" OnClientClick="viewprof()" ><span class="me-2"><i class="fa fa-check-circle"></i></span></asp:LinkButton> 
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
                    </ContentTemplate></asp:UpdatePanel>
                </div>
                <!-- /page content -->

        <!-- page content -->
        <div class="right_col page" role="main" id="edit">
             <asp:UpdatePanel runat="server" ID="UpdatePanel1"><ContentTemplate>
          <div class="">
              <div class="page-title"><br/>
                  <div class="pull-right">
                     <asp:LinkButton ID="btnliste" runat="server" class="btn btn-sm btn-pam" OnClick="btnliste_Click"><i class="fa fa-list-ul"></i>Retour Liste</asp:LinkButton>
                 </div>
            </div><br/>
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
                <div class="col-sm-10 col-md-10 py-2 px-1">
                    <h5>
                     &nbsp;<asp:Label ID="Label1" runat="server" Text="Dossier "></asp:Label>
                     &nbsp; <asp:Label ID="tnomP" runat="server" Text=""></asp:Label>
                      <asp:Label ID="tprenomP" runat="server" Text=""></asp:Label>
                    </h5>
                </div><!--end col-->
                 </div><!--end row-->
                 </div>
                 <div class="pull-right">
                     <div class="col-md-12 col-sm-12 py-2">
                      
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
                         <div class="col-md-4 col-sm-4">
                            <label><b>Lien P responsable:</b></label>
                             <asp:Label ID="tlienrespon" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <label><b>Date_Creation:</b></label>
                              <asp:Label ID="tdatecreation" runat="server" Text=""></asp:Label>
                        </div>
                       
                    </div>
                </div>
                </div><!--end mail-list-->

               <div class="mail_list">
               <div class="row">
               <div class="col-md-12 col-sm-12  ">
                <div class="x_panel">
                  <div class="x_content">
                  
                    <!-- start accordion -->
                    <div class="accordion" id="accordion1" role="tablist" aria-multiselectable="true">
                      <div class="panel">
                        <a class="panel-heading" role="tab" id="headingOne1" data-toggle="collapse" data-parent="#accordion1" href="#collapseOne1" aria-expanded="true" aria-controls="collapseOne">
                          <h4 class="panel-title">Antecedent</h4>
                        </a>
                        <div id="collapseOne1" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                          <div class="panel-body">

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
                          </div><!--panel-body-->
                        </div>
                      </div>
                      <div class="panel">
                        <a class="panel-heading collapsed" role="tab" id="headingTwo1" data-toggle="collapse" data-parent="#accordion1" href="#collapseTwo1" aria-expanded="false" aria-controls="collapseTwo">
                          <h4 class="panel-title">Signe Vitaux</h4>
                        </a>
                        <div id="collapseTwo1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                          <div class="panel-body">
                              <div class="form-group row">
                               <div class="col-md-12 col-sm-12">
                         <div class="table-responsive">
                        <asp:GridView ID="GridSV" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="datecreated" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle  Font-Bold="True" ForeColor="black" />

                            <Columns>  
                                <asp:BoundField DataField="poids" HeaderText="Pds(Kg)" ReadOnly="True" SortExpression="Poids" /> 
                                <asp:BoundField DataField="temperature" HeaderText="Temp(C°)" SortExpression="temp" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="tensionA" HeaderText="TA(mm/Hg)" SortExpression="TA" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="taille" HeaderText="Taille(M)" SortExpression="taille" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="createdby" HeaderText="Creer_Par" SortExpression="CreerPar" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="datecreated" HeaderText="Dcreation" SortExpression="Dcreation" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                 <asp:TemplateField HeaderText="-->">                       
                                <ItemTemplate>                            
                                    <asp:LinkButton ID="btnSV" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btnSV_Click" ><span class="me-2"><i class="fa fa-file-text-o"></i></span></asp:LinkButton> 
                                </ItemTemplate>                         
                             </asp:TemplateField>
                              </Columns> 

                        </asp:GridView>
                                </div>
                    </div><!--end col-->
                                  </div><!--end row-->


                            </div>
                        </div>
                      </div>
                      <div class="panel">
                        <a class="panel-heading collapsed" role="tab" id="headingThree1" data-toggle="collapse" data-parent="#accordion1" href="#collapseThree1" aria-expanded="false" aria-controls="collapseThree">
                          <h4 class="panel-title">Examen</h4>
                        </a>
                        <div id="collapseThree1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                          <div class="panel-body">
                              <div class=" form-group row">
                        <div class="col-md-12 col-sm-12">

                            </div>
                             </div>
                              <div class=" form-group row">
                        <div class="col-md-12 col-sm-12">
                             <div class="table-responsive">
                        <asp:GridView ID="gridexamen" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="datecreated" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle  Font-Bold="True" ForeColor="black" />

                            <Columns>  
                            <asp:BoundField DataField="codePatient" HeaderText="code_patient" ReadOnly="True" SortExpression="codeM" />  
                            <asp:BoundField DataField="descriptionE" HeaderText="Description" SortExpression="Description" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                            <asp:BoundField DataField="resultatE" HeaderText="Resultat" SortExpression="Resultat" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                            <asp:BoundField DataField="datecreated" HeaderText="D_creation" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                             <asp:TemplateField HeaderText="-->">                       
                                <ItemTemplate>                            
                                    <asp:LinkButton ID="btnEx" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btnEx_Click" ><span class="me-2"><i class="fa fa-file-text-o"></i></span></asp:LinkButton> 
                                </ItemTemplate>                         
                             </asp:TemplateField>
                                </Columns> 
                        </asp:GridView>
                                </div>
                        </div><!--end col12-->
                        </div><!--end row-->

                            </div>
                        </div>
                      </div>
                       
                        <div class="panel">
                        <a class="panel-heading collapsed" role="tab" id="headingfive1" data-toggle="collapse" data-parent="#accordion1" href="#collapsefive1" aria-expanded="false" aria-controls="collapsefive">
                          <h4 class="panel-title">Consultation</h4>
                        </a>
                        <div id="collapsefive1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingfive">
                          <div class="panel-body">
                              <div class="x_panel">
                               <div class="row">
                                   <h5>Liste des Consultation</h5>
                               </div>
                                   <div class="table-responsive">
                                <asp:GridView ID="Gridconsultation" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="datecreated" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                                    <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                    <Columns>
                                        <asp:BoundField DataField="age" HeaderText="Age" ReadOnly="True" SortExpression="age" />
                                        <asp:BoundField DataField="motif" HeaderText="Motif" ReadOnly="True" SortExpression="motif" />
                                        <asp:BoundField DataField="signe" HeaderText="signe" ReadOnly="True" SortExpression="signe" />
                                        <asp:BoundField DataField="symptomes" HeaderText="symptomes" ReadOnly="True" SortExpression="symp" />
                                        <asp:BoundField DataField="histoire" HeaderText="Histoire" SortExpression="hist" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                        <asp:BoundField DataField="detail" HeaderText="Diagnostique" SortExpression="diagn" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                                        <asp:BoundField DataField="comment" HeaderText="note" SortExpression="note" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />
                                        <asp:BoundField DataField="datecreated" HeaderText="Date" SortExpression="date" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />
                                        <asp:BoundField DataField="heurecreated" HeaderText="heure" SortExpression="date" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />
                                    <asp:TemplateField HeaderText="-->">                       
                                <ItemTemplate>                            
                                    <asp:LinkButton ID="btnconsultation" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btnconsultation_Click" ><span class="me-2"><i class="fa fa-file-text-o"></i></span></asp:LinkButton> 
                                </ItemTemplate>                         
                             </asp:TemplateField>
                                        </Columns>

                                </asp:GridView>
                            </div>
                                </div>
                          </div>
                        </div>
                      </div>
                        <div class="panel">
                        <a class="panel-heading collapsed" role="tab" id="headingsix1" data-toggle="collapse" data-parent="#accordion1" href="#collapsesix1" aria-expanded="false" aria-controls="collapsesix">
                          <h4 class="panel-title">Traitement</h4>
                        </a>
                        <div id="collapsesix1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingsix">
                          <div class="panel-body">
                              <div class="x_panel">
                               <div class="row">
                                   <h5>Liste Traitement</h5>
                               </div>
                                   <div class="table-responsive">
                                <asp:GridView ID="Gridtraitement" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="datecreated" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                                    <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                    <Columns>
                                        <asp:BoundField DataField="numT" HeaderText="code" ReadOnly="True" SortExpression="signe" />
                                        <asp:BoundField DataField="prevention" HeaderText="Precaution" ReadOnly="True" SortExpression="symp" />
                                        <asp:BoundField DataField="durer" HeaderText="Durer" SortExpression="hist" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                        <asp:BoundField DataField="datecreated" HeaderText="Date" SortExpression="date" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />
                                    <asp:TemplateField HeaderText="-->">                       
                                <ItemTemplate>                            
                                    <asp:LinkButton ID="btntraitement" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btntraitement_Click" ><span class="me-2"><i class="fa fa-file-text-o"></i></span></asp:LinkButton> 
                                </ItemTemplate>                         
                             </asp:TemplateField>
                                        </Columns>

                                </asp:GridView>
                            </div>
                                </div>
                            </div>
                        </div>
                      </div>
                        <div class="panel">
                        <a class="panel-heading collapsed" role="tab" id="headingseven1" data-toggle="collapse" data-parent="#accordion1" href="#collapseseven1" aria-expanded="false" aria-controls="collapseseven">
                          <h4 class="panel-title">Ordonnance</h4>
                        </a>
                        <div id="collapseseven1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingseven">
                          <div class="panel-body">
                           <div class="x_panel">
                               <div class="row">
                                   <h5>Liste des Ordonnance</h5>
                               </div>
                               <div class="row">
                                   <div class="table-responsive">
                        <asp:GridView ID="gridprescription" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="datecreated" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle BackColor="#34495E" Font-Bold="True" ForeColor="White" />

                            <Columns>
                                    <asp:BoundField DataField="codeMed" HeaderText="codeMedicament" ReadOnly="True" SortExpression="codeM" />
                                    <asp:BoundField DataField="nomM" HeaderText="Nom_Medicament" ReadOnly="True" SortExpression="codeM" />
                                    <asp:BoundField DataField="dosage" HeaderText="Dosage" ReadOnly="True" SortExpression="codeM" />
                                    <asp:BoundField DataField="nbrFois" HeaderText="Posologie" SortExpression="Nbrfois" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                    <asp:BoundField DataField="quant" HeaderText="Quantite" SortExpression="quant" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                                    <asp:BoundField DataField="form" HeaderText="Form" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />
                                     <asp:BoundField DataField="datecreated" HeaderText="creation" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />
                                 <asp:TemplateField HeaderText="-->">                       
                                <ItemTemplate>                            
                                    <asp:LinkButton ID="btnordo" runat="server" Height="30px" CssClass="btn btn-pam menu " OnClick="btnordo_Click" ><span class="me-2"><i class="fa fa-file-text-o"></i></span></asp:LinkButton> 
                                </ItemTemplate>                         
                             </asp:TemplateField>
                           </Columns>

                        </asp:GridView>
                        
                        </div>
                               </div>
                           </div>
                              </div>
                        </div>
                      </div>
                         <div class="panel">
                        <a class="panel-heading collapsed" role="tab" id="headingfour1" data-toggle="collapse" data-parent="#accordion1" href="#collapsefour1" aria-expanded="false" aria-controls="collapsefour">
                          <h4 class="panel-title">Rendez-vous</h4>
                        </a>
                        <div id="collapsefour1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingfour">
                          <div class="panel-body">
                           <div class="x_panel">
                               <div class="row">
                                   <h5>Liste des Rendez-vous</h5>
                               </div>
                               <div class="row">
                                   <div class="table-responsive">
                        <asp:GridView ID="gridlistRDV" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="nomP" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle BackColor="#34495E" Font-Bold="True" ForeColor="White" />

                            <Columns>  
                                <asp:BoundField DataField="nomP" HeaderText="Nom" SortExpression="Nom" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="prenomP" HeaderText="Prenom" SortExpression="Prenom" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="adresse" HeaderText="Adresse" SortExpression="Adresse" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="sexe" HeaderText="Sexe" SortExpression="Sexe" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="motifRDV" HeaderText="Motif" SortExpression="Motif" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="daterdv" HeaderText="date" SortExpression="date" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="heure" HeaderText="heure" SortExpression="heure" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                 <asp:BoundField DataField="createdby" HeaderText="Creer_Par" SortExpression="Par" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />                       
                                <asp:BoundField DataField="datecreated" HeaderText="Dcreation" SortExpression="date" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                        
                             </Columns> 

                        </asp:GridView>
                        
                        </div>
                               </div>
                           </div>
                              </div>
                        </div>
                      </div>
                        
                    </div>
                    <!-- end of accordion -->
                    
                    </div>
                  </div>
                </div><!--end col-->
              </div><!--end row-->


                
               </div><!--end mail-list-->
                
                     <div class="mail_list">
                <div class="left">
                    <i class="fa fa-user-md"></i>
                </div>
                <div class="right">
                    <div class="form-group row">
                        <div class="col-md-8 col-sm-8 offset-4">
                        <div class="col-md-4 col-sm-4">
                            <label>Prestataire: </label>
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
                 </ContentTemplate></asp:UpdatePanel>
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
             document.getElementById('liste').style.display = 'none';

             document.getElementById('edit').style.display = 'block';

         }
     </script>
    
</body>
</html>
