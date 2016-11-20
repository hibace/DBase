CREATE TABLE "player" (
	"id" serial NOT NULL,
	"nickname" varchar NOT NULL,
	"number_of_games" varchar NOT NULL,
	CONSTRAINT player_pk PRIMARY KEY ("id")
);

CREATE TABLE "playertemp" (
	"id" serial NOT NULL,
	"id_player" int NOT NULL,
	"id_maintemp" int NOT NULL,
	CONSTRAINT playertemp_pk PRIMARY KEY ("id")
);



CREATE TABLE "player_stat" (
	"verified" bool NOT NULL,
	"time_spent_playing" int NOT NULL,
	"most_matches_played" int NOT NULL,
	"id" serial NOT NULL,
	"id_player" int NOT NULL,
	CONSTRAINT player_stat_pk PRIMARY KEY ("id")
);



CREATE TABLE "hero" (
	"id" serial NOT NULL,
	"name" varchar NOT NULL,
	"class" varchar NOT NULL,
	"role" varchar NOT NULL,
	CONSTRAINT hero_pk PRIMARY KEY ("id")
);

CREATE TABLE "herotemp" (
	"id" serial NOT NULL,
	"id_hero" int NOT NULL,
	"id_maintemp" int NOT NULL,
	CONSTRAINT herotemp_pk PRIMARY KEY ("id")
);


CREATE TABLE "hero_stat" (
	"id_hero" int NOT NULL,
	"id" serial NOT NULL,
	"hero_damage" int NOT NULL,
	"hero_healing" int NOT NULL,
	"tower_damage" int NOT NULL,
	CONSTRAINT hero_stat_pk PRIMARY KEY ("id")
);



CREATE TABLE "match" (
	"id" serial NOT NULL,
	"duration" int NOT NULL,
	"date" DATE NOT NULL,
	"game_mode" varchar NOT NULL,
	CONSTRAINT match_pk PRIMARY KEY ("id")
);

CREATE TABLE "matchtemp" (
	"id" serial NOT NULL,
	"id_match" int NOT NULL,
	"id_maintemp" int NOT NULL,
	CONSTRAINT matchtemp_pk PRIMARY KEY ("id")
);



CREATE TABLE "maintemp" (
	"id" serial NOT NULL,
	"id_item" int NOT NULL,
	"id_player" int NOT NULL,
	"id_hero" int NOT NULL,
	"id_match" int NOT NULL,
	CONSTRAINT maintemp_pk PRIMARY KEY ("id")
);



CREATE TABLE "itemtemp" (
	"id" serial NOT NULL,
	"id_maintemp" int NOT NULL,
	"id_item" int NOT NULL,
	CONSTRAINT itemtemp_pk PRIMARY KEY ("id")
);



CREATE TABLE "item" (
	"id" serial NOT NULL,
	"name" varchar NOT NULL,
	"type" varchar NOT NULL,
	CONSTRAINT item_pk PRIMARY KEY ("id")
);



CREATE TABLE "item_stat" (
	"id" serial NOT NULL,
	"id_item" int NOT NULL,
	"time_used" int NOT NULL,
	CONSTRAINT item_stat_pk PRIMARY KEY ("id")
);




ALTER TABLE "player_stat" ADD CONSTRAINT "player_stat_fk0" FOREIGN KEY ("id_player") REFERENCES "player"("id");

ALTER TABLE "hero_stat" ADD CONSTRAINT "hero_stat_fk0" FOREIGN KEY ("id_hero") REFERENCES "hero"("id");

ALTER TABLE "item_stat" ADD CONSTRAINT "item_stat_fk0" FOREIGN KEY ("id_item") REFERENCES "item"("id");

ALTER TABLE "maintemp" ADD CONSTRAINT "maintemp_fk0" FOREIGN KEY ("id_player") REFERENCES "playertemp"("id");
ALTER TABLE "maintemp" ADD CONSTRAINT "maintemp_fk1" FOREIGN KEY ("id_hero") REFERENCES "herotemp"("id");
ALTER TABLE "maintemp" ADD CONSTRAINT "maintemp_fk2" FOREIGN KEY ("id_match") REFERENCES "matchtemp"("id");
ALTER TABLE "maintemp" ADD CONSTRAINT "maintemp_fk3" FOREIGN KEY ("id_item") REFERENCES "itemtemp"("id");

ALTER TABLE "herotemp" ADD CONSTRAINT "herotemp_fk0" FOREIGN KEY ("id_maintemp") REFERENCES "maintemp"("id");
ALTER TABLE "herotemp" ADD CONSTRAINT "herotemp_fk1" FOREIGN KEY ("id_hero") REFERENCES "hero"("id");

ALTER TABLE "itemtemp" ADD CONSTRAINT "itemtemp_fk0" FOREIGN KEY ("id_maintemp") REFERENCES "maintemp"("id");
ALTER TABLE "itemtemp" ADD CONSTRAINT "itemtemp_fk1" FOREIGN KEY ("id_item") REFERENCES "item"("id");

ALTER TABLE "playertemp" ADD CONSTRAINT "playertemp_fk0" FOREIGN KEY ("id_maintemp") REFERENCES "maintemp"("id");
ALTER TABLE "playertemp" ADD CONSTRAINT "playertemp_fk1" FOREIGN KEY ("id_player") REFERENCES "player"("id");

ALTER TABLE "matchtemp" ADD CONSTRAINT "matchtemp_fk0" FOREIGN KEY ("id_maintemp") REFERENCES "maintemp"("id");
ALTER TABLE "matchtemp" ADD CONSTRAINT "matchtemp_fk1" FOREIGN KEY ("id_match") REFERENCES "match"("id");
