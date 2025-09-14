drop table if exists checklist_answer_rows;
drop table if exists checklists;
drop table if exists checklist_questions;

drop table if exists automatic_check_audit_rows;
drop table if exists automatic_check_audit_headers;
drop table if exists automatic_checks;
drop table if exists company_ips;

drop table if exists incidents;
drop table if exists incident_statuses;
drop table if exists companies;


create table companies
(
    id                int primary key generated always as identity,
    name              text not null,
    password          text not null unique,
--     address           text,
--     responsible_name  text,
    responsible_phone text,
    responsible_email text
--     size              text,
--     sector_type       text,
--     iso_certified     text,
--     risk_assesment    text,
--     risk_solution     text,
--     opsec_tools       text
);

create table incident_statuses
(
    id           int primary key generated always as identity,
    name         text not null unique,
    status_order int  not null unique
);

insert into incident_statuses
values (default, 'INITIAL', 0);
insert into incident_statuses
values (default, 'UPDATED', 1);
insert into incident_statuses
values (default, 'FINAL', 2);
-- insert into incident_status values (default, 'COMPLETED');


create table incidents
(
    id                        int primary key generated always as identity,
    company_id                int         not null references companies,

    first_response            text        not null,
    first_response_timestamp  timestamptz not null default now(),
    second_response           text,
    second_response_timestamp timestamptz,
    third_response            text,
    third_response_timestamp  timestamptz,

    is_critical               bool        not null,
    is_initially_averted      bool        not null,
    repeat_incident_id        int         null references incidents,
    status_id                 int         not null references incident_statuses
);

-----------------------------

-- create table company_ips
-- (
--     id         int primary key generated always as identity,
--     company_id int not null references companies,
--     url        text
-- );

create table automatic_checks
(
    id   int primary key generated always as identity,
    check_order int not null unique,
    name text not null unique
);

insert into automatic_checks
values (default, 0, 'Ports');
insert into automatic_checks
values (default, 1, 'TLS');
insert into automatic_checks
values (default, 2, 'HTTP/HTTPS');
insert into automatic_checks
values (default, 3, 'Vulns');

create table automatic_check_audit_headers
(
    id           int primary key generated always as identity,
    company_id   int not null references companies,
    ip_address   text        not null,
    is_completed bool        not null default false,
--     company_ip_id int         not null references company_ips,
    datetime     timestamptz not null default (now())
);

create index on automatic_check_audit_headers(company_id);
create index on automatic_check_audit_headers(company_id, datetime);

create table automatic_check_audit_rows
(
    id                              int primary key generated always as identity,
    automatic_check_audit_header_id int  not null references automatic_check_audit_headers,
    automatic_check_id              int  not null references automatic_checks,
    passed                          bool not null,
    comment                         text null,
    unique (automatic_check_audit_header_id, automatic_check_id)
);

-----------------------------

create table checklist_questions
(
    id              int primary key generated always as identity,
    question_order  int unique not null,
    question_text   text       not null,
    recommendations text       not null
);

create table checklists
(
    id         int primary key generated always as identity,
    company_id int         not null references companies,
    datetime   timestamptz not null default (now())
    --all the questions and their answers
);

create table checklist_answer_rows
(
    id                 int primary key generated always as identity,
    checklist_id       int  not null references checklists,
    question_id        int  not null references checklist_questions,
    answered_correctly bool not null
);

insert into checklist_questions
values (default, 1, '1. Aveți regulamente interne de control al accesului, logic și fizic, la sistemele informatice?',
        'Faceți un regulament intern unde notați cine are voie să acceseze calculatoarele, programele și documentele. Stabiliți cum se face accesul (parole, carduri, chei, VPN) și cine răspunde pentru fiecare resursă. Important este ca fiecare angajat să aibă contul propriu și să nu existe acces partajat. Regulamentul trebuie revizuit anual sau după un incident.<br>Resurse utile:<br><a href="https://www.dataprotection.ro/?page=Acces-date-control-acces">ANSPDCP - Recomandări privind controlul accesului la date</a>');

insert into checklist_questions
values (default, 2,
        '2. Segmentați accesul la sisteme în dependență de rolul angajatului (administrator, lucrător, client extern)?',
        'Creați roluri separate pentru fiecare tip de utilizator. Administratorii au drepturi de configurare, angajații folosesc doar funcțiile necesare, iar clienții externi primesc acces foarte limitat. Această separare reduce greșelile și atacurile interne. Revizuiți periodic rolurile și adaptați-le la schimbări.<br>Resurse utile:<br><a href="https://gdprcomplet.ro/proceduri-politici-de-securitate-it-conformare-gdpr">Proceduri și politici de securitate IT - conformare la GDPR</a>');

insert into checklist_questions
values (default, 3,
        '3. Aplicați segmentarea rețelelor de calculatoare, Astfel ca sistemele critice să nu fie expuse public?',
        'Împărțiți rețeaua în zone (servere critice, angajați, vizitatori) și controlați traficul dintre ele prin firewall. Țineți bazele de date și serverele interne în spatele rețelei, nu direct în internet. Pentru Wi-Fi, creați rețele separate (ex. rețea de oaspeți și rețea pentru dispozitive IoT). VLAN-urile și reguli de firewall simple reduc masiv riscul de propagare a unui incident.<br>Resurse utile:<br><a href="https://www.bitdefender.com/ro-ro/blog/hotforsecurity/securizarea-casei-inteligente-segmentarea-retelei-pas-cu-pas">Securizarea rețelei prin segmentare – ghid pas cu pas (RO) – Bitdefender, secțiunea „Ghid pas cu pas” (pașii 1–7)</a><br><a href="https://blog.synology.com/romania/segmentarea-retelei-iata-cum-va-asigurati-in-mod-corespunzator-wlan-ul">Segmentarea WLAN cu VLAN și reguli de firewall (RO) – Synology România; vezi paragrafele despre VLAN și „Aplicați reguli de firewall”</a>');

insert into checklist_questions
values (default, 4,
        '4. Aveți sisteme care asigură că doar angajatul corespunzător are acces la sisteme (carduri de acces, chei)?',
        'Folosiți metode personalizate: carduri, chei electronice, parole individuale. Angajații nu trebuie să împartă aceleași date de acces. La plecarea lor, accesul trebuie șters imediat. Pentru vizitatori, folosiți carduri temporare cu acces limitat.');

insert into checklist_questions
values (default, 5,
        '5. Revizuiți regulamentele interne în cazul unor riscuri sau incidente semnificative?',
        'După fiecare incident sau schimbare importantă, actualizați regulamentele interne ca să reflecte noile riscuri. Notați ce s-a întâmplat, ce măsuri ați luat și ce reguli trebuie schimbate. Comunicați clar angajaților versiunile noi.<br>Resurse utile:<br><a href="https://www.enisa.europa.eu/sites/default/files/all_files/ENISA%20Cybersecurity%20guide%20for%20SMEs_RO.pdf">ENISA – Ghid pentru IMM-uri (RO) – vezi p.14 „Gestionați incidentele și învățați din ele”</a>');

insert into checklist_questions
values (default, 6,
        '6. Aveți proceduri de acordare, eliminare și documentare a drepturilor de acces ale angajaților asupra sistemelor?',
        'Faceți o procedură clară pentru fiecare etapă: la angajare, un cont nou; la schimbare de rol, adaptarea accesului; la plecare, eliminarea imediată a drepturilor. Țineți un tabel sau registru cu toate modificările. Această evidență vă protejează în caz de controale sau conflicte.<br>Resurse utile:<br><a href="https://dcd.uaic.ro/?page_id=74">Politica de securitate - DCDI - UAIC</a>');

insert into checklist_questions
values (default, 7,
        '7. Atribuiți angajaților drepturi minime pentru a-și îndeplini sarcina?',
        'Aplicați principiul „celui mai mic privilegiu”. Fiecare primește doar ce are nevoie, nu mai mult. Astfel, dacă un cont este compromis, pagubele sunt limitate. Revizuiți periodic pentru a elimina accesul inutil.');

insert into checklist_questions
values (default, 8,
        '8. Ștergeți drepturile de acces ale angajaților la demisionarea sau concedierea acestora?',
        'Dezactivați conturile imediat ce angajatul pleacă. Aceasta include email, VPN, aplicații interne și carduri fizice. Dacă amânați, există riscul ca foștii angajați să acceseze date. Documentați această acțiune în registru.');

insert into checklist_questions
values (default, 9,
        '9. Aveți o echipă responsabilă de administrarea drepturilor de acces?',
        'Stabiliți o persoană sau o mică echipă care să gestioneze accesul. Ei trebuie să aprobe cererile de acces, să facă modificări și să șteargă drepturi. Astfel evitați situația în care fiecare manager face regulile proprii. O echipă dedicată asigură consecvența.');

insert into checklist_questions
values (default, 10,
        '10. Oferiți drepturi de acces separate pentru persoane terțe (vizitatori, furnizori de servicii), și le limitați accesul și durata drepturilor?', 'Creați conturi temporare cu valabilitate limitată pentru terți. Dați-le acces doar la ce au nevoie și doar pe perioada colaborării. După aceea, ștergeți sau suspendați accesul. Astfel preveniți abuzurile și scurgerile de date.');

insert into checklist_questions
values (default, 11,
        '11. Țineți un registru de drepturi de acces?', 
        'Păstrați o listă cu cine are acces la ce sistem. Actualizați lista la fiecare schimbare. Registrul vă ajută să răspundeți rapid în caz de audit sau incident. Poate fi un simplu tabel, dar trebuie să fie complet și corect.');

insert into checklist_questions
values (default, 12,
        '12. Salvați istoricul modificărilor aplicate asupra drepturilor de acces?',
        'Țineți un jurnal (log) cu toate schimbările de acces: cine a modificat, ce a schimbat și când. Aceste informații sunt vitale în caz de anchetă sau conflict. Logurile nu trebuie șterse, ci arhivate pentru o perioadă minimă.<br>Resurse utile:<br><a href="https://dydy.ro/avantajelesistemelordecontrolacceselectroniceinsecuritateacladirilor">Articol despre sisteme de control acces și loguri (RO)</a>');

insert into checklist_questions
values (default, 13,
        '13. Revizuiți regulat drepturile de acces?',
        'Faceți periodic (ex. la 6 luni) o verificare a tuturor drepturilor. Întrebați managerii dacă angajații chiar mai au nevoie de acces. Eliminați conturile vechi sau permisiunile inutile. Astfel evitați acumularea de riscuri.');

insert into checklist_questions
values (default, 14,
        '14. Controlați regulat siguranța conturilor privilegiate?',
        'Verificați constant dacă administratorii folosesc parole puternice și 2FA. Monitorizați logările și activitatea lor. Schimbați periodic parolele și nu lăsați conturile privilegiate active dacă nu sunt folosite.<br>Resurse utile:<br><a href="https://transport.ec.europa.eu/system/files/2021-10/cybersecurity-toolkit_ro.pdf">Setul de instrumente privind securitatea cibernetică (RO) – vezi p.11 „acreditările pentru conturi privilegiate” și p.18–19 recomandări 2FA/MFA</a>');

insert into checklist_questions
values (default, 15,
        '15. Ați stabilit măsuri de securitate sigure asupra logării în conturile privilegiate? Precum confirmării adiționale prin aplicație de autentificare/sms?',
        'Activați autentificarea cu doi factori (2FA) sau MFA pentru toate conturile privilegiate. Folosiți aplicații de autentificare sau coduri SMS pentru confirmări suplimentare, și limitați numărul de utilizări ale contului dacă nu e nevoie de utilizare frecventă. Asigurați proceduri pentru recuperarea accesului în caz de pierdere a dispozitivului.<br>Resurse utile:<br><a href="https://www.gelusi.ro/consultanta-it/autentificarea-multi-factor-mfa-si-autentificarea-cu-doi-factori-2fa">Autentificarea Multi-Factor (MFA) și Autentificarea cu Doi Factori (2FA) – Gelusi.RO</a>');

insert into checklist_questions
values (default, 16,
        '16. Conturile privilegiate obțin exclusiv accese specifice asupra sistemelor (spre exemplu nu aveți un singur administrator asupra întregului sistem, ci e separat pentru web, servere, baze de date, etc)?',
        'Împărțiți responsabilitățile: un administrator pentru servere, altul pentru baze de date, altul pentru aplicații. Astfel, dacă un cont este compromis, nu cade tot sistemul. Această separare limitează riscurile și ajută la trasabilitate.');

insert into checklist_questions
values (default, 17,
        '17. Email-urile interne sunt utilizate numai în scop corporativ, și nu se folosesc pentru servicii externe sau divertisment?',
        'Reglementați clar că adresele de email ale companiei sunt doar pentru muncă. Interziceți folosirea lor la înscriere pe site-uri externe sau sociale. Astfel reduceți riscul de phishing și spam. Este o regulă simplă, dar foarte eficientă.');

insert into checklist_questions
values (default, 18,
        '18. Sistemele administratorilor sunt protejate prin logare și criptare?',
        'Obligați administratorii să aibă parolă sau autentificare biometrică pe dispozitive. Activați criptarea discului (BitLocker, FileVault). În caz de furt, datele rămân inaccesibile. Această protecție este obligatorie pentru dispozitivele cu acces extins.<br>Resurse utile:<br><a href="https://www.microsoft.com/ro-ro/security/business/identity-access/microsoft-entra-mfa-multi-factor-authentication">Microsoft Security - Autentificare multifactor (MFA)</a>');

insert into checklist_questions
values (default, 19,
        '19. Efectuați regulat traininguri de securitate pe internet pentru angajații voștri?',
        'Organizați sesiuni scurte unde explicați cum să recunoască emailurile false, cum să creeze parole sigure și cum să raporteze incidente. Repetați măcar o dată pe an. Trainingurile cresc atenția și reduc riscurile umane.<br>Resurse utile:<br><a href="https://sigurantaonline.ro">DNSC – Campanie „Siguranța online începe cu tine” (RO)</a>');