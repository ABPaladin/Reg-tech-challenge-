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

create table automatic_check_audit_rows
(
    id                              int primary key generated always as identity,
    automatic_check_audit_header_id int  not null references automatic_check_audit_headers,
    automatic_check_id              int  not null references automatic_checks,
    passed                          bool,
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

insert into checklist_questions values (default, 0, 'Backup?', 'Do backups!');
insert into checklist_questions values (default, 1, 'Trainings?', 'Do trainings!');
insert into checklist_questions values (default, 2, 'OpSec?', 'Do OpSec!');

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