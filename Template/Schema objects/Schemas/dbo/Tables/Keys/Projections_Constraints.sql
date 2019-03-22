ALTER TABLE projections
    ADD CONSTRAINT projections_pk PRIMARY KEY ( projectionid,
                                                projectionroom_prjroomid,
                                                movie_movieid );