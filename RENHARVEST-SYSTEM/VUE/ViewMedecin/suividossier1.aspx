<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="suividossier1.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.ViewMedecin.suividossier1" %>

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
      .page{
        display: none;
      }
      .pag{
          display: none;
      }
      #info{
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
        <div class="right_col" role="main" id="Profil">

          
          <div class="">
            <div class="page-title"><br/>
              <div class="title_left">
                    <h5>Consultation de&nbsp;&nbsp;<span><i class="fa fa-user"></i></span>       
                        <asp:Label ID="lnom" runat="server" Text=""></asp:Label> 
                        <asp:Label ID="lprenom" runat="server" Text=""></asp:Label>
                      &nbsp;  <asp:Label ID="lage" runat="server" Text=""></asp:Label>
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
                        <a class="nav-link active" id="info-tab" onclick="viewprof1()" data-toggle="tab" href="#info" role="tab" aria-controls="info" aria-selected="true"><span><i class="fa fa-exclamation-circle"></i></span> Informations</a>
                      </li>
                       <li class="nav-item">
                        <a class="nav-link" id="antecedent-tab" onclick="viewprof2()" data-toggle="tab" href="#antecedent" role="tab" aria-controls="antecedent" aria-selected="false" ><span><i class="fa fa-code-fork"></i></span> Antecedents</a>
                      </li>
                         <li class="nav-item">
                        <a class="nav-link" id="consultation-tab" onclick="viewprof3()" data-toggle="tab" href="#consultation" role="tab" aria-controls="consultation" aria-selected="false"><span><i class="fa fa-stethoscope"></i></span> Consultation</a>
                      </li>
                         <li class="nav-item">
                        <a class="nav-link" id="ordonance-tab" onclick="viewprof4()" data-toggle="tab" href="#ordonance" role="tab" aria-controls="ordonance" aria-selected="false"><span><i class="fa fa-file-text"></i></span> Ordonnance</a>
                      </li>
                    </ul>
                    <div class="tab-content" id="myTabContent">
                      <div class="tab-pane fade show active" id="info" role="tabpanel" aria-labelledby="info-tab">
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
                      </div><!--end information-->

                        <div class="tab-pane fade page" id="antecedent" role="tabpanel" aria-labelledby="antecedent-tab">
                           
                             <div class="col-md-12 col-sm-12  ">
               
                          <div class="x_content">

                            <div class="col-md-3 col-sm-3">
                              <!-- required for floating -->
                              <!-- Nav tabs -->
                              <div class="nav nav-tabs flex-column  bar_tabs" id="Ant-tab" role="tablist" aria-orientation="vertical">
                                <a class="nav-link active" id="Ant-home-tab" onclick="Ant1()" data-toggle="pill" href="#Ant-home" role="tab" aria-controls="Ant-home" aria-selected="true">Familliaux</a>
                                <a class="nav-link" id="Ant-profile-tab" onclick="Ant2()" data-toggle="pill" href="#Ant-profile" role="tab" aria-controls="Ant-profile" aria-selected="false">Personnels</a>
                                <a class="nav-link" id="Ant-messages-tab" onclick="Ant3()" data-toggle="pill" href="#Ant-messages" role="tab" aria-controls="Ant-messages" aria-selected="false">Chirurgicaux</a>
                                <a class="nav-link" id="Ant-settings-tab" onclick="Ant4()" data-toggle="pill" href="#Ant-settings" role="tab" aria-controls="Ant-settings" aria-selected="false">Habitudes</a>
                              </div>
            
                            </div>

                            <div class="col-md-9 col-sm-9"> <!-- Tab panes -->
                     
                     
                              <div class="tab-content " id="Ant-tabContent">
                           
                                <div class="tab-pane fade show active" id="Ant-home" role="tabpanel" aria-labelledby="Ant-home-tab">
                                     <asp:UpdatePanel runat="server"><ContentTemplate>
                                          <div class="profile_title">
                                      <h2 class="offset-1">Antecedent Famillaux</h2>
                                      </div>
                                   <div class="row">
                                  <div class="col-md-4 col-sm-4 ">
                                      <label for="inputname">Maladie</label>
                                      <asp:DropDownList ID="ddAntmalad" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddAntmalad_SelectedIndexChanged" AutoPostBack="true">
                                          
                                          <asp:ListItem> </asp:ListItem>
                                          <asp:ListItem>HTA</asp:ListItem>
                                           <asp:ListItem>Asthme</asp:ListItem>
                                           <asp:ListItem>Diabete</asp:ListItem>
                                           <asp:ListItem>Anemie falc</asp:ListItem>
                                           <asp:ListItem >Allergies</asp:ListItem>
                                      </asp:DropDownList>
                                      <asp:Label ID="test" runat="server" Text=""></asp:Label>
                                      </div>
                                  <div class="col-md-4 col-sm-4 pag" id="Allerg">
                                      <label for="inputname">type Allergie</label>
                                       <asp:TextBox ID="tallergie" runat="server" class="form-control" ></asp:TextBox>
                                      </div>
                                       <div class="col-md-2 col-sm-2 py-4">
                                           <asp:LinkButton ID="btnantfamil" CssClass="btn btn-success" runat="server" OnClick="btnantfamil_Click"><span><i class="fa fa-plus-circle"></i></span> Ajouter</asp:LinkButton>
                                      </div>
                                     </div><!--end row-->
                                 
                                     <div class="form-group row">
                                          <div class="table-responsive">
                                           <asp:GridView ID="Gridantfamille" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="descriptionAnt" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                                                <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                                <Columns>  
                                                    <asp:BoundField DataField="descriptionAnt" HeaderText="Ant_famille" ReadOnly="True" SortExpression="nom" /> 
                                                    <asp:BoundField DataField="datecreated" HeaderText="datecreation" ReadOnly="True" SortExpression="date" /> 
                                                    <asp:TemplateField HeaderText="Act">                       
                                                    <ItemTemplate>                            
                                                        <asp:LinkButton ID="btnremoveAnt" runat="server" Height="30px" CssClass="btn btn-danger menu " OnClick="btnremoveAnt_Click" ><span class="me-2"><i class="fa fa-trash"></i></span></asp:LinkButton> 
                                                    </ItemTemplate>                         
                                       </asp:TemplateField>
                                                 </Columns> 

                                            </asp:GridView>
                                                 </div>
                                            </div><!--end row-->

                                    </ContentTemplate></asp:UpdatePanel>
                                </div><!--end Familliale-->
                           
                                <div class="tab-pane fade pag" id="Ant-profile" role="tabpanel" aria-labelledby="Ant-profile-tab">
                                      <asp:UpdatePanel runat="server"><ContentTemplate>
                                           <div class="profile_title">
                                      <h2 class="offset-1">Antecedent Famillaux</h2>
                                      </div>
                                   <div class="row">
                                  <div class="col-md-4 col-sm-4 ">
                                      <label for="inputname">Maladie</label>
                                      <asp:DropDownList ID="ddantpers" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddantpers_SelectedIndexChanged" AutoPostBack="true">
                                          
                                          <asp:ListItem> </asp:ListItem>
                                          <asp:ListItem>HTA</asp:ListItem>
                                           <asp:ListItem>Asthme</asp:ListItem>
                                           <asp:ListItem>Diabete</asp:ListItem>
                                           <asp:ListItem>Anemie falc</asp:ListItem>
                                           <asp:ListItem >Allergies</asp:ListItem>
                                           <asp:ListItem >IST</asp:ListItem>
                                      </asp:DropDownList>
                                      <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                      </div>
                                  <div class="col-md-4 col-sm-4 pag" id="Allerg1">
                                      <label for="inputname">type Allergie</label>
                                       <asp:TextBox ID="tallergie1" runat="server" class="form-control" ></asp:TextBox>
                                      </div>
                                        <div class="col-md-4 col-sm-4 pag" id="Ist">
                                      <label for="inputname">type IST</label>
                                       <asp:TextBox ID="tist" runat="server" class="form-control" ></asp:TextBox>
                                      </div>
                                       <div class="col-md-2 col-sm-2 py-4">
                                           <asp:LinkButton ID="btnantpers" CssClass="btn btn-success" runat="server" OnClick="btnantpers_Click"><span><i class="fa fa-plus-circle"></i></span> Ajouter</asp:LinkButton>
                                      </div>
                                     </div><!--end row-->
                                 
                                     <div class="form-group row">
                                          <div class="table-responsive">
                                           <asp:GridView ID="Gridpers" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="descriptionAnt" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                                                <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                                <Columns>  
                                                    <asp:BoundField DataField="descriptionAnt" HeaderText="Ant_famille" ReadOnly="True" SortExpression="nom" /> 
                                                    <asp:BoundField DataField="datecreated" HeaderText="datecreation" ReadOnly="True" SortExpression="date" /> 
                                                    <asp:TemplateField HeaderText="Act">                       
                                                    <ItemTemplate>                            
                                                        <asp:LinkButton ID="btnremoveAntpers" runat="server" Height="30px" CssClass="btn btn-danger menu " OnClick="btnremoveAntpers_Click" ><span class="me-2"><i class="fa fa-trash"></i></span></asp:LinkButton> 
                                                    </ItemTemplate>                         
                                       </asp:TemplateField>
                                                 </Columns> 

                                            </asp:GridView>
                                                 </div>
                                            </div><!--end row-->
                                       </ContentTemplate></asp:UpdatePanel>
                                </div><!--end Personnel-->
                                <div class="tab-pane fade pag" id="Ant-messages" role="tabpanel" aria-labelledby="Ant-messages-tab">
                                     <asp:UpdatePanel runat="server"><ContentTemplate>
                                          <div class="profile_title">
                                      <h2 class="offset-1">Antecedent Chirurgicaux</h2>
                                      </div>
                                   <div class="row">
                                  <div class="col-md-4 col-sm-4 ">
                                       <label for="inputname">type Operation</label>
                                       <asp:TextBox ID="ttypeoperation" runat="server" class="form-control" ></asp:TextBox>
                                    </div>
                                  <div class="col-md-4 col-sm-4 " >
                                      <label>Date Operation</label>
                                    <asp:TextBox ID="tdateoperation" class="date-picker form-control" placeholder="dd-mm-yyyy" type="text" required="required"  onfocus="this.type='date'" onmouseover="this.type='date'" onclick="this.type='date'" onblur="this.type='text'" onmouseout="timeFunctionLong(this)" runat="server"></asp:TextBox>
										<script>
                                            function timeFunctionLong(TextBox) {
                                                setTimeout(function (input) {
                                                    input.type = 'text';
                                                }, 60000);
                                            }
                                        </script>
                                      </div>
                                       <div class="col-md-2 col-sm-2 py-4">
                                           <asp:LinkButton ID="btnantoperation" CssClass="btn btn-success" runat="server" OnClick="btnantoperation_Click"><span><i class="fa fa-plus-circle"></i></span> Ajouter</asp:LinkButton>
                                      </div>
                                     </div><!--end row-->
                                 
                                     <div class="form-group row">
                                          <div class="table-responsive">
                                           <asp:GridView ID="Gridantoperation" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="descriptionAnt" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                                                <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                                <Columns>  
                                                    <asp:BoundField DataField="descriptionAnt" HeaderText="Ant_famille" ReadOnly="True" SortExpression="nom" /> 
                                                     <asp:BoundField DataField="dateOperation" HeaderText="Date_Operation" ReadOnly="True" SortExpression="dateope" /> 
                                                    <asp:BoundField DataField="datecreated" HeaderText="datecreation" ReadOnly="True" SortExpression="date" /> 
                                                    <asp:TemplateField HeaderText="Act">                       
                                                    <ItemTemplate>                            
                                                        <asp:LinkButton ID="btnremoveopera" runat="server" Height="30px" CssClass="btn btn-danger menu " OnClick="btnremoveopera_Click" ><span class="me-2"><i class="fa fa-trash"></i></span></asp:LinkButton> 
                                                    </ItemTemplate>                         
                                       </asp:TemplateField>
                                                 </Columns> 

                                            </asp:GridView>
                                                 </div>
                                            </div><!--end row-->
                                         </ContentTemplate></asp:UpdatePanel>
                             
                                </div><!--end Chirurgicaux-->
                                <div class="tab-pane fade pag" id="Ant-settings" role="tabpanel" aria-labelledby="Ant-settings-tab">
                                    <asp:UpdatePanel runat="server"><ContentTemplate>
                                         <div class="profile_title">
                                      <h2 class="offset-1">Habitudes</h2>
                                      </div>
                                   <div class="row">
                                  <div class="col-md-4 col-sm-4 ">
                                      <label for="inputname">Habitudes</label>
                                      <asp:DropDownList ID="ddhabitude" runat="server" CssClass="form-control">
                                          
                                          <asp:ListItem> </asp:ListItem>
                                          <asp:ListItem>Alcool</asp:ListItem>
                                           <asp:ListItem>Tabac</asp:ListItem>
                                           <asp:ListItem>Cafe</asp:ListItem>
                                      </asp:DropDownList>
                                      </div>
                                       <div class="col-md-2 col-sm-2 py-4">
                                           <asp:LinkButton ID="btnhabitude" CssClass="btn btn-success" runat="server" OnClick="btnhabitude_Click"><span><i class="fa fa-plus-circle"></i></span> Ajouter</asp:LinkButton>
                                      </div>
                                     </div><!--end row-->
                                 
                                     <div class="form-group row">
                                          <div class="table-responsive">
                                           <asp:GridView ID="Gridhabitude" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="descriptionAnt" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                                                <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                                <Columns>  
                                                    <asp:BoundField DataField="descriptionAnt" HeaderText="Ant_famille" ReadOnly="True" SortExpression="nom" /> 
                                                    <asp:BoundField DataField="datecreated" HeaderText="datecreation" ReadOnly="True" SortExpression="date" /> 
                                                    <asp:TemplateField HeaderText="Act">                       
                                                    <ItemTemplate>                            
                                                        <asp:LinkButton ID="btnremoveHabitude" runat="server" Height="30px" CssClass="btn btn-danger menu " OnClick="btnremoveHabitude_Click" ><span class="me-2"><i class="fa fa-trash"></i></span></asp:LinkButton> 
                                                    </ItemTemplate>                         
                                       </asp:TemplateField>
                                                 </Columns> 

                                            </asp:GridView>
                                                 </div>
                                            </div><!--end row-->
                                    </ContentTemplate></asp:UpdatePanel>
                             
                                </div><!--end Habitudes-->
                              </div>
                            </div>

                          </div>
                           </div>  


                      </div><!--end antecedents-->
                     
                       <div class="tab-pane fade page" id="consultation" role="tabpanel" aria-labelledby="consultation-tab">
                           
                          
                           <div class="col-md-12 col-sm-12  ">
               
                  <div class="x_content">

                    <div class="col-md-3 col-sm-3">
                      <!-- required for floating -->
                      <!-- Nav tabs -->
                      <div class="nav nav-tabs flex-column  bar_tabs" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                        <a class="nav-link active" id="v-pills-home-tab" onclick="menu1()" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-home" aria-selected="true"><span><i class="fa fa-bookmark-o"></i></span> Motif Consultation</a>
                        <a class="nav-link" id="v-pills-profile-tab" onclick="menu2()" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-selected="false"><span><i class="fa fa-stethoscope"></i></span> Signe Vitaux</a>
                        <a class="nav-link" id="v-pills-messages-tab" onclick="menu3()" data-toggle="pill" href="#v-pills-messages" role="tab" aria-controls="v-pills-messages" aria-selected="false"><span><i class="fa fa-tint"></i></span>Examen</a>
                        <a class="nav-link" id="v-pills-settings-tab" onclick="menu4()" data-toggle="pill" href="#v-pills-settings" role="tab" aria-controls="v-pills-settings" aria-selected="false"><span><i class="fa fa-stethoscope"></i></span> Consultation</a>
                      </div>
            
                    </div>

                    <div class="col-md-9 col-sm-9"> <!-- Tab panes -->
                     
                     
                      <div class="tab-content " id="v-pills-tabContent">
                           
                        <div class="tab-pane fade show active" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab">
                             <asp:UpdatePanel runat="server"><ContentTemplate>
                                 <div class="profile_title">
                                      <h2 class="offset-1">Motif Consultation</h2>
                                      </div>
                            <div class="form-group row">
                        <div class="col-md-8 col-sm-8 offset-1">
                          <label>Histoire <small>(anamenese)</small></label>
                            <asp:TextBox ID="thistoire" class="form-control" placeholder="" runat="server"></asp:TextBox>
                          </div>
                        </div><!--end row-->
                        <div class="form-group row">
                        <div class="col-md-8 col-sm-8 offset-1">
                          <label>Signe</label>
                            <asp:TextBox ID="tsigne" class="form-control" placeholder="" runat="server"></asp:TextBox>
                          </div>
                        </div><!--end row-->
                         <div class="form-group row">
                        <div class="col-md-8 col-sm-8 offset-1">
                          <label>Symptomes</label>
                            <asp:TextBox ID="tsymp" class="form-control" placeholder="" runat="server"></asp:TextBox>
                          </div>
                          </div><!--end row-->
                                  <div class="form-group row">
                        <div class="col-md-4 col-sm-4 offset-8">
                            <a class="btn btn-pam"  onclick="menu2()"data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-selected="false" ><span><i class="fa fa-arrow-circle-o-right"></i></span> Suivant<a>
                          </div>
                          </div><!--end row-->

                            </ContentTemplate></asp:UpdatePanel>
                        </div><!--end motif-->
                           
                        
                        <div class="tab-pane fade pag" id="v-pills-profile" role="tabpanel" aria-labelledby="v-pills-profile-tab">

                            <div class="col-sm-12 col-md-12" id="SVlist">
                              <asp:UpdatePanel runat="server"><ContentTemplate>
                                  <div class="profile_title">
                                      <h2 class="offset-1">Signe Vitaux</h2>
                                      </div>
                                  
                                  <div class="form-group row">
                                      <div class="col-md-4 col-sm-4 offset-8">
                                      <asp:LinkButton ID="btnAjouterSV" CssClass="btn btn-success" OnClientClick="SV()" runat="server"><span><i class="fa fa-plus-circle"></i></span> Ajouter</asp:LinkButton>
                                          </div>  

                                      </div>
                                  <div class="form-group row">
                                      <div class="table-responsive">
                       <asp:GridView ID="magridSign" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codesigneV" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                            <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                            <Columns>  
                                <asp:BoundField DataField="codesigneV" HeaderText="code" ReadOnly="True" SortExpression="code" />  
                                <asp:BoundField DataField="poids" HeaderText="Pds(Kg)" SortExpression="Prenom" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="Temperature" HeaderText="temp(C°)" SortExpression="Sexe" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                <asp:BoundField DataField="tensionA" HeaderText="TA(mm/Hg)" SortExpression="TA" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />  
                                <asp:BoundField DataField="taille" HeaderText="Taille(m)" SortExpression="taille" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                <asp:BoundField DataField="pouls" HeaderText="Pouls" SortExpression="Telephone" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                <asp:BoundField DataField="createdby" HeaderText="createdby" SortExpression="Telephone" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                <asp:BoundField DataField="datecreated" HeaderText="datecreated" SortExpression="Telephone" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" /> 
                                           
                             </Columns> 

                        </asp:GridView>
                                   </div>
                                  </div>
                                       <div class="form-group row">
                        <div class="col-md-4 col-sm-4 offset-10">
                            <a class="btn btn-pam"  onclick="menu3()" data-toggle="pill" href="#v-pills-messages" role="tab" aria-controls="v-pills-messages" aria-selected="false" ><span><i class="fa fa-arrow-circle-o-right"></i></span> Suivant<a>
                          </div>
                          </div><!--end row-->
                             
                                  </ContentTemplate></asp:UpdatePanel>
                                </div><!--end col12-->

                                  <div class="col-sm-12 col-md-12 pag" id="SVadd">
                                      <asp:UpdatePanel runat="server"><ContentTemplate>
                                      <div class="form-group row">
                                      <div class="col-md-4 col-sm-4 offset-10">
                                      <asp:LinkButton ID="LinkButton1" CssClass="btn btn-pam" OnClientClick="menu2()" runat="server"><span><i class="fa fa-list"></i></span> Retour</asp:LinkButton>
                                          </div>  

                                      </div>
                                <div class="form-group row">
                                      <div class="col-md-6 col-sm-6">
                                        <label for="inputname">Poids(Kg)*</label>
                                          <asp:TextBox ID="tpoid" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                     <div class="col-md-6 col-sm-6">
                                                      <label for="inputname">Temprature(C°)*</label>
                                                        <asp:TextBox ID="ttemp" runat="server" class="form-control"  required='required'></asp:TextBox>
                                                    </div>
                                    </div>

                                        <div class="form-group row">
                                                <div class="col-md-6 col-sm-6 ">
                                                  <label for="inputname">Tension Aterielle. (mm/Hg)*</label>
                                                    <asp:TextBox ID="tta" runat="server" class="form-control" ></asp:TextBox>
                                                </div>
                                             <div class="col-md-6 col-sm-6 ">
                                                  <label for="inputname">Taille (m)*</label>
                                                    <asp:TextBox ID="ttaille" runat="server" class="form-control" ></asp:TextBox>
                                                </div>
                                        </div>
                                  <div class="form-group row">
                                                <div class="col-md-6 col-sm-6 ">
                                                  <label for="inputname">Pouls*</label>
                                                    <asp:TextBox ID="tpouls" runat="server" class="form-control" ></asp:TextBox>
                                                </div>
                                        </div>
                                          <div class="form-group row">
                                             <div class="col-md-4 col-sm-4 offset-4">
                                         <asp:LinkButton ID="btnaddSV" CssClass="btn btn-pam" runat="server" OnClientClick="menu2()" OnClick="btnajouterSV_Click">Enregistrer</asp:LinkButton>
                                          </div> 
                                              <div class="form-group row">
                                              <asp:LinkButton ID="btnannulerSV" CssClass="btn btn-default" runat="server" OnClick="btnannulerSV_Click" BorderColor="#29458D">Annuler</asp:LinkButton>
                                              </div>
                                          </div>
                                          </ContentTemplate></asp:UpdatePanel>
                                      </div><!--end col10-->


                                  
                        </div><!--end signe vitaux-->
                        <div class="tab-pane fade pag" id="v-pills-messages" role="tabpanel" aria-labelledby="v-pills-messages-tab">
                             <asp:UpdatePanel runat="server"><ContentTemplate>
                                 <div class="profile_title">
                                      <h2 class="offset-1">Examen</h2>
                                      </div>
                                   
                                   <div class="row">
                                  <div class="col-md-4 col-sm-4 ">
                                      <label for="inputname">Description Examen</label>
                                       <asp:TextBox ID="tdesc" runat="server" class="form-control" ></asp:TextBox>
                                      </div>
                                  <div class="col-md-6 col-sm-6 ">
                                      <label for="inputname">Resultat Examen</label>
                                       <asp:TextBox ID="tresultat" runat="server" class="form-control" ></asp:TextBox>
                                      </div>
                                       <div class="col-md-2 col-sm-2 py-4">
                                           <asp:LinkButton ID="btnaddEx" CssClass="btn btn-success" runat="server" OnClick="btnaddEx_Click" OnClientClick="menu3()"><span><i class="fa fa-plus-circle"></i></span> Ajouter</asp:LinkButton>
                                      </div>
                                     </div><!--end row-->
                                 
                                     <div class="form-group row">
                                          <div class="table-responsive">
                                           <asp:GridView ID="gridexamen" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codePatient" EmptyDataText="" OnSelectedIndexChanged="Page_Load">
                                                <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                                <Columns>  
                                                                <asp:BoundField DataField="codePatient" HeaderText="code_patient" ReadOnly="True" SortExpression="codeM" />  
                                                                <asp:BoundField DataField="descriptionE" HeaderText="Description" SortExpression="Nbrfois" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                                                <asp:BoundField DataField="resultatE" HeaderText="Resultat" SortExpression="quant" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                                                <asp:BoundField DataField="datecreated" HeaderText="creation" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                                               <asp:TemplateField HeaderText="Act">                       
                                                               <ItemTemplate>                            
                                                                   <asp:LinkButton ID="btnremoveEx" runat="server" Height="30px" CssClass="btn btn-danger menu " OnClientClick="menu3()" OnClick="btnremoveEx_Click" ><span class="me-2"><i class="fa fa-trash"></i></span></asp:LinkButton> 
                                                               </ItemTemplate>                         
                                       </asp:TemplateField>
                                                 </Columns> 

                                            </asp:GridView>
                                                 </div>
                                            </div><!--end row-->
                                 <div class="form-group row">
                                  <div class="col-md-4 col-sm-4 offset-6">
                            
                                 <a class="btn btn-pam"  onclick="menu4()" data-toggle="pill" href="#v-pills-settings" role="tab" aria-controls="v-pills-settings" aria-selected="false" ><span><i class="fa fa-arrow-circle-o-right"></i></span> Suivant<a>
                                </div>
                          </div><!--end row-->
                                 </ContentTemplate></asp:UpdatePanel>
                             
                        </div><!--end examen-->
                        <div class="tab-pane fade pag" id="v-pills-settings" role="tabpanel" aria-labelledby="v-pills-settings-tab">
                            <asp:UpdatePanel runat="server"><ContentTemplate>
                                 <div class="profile_title">
                                      <h2 class="offset-1">Consultation</h2>
                                      </div>
                                         <div class="form-group row">
                                        <div class="col-md-8 col-sm-7 offset-1">
                                            <label for="inputname">Diagnostique*</label>
                                            <asp:DropDownList ID="ddiag" runat="server" class="form-control" >
                                            </asp:DropDownList>

                                        </div>
                                        </div>
                                      <div class="form-group row">
                                                <div class="col-md-8 col-sm-7 offset-1">
                                                  <label for="inputname">Note</label>
                                                    <asp:TextBox ID="tcomment" TextMode="MultiLine" Rows="3" runat="server" class="form-control" ></asp:TextBox>
                                                </div>
                                        </div>
                                 <div class="form-group row">
                                  <div class="col-md-4 col-sm-4 offset-6">
                                 <asp:LinkButton ID="btnsaveCons" CssClass="btn btn-pam" OnClientClick="viewprof4()" data-toggle="tab" href="#ordonance" role="tab" aria-controls="ordonance" aria-selected="false" runat="server">Suivante</asp:LinkButton>
                          </div>
                          </div><!--end row-->
                            </ContentTemplate></asp:UpdatePanel>
                             
                        </div><!--end Consultation-->
                      </div>
                    </div>

                  </div>
                               </div>    
                      </div><!--end Consultation-->

                         <div class="tab-pane fade page" id="ordonance" role="tabpanel" aria-labelledby="ordonance-tab">
                           <asp:UpdatePanel runat="server"><ContentTemplate>
                           <div class="form-horizontal" >
                                    
                                    <div class="form-group row">
                                    <div class="col-md-4 col-sm-4">
                                      <strong>   <asp:Label ID="lblPatient" runat="server" Text=" Code Patient:     "></asp:Label></strong>  
                                        <asp:Label ID="lblpatien" runat="server" Text=""></asp:Label>
                                    </div>
                                       
                                         <div class="col-sm-4 col-md-4">
                                        <strong>  <asp:Label ID="Label15" runat="server" Text=""></asp:Label></strong>   
                                        <asp:Label ID="lblage1" runat="server" Text=""></asp:Label>
                                    </div>
                                     <div class="col-sm-4 col-md-4">
                                        <strong>  <asp:Label ID="Label17" runat="server" Text=""></asp:Label></strong>   
                                        <asp:Label ID="lbldateP" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    <div class="form-group row ">
                                        <div class="col-md-3 col-sm-3" >
                                       <b> <label>Prevention</label></b>
<%--                                        <asp:TextBox ID="t" class="form-control" placeholder="" runat="server" Enabled="false"></asp:TextBox>--%>
                                        <asp:TextBox ID="tprevention" class="form-control" placeholder="" runat="server"></asp:TextBox>
                          
                                        </div><!--end col--> 
                                        <div class="col-md-3 col-sm-3">
                                       <b> <label>Durer</label></b>
                                        <asp:TextBox ID="tdurer" class="form-control" placeholder="" runat="server"></asp:TextBox>
                          
                                        </div><!--end col-->
                                    </div>
                                    <div class="form-group row">
                                    <div class="col-md-3 col-sm-3">
                                        <b><label>Nom Medicament</label></b>
                                        <%--<asp:TextBox ID="tnomM" class="form-control" placeholder="" runat="server"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddnomM" class="form-control" runat="server"></asp:DropDownList>
                                        </div><!--end col-->
                                        <div class="col-md-3 col-sm-3">
                                       <b> <label>Posologie</label></b>
                                        <asp:TextBox ID="tnbrfois" class="form-control" placeholder="" runat="server"></asp:TextBox>
                          
                                        </div><!--end col-->
                                        <div class="col-md-1 col-sm-1">
                                        <b><label>Quantite</label></b>
                                        <asp:TextBox ID="tquant" class="form-control" placeholder="" runat="server"></asp:TextBox>
                          
                                        </div><!--end col-->
                                        <div class="col-md-2 col-sm-2">
                                        <b><label>Form</label></b>
                                        <asp:TextBox ID="tform" class="form-control" placeholder="" runat="server"></asp:TextBox>
                          
                                        </div><!--end col-->
                                        <div class="col-md-2 col-sm-2 py-4">
                                            <asp:LinkButton ID="Addpress" CssClass="btn btn-success" Height="40px" runat="server" OnClick="Addpress_Click"><span><i class="fa fa-plus-circle"></i></span> Ajouter</asp:LinkButton>
                                        </div>
                                        </div><!--end row-->
                                        <div class="form-group row">
                                          <div class="table-responsive">
                                           <asp:GridView ID="magridPres" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="codeMed" EmptyDataText="Pas info a afficher." OnSelectedIndexChanged="Page_Load">
                                                <HeaderStyle BackColor="#F5F7FA" Font-Bold="True" ForeColor="black" />

                                                <Columns>  
                                                <asp:BoundField DataField="codeMed" HeaderText="codeMedicament" ReadOnly="True" SortExpression="codeM" />  
                                                <asp:BoundField DataField="nbrFois" HeaderText="Posologie" SortExpression="Nbrfois" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                                <asp:BoundField DataField="quant" HeaderText="Quantite" SortExpression="quant" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                                <asp:BoundField DataField="form" HeaderText="Form" SortExpression="form" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                                <asp:TemplateField HeaderText="Act">                       
                                                <ItemTemplate>                            
                                                    <asp:LinkButton ID="btnremove" runat="server" Height="30px" CssClass="btn btn-danger menu " OnClick="btnremove_Click"><span class="me-2"><i class="fa fa-trash"></i></span></asp:LinkButton> 
                                                </ItemTemplate>                         
                                                </asp:TemplateField>
                                                 </Columns> 

                                            </asp:GridView>
                                                 </div>
                                            </div><!--end row-->
<%--                                      <asp:LinkButton ID="btnsavePresc" runat="server" CssClass="btn btn-pam" data-toggle="modal" data-target=".bs-example-modal-lg" >Imprimer</asp:LinkButton>--%>
                        
                 
                               </div><!--end form-horizontal-->
                            </ContentTemplate></asp:UpdatePanel>
                      </div><!--end ordonance-->
                      </div>


                   
                  </div><!--x-content-->
                    
                </div><!--x-panel-->
              </div><!--end col-->

            </div><!--end row-->
              <div class="row">
                  <div class="col-sm-4 col-md-4 offset-4">
                <asp:LinkButton ID="btnsave" CssClass="btn btn-success" OnClick="btnsave_Click" runat="server">Enregistrer</asp:LinkButton>
               <asp:LinkButton ID="btnanuler" CssClass="btn btn-default" OnClick="btnanuler_Click" runat="server" BorderColor="#29458D">Annuler</asp:LinkButton>
                      </div>
              </div><!--end row-->

        </div>
        </div>
        <!-- /page content -->


        <!-- footer content -->
        <footer>
          <div class="pull-right">
            <strong >Copyright &copy tout droit reservé.
          g >Copyright &copy tout droit reservé.
          </div>
          <div class="clearfix">
              
            </div>
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
   <%-- <script src="../build/js/myjs.js"></script>--%>
    <script type="text/javascript">
      
         function viewprof1() {
             document.getElementById('antecedent').style.display = 'none';
             document.getElementById('consultation').style.display = 'none';
             document.getElementById('ordonance').style.display = 'none';
             document.getElementById('info').style.display = 'block';
             document.getElementById('v-pills-v-pills-home').style.display = 'none';
             document.getElementById('v-pills-profile').style.display = 'none';
             document.getElementById('v-pills-messages').style.display = 'none';
             document.getElementById('v-pills-settings').style.display = 'none';
             document.getElementById('Ant-home').style.display = 'none';
             document.getElementById('Ant-profile').style.display = 'none';
             document.getElementById('Ant-messages').style.display = 'none';
             document.getElementById('Ant-settings').style.display = 'none';

         }
         function viewprof2() {
             document.getElementById('antecedent').style.display = 'block';
             document.getElementById('consultation').style.display = 'none';
             document.getElementById('ordonance').style.display = 'none';
             document.getElementById('info').style.display = 'none';
             document.getElementById('v-pills-home').style.display = 'none';
             document.getElementById('v-pills-profile').style.display = 'none';
             document.getElementById('v-pills-messages').style.display = 'none';
             document.getElementById('v-pills-settings').style.display = 'none';
             document.getElementById('Ant-home').style.display = 'block';
             document.getElementById('Ant-profile').style.display = 'none';
             document.getElementById('Ant-messages').style.display = 'none';
             document.getElementById('Ant-settings').style.display = 'none';


        }
        function viewprof3() {
            document.getElementById('antecedent').style.display = 'none';
            document.getElementById('consultation').style.display = 'block';
            document.getElementById('ordonance').style.display = 'none';
            document.getElementById('info').style.display = 'none';
            document.getElementById('v-pills-home').style.display = 'block';
            document.getElementById('v-pills-profile').style.display = 'none';
            document.getElementById('v-pills-messages').style.display = 'none';
            document.getElementById('v-pills-settings').style.display = 'none';
            document.getElementById('Ant-home').style.display = 'none';
            document.getElementById('Ant-profile').style.display = 'none';
            document.getElementById('Ant-messages').style.display = 'none';
            document.getElementById('Ant-settings').style.display = 'none';

        }
        function viewprof4() {
            document.getElementById('antecedent').style.display = 'none';
            document.getElementById('consultation').style.display = 'none';
            document.getElementById('ordonance').style.display = 'block';
            document.getElementById('info').style.display = 'none';
            document.getElementById('v-pills-home').style.display = 'none';
            document.getElementById('v-pills-profile').style.display = 'none';
            document.getElementById('v-pills-messages').style.display = 'none';
            document.getElementById('v-pills-settings').style.display = 'none';
            document.getElementById('Ant-home').style.display = 'none';
            document.getElementById('Ant-profile').style.display = 'none';
            document.getElementById('Ant-messages').style.display = 'none';
            document.getElementById('Ant-settings').style.display = 'none';

        }
        function menu1() {
            document.getElementById('v-pills-home').style.display = 'block';
            document.getElementById('v-pills-profile').style.display = 'none';
            document.getElementById('v-pills-messages').style.display = 'none';
            document.getElementById('v-pills-settings').style.display = 'none';

        }
        function menu2() {
            document.getElementById('v-pills-home').style.display = 'none';
            document.getElementById('v-pills-profile').style.display = 'block';
            document.getElementById('v-pills-messages').style.display = 'none';
            document.getElementById('v-pills-settings').style.display = 'none';

            document.getElementById('SVadd').style.display = 'none';
            document.getElementById('SVlist').style.display = 'block';


        }
        function SV() {
            document.getElementById('SVlist').style.display = 'none';
            document.getElementById('SVadd').style.display = 'block';
            
        }
        function menu3() {
            document.getElementById('v-pills-home').style.display = 'none';
            document.getElementById('v-pills-profile').style.display = 'none';
            document.getElementById('v-pills-messages').style.display = 'block';
            document.getElementById('v-pills-settings').style.display = 'none';

        }
        function menu4() {
            document.getElementById('v-pills-home').style.display = 'none';
            document.getElementById('v-pills-profile').style.display = 'none';
            document.getElementById('v-pills-messages').style.display = 'none';
            document.getElementById('v-pills-settings').style.display = 'block';

        }
        function Ant1() {
            document.getElementById('Ant-home').style.display = 'block';
            document.getElementById('Ant-profile').style.display = 'none';
            document.getElementById('Ant-messages').style.display = 'none';
            document.getElementById('Ant-settings').style.display = 'none';

        }
        function Ant2() {
            document.getElementById('Ant-home').style.display = 'none';
            document.getElementById('Ant-profile').style.display = 'block';
            document.getElementById('Ant-messages').style.display = 'none';
            document.getElementById('Ant-settings').style.display = 'none';

        }
        function Ant3() {
            document.getElementById('Ant-home').style.display = 'none';
            document.getElementById('Ant-profile').style.display = 'none';
            document.getElementById('Ant-messages').style.display = 'block';
            document.getElementById('Ant-settings').style.display = 'none';

        }
        function Ant4() {
            document.getElementById('Ant-home').style.display = 'none';
            document.getElementById('Ant-profile').style.display = 'none';
            document.getElementById('Ant-messages').style.display = 'none';
            document.getElementById('Ant-settings').style.display = 'block';
        }
        function Allerg() {
            document.getElementById('Allerg').style.display = 'block';
        }
        function Allerg1() {
            document.getElementById('Allerg1').style.display = 'block';
        }
        function Ist() {
            document.getElementById('Ist').style.display = 'block';
        }
        
    </script>
    
</body>
</html>

