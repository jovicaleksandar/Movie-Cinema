ALTER TABLE admin
    ADD CONSTRAINT admin_employee_fk FOREIGN KEY ( employeeid )
        REFERENCES employee ( employeeid );