CREATE TABLE ticket (
    ticketid                   INTEGER NOT NULL,
    ticketprice                INTEGER,
    ticketmoviename            VARCHAR(20),
    ticketseatnumber           VARCHAR(20),
    ticketdatetime             DATE,
    ticketseller_employeeid    INTEGER NOT NULL,
    projectionroom_prjroomid   INTEGER NOT NULL
);