ALTER TABLE ticket
    ADD CONSTRAINT ticket_ticketseller_fk FOREIGN KEY ( ticketseller_employeeid )
        REFERENCES ticketseller ( employeeid );