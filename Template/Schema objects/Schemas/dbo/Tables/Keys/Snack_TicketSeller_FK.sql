ALTER TABLE snack
    ADD CONSTRAINT snack_ticketseller_fk FOREIGN KEY ( ticketseller_employeeid )
        REFERENCES ticketseller ( employeeid );