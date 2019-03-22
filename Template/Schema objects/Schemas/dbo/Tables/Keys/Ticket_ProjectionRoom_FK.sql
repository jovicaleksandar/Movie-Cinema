ALTER TABLE ticket
    ADD CONSTRAINT ticket_projectionroom_fk FOREIGN KEY ( projectionroom_prjroomid )
        REFERENCES projectionroom ( prjroomid );