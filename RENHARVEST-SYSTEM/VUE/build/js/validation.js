(function () {
    'use strict'
var nom_v = /^[a-zA-Z][a-z]+([-'\s][a-zA-ZE][a-zei]+)?/;
var prenom_v = /^[a-zA-ZIEe][a-ze]+([-'\s][a-zA-ZE][a-zei]+)?/;
var email_v = /^([a-z0-9._-]+)@([a-z0-9._-]+)\.([a-z]{2,6})$/;
var numero_v = /^[0-9]{4,}$/;
var validation = document.getElementById('btnvalider');
var nom = document.getElementById('tnomp');
var prenom = document.getElementById('tprenomp');
var sexe = document.getElementById('ddsexe');
var date = document.getElementById('tdatenaiss');
var email = document.getElementById('temail');
var adresse = document.getElementById('tadresse');
var phone = document.getElementById('tphone');
var matricule = document.getElementById('tmatricule');
var g_s = document.getElementById('ddg_s');
var p_respon = document.getElementById('tp_respon');
var p_respon = document.getElementById('ddlienp');
var forms = document.querySelectorAll('.needs-validation')




    validation.addEventListener('click', f_valid);

    function f_valid(e) {
        if (nom.value == "") {
            e.preventDefault();

            nom.style.borderColor = 'red';
        }
        
        
        

      }

})()