ALTER TABLE "Table"
    ADD CONSTRAINT table_waiter_fk FOREIGN KEY ( waiter_employeeid )
        REFERENCES waiter ( employeeid );