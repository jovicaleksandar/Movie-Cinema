ALTER TABLE bill
    ADD CONSTRAINT bill_table_fk FOREIGN KEY ( table_tableid )
        REFERENCES "Table" ( tableid );