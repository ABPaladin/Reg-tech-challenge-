create table companies (
    id int primary key generated always as identity,
    name text not null,
    password text not null unique
);
DROP TABLE companies;

create table incident_statuses (
    id int primary key generated always as identity,
    name text not null unique,
    status_order int not null unique
);
DROP TABLE incident_statuses

insert into incident_statuses values (default, 'INITIAL', 0);
insert into incident_statuses values (default, 'UPDATED', 1);
insert into incident_statuses values (default, 'FINAL', 2);
-- insert into incident_status values (default, 'COMPLETED');


create table incidents (
    id int primary key generated always as identity,
    company_id int not null references companies,
    
    first_response text not null,
    first_response_timestamp timestamptz not null default now(),
    second_response text,
    second_response_timestamp timestamptz,
    third_response text,
    third_response_timestamp timestamptz,
    
    is_critical bool not null,
    is_initially_averted bool not null,
    repeat_incident_id int null references incidents,
    status int not null references incident_statuses  
);
DROP TABLE incidents;

-----------------------------

create table company_ips(
    id int primary key generated always as identity,
    company_id int not null references companies,
    url text
);
DROP TABLE company_ips;

create table automatic_checks(
    id int primary key generated always as identity,
    name text not null unique
);
DROP TABLE automatic_checks;

insert into automatic_checks values(default, 'Ports');
insert into automatic_checks values(default, 'TLS');
insert into automatic_checks values(default, 'HTTP/HTTPS');
insert into automatic_checks values(default, 'Vulns');

create table automatic_check_audit_headers(
    id int primary key generated always as identity,
    company_ip_id int not null references company_ips,
    datetime timestamptz not null default(now())
);
DROP TABLE automatic_check_audit_headers;

create table automatic_check_audit_rows(
    id int primary key generated always as identity,
    automatic_check_audit_header_id int not null references automatic_check_audit_headers,
    automatic_check_id int not null references automatic_checks,
    passed bool,
    comment text null,
    unique (automatic_check_audit_header_id, automatic_check_id)
);
DROP TABLE automatic_check_audit_rows;

-----------------------------

create table checklists(
    id int primary key generated always as identity,
    company_ip_id int not null references company_ips,
    datetime timestamptz not null default now()
    
    --all the questions and their answers
);
DROP TABLE checklists;

