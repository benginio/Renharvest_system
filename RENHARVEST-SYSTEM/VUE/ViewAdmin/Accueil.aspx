<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accueil.aspx.cs" Inherits="RENHARVEST_SYSTEM.VUE.Accueil" %>

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
        <div class="right_col" role="main">
          <div class="">

             <div class="page-title">
              <div class="title_left"><br/>
                <h5> Accueil |</h5>
              </div>
            </div>
                <!-- Info boxes -->
        <div class="row">
          <div class=" col-sm-3 col-md-3">
            <div class="info-box">
              <span class="info-box-icon bg-green elevation-1"><i class="fa fa-users"></i></span>

              <div class="info-box-content">
                <span class="info-box-text">Nbr Patients</span>
                <span class="info-box-number">
                    <asp:Label ID="nbrPers" runat="server" Text=""></asp:Label>
                </span>
              </div>
              <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
          </div>
          <!-- /.col -->
          <div class=" col-sm-3 col-md-3">
            <div class="info-box mb-3">
              <span class="info-box-icon bg-white elevation-1"><i class="fa fa-users"></i></span>

              <div class="info-box-content">
                <span class="info-box-text">Nombres Utilisateur</span>
                <span class="info-box-number">
                    <asp:Label ID="lbluser" runat="server" Text=""></asp:Label>
                </span>
              </div>
              <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
          </div>
          <!-- /.col -->
          
          <div class=" col-sm-3 col-md-3">
            <div class="info-box mb-3">
              <span class="info-box-icon bg-pam elevation-1"><i class="fa fa-users"></i></span>

              <div class="info-box-content">
                <span class="info-box-text"> Patients inscrit aujourd'hui</span>
                <span class="info-box-number">
                     <asp:Label ID="lblNbrinscription" runat="server" Text=""></asp:Label>
                </span>
              </div>
              <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
          </div>
          <!-- /.col -->

          <div class=" col-sm-3 col-md-3">
            <div class="info-box mb-3">
              <span class="info-box-icon bg-white elevation-1"><i class="fa fa-users"></i></span>

              <div class="info-box-content">
                <span class="info-box-text">Consultation aujourd'hui</span>
                <span class="info-box-number">
                    <asp:Label ID="lblconsultation" runat="server" Text=""></asp:Label>
                </span>
              </div>
              <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
          </div>
          <!-- /.col -->
        </div>
        <!-- /.row -->
          

              <div class="row">
              <div class="col-sm-5 col-md-5">
                    <div class="x_panel">
                        <strong><label>Feminin :</label></strong><asp:Label ID="nbfille" runat="server" Text="" ></asp:Label>&nbsp;&nbsp;
                        <strong><label>Masculin :</label></strong><asp:Label ID="nbgarc" runat="server" Text=""></asp:Label><br />
                        <div class="x_content">
                        <canvas id="pieChart"></canvas>
                        </div>
                        </div>
                </div>

                  <div class="col-sm-7 col-md-7">
                      <div class="x_panel">
                           <div class="x_content">
                    <canvas id="mybarChart"></canvas>
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
     <!-- Chart.js -->
    <script src="../vendors/Chart.js/dist/Chart.min.js"></script>
    

    <!-- jQuery custom content scroller -->a
    <script src="../vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    <script type="text/javascript">

        document.addEventListener('DOMContentLoaded', function () {
            fille = document.getElementById('nbfille').textContent;
            garc = document.getElementById('nbgarc').textContent;

            var xValues = ["Masculin", "Feminin"];
            var yValues = [parseInt(garc), parseInt(fille)];
            var barColors = [
                "#00aba9",
                "#BDC3C7",
                "#2b5797",
                "#e8c3b9",
                "#1e7145"
            ];

            if ($("#pieChart").length) e = document.getElementById("pieChart"),
                new Chart(e, {
                    type: "pie",
                    data: {
                        labels: xValues,
                        datasets: [{
                            backgroundColor: barColors,
                            data: yValues
                        }]
                    },
                    options: {
                        title: {
                            display: true,
                            text: "Graph suivant le sexe des patients dans le systeme"
                        }
                    }
                });


        });



    </script>
    <script type="text/javascript">
        // Bar chart
        function init_charts() {

            console.log('run_charts  typeof [' + typeof (Chart) + ']');

            if (typeof (Chart) === 'undefined') { return; }

            console.log('init_charts');


            Chart.defaults.global.legend = {
                enabled: false
            };

            if ($('#mybarChart').length) {

                var ctx = document.getElementById("mybarChart");
                var mybarChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: ["January", "February", "March", "April", "May", "June", "July", "March", "April", "May", "June", "July"],
                        datasets: [{
                            label: '#',
                            backgroundColor: "#26B99A",
                            data: [51, 30, 40, 28, 92, 50, 45, 40, 28, 92, 50, 45]
                        }]
                    },

                    options: {
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true
                                }
                            }]
                        }
                    }
                });

            }
        }
        $(document).ready(function () {
            init_charts();
        });
    </script>
    
</body>
</html>
