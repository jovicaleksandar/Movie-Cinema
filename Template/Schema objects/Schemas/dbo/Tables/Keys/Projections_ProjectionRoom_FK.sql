ALTER TABLE projections
    ADD CONSTRAINT projections_projectionroom_fk FOREIGN KEY ( projectionroom_prjroomid )
        REFERENCES projectionroom ( prjroomid );