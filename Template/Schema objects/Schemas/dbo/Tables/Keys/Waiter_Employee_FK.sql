ALTER TABLE waiter
    ADD CONSTRAINT waiter_employee_fk FOREIGN KEY ( employeeid )
        REFERENCES employee ( employeeid );