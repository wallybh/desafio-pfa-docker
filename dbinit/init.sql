SET NAMES 'utf8';
create table IF NOT EXISTS modules(
    id int not null auto_increment,
    name nvarchar(256) collate utf8_unicode_ci,
    url nvarchar(500),
    primary key(id)
);

insert modules (name, url) values ('Docker','https://portal.code.education/lms/#/180/163/110/conteudos');
insert modules (name, url) values ('Fundamentos de Arquitetura de Software','https://portal.code.education/lms/#/180/163/112/conteudos');
insert modules (name, url) values ('Comunicação','https://portal.code.education/lms/#/180/163/116/conteudos');
insert modules (name, url) values ('RabbitMQ','https://portal.code.education/lms/#/180/163/102/conteudos');
insert modules (name, url) values ('Autenticação e Keycloak','https://portal.code.education/lms/#/180/163/108/conteudos');
insert modules (name, url) values ('DDD e Arquitetura hexagonal','https://portal.code.education/lms/#/180/163/123/conteudos');
insert modules (name, url) values ('Arquitetura do projeto prático - Codeflix','https://portal.code.education/lms/#/180/163/124/conteudos');