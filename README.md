# starcraft2-stream-chat-assistant
Stream chat bot which provides basic information like win-loses stats and MMR change for stream viewers

##Custom output formatting
If you would like to change the visual output of the software, please take a look on template_output_1vs1.html and template_output_2vs2.html files. The software looks for placeholders (identifiers surrounded by '%' symbol) and replaces them with the appropriate information.
The following placeholders are available:
- %wins_count% - the number of your wins
- %loses_count% - the number of your loses
- %player1_name% - the name of character for player 1 (your character)
- %player1_race% - the single-letter code of the race of player 1 (T, Z, P or R)
- %player2_name% - the name of character for player 2 (your ally in 2 vs 2 or your opponent in 1 vs 1)
- %player2_race% - the single-letter code of the race of player 2
- %player3_name% - the name of character for player 3 (your opponent in 2 vs 2)
- %player3_race% - the single-letter code of the race of player 3
- %player3_name% - the name of character for player 3 (your opponent in 2 vs 2)
- %player4_race% - the single-letter code of the race of player 4
- %player1_name_race% - the name of player 1 following her race in round brackets
- %player2_name_race% - the name of player 2 following her race in round brackets
- %player3_name_race% - the name of player 3 following her race in round brackets
- %player4_name_race% - the name of player 4 following her race in round brackets
- %player1_mmr% - mmr of player 1
- %player2_mmr% - mmr of player 2
- %player3_mmr% - mmr of player 3
- %player4_mmr% - mmr of player 4
- %player1_mmr_progress% - change of mmr during the time the software is running, calculated only for your character, therefore mmr progress info is not available for other players
- %player1_mmr_with_progress% - mmr of player 1 following mmr change in round brackets

