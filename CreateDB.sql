-- Файл создания структуры базы данных
-- Создание таблицы reminder
create table reminder (id int identity (1,1) primary key not null, text nvarchar( max) not null, time nvarchar(8), date nvarchar(50))

-- Создание таблицы notes
create table notes (id int identity (1,1) primary key not null, note nvarchar(max) not null)


-- Создание таблицы contragents
create table contragents (id int identity (1,1) primary key not null, 
                          name_contr nvarchar(255) not null, phone nvarchar(20), 
						  phone_2 nvarchar(20), email nvarchar(30), coment nvarchar(max),
						  id_notes int foreign key references notes(id) )

-- Создание таблицы deals
create table deals (id int identity (1,1) primary key not null, id_contr int foreign key references contragents(id), 
                                                               name_item nvarchar(255) not null, price decimal(10,2),
                                                                account_num  int , count_ int, date nvarchar(50),
                                                                status nvarchar(max))
