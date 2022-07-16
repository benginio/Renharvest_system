
    var nom_v = /^[a-zA-Z][a-z]+([-'\s][a-zA-ZE][a-zei]+)?/;
    var prenom_v = /^[a-zA-ZIEe][a-ze]+([-'\s][a-zA-ZE][a-zei]+)?/;
    var email_v = /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
    var numero_v = /^[0-9]{4,}$/;
    var job_v = /^[a-zA-Z][a-z]+([-'\s][a-zA-ZE][a-zei]+)?/;
    var adresse_v = /^[a-zA-Z0-9]+$/i;
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
        }else {
            adress_m.textContent = '';
        }
        adresse.addEventListener('change', nomValidadress);
        function nomValidadress(e) {
            if (adresse.value == "") {
                e.preventDefault();
                adress_m.textContent = 'Veuillez saisir ladresse!';
                /*adresse.style.borderColor = 'red';*/
                adress_m.style.color = 'red';
            } else if (!adresse_v.test(adresse.value)) {
                e.preventDefault();
                adress_m.textContent = 'Format incorrect';
                adress_m.style.color = 'orange';
            } else {
                adress_m.textContent = '';
            }

        }

        //email
        if (email.value == "") { email_m.textContent = ''; }
        else {
            if (!email_v.test(email.value)) {
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
                if (!email_v.test(email.value)) {
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



