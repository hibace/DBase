/*Last 10 Matches history by player*/
SELECT ma.id as Match_ID, ma.duration as Duration, ma.game_mode as Game_Mode, ma.date as Match_Date, h.name as Hero
FROM MainTemp m, player p, hero h, match ma
WHERE m.id_player = p.id AND m.id_hero = h.id AND m.id_match = ma.id AND m.id_player = 3
ORDER by match_id

EXPLAIN SELECT m.id_match as MATCH_ID, p.nickname as Player, h.name as Hero
FROM MainTemp m, player p, hero h, match ma
WHERE m.id_player = p.id AND m.id_hero = h.id AND ma.id = m.id_match
ORDER BY Player

SELECT m.id_match as MATCH_ID, p.nickname
FROM MainTemp m, player p, hero h, match ma
WHERE m.id_player = p.id AND m.id_hero = h.id AND ma.id = m.id_match AND ma.id = 1
GROUP BY match_id, p.nickname
ORDER BY match_id

SELECT * FROM Hero

SELECT h.name, m.id
FROM hero h JOIN Maintemp m on h.id = m.id_hero WHERE m.id_player = 1;

SELECT m.id_match as MATCH_ID, p.nickname as nickname, h.name as hero
/*Info by match with players and heroes in it*/
FROM maintemp m, match ma, player p, hero h
WHERE m.id_match = 1 AND m.id_hero = h.id AND m.id_player = p.id
GROUP BY match_id, nickname, hero, p.id, h.id



SELECT p.nickname, h.name as hero,(CAST(COUNT(h.id) AS FLOAT)/CAST(COUNT(a.hero_played_number) AS FLOAT) * 100) as percent
FROM MainTemp m, player p, hero h
JOIN 
(
SELECT p.nickname, COUNT(h.id) as hero_played_number
FROM MainTemp m, player p, hero h
WHERE m.id_player = p.id AND m.id_hero = h.id
GROUP BY nickname
) a
ON a.nickname = nickname
GROUP BY a.nickname, h.name, a.hero_played_number, p.nickname
ORDER BY a.nickname












SELECT p.nickname, COUNT(h.id) as hero_played_number
FROM MainTemp m, player p, hero h
WHERE m.id_player = p.id AND m.id_hero = h.id
GROUP BY nickname

SELECT p.nickname, h.name as hero, COUNT(h.id) as Played_Games_On_This_Hero
FROM MainTemp m, player p, hero h
WHERE m.id_player = p.id AND m.id_hero = h.id
GROUP BY nickname, hero

SELECT p.nickname, COUNT(h.id) as hero_played_number
FROM MainTemp m, player p, hero h
WHERE m.id_player = p.id AND m.id_hero = h.id
GROUP BY nickname

--------------------

CREATE VIEW Players_played_heroes
AS SELECT p.nickname, p.id as id_player, h.name as hero, h.id as id_hero, COUNT(h.id) as Played_Games_On_This_Hero
FROM MainTemp m, player p, hero h
WHERE m.id_player = p.id AND m.id_hero = h.id
GROUP BY nickname, hero, p.id, h.id;

CREATE VIEW Players_played_heroes_num AS
SELECT p.nickname, p.id as id_player, COUNT(h.id) as hero_played_number
FROM MainTemp m, player p, hero h
WHERE m.id_player = p.id AND m.id_hero = h.id
GROUP BY nickname, p.id






/*Pick percent by player nickname*/
SELECT pp.nickname, hero, Played_Games_On_This_Hero, number_of_played_games as number_of_played_games, 
round(((played_games_on_this_hero::numeric)/(number_of_played_games::numeric) * 100), 1) as pick_percent
FROM (
SELECT p.nickname, p.id as id_player, h.name as hero, h.id as id_hero, COUNT(*) as Played_Games_On_This_Hero
FROM MainTemp m JOIN player p on m.id_player = p.id
JOIN hero h on m.id_hero = h.id
GROUP BY nickname, hero, p.id, h.id
) pp
JOIN (
SELECT p.nickname, p.id as id_player, COUNT(*) as number_of_played_games
FROM MainTemp m JOIN player p on m.id_player = p.id 
GROUP BY nickname, p.id
) pn 
ON pp.id_player = pn.id_player  /* AND pp.id_player = 1 */
ORDER BY nickname








SELECT DISTINCT(h.id)
FROM Maintemp m JOIN Hero h on m.id_hero = h.id


SELECT COUNT(h.id), id_player
FROM Maintemp m JOIN Hero h on m.id_hero = h.id
GROUP BY id_player

SELECT p.nickname, p.id as id_player, h.name as hero, h.id as id_hero, COUNT(h.id) as Played_Games_On_This_Hero
FROM Maintemp m Join Player p on m.id_player = p.id JOIN hero h on h.id = m.id_hero 
GROUP BY nickname, hero, p.id, h.id

/*Pick percent by player nickname*/
SELECT p.nickname, hero, played_games_on_this_hero, hero_played_number as all_number_of_games, 
round(((played_games_on_this_hero::numeric)/CAST(hero_played_number AS NUMERIC) * 100), 1) as pick_percent
FROM Players_played_heroes p 
JOIN Players_played_heroes_num pn 
ON p.nickname = pn.nickname AND p.nickname = 'Player1'
ORDER BY pick_percent DESC
	
SELECT * FROM Player 
INSERT INTO MATCH(duration, game_mode, date) VALUES (15, 'All Pick', '2017-12-05');
INSERT INTO MATCH(duration, game_mode, date) VALUES (25, 'All Random', '2017-11-22');
INSERT INTO MATCH(duration, game_mode, date) VALUES (35, 'Single Draft', '2017-11-06');

SELECT * FROM Hero

UPDATE Item Set name = 'Tranquil Boots' where id = 8

INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (1,1,8);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (2,2,8);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (3,3,8);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (4,4,8);

INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (2,5,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (3,6,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (4,7,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (5,8,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (6,9,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (7,10,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (8,11,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (9,12,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (10,13,9);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (1,14,9);

INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (6,16,10);
INSERT INTO Maintemp(id_player, id_hero, id_match) VALUES (8,15,10);

/*Last month matches + players in these matches*/
CREATE VIEW Temp AS 
SELECT ma.id as MATCH_ID, m.id_player, p.nickname
FROM maintemp m, match ma, player p
WHERE m.id_match = ma.id AND p.id = m.id_player AND ma.date BETWEEN date_trunc('month', current_date - interval '1' month) AND current_date

ORDER By match_id, ma.duration, ma.game_mode, ma.date

Select id, duration, game_mode, date, id_player FROM MAINTEMP m JOIN Temp t on m.id_match = t.match_id
ORDER BY match_id

SELECT m.id_match, p.nickname, p.id
FROM maintemp m, player p, match ma
WHERE m.id_match = ma.id AND m.id_player = p.id 
ORDER BY m.id_match, p.id

SELECT DISTINCT(id_match), ma.date, ma.duration, ma.game_mode
FROM maintemp m JOIN match ma ON id_match = ma.id 
SELECT * FROM match
SELECT * FROM Match WHERE date BETWEEN date_trunc('month', current_date - interval '1' month) AND current_date