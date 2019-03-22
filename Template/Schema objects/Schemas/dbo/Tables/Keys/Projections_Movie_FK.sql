ALTER TABLE projections
    ADD CONSTRAINT projections_movie_fk FOREIGN KEY ( movie_movieid )
        REFERENCES movie ( movieid );