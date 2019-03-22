ALTER TABLE drink
    ADD CONSTRAINT drink_bar_fk FOREIGN KEY ( bar_barid )
        REFERENCES bar ( barid );