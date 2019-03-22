ALTER TABLE projections
    ADD CONSTRAINT projections_admin_fk FOREIGN KEY ( admin_employeeid )
        REFERENCES admin ( employeeid );