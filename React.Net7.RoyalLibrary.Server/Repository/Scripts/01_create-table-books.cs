create table books (
  book_id INT PRIMARY KEY IDENTITY (1, 1),
  title Varchar(100) not null,
    first_name VARCHAR (50) NOT NULL,
    last_name VARCHAR (50) NOT NULL,
   total_copies int not null default 0,
   copies_in_use int not null default 0,
   type varchar(50),
   isbn varchar (80),
   category varchar(50));