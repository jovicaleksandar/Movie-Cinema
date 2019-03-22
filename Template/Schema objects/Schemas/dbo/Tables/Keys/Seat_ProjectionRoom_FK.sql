ALTER TABLE seat
    ADD CONSTRAINT seat_projectionroom_fk FOREIGN KEY ( projectionroom_prjroomid )
        REFERENCES projectionroom ( prjroomid );