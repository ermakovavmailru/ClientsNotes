-- Файл создания структуры базы данных
-- Создание таблицы reminder
create table reminder (id int identity (1,1) primary key not null, text nvarchar( max) not null, time nvarchar(8), date nvarchar(50))

-- Создание таблицы notes
create table notes (id int identity (1,1) primary key not null, note nvarchar(max) not null)

-- Создание таблицы items
create table items (id int identity (1,1) primary key not null, name_item nvarchar(255) not null, size int, price decimal(10,2))

-- Создание таблицы contragents
create table contragents (id int identity (1,1) primary key not null, name_contr nvarchar(255) not null, phone bigint, phone_2 bigint, email nvarchar(30), coment nvarchar(max) )

-- Создание таблицы deals
create table deals (id int identity (1,1) primary key not null, id_contr int foreign key references contragents(id), 
                                                                id_item int foreign key references items(id),
                                                                account_num int, count_ int, day int, month int, year int,
                                                                status nvarchar(max))