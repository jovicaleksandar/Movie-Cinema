ALTER TABLE waiter
    ADD CONSTRAINT waiter_bar_fk FOREIGN KEY ( bar_barid )
        REFERENCES bar ( barid );