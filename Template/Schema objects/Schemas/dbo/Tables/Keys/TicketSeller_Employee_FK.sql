ALTER TABLE ticketseller
    ADD CONSTRAINT ticketseller_employee_fk FOREIGN KEY ( employeeid )
        REFERENCES employee ( employeeid );