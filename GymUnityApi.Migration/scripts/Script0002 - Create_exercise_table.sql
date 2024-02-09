CREATE TABLE exercise (id UUID PRIMARY KEY, name text, type text);
CREATE TABLE cardio_exercise (id UUID REFERENCES exercise(id), duration int);
CREATE TABLE strength_exercise (id UUID REFERENCES exercise(id), sets int, reps int, weight int, rest_time int);

ALTER TABLE training RENAME TO workout;
drop table training_exercise;
CREATE TABLE workout_exercise (workout_id UUID REFERENCES workout(id), exercise_id UUID REFERENCES exercise(id));